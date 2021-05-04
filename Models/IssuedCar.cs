using System;

namespace lab.Models
{
    public class IssuedCar
    {
        public int ID { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } 
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal ServiceCost { get; set; }
    }
}
/* 
dotnet aspnet-codegenerator razorpage -m IssuedCar -dc LabContext -udl -outDir Pages/IssuedCars --referenceScriptLibraries -sqlite
dotnet aspnet-codegenerator razorpage -m Client -dc LabContext -udl -outDir Pages/Clients --referenceScriptLibraries -sqlite
dotnet aspnet-codegenerator razorpage -m Car -dc LabContext -udl -outDir Pages/Cars --referenceScriptLibraries -sqlite
 */