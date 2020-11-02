// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBook.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Dheer Singh Meena"/>
// --------------------------------------------------------------------------------------------------------------------
using NUnit.Framework;
using CabInvoiceGenerator_Day_23;

namespace CabIvoiceGeneratorNUnitTest
{
    /// <summary>
    /// Creating class for NUnit test cases.
    /// </summary>
    public class Tests
    {
        // Initiallizing the instance of the Invoice Generator class and assigning null value to its reference. 
        InvoiceGenerator invoiceGenerator = null;
        /// <summary>
        /// UC1 Given Distance And Time Should Return Total Fare For The Journey By Computing Through The Calculate Fare Method
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFareForTheJourney()
        {
            ///Act
            double distance = 5.0;
            int time = 6;
            // Instantinating the object with normal ride type
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double actualTotalFare = invoiceGenerator.CalculateTotalFare(distance, time);
            double expectedlTotalFare = 56;
            ///Assert
            Assert.AreEqual(actualTotalFare, expectedlTotalFare);
        }

        /// <summary>
        /// UC2/UC3 Given Multiple Rides Should Return Number Of Rides AndAggregateFare And Average Fare.
        /// </summary>
        [Test]
        public void GivenMultipleRide_ShouldReturnNumberOfRideAggregrateFareAndAverageFare()
        {
            /// Arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 9), new Ride(0.1, 1), new Ride(0.2, 1) };
            /// Act
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateTotalFare(rides);
            var resultHashCode = invoiceSummary.GetHashCode();
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(3,39.0,13.0);
            var resultExpectedHashCode = expectedInvoiceSummary.GetHashCode();
            /// Assert
            Assert.AreEqual(invoiceSummary, expectedInvoiceSummary);
        }
       /// <summary>
        /// UC 4 : Given the user id, invoice service gets list of rides and returns invoice summary.
        /// </summary>
        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRides_ShouldReturnInvoiceSummary()
        {
            /// Arrange 
            ///initialising the instance of the invoice generator class
            /// Creating the instance of the ride repository.
            /// Initialising the ride array with details of the ride.
            /// Adding the ride data for the user to the ride repository
            ///Getting the ride data from the ride repository class.
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            RideRepository repository = new RideRepository();
            string userId = "xyz@12";
            Ride[] rides = { new Ride(2.0, 9), new Ride(0.1, 1), new Ride(0.2, 1) };
            repository.AddRide(userId, rides);
            ///Act
            Ride[] rideData = repository.GetRides(userId);
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateTotalFare(rideData);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(3, 39.0, 13.0);
            /// Assert
            Assert.AreEqual(expectedInvoiceSummary, invoiceSummary);
        }
        /// <summary>
        /// UC5 Given Distance And Time Should Return TotalFare For PremiumRide.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFareForPremiumRide()
        {
            ///Arrange
            double distance = 10;
            int time = 10;
            double expected = 170;
            ///Act
            this.invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double actual = invoiceGenerator.CalculateTotalFare(distance, time);
            ///Assert
            Assert.AreEqual(expected, actual);
        }
    }
}