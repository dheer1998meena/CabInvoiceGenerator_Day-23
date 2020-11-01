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
    // Creating CabInvoiceException class for custum exception handelling.
    [Serializable]
    public class CabInvoiceException : Exception
    {
        public ExceptionType exceptionType;
        //creating enum for exception type.
        public enum ExceptionType
        {
                INVALID_DISTANCE, INVALID_TIME, NULL_RIDES,
                INVALID_RIDE_TYPE,INVALID_USER_ID
        }
        // Parameterised constructor to override the base class message.
        public CabInvoiceException(ExceptionType innerException, string message) : base(message)
        {
            this.exceptionType = innerException;
        }

    }
}
