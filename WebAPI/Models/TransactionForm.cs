using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TransactionForm
    {
        public int UserID { get; set; }
        public float Balance { get; set; }
    }
}
