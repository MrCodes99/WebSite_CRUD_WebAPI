//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LF_repaso_DSWI_rq.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_productos()
        {
            this.tb_pedidosdeta = new HashSet<tb_pedidosdeta>();
        }
    
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public string umedida { get; set; }
        public decimal PrecioUnidad { get; set; }
        public short UnidadesEnExistencia { get; set; }
    
        public virtual tb_categorias tb_categorias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_pedidosdeta> tb_pedidosdeta { get; set; }
        public virtual tb_proveedores tb_proveedores { get; set; }
    }
}
