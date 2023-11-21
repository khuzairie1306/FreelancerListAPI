using System.ComponentModel.DataAnnotations;

namespace FreelanceFrontEnd.Models
{
    public class SkillsViewModel
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
