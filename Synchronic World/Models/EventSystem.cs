using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synchronic_World.Models
{
    public class EventSystem
    {
        public EventSystem() {
            IContributionSystem = new List<ContributionSystem>();
        }

        [HiddenInput(DisplayValue=false)]
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
        [Timestamp]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Timestamp]
        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public int StatusId { get; set; }
        public int typeId { get; set; }
        public virtual TypeOfEvent TypeOfEvent { get; set; }
        public virtual StatusOfEvent StatusOfEvent { get; set; }
        public virtual ICollection<ContributionSystem> IContributionSystem { get; set; }
    }
}