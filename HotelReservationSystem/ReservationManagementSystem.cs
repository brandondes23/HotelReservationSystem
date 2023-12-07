using System;
using System.Collections.Generic;

namespace SunsetHotelReservationSystem
{
    class ReservationManagementSystem
    {
        private List<Reservation> reservations;

        public ReservationManagementSystem()
        {
            reservations = new List<Reservation>();
        }

        public void CreateReservation(Guest guest, Room room, DateTime checkInDate, DateTime checkOutDate)
        {
            int reservationID = GenerateReservationID();
            Reservation newReservation = new Reservation(reservationID, guest, room, checkInDate, checkOutDate);

            // Check if the room is available for the specified dates
            if (IsRoomAvailable(room, checkInDate, checkOutDate))
            {
                reservations.Add(newReservation);
                Console.WriteLine($"Reservation successful! Reservation ID: {reservationID}");
            }
            else
            {
                Console.WriteLine("Sorry, the selected room is not available for the specified dates.");
            }
        }

        public void ModifyReservation(int reservationID, DateTime newCheckInDate, DateTime newCheckOutDate)
        {
            Reservation reservation = FindReservation(reservationID);

            if (reservation != null)
            {
                // Check if the modified dates are valid
                if (IsRoomAvailable(reservation.Room, newCheckInDate, newCheckOutDate))
                {
                    reservation.CheckInDate = newCheckInDate;
                    reservation.CheckOutDate = newCheckOutDate;
                    Console.WriteLine($"Reservation {reservationID} modified successfully!");
                }
                else
                {
                    Console.WriteLine("Sorry, the modified dates conflict with an existing reservation.");
                }
            }
            else
            {
                Console.WriteLine($"Reservation with ID {reservationID} not found.");
            }
        }

        public void CancelReservation(int reservationID)
        {
            Reservation reservation = FindReservation(reservationID);

            if (reservation != null)
            {
                reservations.Remove(reservation);
                Console.WriteLine($"Reservation {reservationID} canceled successfully!");
            }
            else
            {
                Console.WriteLine($"Reservation with ID {reservationID} not found.");
            }
        }

        private int GenerateReservationID()
        { 

            return reservations.Count + 1;
        }

        private bool IsRoomAvailable(Room room, DateTime checkInDate, DateTime checkOutDate)
        {
            // Check if the room is available for the specified dates
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

        private Reservation FindReservation(int reservationID)
        {
            return reservations.Find(reservation => reservation.ReservationID == reservationID);
        }
    }
}

