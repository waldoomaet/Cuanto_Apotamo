using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Domain
{
    public class BalanceTransaction
    {

        public int Id { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public float Balance { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
