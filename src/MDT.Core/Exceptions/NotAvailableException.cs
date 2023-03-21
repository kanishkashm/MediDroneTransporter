namespace MDT.Core.Exceptions
{
    public class NotAvailableException : ApplicationException
    {
        public NotAvailableException(string name, object key)
            : base($"Entity \"{name}\" not available {key}.")
        {
        }
    }
}
