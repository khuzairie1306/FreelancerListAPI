using System.ComponentModel.DataAnnotations;

namespace FreelancerListAPI.Models
{
    public class UsersSkills
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        public int skillid { get; set; }
        [Required]
        public int userid { get; set; }

        public bool IsChecked { get; set; }


    }
}
