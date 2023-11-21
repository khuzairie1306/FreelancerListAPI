using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FreelanceFrontEnd.Models
{
    public class UsersViewModel 
    {
        [Required]
        public int Id { get; set; }

        [Required]
        
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Hobby { get; set; }
        [DisplayName("Skill Set")]
        public List<SkillsListing> SkillSet { get; set; }

        




    }

    public class SkillsListing
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int skillid { get; set; }
        [Required]
        public string skillname { get; set; }

        public bool IsChecked { get; set; }

    }
}
