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
    
    public partial class ObjectType
    {
        public ObjectType()
        {
            this.Object = new HashSet<Object>();
        }
    
        public int ID { get; set; }
        public short HPRestoreValue { get; set; }
        public string Name { get; set; }
        public short AttackStrenghtBoost { get; set; }
        public short DefenseBoost { get; set; }
    
        public virtual ICollection<Object> Object { get; set; }
    }
}
