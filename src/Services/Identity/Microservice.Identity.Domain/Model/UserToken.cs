using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.Model
{
    public class UserToken : AccessToken
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PictureName { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
