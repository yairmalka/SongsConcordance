using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class GroupModel
    {
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Missing Group Name")]
        [MinLength(1, ErrorMessage = "must be minimum length of 1 char at least")]
        [MaxLength(150, ErrorMessage = "must not exceed 150 chars")]
        public string GroupName { get; set; } = null!;
        
        [Range(0,1000000,ErrorMessage ="index must be between 0 to 1M")]
        public int? GroupIndex { get; set; }



        public GroupModel(Group group)
        {
            GroupId = group.GroupId;
            GroupName = group.GroupName;
            GroupIndex = group.GroupIndex;
        }

        public GroupModel() { }

    }



}
