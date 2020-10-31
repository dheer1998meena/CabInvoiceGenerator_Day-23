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
    }
}