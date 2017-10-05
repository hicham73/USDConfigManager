using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDManager.Model
{
    class Record
    {

        Guid _id;
        string _path;

        public Guid Id {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name { get; set; }
        public USDEntity Entity { get; set; }
        public Dictionary<string, Attribute> Attributes { get; set; } = new Dictionary<string, Attribute>();

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }
    }
}
