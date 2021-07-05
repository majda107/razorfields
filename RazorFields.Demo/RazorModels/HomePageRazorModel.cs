using System.Collections.Generic;
using RazorFields.Attributes;

namespace RazorFields.Demo.RazorModels
{
    [RazorModel]
    public record HomePageRazorModel
    {
        public string Heading { get; init; } = "Home heading";

        public IList<string> Users { get; init; }
    }
}