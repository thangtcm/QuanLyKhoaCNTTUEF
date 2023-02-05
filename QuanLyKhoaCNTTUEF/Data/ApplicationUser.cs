using Microsoft.AspNetCore.Identity;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? City { get; set; }

        public string? FirtName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public List<MembersGroups>? MembersGroups { get; set; }
    }
}
