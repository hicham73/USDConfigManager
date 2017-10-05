using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDManager.Data
{
    class Relationship
    {
        public string Name { get; set; }
        public bool IsmanyToMany { get; set; }
        public bool Isreflexive { get; set;  }
        public string RelatedEntityName { get; set; }
        public string M2mTargetEntity { get; set; }
        public string M2mTargetEntityPrimaryKey { get; set; }
    }
}