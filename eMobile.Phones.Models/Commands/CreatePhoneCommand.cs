using Common.Command;
using System.Collections.Generic;

namespace eMobile.Phones.Models.Commands
{
    public class CreatePhoneCommand : ICommand
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public PhoneDimensions Dimensions { get; set; }
        public List<PhoneMedia> Media { get; set; }
        public PhoneDisplay Display { get; set; }
        public double Weight { get; set; }
        public string CPUModel { get; set; }
        public int RAM { get; set; }
        public string OS { get; set; }
        public double Price { get; set; }
    }

    public class PhoneDimensions
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class PhoneMedia
    {
        public string PhotoUrl { get; set; }
        public string VideoUrl { get; set; }
    }

    public class PhoneDisplay
    {
        public double Size { get; set; }
        public int VerticalResolution { get; set; }
        public int HorizontalResolution { get; set; }
    }
}
