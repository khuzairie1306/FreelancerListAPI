using System.ComponentModel.DataAnnotations;

namespace FreelancerListAPI.Models
{
    public class UserFreelance
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Hobby { get; set; }

        public List<SkillsConfig> SkillSet { get; set; }

        

    }
}
