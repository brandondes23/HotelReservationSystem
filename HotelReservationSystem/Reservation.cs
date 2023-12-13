
namespace HotelReservationSystem
{
    record Reservation(int ReservationID, string FirstName, string LastName, string Email)
    {
        private readonly global::System.Int32 age; //private fields for age and phone
        private readonly global::System.String phone;

        public System.Int32 Age => age;

        public System.String Phone => phone;
        //constructor for creating reservation instances, made up of reservationID, firstName, lastName, age, phone, email
        public Reservation(int reservationID, string firstName, string lastName, int age, string phone, string email) : this(reservationID, firstName, lastName, email)
        {
            SetAge(age); //call private methods 
            SetPhone(phone); 
        }
        // Override the ToString method to provide a human-readable string representation of the object
        public override string ToString => $"Reservation ID: {ReservationID}, Guest: {FirstName} {LastName}, Age: {Age}, Phone: {Phone}, Email: {Email}";
    }
}
