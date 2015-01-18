using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Synchronic_World.Models
{
    public class FriendSystem
    {
        public int ID { get; set; }
        public string FriendName { get; set; }
        public int PersonId { get; set; }
        public virtual PersonSystem PersonSystems { get; set; }
    }
}