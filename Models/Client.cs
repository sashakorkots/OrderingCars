using System;
using System.Collections.Generic;

namespace lab.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Discount { get; set; }
        public List<IssuedCar> MyProperty { get; set; }

    }
}