using System.ComponentModel.DataAnnotations;
namespace Cross_Zero.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;set; }
    }
}