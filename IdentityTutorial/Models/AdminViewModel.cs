using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IdentityTutorial.Models
{
    /// <summary>
    ///  This class contains register and edit roles models
    /// </summary>

    public class RoleViewModel
    {
        public string RoleId { get; set; }
        [Required(AllowEmptyStrings =false)]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
        public string Description { get; set; }

    }
    public class EditUserViewModel
    {
        

        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }

    }
}