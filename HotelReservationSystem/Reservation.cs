
namespace HotelReservationSystem
{
    record Reservation(int ReservationID, string FirstName, string LastName, string Email)
    {
        private readonly global::System.Int32 age;
        private readonly global::System.String phone;

        public System.Int32 Age => age;

        public System.String Phone => phone;

        public Reservation(int reservationID, string firstName, string lastName, int age, string phone, string email) : this(reservationID, firstName, lastName, email)
        {
            SetAge(age);
            SetPhone(phone);
        }

        public override string ToString => $"Reservation ID: {ReservationID}, Guest: {FirstName} {LastName}, Age: {Age}, Phone: {Phone}, Email: {Email}";
    }
}
