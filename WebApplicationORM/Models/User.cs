using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationORM.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ✅ Important
        public int Id { get; set; }

        [MaxLength(400)]
        public string Email { get; set; }

        [MaxLength(400)]
        public string Password { get; set; }
    }
}