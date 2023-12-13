namespace HotelReservationSystem
{
    public class Program
    {
            private static List<Reservation> reservations;

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
                Console.WriteLine("Options: Reserve Room - 1, View Reservations - 2, Exit - 3");
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
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }

        static void ReserveRoomMenu()
        {
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter room type (Single/Double): ");
            string roomTypeInput = Console.ReadLine();
            Enum.TryParse(roomTypeInput, out RoomType roomType);

            Console.Write("Enter check-in date (yyyy-MM-dd): ");
            DateTime checkInDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter check-out date (yyyy-MM-dd): ");
            DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

            var guest = new Guest(firstName, lastName);
            var room = new Room("100", roomType);

            var reservation = new Reservation(reservations.Count + 1, guest, room, checkInDate, checkOutDate);

            if (IsRoomAvailable(room, checkInDate, checkOutDate))
            {
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
            Console.WriteLine("All Reservations:");

            if (reservations.Count == 0)
            {
                Console.WriteLine("No reservations found.");
            }
            else
            {
                foreach (var reservation in reservations)
                {
                    Console.WriteLine($"Reservation ID: {reservation.ReservationID}, Guest: {reservation.Guest.FullName}, Room: {reservation.Room.RoomNumber}, Dates: {reservation.CheckInDate:yyyy-MM-dd} to {reservation.CheckOutDate:yyyy-MM-dd}");
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
    }

    enum RoomType
    {
        Single,
        Double
    }

    class Room
    {
        public string RoomNumber { get; }
        public RoomType Type { get; }

        public Room(string roomNumber, RoomType type)
        {
            RoomNumber = roomNumber;
            Type = type;
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
 