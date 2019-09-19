using System;
using SQLite;

namespace SP19.P05.Mobile.Forms.Model
{
    public class Customer
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string MailingAddress { get; set; }

        public Customer() { }
        
    }
}
