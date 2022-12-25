using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RepoPractice.Models
{
    public class CartModel
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float TotalAmount { get; set; }
        public int price { get; set; }
        public string productname { get; set; }

        public UserModel UserModel { get; set; }

        [ForeignKey("ProductModel")]
        public int ProductModel_ProductId { get; set; }

        public ProductModel ProductModel { get; set; }
    }
}