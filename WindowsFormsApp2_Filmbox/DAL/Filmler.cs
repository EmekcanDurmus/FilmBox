//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Filmler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Filmler()
        {
            this.FilmOyunculars = new HashSet<FilmOyuncular>();
        }
    
        public int FilmID { get; set; }
        public string FilmAdi { get; set; }
        public Nullable<System.DateTime> YayinTarihi { get; set; }
        public Nullable<int> YonetmenID { get; set; }
    
        public virtual Yonetmenler Yonetmenler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilmOyuncular> FilmOyunculars { get; set; }
    }
}
