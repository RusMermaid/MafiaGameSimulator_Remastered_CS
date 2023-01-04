using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class UserModel
    {
        [Required]
        public string Pseudo { get; set; }

        [Required]
        public string Mdp { get; set; }
    }
}