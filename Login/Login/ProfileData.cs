using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class ProfileData
    {
        private string firstName;
        private string lastName;
        private DateTime dob;
        private string gender;
        private string phNumber;
        private string emailAddress;

        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public DateTime Dob { get { return dob; } set { dob = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string PhNumber { get { return phNumber; } set { phNumber = value; } }
        public string EmailAddress { get { return emailAddress; } set { emailAddress = value; } }
    }
}
