using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities.Meta
{
    [MetadataType(typeof(EspecialidadMetadata))]
    public partial class Especialidad
    {
        public class EspecialidadMetadata
        {
        }
    }
}
