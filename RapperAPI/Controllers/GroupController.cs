using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }
        [Route("/groups")]
        [HttpGet]
        public string Groups() {
            string groups = "Here's a list of all the Groups\n";
            foreach (var item in allGroups)
            {
                groups += item.GroupName + "\n";
            }
            return groups;
        }
        [Route("/groups/Name/{gname}")]
        [HttpGet]
        public string gName(string gname) {
            string GroupByName = "Group search by Name\n";
            var groupByName = allGroups.Where(p => p.GroupName.Contains(gname));
            foreach (var item in groupByName)
            {
                GroupByName += item.GroupName + "\n";
            }
            return GroupByName;
        }
        [Route("/groups/GroupId/{gID}")]
        [HttpGet]
        public string GroupID(int gID) {
            string GroupByID = "Groups searched by Group ID\n";
            var groupByID = allGroups.Where(p => p.Id==(gID));
            foreach (var item in groupByID)
            {
                GroupByID += item.GroupName + "\n";
            }
            return GroupByID;
        }
    }
}