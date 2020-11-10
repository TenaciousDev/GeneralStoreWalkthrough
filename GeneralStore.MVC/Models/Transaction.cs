using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStore.MVC.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTimeOffset TimeStamp { get; private set; }
        public Transaction() { }
        public Transaction(int transactionId, int productId, int customerId, decimal amount)
        {
            TransactionId = transactionId;
            ProductId = productId;
            CustomerId = customerId;
            Amount = amount;
            TimeStamp = DateTimeOffset.Now;
        }
    }
}