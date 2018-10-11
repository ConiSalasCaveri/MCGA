using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities
{
    [MetadataType(typeof(EstadoCivilMetadata))]
    public partial class EstadoCivil
    {
        public class EstadoCivilMetadata
        {
            [DisplayName("Descripción")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string descripcion { get; set; }
        }
    }
}
