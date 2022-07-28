using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStoreAPI.Models
{
    public class TransactionEdit
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantitiy { get; set; }
        // public Datetime DateOfTransaction { get; set; }
    }
}