using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem;


    public class RoomInventory
    {
        public DateTime Date { get; set; }
        public int AvailableRooms { get; set; }

        public RoomInventory(DateTime date, int availableRooms)
        {
            Date = date;
            AvailableRooms = availableRooms;
        }
    }

    public class Hotel
    {
        private List<RoomInventory> roomInventories;

        public Hotel()
        {
            roomInventories = new List<RoomInventory>();
        }

        public void AddRoomInventory(RoomInventory roomInventory)
        {
            roomInventories.Add(roomInventory);
        }

        public List<RoomInventory> GetAvailableRooms(DateTime date)
        {
            
            RoomInventory inventory = roomInventories.Find(room => room.Date == date);

            if (inventory != null)
            {
                
                return new List<RoomInventory> { inventory };
            }

            
            return new List<RoomInventory>();
        }
    }

    


