//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Certamen_3.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AFP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AFP()
        {
            this.CLIENTEs = new HashSet<CLIENTE>();
        }
    
        public int ID_AFP { get; set; }
        public string NOM_AFP { get; set; }
        public int COMISION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE> CLIENTEs { get; set; }
    }
}
