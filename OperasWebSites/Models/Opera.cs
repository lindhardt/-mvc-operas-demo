using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OperasWebSites.Models
{
    public class Opera
    {
        public int OperaID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [CheckValidYear]
        public int Year { get; set; }

        public string Composer { get; set; }
    }

    public class CheckValidYear : ValidationAttribute
    {
        public CheckValidYear()
        {
            ErrorMessage = "The earliest opera is Daphe. 1598, Peri and Rinuccini";
        }

        public override bool IsValid(object value)
        {
            int year = (int)value;

            return year >= 1598;
        }
    }
}