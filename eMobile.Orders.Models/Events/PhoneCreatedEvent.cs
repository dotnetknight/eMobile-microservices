using Common.Events;
using eMobile.Orders.Models.Dtos;
using System.Collections.Generic;

namespace eMobile.Orders.Models.Events
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
    }
}
