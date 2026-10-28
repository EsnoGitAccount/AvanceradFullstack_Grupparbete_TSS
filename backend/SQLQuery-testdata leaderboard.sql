DECLARE @Today date = CONVERT(date, GETUTCDATE());

DECLARE @ChallengeId int = (
    SELECT TOP (1) DailyChallangeId
    FROM DailyChallanges
    WHERE ChallangeDate = @Today
    ORDER BY DailyChallangeId
);

IF @ChallengeId IS NULL
BEGIN
    THROW 50001, 'Dagens utmaning saknas. Skapa den via spelet först.', 1;
END;

IF EXISTS (
    SELECT 1
    FROM Games
    WHERE CompletedAt = @Today
      AND UserName LIKE N'LBTest-%'
)
BEGIN
    THROW 50002, 'Testdata finns redan för i dag.', 1;
END;

INSERT INTO Games
    (UserName, UserId, DailyChallangeId, TotalScore, CompletedAt)
VALUES
    (N'LBTest-Alva',    NULL, @ChallengeId, 50, @Today),
    (N'LBTest-Erik',    NULL, @ChallengeId, 48, @Today),
    (N'LBTest-Maja',    NULL, @ChallengeId, 46, @Today),
    (N'LBTest-Oskar',   NULL, @ChallengeId, 44, @Today),
    (N'LBTest-Elsa',    NULL, @ChallengeId, 42, @Today),
    (N'LBTest-Hugo',    NULL, @ChallengeId, 40, @Today),
    (N'LBTest-Linnea',  NULL, @ChallengeId, 38, @Today),
    (N'LBTest-William', NULL, @ChallengeId, 36, @Today),
    (N'LBTest-Alice',   NULL, @ChallengeId, 34, @Today),
    (N'LBTest-Noah',    NULL, @ChallengeId, 32, @Today),
    (N'LBTest-Vera',    NULL, @ChallengeId, 31, @Today),
    (N'LBTest-Liam',    NULL, @ChallengeId, 30, @Today),
    (N'LBTest-Saga',    NULL, @ChallengeId, 29, @Today),
    (N'LBTest-Daniel',  NULL, @ChallengeId, 28, @Today),
    (N'LBTest-Axel',    NULL, @ChallengeId, 20, @Today);