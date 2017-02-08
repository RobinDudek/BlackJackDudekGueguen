using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDudekGueguen.Model
    {
        public class Inscription
        {
            private string firstName;

            public string FirstName
            {
                get { return firstName; }
                set
                {
                    firstName = value;
                }
            }

            private string lastName;

            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }
            private string mail;

            public string Mail
            {
                get { return mail; }
                set { mail = value; }
            }
            private string userlogin;

            public string Userlogin
            {
                get { return userlogin; }
                set { userlogin = value; }
            }

        private string userpwd;

        public string UserPwd
        {
            get { return userpwd; }
            set { userpwd = value; }
        }


    }
}
