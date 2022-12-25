using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepoPractice.Models
{
    public class PreviousOrdersModel
    {
        [Key]
        public int PreviousOrdersId { get; set; }

        public UserModel UserModel { get; set; }

        public OrderModel OrderModel { get; set; }
    }
}