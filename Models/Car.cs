using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public int Cost { get; set; }
        public int RentalPrice { get; set; }
        public string Type { get; set; }
        public int YearManufacture { get; set; }
        public List<IssuedCar> MyProperty { get; set; }
    }
}