using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class WordVsGroupModel
    {
        public int ID { get; set; }
        public int GroupId { get; set; }
        public int WordId { get; set; }


        [Required(ErrorMessage = "Missing Group Name")]
        [MinLength(1, ErrorMessage = "must be minimum length of 1 char at least")]
        [MaxLength(150, ErrorMessage = "must not exceed 150 chars")]
        public string GroupName { get; set; } = null!;

        [Required(ErrorMessage = "Missing Word value")]
        [MinLength(1, ErrorMessage = "must be minimum length of 1 char at least")]
        [MaxLength(100, ErrorMessage = "must not exceed 100 chars")]
        public string? WordValue { get; set; }


        public WordVsGroupModel() { }
    }

}
