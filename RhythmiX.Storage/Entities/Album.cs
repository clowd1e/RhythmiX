using RhythmiX.Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhythmiX.Storage.Entities
{
    [Table("Albums", Schema = "RhythmiX")]
    public class Album : BaseEntity
    {
        [Required]
        public long Id { get; set; }
    }
}
