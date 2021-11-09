namespace API.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        string _message;
        public InternalServerErrorException(string message = null)
        {
            _message = message ?? "Something get wrong";
        }
    }
}