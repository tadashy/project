using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST.Models
{
    public class User                                                   
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Passwprd { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Memo { get; set; }
    }
}