using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace firstpack
{
    [TableName("hn_firstpack_people")]
    public class person
    {
        [PrimaryKeyColumn(AutoIncrement =true)]
        public int id { get; set; }
        [ForeignKey(typeof(department),Column ="id")]
        public int deptID { get; set; }
        public string name { get; set; }
        public string tel { get; set; }
    }
    [TableName("hn_firstpack_departments")]
    public class department
    {
        [PrimaryKeyColumn(AutoIncrement =true)]
        public int id { get; set; }
        public string name { get; set; }        
    }
}