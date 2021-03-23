using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace PoulSite.Models
{
    public class Orders
    {
        [Key]
        public int OrderNo { get; set; }

        [DataType(DataType.MultilineText)]
        public string OrderLists { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string ContactNo { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Date and Time of Delivery")]
        public DateTime DateTimeOrdered { get; set; }

        [Display(Name = "Date Ordered")]
        public DateTime DateAdded { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Mode Of Payment")]
        public MOPType MOP { get; set; }
    }

    public enum MOPType 
    { 
        COD = 1,
        GCash = 2,
        CreditCard = 3
    }
}
