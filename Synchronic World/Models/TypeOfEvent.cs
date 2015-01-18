using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synchronic_World.Models
{
    public class TypeOfEvent
    {
        public TypeOfEvent() {
            EventSystem = new List<EventSystem>();
        }
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [Required]
        public string Category { get; set; }

        public virtual ICollection<EventSystem> EventSystem { get; set; }
    }
}