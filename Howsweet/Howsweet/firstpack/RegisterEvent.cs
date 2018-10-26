using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence;

namespace firstpack
{
    public class RegisterEvent : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //base.ApplicationStarted(umbracoApplication, applicationContext);
            var logger = LoggerResolver.Current.Logger;
            var dbContext = ApplicationContext.Current.DatabaseContext;
            var helper = new DatabaseSchemaHelper(dbContext.Database, logger, dbContext.SqlSyntax);
            if (!helper.TableExist("hn_firstpack_departments"))
            {
                helper.CreateTable(false,typeof(department));
            }
            if (!helper.TableExist("hn_firstpack_people"))
            {
                helper.CreateTable(false, typeof(person));
            }
            //add section
            Umbraco.Core.Models.Section section = applicationContext.Services.SectionService.GetByAlias("hnfirstpack");
            if (section == null)
            {
                applicationContext.Services.SectionService.MakeNew("firstpack", "hnfirstpack", "icon-employee");
                // Grant all existing users access to the new section
               // applicationContext.Services.UserService.
            }
            
        }
    }
}