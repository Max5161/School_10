//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace School_10.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uroki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uroki()
        {
            this.Uroki_Ucheniki = new HashSet<Uroki_Ucheniki>();
        }
    
        public int ID_Uroka { get; set; }
        public int Teacher_ID { get; set; }
        public int Predmet_ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int Klass_ID { get; set; }
        public string Thema { get; set; }
        public string Home_work { get; set; }
    
        public virtual Klassi Klassi { get; set; }
        public virtual Predmeti Predmeti { get; set; }
        public virtual Teacher Teacher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uroki_Ucheniki> Uroki_Ucheniki { get; set; }
    }
}
