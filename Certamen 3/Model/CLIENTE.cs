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
    
    public partial class CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTE()
        {
            this.ACREDITACIONs = new HashSet<ACREDITACION>();
        }
    
        public int RUT_CLIENTE { get; set; }
        public string DV_CLIENTE { get; set; }
        public string NOMBRES_CLIENTE { get; set; }
        public string APELLIDOS_CLIENTE { get; set; }
        public System.DateTime FECHA_NACIMIENTO { get; set; }
        public int ID_AFP { get; set; }
        public int REMUNERACION_CLIENTE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACREDITACION> ACREDITACIONs { get; set; }
        public virtual AFP AFP { get; set; }
    }
}
