using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orient
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public int ResourceId { get; set; }
        public DateTime ExpiryDate {get; set;} 
        public int HitCounter { get; set; }
        public string UserType { get; set; }
    }
}