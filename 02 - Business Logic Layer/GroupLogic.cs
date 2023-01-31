namespace DbProject
{
    public class GroupLogic : BaseLogic
    {
        //FIX IT: Validate the string groupName and the groupIndex that they are not in the db already.
        public GroupModel addGroup(GroupModel groupModel)
        {
            groupModel.GroupName = groupModel.GroupName.ToLower();
            Group groupRow = new Group
            {
                GroupName = groupModel.GroupName,
                GroupIndex = groupModel.GroupIndex
            };
            //FIX IT: 
            //groups.Add(groupRow); should I need the groups List at all??? check it later
            db.Groups.Add(groupRow);
            db.SaveChanges();
            groupModel.GroupId = groupRow.GroupId;
            return groupModel;
        }

        public List<GroupModel> getAllGroups()
        {
            return db.Groups.OrderBy(g=> g.GroupIndex).Select(g => new GroupModel(g)).ToList();
        }

    }
}
