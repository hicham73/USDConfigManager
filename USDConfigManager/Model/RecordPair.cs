using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USDManager.Model
{
    class RecordPair : TreeNode
    {
        Record _lRecord = new Record();
        Record _rRecord = new Record();
        public string PrimaryFieldName { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public EntityReference LastModifiedBy { get; set; }
        
        public USDEntity Entity { get; set; }

        public Record LRecord
        {
            get
            {
                return _lRecord;
            }
        }

        public Record RRecord
        {
            get
            {
                return _rRecord;
            }
        }

        public bool IsDiff()
        {
            var idFieldName = Entity.LogicalName + "id";
            if (_lRecord.Attributes.Count != _rRecord.Attributes.Count)
                return true;
            else
            {
                foreach (var key in _lRecord.Attributes.Keys)
                {

                    if (key != PrimaryFieldName && key != idFieldName && key != "modifiedby" && key != "modifiedon" && (!_rRecord.Attributes.ContainsKey(key) || _lRecord.Attributes[key].Name != _rRecord.Attributes[key].Name))
                        return true;
                }
            }

            return false;
        }
    }
}
