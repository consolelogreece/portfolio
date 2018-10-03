using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(200)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Required")]
        [MaxLength(750)]
        public string Message { get; set; }
    }
}
