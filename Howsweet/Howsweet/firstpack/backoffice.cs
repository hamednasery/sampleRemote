//using umbraco.businesslogic;


//[umbraco.businesslogic.Application("hn-firstpack", "firstpack", "icon-employee")]
//public class Section : IApplication { }

namespace firstpack.Trees
{
    using System;
    using umbraco;
    
    using umbraco.interfaces;
    using Umbraco.Web.Mvc;    
    using umbraco.BusinessLogic.Actions;
    using Umbraco.Core;
    using Umbraco.Web.Models.Trees;
    using Umbraco.Web.Trees;
    /// <summary>
    /// The merchello application.
    /// </summary>
    [umbraco.businesslogic.Application("hnfirstpack", "firstpack", "icon-employee")] 
    [PluginController("hnfirstpack")]
    public class MerchelloApp : IApplication
    {
    }

    ///
    [Tree("hnfirstpack", "firstpackTree", "treeSome")]
    [Umbraco.Web.Mvc.PluginController("hnfirstpack")]
    public class PeopleTreeController : TreeController
    {
        protected override Umbraco.Web.Models.Trees.TreeNodeCollection GetTreeNodes(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            //check if we’re rendering the root node’s children
            if (id == Constants.System.Root.ToInvariantString())
            {
                var nodes = new TreeNodeCollection();
                var node = CreateTreeNode("1", "-1", queryStrings, "عنوان نود", "icon-user", false);
                var node1 = CreateTreeNode("2", "-1", queryStrings, "عنوان دومین", "icon-user", false);
                nodes.Add(node);
                nodes.Add(node1);
                return nodes;
            }
            //this tree doesn’t suport rendering more than 1 level
            throw new NotSupportedException();
        }

        protected override Umbraco.Web.Models.Trees.MenuItemCollection GetMenuForNode(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            //not worying about menu atm
            var menu = new MenuItemCollection();
            menu.Items.Add<CreateChildEntity, ActionNew>(ui.Text("actions", ActionNew.Instance.Alias));
            return menu;
        }
    }
}