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
   public class InvoiceGenerator
    {
        //variable.
        public RideType rideType;
        //Constants
        private readonly int costPerKm;
        private readonly double minimumCostPerKm;
        private readonly double minimumFare;
        //Creating default constructor of the Invoice Generator Class. 
        public InvoiceGenerator()
        {

        }
        //Creating parameterized constructor of the Invoice Generator Class.
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            //Exception handling for the invalid ride type.
            try
            {
                //Checking the ride type is equal Normal or not. 
                if (rideType.Equals(RideType.NORMAL))
                {
                    this.costPerKm = 1;
                    this.minimumCostPerKm = 10;
                    this.minimumFare = 5;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }
        }
        /// <summary>
        /// Creating a method for Calculating total fare of the cab journey.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateTotalFare(double distance, int time)
        {
            //Initializing total fare.
            double totalFare = 0;
            // Exception handling for the Invalid distance and time.
            try
            {
                //Calculating total fare.
                totalFare = distance * minimumCostPerKm + time * costPerKm;
            }
            catch (CabInvoiceException)
            {
                if (distance < 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                if (time < 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
            }
            //Comparing total fare with minimum fare.
            return Math.Max(totalFare, minimumFare);
        }
    }
}
