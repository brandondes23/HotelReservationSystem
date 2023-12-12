using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem;

public class Room
{
    public int RoomNumber { get; set; }
    public string RoomType { get; set; }
    public double PricePerNight { get; set; }
    public string View {  get; set; }
    public string Bedtype { get; set; }

    public Room()
    {

    }


    public Room(int roomNumber, string roomType, double pricePerNight, string view, string bedtype)
    {
        RoomNumber = roomNumber;
        RoomType = roomType;
        PricePerNight = pricePerNight;
        View = view;
        Bedtype = bedtype;
     
    }
}
