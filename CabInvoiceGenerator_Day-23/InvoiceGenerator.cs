// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBook.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Dheer Singh Meena"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
        //UC4 Initiallizing the riderespository class.
        RideRepository rideRepository = null;
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
                /// Initialising the default value for the PREMIUM Ride Type
                else if (rideType.Equals(RideType.PREMIUM))
                {
                    this.minimumCostPerKm = 15;
                    this.costPerKm = 2;
                    this.minimumFare = 20;
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

        public InvoiceSummary CalculateTotalFare(Ride[] rides)
        {
            //Initiallizing variable.
            double totalFare = 0;
            double averageFare = 0;
            /// Exception handling for the null rides.
            try
            {
                ///Calculating toatal fare.
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateTotalFare(ride.distance, ride.time);
                }
                //Calculating average Fare
                averageFare = totalFare / rides.Length;
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides passed are null..");
                }
            }
            return new InvoiceSummary(rides.Length, totalFare,averageFare);
        }
        /// <summary>
        /// Creating  method to return the invoice summary when passed with user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRides(string userId, Ride[] rides)
        {
            try
            {
                // Calling the Add ride method of Ride Repository class
                rideRepository.AddRide(userId, rides);
            }
            // Returning the custom exception in case the rides are null
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Null Rides");
                }
            }
           
        }
        /// <summary>
        /// Creating  method to return the invoice summary when passed with user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            try
            {
                return CalculateTotalFare(rideRepository.GetRides(userId));
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user Id");
            }
        }
    }
}
