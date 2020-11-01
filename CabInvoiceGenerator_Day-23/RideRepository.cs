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
    /// Creating a class to add the ride data into dictionary and retrieve ride details of a particular user.
    /// </summary>
   public class RideRepository
    {
        //Initiallizing dictionary with key as user id and ride details list as value.
        Dictionary<string, List<Ride>> userRides = null;
        // Creating default constructor Initialising the instance of the User Ride Dictionary.
        public RideRepository()
        {
            userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRide(string userId, Ride[] rides)
        {
            /// checking the presence of the customer data on basis of his id as the key
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> listOfRides = new List<Ride>();
                    /// Adding the array to the list
                    listOfRides.AddRange(rides);
                    /// Adding to the dictionary with userId as the key and list of rides.
                    this.userRides.Add(userId, listOfRides);
                }
            }
            /// Catch exception if the list of ride details is null
            catch (CabInvoiceException)
            {
                if (rides == null)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, " Null Rides ");
            }
        }
        //Creating method to get the details of the ride history for a particular user with key as userID
        public Ride[] GetRides(string userId)
        {
            // Catch the exception if the invalid user Id.
            try
            {
                // Returning the ride history as array of Ride class type
                return this.userRides[userId].ToArray();
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user id");
            }
        }
    }
}
