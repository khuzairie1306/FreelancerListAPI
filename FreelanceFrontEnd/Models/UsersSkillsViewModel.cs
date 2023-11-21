using System.ComponentModel.DataAnnotations;

namespace FreelanceFrontEnd.Models
{
    public class UsersSkillsViewModel
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public int skillid { get; set; }
        [Required]
        public int userid { get; set; }


    }
}
