using System.Collections.Generic;
using RazorFields.Attributes;

namespace RazorFields.Demo.RazorModels
{
    [RazorModel]
    public record HomeRazorModel
    {
        public string Heading { get; init; } = "Home heading";

        public IList<UserRazorModel> Users { get; init; }
        public IList<int> Numbers { get; init; }
    }
}