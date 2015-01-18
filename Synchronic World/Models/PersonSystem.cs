using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synchronic_World.Models
{
    public class PersonSystem
    {
        public PersonSystem() {
            FriendSystems = new List<FriendSystem>();
            
        }
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public int EventID { get; set; }
        public virtual RoleOfPerson RoleOfPerson { get; set; }
        public int RoleId { get; set; }
        public virtual ICollection<FriendSystem> FriendSystems { get; set; }
    }
}