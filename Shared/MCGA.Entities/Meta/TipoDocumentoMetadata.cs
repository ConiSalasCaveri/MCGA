using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MCGA.Entities.Meta
{
    [MetadataType(typeof(TipoDocumentoMetadata))]
    public partial class TipoDocumento
    {
        public class TipoDocumentoMetadata
        {
            [DisplayName("Descripción")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string descripcion { get; set; }
        }
    }
}
