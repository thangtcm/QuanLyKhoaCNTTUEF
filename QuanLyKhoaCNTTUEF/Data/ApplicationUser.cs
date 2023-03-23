using Microsoft.AspNetCore.Identity;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? City { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? UrlAvartar { get; set; }

        //public bool? NeedChat { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {MiddleName} {LastName}"; }
        }

        public string NameAndId
        {
            get { return $"{FullName} (ID: {Id})"; }
        }
        public virtual ICollection<MembersGroups>? MembersGroups { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {

    }
}
