using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SP19.P05.Mobile.Forms.Model
{
   public class Token
    {
        public int Id { get; set; }
        public string Access_token { get; set; }
        public string  Error_description { get; set; }
        public string Expire_date { get; set; }

        public Token() { }
    }
}
