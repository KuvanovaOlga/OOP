//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab8
{
    using System;
    using System.Collections.Generic;
    
    public partial class GROUPS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GROUPS()
        {
            this.STUDENT = new HashSet<STUDENT>();
        }
    
        public int IDGROUP { get; set; }
        public string FACULTY { get; set; }
        public string PROFESSION { get; set; }
        public Nullable<short> YEAR_FIRST { get; set; }
    
        public virtual FACULTY FACULTY1 { get; set; }
        public virtual PROFESSION PROFESSION1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT> STUDENT { get; set; }
    }
}
