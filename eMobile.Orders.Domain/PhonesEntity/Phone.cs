using eMobile.Orders.Domain.DimensionsEntity;
using eMobile.Orders.Domain.DisplayEntity;
using eMobile.Orders.Domain.MediaEntity;
using eMobile.Orders.Domain.OrdersEntity;
using System.Collections.Generic;

namespace eMobile.Orders.Domain.PhonesEntity
{
    public class Phone : BaseEntity
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public Dimensions Dimensions { get; set; }
        public double Weight { get; set; }
        public Display Display { get; set; }
        public string CPUModel { get; set; }
        public int RAM { get; set; }
        public string OS { get; set; }
        public double Price { get; set; }
        public List<Media> Media { get; set; }
        public Order Order { get; set; }
    }
}
