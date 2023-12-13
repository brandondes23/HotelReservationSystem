using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem;


public class RoomInventory // Keeps track of the available rooms
{
    public DateTime Date { get; set; }
    public int AvailableRooms { get; set; }

    public RoomInventory(DateTime date, int availableRooms)
    {
        Date = date;
        AvailableRooms = availableRooms;
    }
}

public class Hotel // 
{
    private List<RoomInventory> roomInventories; // creates a list of available rooms

    public Hotel() // Constructor for hotel class
    {
        roomInventories = new List<RoomInventory>();
    }

    public void AddRoomInventory(RoomInventory roomInventory) // Adds room to the list
    {
        roomInventories.Add(roomInventory);
    }

    public List<RoomInventory> GetAvailableRooms(DateTime date) // Gets the dates for available rooms
    {

        RoomInventory inventory = roomInventories.Find(room => room.Date == date);

        if (inventory != null) 
        {

            return new List<RoomInventory> { inventory };
        }


        return new List<RoomInventory>();
    }
}
