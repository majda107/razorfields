using RazorFields.Attributes;

namespace RazorFields.Demo.Models
{
    [RazorModel]
    public record ExternalRazorModel
    {
        public string Hello { get; init; } = "Hello from external";
    }
}