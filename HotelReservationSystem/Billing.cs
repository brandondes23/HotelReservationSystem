using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem;

public class Billing
{
    public int ReservationId { get; set; }
    public double Charges { get; set; }


    public Billing(int reservationId, double charges)
    {
        ReservationId = reservationId;
        Charges = charges;
    }
}
