using System;
using Newtonsoft.Json;

namespace FactoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"Type\": \"car\", \"Doors\": \"4\",\"Wheels\": \"4\",\"ManufacturerCertificate\": \"some car certificate\"}";
            json = "{\"Type\": \"bike\", \"Pistons\": \"4\",\"Wheels\": \"2\",\"Certificate\": \"some bike certificate\"}";

            VehicleFactory vf =
                new VehicleFactory((VehicleTypes)Enum.Parse(typeof(VehicleTypes), JsonConvert.DeserializeObject<VehicleType>(json).Type), json);
            var vehicle = vf.vehicle;
            Console.WriteLine(vehicle.GetManufacturerCertification());
        }


    }

    public class VehicleType
    {
        public string Type;
    }

    public interface IVehicle
    {
        string GetManufacturerCertification();
    }

    public class Car : IVehicle
    {
        public string Type;
        public string Wheels;
        public string Doors;

        public string ManufacturerCertificate { get; set; } = "";

        public string GetManufacturerCertification()
        {
            return ManufacturerCertificate;
        }
    }

    public class Bike : IVehicle
    {
        public string Type;
        public string Wheels;
        public string Pistons;
        public string Certificate { get; set; } = "";

        public string GetManufacturerCertification()
        {
            return Certificate;
        }
    }

    public class VehicleFactory
    {
        public IVehicle vehicle;
        public VehicleFactory(VehicleTypes vehicleType, string jsonValues)
        {
            switch (vehicleType)
            {
                case VehicleTypes.car: vehicle = JsonConvert.DeserializeObject<Car>(jsonValues); break;
                case VehicleTypes.bike: vehicle = JsonConvert.DeserializeObject<Bike>(jsonValues); break;
                default: vehicle = null; break;
            }
        }
    }

    public enum VehicleTypes
    {
        car,
        bike
    }
}
