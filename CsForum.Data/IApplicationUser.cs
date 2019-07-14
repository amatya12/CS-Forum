using CsForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CsForum.Data
{
   public  interface IApplicationUser
   {
        IApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();
        Task SetProfileImageAsync(string id, Uri uri);
        Task IncrementRating(string id, Type type);
   }
}
