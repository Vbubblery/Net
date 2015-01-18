using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synchronic_World.Models
{
    public class TypeOfContribution
    {
        public TypeOfContribution() {
            ContributionSystems = new List<ContributionSystem>();
        }
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int ID { get; set; }
        [Required]
        public string Category { get; set; }
        public virtual ICollection<ContributionSystem> ContributionSystems { get; set; }
    }
}