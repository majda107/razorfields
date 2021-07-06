namespace RazorFields.Interfaces
{
    public interface IRazorFieldsExtension
    {
        public bool TryPopulateModel(object model);
    }
}