using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities
{
    [MetadataType(typeof(TurnoMetadata))]
    public partial class Turno
    {
        public class TurnoMetadata
        {

            [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime Fecha { get; set; }
        }
    }
}
