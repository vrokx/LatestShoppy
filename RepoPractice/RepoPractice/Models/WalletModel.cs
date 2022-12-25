using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepoPractice.Models
{
    public class WalletModel
    {
        [Key]
        public int WalletId { get; set; }

        [Required]
        public int CurrentBalance { get; set; }

        public UserModel UserModel { get; set; }

        public CartModel CartModel { get; set; }
    }
}