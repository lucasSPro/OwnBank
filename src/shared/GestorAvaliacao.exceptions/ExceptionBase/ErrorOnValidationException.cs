namespace GestorAvaliacao.Exceptions.ExceptionBase
{
    public class ErrorOnValidationException : GestorAvaliacaoExceptions
    {
        public IList<string> ErrorMessages { get; set; }
        public ErrorOnValidationException(IList<string> erroMessages) 
        {
            ErrorMessages = erroMessages;  
        }
    }
}
