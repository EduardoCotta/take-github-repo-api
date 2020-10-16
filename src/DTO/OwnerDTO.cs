using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeGithubAPI.Models;

namespace TakeGithubAPI.DTO
{
    public class OwnerDTO
    {
        public OwnerDTO()
        {
        }
        public OwnerDTO(Owner owner)
        {
            AvatarURL = owner.AvatarURL;
            Name = owner.Login;
        }
        public string AvatarURL { get; set; }
        public string Name { get; set; }
    }
}
