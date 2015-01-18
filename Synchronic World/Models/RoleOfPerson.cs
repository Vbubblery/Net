using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synchronic_World.Models
{
    public class RoleOfPerson
    {
        public RoleOfPerson() {
            Persons = new List<PersonSystem>();
        }
        [Key]
        public int Id { get; set; }
        public string who { get; set; }

        public virtual ICollection<PersonSystem> Persons { get; set; }

    }
}