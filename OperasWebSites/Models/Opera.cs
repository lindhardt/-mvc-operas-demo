using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

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

        [DisplayName("Created by")]
        public string CreatedBy { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckValidYear : ValidationAttribute
    {
        public CheckValidYear()
        {
            ErrorMessage = "The earliest opera is Daphe. 1598, Peri and Rinuccini";
        }

        public override bool IsValid(object value)
        {
            try
            {
                int year = (int)value;
                return year >= 1598;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Exception casting value to int", e);
            }
        }
    }
}