//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BorAutoProjectail.Appdata
{
    using System;
    using System.Collections.Generic;
    
    public partial class cars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cars()
        {
            this.sells = new HashSet<sells>();
        }
    
        public int id { get; set; }
        public string mark { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public decimal cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sells> sells { get; set; }
    }
}
