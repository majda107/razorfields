using System.Collections.Generic;
using RazorFields.Attributes;

namespace RazorFields.Demo.RazorModels
{
    [RazorModel]
    public record HomeRazorModel
    {
        public string Heading { get; init; } = "Home heading";
        public string SubHeading { get; init; } = "Sub heading copywriting";

        public IList<UserRazorModel> Users { get; init; } = new List<UserRazorModel>
        {
            new UserRazorModel {Name = "Majda"}
        };

        public IList<int> Numbers { get; init; } = new List<int>
        {
            0, 1, 2
        };
    }
}