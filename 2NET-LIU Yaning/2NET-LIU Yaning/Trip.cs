//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _2NET_LIU_Yaning
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trip
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public System.DateTime DepartureTime { get; set; }
        public string Arrival { get; set; }
        public System.DateTime ArrivalTime { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
    
        public virtual Driver Driver { get; set; }
    }
}
