using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SP19.P05.Mobile.Forms.Model
{

  public  class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public User() { }
        public User(string Username,  string Password)
        {
            this.Username = Username;
            this.Password = Password;

        }

        public  bool CheckInformation()
        {
            if (this.Username== null && this.Password== null)
                return false;
            else
                return true;
        }
    }
}
