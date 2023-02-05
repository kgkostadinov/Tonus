using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tonus.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = " *")]
        public string Name { get; set; }
        [Required(ErrorMessage=" *")]
        public string Message { get; set; }
    }
}