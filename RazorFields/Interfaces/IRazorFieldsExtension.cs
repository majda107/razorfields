namespace RazorFields.Interfaces
{
    public interface IRazorFieldsExtension
    {
        public bool TryPopulateModel(object model);
        public bool TrySaveModel(object model);
    }
}