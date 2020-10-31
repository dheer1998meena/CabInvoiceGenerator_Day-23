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
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(39.0, 3, 13.0);
            var resulExpectedHashCode = expectedInvoiceSummary.GetHashCode();
            /// Assert
        }
    }
}