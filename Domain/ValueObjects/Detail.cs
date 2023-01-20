using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public class Detail : ValueObject
    {

        public String EmailAddress { get; private set; }
        public String PhoneNumber { get; private set; }
        public String Name { get; private set; }
        public String OfficePhoneNumber { get; private set; }

        public Detail() { }
        
        public Detail(string email, string phoneNumber,string name,string officeNumber)
        {

            EmailAddress = email;
            PhoneNumber = phoneNumber;
            Name = name;
            OfficePhoneNumber = officeNumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailAddress;
            yield return PhoneNumber;
            yield return Name;
            yield return OfficePhoneNumber;
        }
    }
}
