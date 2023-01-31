using System;
using System.Collections.Generic;

namespace DbProject
{
    public partial class Group
    {
        public Group()
        {
            WordsVsGroups = new HashSet<WordsVsGroup>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;
        public int? GroupIndex { get; set; }

        public virtual ICollection<WordsVsGroup> WordsVsGroups { get; set; }
    }
}
