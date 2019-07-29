using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsForum.Models.ApplicationUser
{
    public class ProfileList
    {
        public IEnumerable<ProfileModel> Profiles { get; set; }
    }
}
