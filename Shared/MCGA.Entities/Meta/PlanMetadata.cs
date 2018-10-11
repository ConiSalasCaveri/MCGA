using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities
{
    [MetadataType(typeof(PlanMetadata))]
    public partial class Plan
    {
        public class PlanMetadata
        {
            [DisplayName("Descripción")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string descripcion { get; set; }

            [DisplayName("Precio consulta")]
            [Required(ErrorMessage = "Requerido")]
            public decimal precio_bono_consulta { get; set; }

            [DisplayName("Precio farmacia")]
            [Required(ErrorMessage = "Requerido")]
            public decimal precio_bono_farmacia { get; set; }

            [ScaffoldColumn(false)]
            public System.DateTime createdon { get; set; }

            [ScaffoldColumn(false)]
            public string createdby { get; set; }

            [ScaffoldColumn(false)]
            public System.DateTime changedon { get; set; }

            [ScaffoldColumn(false)]
            public string changedby { get; set; }

            [ScaffoldColumn(false)]
            public Nullable<System.DateTime> deletedon { get; set; }

            [ScaffoldColumn(false)]
            public string deletedby { get; set; }

            [ScaffoldColumn(false)]
            public bool isdeleted { get; set; }
        }
    }
}
