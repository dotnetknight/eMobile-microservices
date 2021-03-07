using eMobile.Phones.Models.Commands;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace eMobile.Phones.API.SwaggerRequestExamples
{
    public class CreatePhoneCommandRequestExample : IExamplesProvider<CreatePhoneCommand>
    {
        public CreatePhoneCommand GetExamples()
        {
            return new CreatePhoneCommand
            {
                Name = "Samsung Galaxy Note 3",
                OS = "Android",
                Price = 399.99,
                RAM = 3,
                Weight = 168,
                Manufacturer = "Samsung",
                CPUModel = "Octa-core (4x1.9 GHz Cortex-A15 & 4x1.3 GHz Cortex-A7)",
                Dimensions = new PhoneDimensions
                {
                    Height = 151.2,
                    Length = 79.2,
                    Width = 8.3
                },
                Display = new PhoneDisplay
                {
                    HorizontalResolution = 1920,
                    VerticalResolution = 1080,
                    Size = 5.7
                },
                Media = new List<PhoneMedia>
                {
                    new PhoneMedia()
                    {
                        PhotoUrl = "https://fdn2.gsmarena.com/vv/pics/samsung/samsung-galaxy-note-3-1.jpg",
                        VideoUrl = "https://www.youtube.com/watch?v=nl9n3xlEnJA"
                    }
                }
            };
        }
    }
}
