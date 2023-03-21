namespace MDT.Core.Exceptions
{
    public class ResourceAlreadyExistsException : ApplicationException
    {
        public ResourceAlreadyExistsException(string name, object key)
            : base($"Entity \"{name}\" already exists {key}.")
        {
        }
    }
}
