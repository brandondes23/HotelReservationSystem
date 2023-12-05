﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{ 
    class Guest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Guest(string firstName, string lastName, int age, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Phone = phone;
            Email = email;
        }
    }
}