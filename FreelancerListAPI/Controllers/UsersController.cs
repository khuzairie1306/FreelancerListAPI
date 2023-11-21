using FreelancerListAPI.DAL;
using FreelancerListAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;



namespace FreelancerListAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FreelanceDBContext _context;

        public UsersController(FreelanceDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _context.UsersFreelances.Select(x=> new UserFreelance { 
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Hobby = x.Hobby,
                    SkillSet = _context.UsersSkills.Where(UsersSkills => UsersSkills.userid == x.Id).Join(_context.ConfigSkill, UsersSkills => UsersSkills.skillid ,Skills =>Skills.Skillid , (UsersSkills, Skills) => new SkillsConfig
                    {
                        Skillid = Skills.Skillid,
                        skillname = Skills.skillname
                    }).ToList()
                }).ToList();
                


                if (users.Count == 0)
                {
                    return NotFound("No Freelancer are register in out system");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetUsers(int id)
        {
            try
            {
                var userskill = _context.UsersSkills.Where(x => x.userid == id).Select(y => y.skillid).ToArray();
                var secondlist = _context.ConfigSkill.Where(x => !userskill.Contains(x.Skillid)).ToList();
                List<SkillsConfig> skillConfigLatest = new List<SkillsConfig>();


                foreach(var item in secondlist)
                {
                    SkillsConfig sc = new SkillsConfig();
                    sc.Skillid = item.Skillid;
                    sc.skillname = item.skillname;
                    sc.IsChecked = false;
                    skillConfigLatest.Add(sc);
                }
               

                var users = _context.UsersFreelances.Where(k => k.Id == id).Select(x => new UserFreelance
                {
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Hobby = x.Hobby,
                    //SkillSetAll = _context.ConfigSkill.Select(x=> new ConfigSkill
                    //{
                    //    Id=x.Id,
                    //    Skillid = x.Skillid,
                    //    skillname = x.skillname,
                    //    IsChecked = (_context.UsersSkills.Where(z=>z.userid == id).FirstOrDefaultAsyn) ? true : false
                    //}).ToList()
                    SkillSet = _context.UsersSkills.Where(UsersSkills => UsersSkills.userid == x.Id).Join(_context.ConfigSkill, UsersSkills => UsersSkills.skillid, Skills => Skills.Skillid, (UsersSkills, Skills) => new SkillsConfig
                    {
                        Skillid = Skills.Skillid,
                        skillname = Skills.skillname,
                        IsChecked = true

                    }).ToList()
                }).ToList();


                List<UserFreelance> users1 = users;

                foreach(var user in users1)
                {
                    user.SkillSet.AddRange(skillConfigLatest);
                }

         

                //List<SkillsConfig>
                 //var users = _context.UsersFreelances.Find(id);
                if (users == null)
                {
                    return NotFound($"Users Of Freelance Not Found / Not Exist in Our System with this id {id}");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateUser(UserFreelance userFreelanceModel)
        {
            try
            {
                var usersnew = new UserFreelance {  Username = userFreelanceModel.Username , Email = userFreelanceModel.Email , PhoneNumber = userFreelanceModel.PhoneNumber , Hobby = userFreelanceModel.Hobby };

                _context.Add(usersnew);
                _context.SaveChanges();

                var id = usersnew.Id;
                //var id = _context.UsersFreelances.OrderBy(x => x.Id).LastOrDefault();
                List<UsersSkills> listUsersSkills = new List<UsersSkills>();

            foreach (var ud in userFreelanceModel.SkillSet)
                {
                    UsersSkills uskill = new UsersSkills();
                    uskill.userid = id;
                    uskill.skillid = ud.Skillid;
                    listUsersSkills.Add(uskill);
                }
                _context.AddRange(listUsersSkills);
                _context.SaveChanges();

                return Ok("User of Freelance has been created Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(UserFreelance userFreelanceModel)
        {
            if(userFreelanceModel == null || userFreelanceModel.Id == 0)
            {
                if (userFreelanceModel == null)
                {
                    return BadRequest("Data User Is Invalid , Please try again");
                }

                else if (userFreelanceModel.Id == 0)
                {
                    return BadRequest($"this user {userFreelanceModel.Username} is invalid ");
                }
            }


            try
            {
                var users = _context.UsersFreelances.Find(userFreelanceModel.Id);
                if (users == null)
                {
                    return BadRequest($"user belongs to this name {userFreelanceModel.Username} not found in this system, Please reupdate with correct details");

                }
                users.Username = userFreelanceModel.Username;
                users.Email = userFreelanceModel.Email;
                users.PhoneNumber = userFreelanceModel.PhoneNumber;
                users.Hobby = userFreelanceModel.Hobby;
                _context.SaveChanges();

                List<UsersSkills> usk = new List<UsersSkills>();

                var here= usk.Where(x => x.userid == userFreelanceModel.Id).ToList();

                var usersskills = _context.UsersSkills.Where(x => x.userid == userFreelanceModel.Id).ToList();

                _context.RemoveRange(usersskills);
                _context.SaveChanges();
                //foreach(var item in usersskills)
                //{
                //    _context.Remove(item);
                //    _context.SaveChanges();

                //}

                //Add back
                List<UsersSkills> listUsersSkills = new List<UsersSkills>();

                foreach (var ud in userFreelanceModel.SkillSet.Where(x=>x.IsChecked == true))
                {
                    UsersSkills uskill = new UsersSkills();
                    uskill.userid = userFreelanceModel.Id;
                    uskill.skillid = ud.Skillid;
                    listUsersSkills.Add(uskill);
                }
                _context.AddRange(listUsersSkills);
                _context.SaveChanges();

                return Ok("User Details Update Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var users = _context.UsersFreelances.Find(id);

                var usersSkill = _context.UsersSkills.Where(x=>x.userid == id);
                if (users == null)
                {
                    return NotFound($"User {id} Details Not Found");

                }
                _context.Remove(users);
                _context.RemoveRange(usersSkill);
                _context.SaveChanges();
                return Ok("Users Details has been deleted at our System ,Thank you");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetAllSkill()
        {
            try
            {
                var skillslist = _context.ConfigSkill.ToList().Select(x=> new
                {
                    Id = x.Id,
                    Skillid = x.Skillid,
                    skillname = x.skillname
                }).ToList();

                if (skillslist.Count == 0)
                {
                    return NotFound("No Skill register in out system");
                }
                return Ok(skillslist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
