using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MCGA.Entities
{
    [MetadataType(typeof(TipoSexoMetadata))]
    public partial class TipoSexo
    {
        public class TipoSexoMetadata
        {
            [DisplayName("Descripción")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string descripcion { get; set; }
        }
    }
}
