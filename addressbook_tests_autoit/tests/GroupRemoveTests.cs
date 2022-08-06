using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemoveTests : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
               Name = "remove"
            };
            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            // find id
            int id = app.Groups.GetGroupId(newGroup);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreNotEqual(oldGroups, newGroups);
            app.Groups.Remove(id);
            newGroups = app.Groups.GetGroupList();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
