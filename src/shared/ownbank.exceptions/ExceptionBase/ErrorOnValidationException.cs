namespace ownbank.Exceptions.ExceptionBase
{
    public class ErrorOnValidationException : OwnbankExceptions
    {
        public IList<string> ErrorMessages { get; set; }
        public ErrorOnValidationException(IList<string> erroMessages) 
        {
            ErrorMessages = erroMessages;  
        }
    }
}
