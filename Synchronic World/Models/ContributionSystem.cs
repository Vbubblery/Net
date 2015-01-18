using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synchronic_World.Models
{
    public class ContributionSystem
    {
        public ContributionSystem() {      }

        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        public virtual TypeOfContribution TypeOfContributions { get; set; }
        public virtual EventSystem ES { get; set; }
        public int EventId { get; set; }
        public int TypeId { get; set; }
    }
}