using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Model;

public class ServiceAvailable
{
    public List<string> Amenities { get; private set; }

    public ServiceAvailable()
    {
        Amenities = new List<string> // List of available amenities
            {
                "Gym",
                "Swimming Pool",
                "Spa",
                "Restaurant",
                "Conference Room",
                "Free Breakfast"
            };
    }

    public void ListServices() // Prints out all available amenities
    {
        Console.WriteLine("Available Amenities");
        foreach (var service in Amenities)
        {
            Console.WriteLine(service);
        }
    }
}
