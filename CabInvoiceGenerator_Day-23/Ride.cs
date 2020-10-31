// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBook.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Dheer Singh Meena"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator_Day_23
{
    /// <summary>
    /// Creating Ride class to set data for particular ride.
    /// </summary>
    public class Ride
    {
        //variable.
        public double distance;
        public int time;
        //Creating parameterized constructor for setting data.
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
