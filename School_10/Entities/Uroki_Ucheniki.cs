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
    
    public partial class Uroki_Ucheniki
    {
        public int ID { get; set; }
        public int Uroki_ID { get; set; }
        public int Uchenik_ID { get; set; }
        public string Ocenka { get; set; }
        public string Primechanie { get; set; }
    
        public virtual Ucheniki Ucheniki { get; set; }
        public virtual Uroki Uroki { get; set; }
    }
}
