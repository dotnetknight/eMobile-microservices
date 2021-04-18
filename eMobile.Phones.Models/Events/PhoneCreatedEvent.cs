using Common.Events;
using eMobile.Phones.Models.Dtos;
using System.Collections.Generic;

namespace eMobile.Phones.Models.Events
{
    public class PhoneCreatedEvent : Event
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

        public PhoneCreatedEvent(string name, string manufacturer, PhoneDimensions dimensions, double weight, PhoneDisplay display, string cpuModel, int ram, string os, double price, List<PhoneMedia> media)
        {
            Name = name;
            Manufacturer = manufacturer;
            Dimensions = dimensions;
            Weight = weight;
            Display = display;
            CPUModel = cpuModel;
            RAM = ram;
            OS = os;
            Price = price;
            Media = media;
        }
    }
}
