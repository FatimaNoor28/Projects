using eadProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace eadProject.Models
{

    public partial class Admin : FullAudinModel
    {
        
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter CNIC")]
        [StringLength(15)]
        public string? CNIC { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [MinLength(8)]
        public string? Password { get; set; }
    }

}