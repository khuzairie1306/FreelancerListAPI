using System.ComponentModel.DataAnnotations;

namespace FreelancerListAPI.Models
{
    public class ConfigSkill
    {

        [Key]
        
        public int Id { get; set; }

        public int Skillid { get; set; }

        
        public string skillname { get; set; }





    }
}
