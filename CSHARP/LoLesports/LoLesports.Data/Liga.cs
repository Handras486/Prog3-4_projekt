//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoLesports.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Liga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Liga()
        {
            this.Csapat = new HashSet<Csapat>();
        }
    
        public string Liga_nev { get; set; }
        public string Regio { get; set; }
        public string Studio_hely { get; set; }
        public Nullable<System.DateTime> Szezon_kezdet { get; set; }
        public Nullable<System.DateTime> Szezon_vege { get; set; }
        public int Csapatok_szama { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Csapat> Csapat { get; set; }
    }
}
