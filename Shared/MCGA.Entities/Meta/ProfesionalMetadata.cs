using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities
{
    [MetadataType(typeof(ProfesionalMetadata))]
    public partial class Profesional
    {
        public class ProfesionalMetadata
        {
            [DisplayName("Nombre")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string Nombre { get; set; }

            [DisplayName("Apellido")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string Apellido { get; set; }

            [DisplayName("Tipo de documento")]
            [Required(ErrorMessage = "Requerido")]   
            [ScaffoldColumn(false)]
            public string TipoDocumentoId { get; set; }

            [DisplayName("Matricula")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string Matricula { get; set; }

            [DisplayName("Numero")]
            [Required(ErrorMessage = "Requerido")]            
            public string Numero { get; set; }

            [DisplayName("Dirección")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string Direccion { get; set; }

            [DisplayName("Teléfono")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string Telefono { get; set; }

            [DisplayName("Mail")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            [EmailAddress(ErrorMessage = "Formato de email inválido")]
            public string Email { get; set; }

            [DisplayName("Fecha nacimiento")]
            [Required(ErrorMessage = "Requerido")]
            [DataType(DataType.Date)]
            public DateTime FechaNacimiento { get; set; }

            [DisplayName("Tipo documento")]
            [Required(ErrorMessage = "Requerido")]
            public TipoDocumento TipoDocumento { get; set; }

            [ScaffoldColumn(false)]            
            public DateTime createdon { get; set; }

            [ScaffoldColumn(false)]
            public string createdby { get; set; }

            [ScaffoldColumn(false)]
            public DateTime changedon { get; set; }

            [ScaffoldColumn(false)]
            public string changedby { get; set; }

            [ScaffoldColumn(false)]
            public DateTime deletedon { get; set; }

            [ScaffoldColumn(false)]
            public string deletedby { get; set; }

            [ScaffoldColumn(false)]
            public bool isdeleted { get; set; }

        }
    }
}
