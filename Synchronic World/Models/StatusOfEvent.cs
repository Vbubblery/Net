using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synchronic_World.Models
{
    public class StatusOfEvent
    {
        public StatusOfEvent()
        {
            EventSystems = new List<EventSystem>();
        }
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        public string status { get; set; }

        public virtual ICollection<EventSystem> EventSystems { get; set; }
    }
}