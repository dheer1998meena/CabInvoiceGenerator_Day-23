﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator_Day_23
{
    public class InvoiceSummary
    {
        ///invoice summary length = length of the journey.
        ///totalfare = computed totalfare of the journey.
        public int numberOfRides;
        public double averageFare;
        private double totalFare;
        private int length;
        // Creating parameterised constructor to initialise the data attributes with the user defined values.
        public InvoiceSummary(double totalFare, int length)
        {
            this.totalFare = totalFare;
            this.length = length;
        }

        public InvoiceSummary(int length, double totalFare)
        {
            this.length = length;
            this.totalFare = totalFare;
        }

        /// Over riding the Equals method so as to match the value of the object references.
        /// Default Equals method comapre the reference of the objects and not the values.
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is InvoiceSummary))
                return false;
            InvoiceSummary summary = (InvoiceSummary)obj;
            return (this.numberOfRides == summary.numberOfRides) && (this.totalFare == summary.totalFare) && (this.averageFare == summary.averageFare);
        }
        // Overriding equals method require overriding the GetHashCode method too else we get a compiler warning.
        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode() ^ this.length.GetHashCode();
        }
    }
}