using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MCGA.Entities
{
    /// <summary>
    /// TipoDia Metadata
    /// </summary>
    [MetadataType(typeof(TipoDiaMetadata))]
    public partial class TipoDia
    {
        public class TipoDiaMetadata
        {
            [DisplayName("Descripción")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string descripcion { get; set; }
        }
    }
}
