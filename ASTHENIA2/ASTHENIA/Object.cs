//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASTHENIA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Object
    {
        public int ID { get; set; }
        public int PlayerID { get; set; }
        public int ObjectTypeID { get; set; }
    
        public virtual ObjectType ObjectType { get; set; }
        public virtual Player Player { get; set; }
    }
}
