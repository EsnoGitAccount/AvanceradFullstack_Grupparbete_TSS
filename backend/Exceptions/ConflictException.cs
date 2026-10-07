namespace Backend.Exceptions
{
	public class ConflictException:Exception
	{
		//409
		public ConflictException(string message) : base(message)
		{

		}
	}
}
