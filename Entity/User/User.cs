using System.ComponentModel.DataAnnotations.Schema;
using PC.Utility.Domain;
using PD.Entity.Patient;

namespace PD.Entity.User
{
    public class User : BaseEntity
    {
        public string FName { get; set; }

        public string LName { get; set; }

        public string Phone { get; set; }

        public string? Address { get; set; }

        public string Password { get; set; }

        public bool MobailActiveStatus { get; set; }

        public string ActivationCode { get; set; }

        public string? Avatar { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role.Role Role { get; set; }

        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        public List<Patient.Patient> Patient { get; set; }

        public List<Psychologist.Psychologist> Psychologists { get; set; }

        public List<Comment> Comments { get; set; }

        public string? Token { get; set; }

        public void Edit(string fName, string lName, string? address, string? avatar, int roleId, int genderId)
        {
            FName = fName;
            LName = lName;
            Address = address;
            Avatar = avatar;
            RoleID = roleId;
            GenderId = genderId;
            UpdatedAt = DateTime.Now;
        }

        public void ActiveMobail()
        {
            MobailActiveStatus = true;
        }

        public void Active()
        {
            IsActive = true;
        }

        public void DeActive()
        {
            IsActive = false;
        }

        public void SetToken(string token)
        {
            Token = token;
        }

        public string FullName()
        {
            return FName + LName;
        }

        public void ChangeAuth(int roleId)
        {
            RoleID = roleId;
        }
    }
}