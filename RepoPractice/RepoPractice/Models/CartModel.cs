using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public UserModel UserModel { get; set; }

        public ProductModel ProductModel { get; set; }
    }
}