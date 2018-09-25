using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MCGA.Entities
{
    [MetadataType(typeof(TipoReservaMetadata))]
    public partial class TipoReserva
    {
        public class TipoReservaMetadata
        {
            [DisplayName("Descripción")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string descripcion { get; set; }
        }
    }
}
