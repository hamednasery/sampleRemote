using System;
using System.Collections;
using System.Collections.Generic;
using umbraco.interfaces;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Web.Editors;

namespace firstpack.controllers
{
    [Umbraco.Web.Mvc.PluginController("hnfirstpack")]
    public class departmentApiController : UmbracoAuthorizedJsonController
    {
        public department getById(int id)
        {
           return DatabaseContext.Database.SingleOrDefault<department>(id);
        }
        public IEnumerable<department> getall()
        {
            var query = new Sql("select * from hn_firstpack_departments");
            return DatabaseContext.Database.Fetch<department>(query);
        }
        public department Postsave(department dept)
        {
            if (dept.id > 0)
            {
                DatabaseContext.Database.Update(dept);
            }
            else
                DatabaseContext.Database.Save(dept);
            
            return dept;
        }
    }
}