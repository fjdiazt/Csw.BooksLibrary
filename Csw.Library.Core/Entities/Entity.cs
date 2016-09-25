using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Csw.Library.Core.Entities
{
    public abstract class Entity
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        [Column( Order = 1 )]
        public int Id { get; set; }
    }
}