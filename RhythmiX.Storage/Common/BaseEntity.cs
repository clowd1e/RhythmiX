using System.ComponentModel.DataAnnotations;

namespace RhythmiX.Storage.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public long BaseId { get; set; }
    }
}
