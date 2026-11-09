using Backend.Dto;
using Backend.Exceptions;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Backend.Services;
using Backend.Services.IServices;
using Microsoft.Extensions.Logging;
using Moq;

namespace Backend.Tests.Services;

public class AdminCityContentTests
{
    private static CityContentCreateDto Content() => new()
    {
        Questions = Enumerable.Range(1, 2).Select(index => new QuestionCreateDto
        {
            QuestionText = $" Question {index} ",
            Options = Enumerable.Range(0, 4).Select(option => new OptionCreateDto
            { OptionText = $" Answer {option} ", IsCorrect = option == 0 }).ToList()
        }).ToList(),
        Clues = Enumerable.Range(1, 5).Select(index => $" Clue {index} ").ToList()
    };

    private static City NewCity() => new() { CityId = 1, Name = "City", CityPicture = "image" };

    private static (CityService Service, Mock<ICityRepository> Repo) Setup(City city)
    {
        var repo = new Mock<ICityRepository>();
        repo.Setup(r => r.GetCityWithQuestionsAsync(1)).ReturnsAsync(city);
        // Exercise service logic inside the transaction callback; SQL locking is not mocked here.
        repo.Setup(r => r.WithCityContentTransactionAsync(1, It.IsAny<Func<City, Task<CityQuestionsEditDto>>>()))
            .Returns((int _, Func<City, Task<CityQuestionsEditDto>> action) => action(city));
        repo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(() =>
        {
            var nextId = 100;
            foreach (var question in city.Questions)
            {
                if (question.QuestionId == 0) question.QuestionId = nextId++;
                foreach (var option in question.Options)
                    if (option.OptionId == 0) option.OptionId = nextId++;
            }
            foreach (var clue in city.Clues)
                if (clue.ClueId == 0) clue.ClueId = nextId++;
            return true;
        });
        return (new CityService(repo.Object, Mock.Of<IBlobStorageService>(), Mock.Of<ILogger<CityService>>()), repo);
    }

    [Fact]
    public async Task EmptyCity_SavesTwoQuestionsAndFiveClues()
    {
        var city = NewCity();
        var (service, repo) = Setup(city);
        var result = await service.CreateCityContentAsync(1, Content());
        Assert.Equal(2, result.Questions.Count);
        Assert.Equal(new decimal[] { 10, 8, 6, 4, 2 }, result.Clues.Select(clue => clue.Point));
        Assert.All(result.Questions, question =>
        {
            Assert.True(question.QuestionId > 0);
            Assert.Equal(question.QuestionText.Trim(), question.QuestionText);
            Assert.Equal(4, question.Options.Count);
            Assert.Single(question.Options, option => option.IsCorrect);
        });
        repo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task PartialCity_PreservesExistingIdsAndAddsMissingRecords()
    {
        var city = NewCity();
        var question = new Question { QuestionId = 7, CityId = 1, QuestionText = "Before",
            Options = new() { new() { OptionId = 8, OptionText = "Before", IsCorrect = true } } };
        var clue = new Clue { ClueId = 9, CityId = 1, Point = 10, ClueText = "Before" };
        city.Questions.Add(question);
        city.Clues.Add(clue);
        var (service, _) = Setup(city);
        await service.CreateCityContentAsync(1, Content());
        Assert.Same(question, city.Questions[0]);
        Assert.Equal(7, question.QuestionId);
        Assert.Equal(8, question.Options[0].OptionId);
        Assert.Same(clue, city.Clues[0]);
        Assert.Equal(9, clue.ClueId);
        Assert.Equal(2, city.Questions.Count);
        Assert.Equal(4, question.Options.Count);
        Assert.Equal(5, city.Clues.Count);
    }

    [Fact]
    public async Task RepeatedSetup_IsRejectedWithoutDuplicates()
    {
        var city = NewCity();
        var (service, repo) = Setup(city);
        await service.CreateCityContentAsync(1, Content());
        await Assert.ThrowsAsync<ConflictException>(() => service.CreateCityContentAsync(1, Content()));
        Assert.Equal(2, city.Questions.Count);
        Assert.Equal(5, city.Clues.Count);
        repo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Theory]
    [InlineData("question-count")]
    [InlineData("blank-question")]
    [InlineData("option-count")]
    [InlineData("blank-option")]
    [InlineData("no-correct")]
    [InlineData("multiple-correct")]
    [InlineData("clue-count")]
    [InlineData("blank-clue")]
    public async Task InvalidSetup_IsRejectedBeforeSaving(string scenario)
    {
        var city = NewCity();
        var (service, repo) = Setup(city);
        var content = Content();
        switch (scenario)
        {
            case "question-count": content.Questions.RemoveAt(0); break;
            case "blank-question": content.Questions[0].QuestionText = " "; break;
            case "option-count": content.Questions[0].Options.RemoveAt(0); break;
            case "blank-option": content.Questions[0].Options[0].OptionText = " "; break;
            case "no-correct": content.Questions[0].Options[0].IsCorrect = false; break;
            case "multiple-correct": content.Questions[0].Options[1].IsCorrect = true; break;
            case "clue-count": content.Clues.RemoveAt(0); break;
            case "blank-clue": content.Clues[0] = " "; break;
        }
        await Assert.ThrowsAsync<AppValidationException>(() => service.CreateCityContentAsync(1, content));
        Assert.Empty(city.Questions);
        Assert.Empty(city.Clues);
        repo.Verify(r => r.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhitespaceOnlyUpdate_SucceedsWhenNoRowsChange()
    {
        var city = NewCity();
        var (service, repo) = Setup(city);
        var saved = await service.CreateCityContentAsync(1, Content());
        repo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(false);
        var update = new CityQuestionsUpdateDto
        {
            Questions = saved.Questions,
            Clues = saved.Clues.Select(clue => new ClueUpdateDto
                { ClueId = clue.ClueId, ClueText = clue.ClueText + " " }).ToList()
        };
        await service.UpdateCityQuestionsAsync(1, update);
        Assert.All(city.Clues, clue => Assert.Equal(clue.ClueText.Trim(), clue.ClueText));
    }

    [Fact]
    public async Task ForeignClueId_IsRejectedBeforeAnyChanges()
    {
        var city = NewCity();
        var (service, repo) = Setup(city);
        var saved = await service.CreateCityContentAsync(1, Content());
        var update = new CityQuestionsUpdateDto
        {
            Questions = saved.Questions,
            Clues = saved.Clues.Select(clue => new ClueUpdateDto
                { ClueId = clue.ClueId, ClueText = clue.ClueText }).ToList()
        };
        update.Questions[0].QuestionText = "Should not be applied";
        update.Clues[0].ClueId = 9999;
        await Assert.ThrowsAsync<AppValidationException>(() => service.UpdateCityQuestionsAsync(1, update));
        Assert.Equal("Question 1", city.Questions[0].QuestionText);
        repo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}
