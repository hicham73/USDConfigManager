using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDManager.Model
{
    class Attribute
    {
        Object _object;
        string _value;
        string _name;
        string _type;

        public Object Object {
            get
            {
                return _object;
            }
            set
            {
                _type = value.GetType().Name;
                _object = value;
                switch (_type)
                {
                    case "OptionSetValue":
                        _value = ((OptionSetValue)value).Value.ToString();
                        _name = _value;
                        break;
                    case "EntityReference":
                        _value = ((EntityReference)value).Id.ToString();
                        _name = ((EntityReference)value).Name;
                        break;
                    default:
                        _value = value.ToString();
                        _name = _value;
                        break;
                }
            }
        }

        public string Name {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public string Type {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
    }
}
