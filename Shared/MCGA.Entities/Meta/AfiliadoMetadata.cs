using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities
{
    [MetadataType(typeof(AfiliadoMetadata))]
    public partial class Afiliado
    {
        public class AfiliadoMetadata
        {
            [DisplayName("Nombre")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string Nombre { get; set; }

            [DisplayName("Apellido")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string Apellido { get; set; }

            [DisplayName("Numero")]
            [Required(ErrorMessage = "Requerido")]            
            [MaxLength(10, ErrorMessage = "La longitud es de 10 caracteres")]
            public string Numero { get; set; }

            [DisplayName("Direccion")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string Direccion { get; set; }

            [DisplayName("Telefono")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(50, ErrorMessage = "La longitud es de 50 caracteres")]
            public string Telefono { get; set; }

            [DisplayName("Mail")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(100, ErrorMessage = "La longitud es de 100 caracteres")]
            [EmailAddress(ErrorMessage = "Formato de email inválido")]
            public string Email { get; set; }

            [DisplayName("Fecha nacimiento")]
            [Required(ErrorMessage = "Requerido")]
            [DataType(DataType.Date)]
            public System.DateTime FechaNacimiento { get; set; }

            [DisplayName("Nro afiliado")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(255, ErrorMessage = "La longitud es de 255 caracteres")]
            public string NumeroAfiliado { get; set; }

            [ScaffoldColumn(false)]
            public string Foto { get; set; }

            [ScaffoldColumn(false)]
            public bool Habilitado { get; set; }

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
