using System;
using System.Collections.Generic;

namespace HotelReservationSystem
{
    class Program
    {
        private static List<Reservation> reservations;
        private static Guest authenticatedGuest;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hotel Reservation System!");
            Initialize(); // Create and initialize reservations ...
            Menu();
        }

        static void Initialize()
        {
            reservations = new List<Reservation>();

            // Initialize some sample reservations
            var room1 = new Room("101", RoomType.Single);
            var room2 = new Room("202", RoomType.Double);

            var guest1 = new Guest("John", "Doe");
            var guest2 = new Guest("Jane", "Smith");

            var reservation1 = new Reservation(1, guest1, room1, new DateTime(2023, 1, 15), new DateTime(2023, 1, 20));
            var reservation2 = new Reservation(2, guest2, room2, new DateTime(2023, 2, 10), new DateTime(2023, 2, 15));

            reservations.Add(reservation1);
            reservations.Add(reservation2);
        }

        static void Menu()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Options: Reserve Room - 1, View Reservations - 2, Login - 3, Logout - 4, Exit - 5, Clear Screen - 6");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ReserveRoomMenu();
                        break;
                    case "2":
                        ViewReservations();
                        break;
                    case "3":
                        LoginMenu();
                        break;
                    case "4":
                        LogoutMenu();
                        break;
                    case "5":
                        done = true;
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }

        static void ReserveRoomMenu()
        {
            if (authenticatedGuest == null)
            {
                Console.WriteLine("You need to log in to make a reservation.");
                return;
            }

            Console.Write("Enter room type (Single/Double): ");
            string roomTypeInput = Console.ReadLine();
            Enum.TryParse(roomTypeInput, out RoomType roomType);

            Console.Write("Enter room view: ");
            string roomView = Console.ReadLine();

            Console.Write("Enter bed type: ");
            string bedType = Console.ReadLine();

            Console.Write("Enter check-in date (yyyy-MM-dd): ");
            DateTime checkInDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter check-out date (yyyy-MM-dd): ");
            DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

            var room = new Room("100", roomType, roomView, bedType);

            if (IsRoomAvailable(room, checkInDate, checkOutDate))
            {
                var reservation = new Reservation(reservations.Count + 1, authenticatedGuest, room, checkInDate, checkOutDate);
                reservations.Add(reservation);
                Console.WriteLine($"Reservation successful! Reservation ID: {reservation.ReservationID}");
            }
            else
            {
                Console.WriteLine("Sorry, the selected room is not available for the specified dates.");
            }
        }

        static void ViewReservations()
        {
            if (authenticatedGuest == null)
            {
                Console.WriteLine("You are not logged in. Please log in to view reservations.");
                return;
            }

            Console.WriteLine($"Reservations for {authenticatedGuest.FullName}:");

            var guestReservations = reservations.Where(r => r.Guest == authenticatedGuest);

            if (guestReservations.Count() == 0)
            {
                Console.WriteLine("No reservations found.");
            }
            else
            {
                foreach (var reservation in guestReservations)
                {
                    Console.WriteLine($"Reservation ID: {reservation.ReservationID}, Type: {reservation.Room.RoomType}, View: {reservation.Room.View}, Bed Type: {reservation.Room.Bedtype}, Dates: {reservation.CheckInDate:yyyy-MM-dd} to {reservation.CheckOutDate:yyyy-MM-dd}");
                }
            }
        }

        static bool IsRoomAvailable(Room room, DateTime checkInDate, DateTime checkOutDate)
        {
            foreach (Reservation reservation in reservations)
            {
                if (reservation.Room == room &&
                    (checkInDate < reservation.CheckOutDate && checkOutDate > reservation.CheckInDate))
                {
                    return false; // Room is not available
                }
            }
            return true; // Room is available
        }

        static void LoginMenu()
        {
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();

            authenticatedGuest = new Guest(firstName, lastName);
            Console.WriteLine($"Welcome, {authenticatedGuest.FullName}!");
        }

        static void LogoutMenu()
        {
            authenticatedGuest = null;
            Console.WriteLine("Logged out!");
        }
    }

    enum RoomType
    {
        Single,
        Double
    }

    class Room
    {
        private string v1;
        private RoomType @double;
        private string v2;
        private string v3;
        private string v;
        private RoomType single;

        public string RoomType { get; set; }
        public string View { get; set; }
        public string Bedtype { get; set; }

        public Room(int v, string roomType, double pricePerNight, string view, string bedType)
        {

            RoomType = roomType;
            View = view;
            Bedtype = bedType;
        }

        public Room(string v1, RoomType @double, string v2, string v3)
        {
            this.v1 = v1;
            this.@double = @double;
            this.v2 = v2;
            this.v3 = v3;
        }

        public Room(string v, RoomType single)
        {
            this.v = v;
            this.single = single;
        }
    }

    class Guest
    {
        public string FirstName { get; }
        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";

        public Guest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    class Reservation
    {
        public int ReservationID { get; }
        public Guest Guest { get; }
        public Room Room { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }

        public Reservation(int reservationID, Guest guest, Room room, DateTime checkInDate, DateTime checkOutDate)
        {
            ReservationID = reservationID;
            Guest = guest;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }
}



