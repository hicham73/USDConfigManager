using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USDManager.Connection;
using USDManager.Model;

namespace USDManager
{
    class USDMeta
    {
        private static List<USDEntity> _entities = new List<USDEntity>();
        private static List<USDRelationship> _relationships = new List<USDRelationship>();
        public List<USDEntity> Entities { get { return _entities; } set { _entities = value; } }
        public List<USDRelationship> Relationships { get { return _relationships; } set { _relationships = value; } }

        public USDMeta()
        {
            InitEntities();
        }

        private void InitRelationships()
        {
            _relationships.Add(new USDRelationship()
            {
                Name = "msdyusd_toolbarbutton_agentscriptaction",
                FromEntityName = "msdyusd_toolbarbutton",
                FromEntityPrimaryName = "msdyusd_name",
                ToEntityName = "msdyusd_agentscriptaction",
                ToEntityPrimaryName = "msdyusd_name"
            });
        }

        private void InitEntities()
        {
            _entities.Add(new USDEntity()
            {
                LogicalName = "uii_hostedapplication",
                DisplayName = "Hosted Controls",
                PrimaryFieldName = "uii_name",
                LinkEntity = "msdyusd_configuration_hostedcontrol",
                LinkEntityFrom = "uii_hostedapplicationid",
                LinkEntityTo = "uii_hostedapplicationid",
                Columns = new List<string>() {
                    "uii_sortorder",
                    "uii_hostedapplicationtype",
                    "uii_displaygroup",
                    "uii_isglobalapplication",
                    "msdyusd_crmwindowhosttype",
                    "uii_hostedapplicationid"
                },
                Relationships = {
                    new Data.Relationship(
                        
                    )
                }
            });

            _entities.Add(new USDEntity()
            {
                LogicalName = "msdyusd_agentscriptaction",
                DisplayName = "Action Calls",
                PrimaryFieldName = "msdyusd_name",
                LinkEntity = "msdyusd_configuration_actioncalls",
                LinkEntityFrom = "msdyusd_agentscriptactionid",
                LinkEntityTo = "msdyusd_agentscriptactionid",
                Columns = new List<string>() {
                    "msdyusd_order",
                    "msdyusd_application",
                    "msdyusd_actiondata",
                    "msdyusd_condition",
                    "msdyusd_launchifdynamic",
                    "msdyusd_shortcutkey",
                }
            });

            _entities.Add(new USDEntity()
            {
                LogicalName = "msdyusd_answer",
                DisplayName = "Answers",
                PrimaryFieldName = "msdyusd_name",
                Columns = new List<string>() {
                    "msdyusd_answertext",
                    "msdyusd_enabledcondition",
                    "msdyusd_linkedtask",
                    "msdyusd_order",
                    "msdyusd_visiblecondition",
                    "msdyusd_showtab"

                }
            });

            _entities.Add(new USDEntity()
            {
                LogicalName = "msdyusd_task",
                DisplayName = "Agent Script Tasks",
                PrimaryFieldName = "msdyusd_name",
                LinkEntity = "msdyusd_configuration_agentscript",
                LinkEntityFrom = "msdyusd_taskid",
                LinkEntityTo = "msdyusd_taskid",
                Columns = new List<string>() {
                    "msdyusd_category",
                    "msdyusd_scripttext",
                    "msdyusd_showtab",
                    "msdyusd_starttask",
                }
            });

            _entities.Add(new USDEntity()
            {
                LogicalName = "msdyusd_uiievent",
                DisplayName = "Event",
                PrimaryFieldName = "msdyusd_name",
                LinkEntity = "msdyusd_configuration_event",
                LinkEntityFrom = "msdyusd_uiieventid",
                LinkEntityTo = "msdyusd_uiieventid",
                Columns = new List<string>() {
                    "msdyusd_hostedapplicationid",
                },
                KeyFieldNames = new List<string> {
                    "msdyusd_hostedapplicationid",
                }
            });

            _entities.Add(new USDEntity()
            {
                LogicalName = "uii_action",
                DisplayName = "UII Action",
                PrimaryFieldName = "uii_name",
                Columns = new List<string>() {
                    "uii_automationmode",
                    "uii_isfocussedapplication",
                    "uii_hostedapplicationid",
                    "uii_isdefault",
                    "uii_method",
                    "uii_querystring",
                    "uii_isrunmodeasynchronous",
                    "uii_scriptfilepathtorun",
                    "uii_url",
                    "uii_workflowassemblytype",
                    "uii_workflowrules",
                    "uii_workflowxaml"
                },
                KeyFieldNames = new List<string> {
                    "uii_hostedapplicationid",
                }
            });

            _entities.Add(new USDEntity()
            {
                LogicalName = "msdyusd_scriptlet",
                DisplayName = "Scriptlet",
                PrimaryFieldName = "msdyusd_name",
                LinkEntity = "msdyusd_configuration_scriptlet",
                LinkEntityFrom = "msdyusd_scriptletid",
                LinkEntityTo = "msdyusd_scriptletid",
                Columns = new List<string>() {
                    "msdyusd_scripttext",
                }
            });
            _entities.Add(new USDEntity()
            {
                LogicalName = "msdyusd_sessioninformation",
                DisplayName = "Session Info.",
                PrimaryFieldName = "msdyusd_name",
                LinkEntity = "msdyusd_configuration_sessionlines",
                LinkEntityFrom = "msdyusd_sessioninformationid",
                LinkEntityTo = "msdyusd_sessioninformationid",
                Columns = new List<string>() {
                    "msdyusd_selectedentity",
                    "msdyusd_type",
                    "msdyusd_display",
                }
            });
            _entities.Add(new USDEntity()
            {
                LogicalName = "msdyusd_toolbarstrip",
                DisplayName = "Toolbar Strip",
                PrimaryFieldName = "msdyusd_name",
                LinkEntity = "msdyusd_configuration_toolbar",
                LinkEntityFrom = "msdyusd_toolbarstripid",
                LinkEntityTo = "msdyusd_toolbarstripid",
                Columns = new List<string>() {
                    "msdyusd_autoload",
                    "msdyusd_enabledcondition",
                }
            });
            _entities.Add(new USDEntity()
            {
                LogicalName = "msdyusd_toolbarbutton",
                DisplayName = "Button",
                PrimaryFieldName = "msdyusd_name",
                Columns = new List<string>() {
                    "msdyusd_buttontext",
                    "msdyusd_enablecondition",
                    "msdyusd_enabledcondition",
                    "msdyusd_scriptcondition",
                    "msdyusd_showtab",
                    "msdyusd_toolbarid",
                    "msdyusd_tooltip",
                    "msdyusd_visiblecondition",
                    "msdyusd_webresourceurl"
                }
            });

            _entities.Add(new USDEntity()
            {
                LogicalName = "uii_option",
                DisplayName = "Option",
                PrimaryFieldName = "uii_name",
                LinkEntity = "msdyusd_configuration_option",
                LinkEntityFrom = "uii_optionid",
                LinkEntityTo = "uii_optionid",
                Columns = new List<string>() {
                    "uii_value",
                }
            });


            _entities.Add(new USDEntity()
            {
                LogicalName = "msdyusd_windowroute",
                DisplayName = "Nav. Rule",
                PrimaryFieldName = "msdyusd_name",
                LinkEntity = "msdyusd_configuration_windowroute",
                LinkEntityFrom = "msdyusd_windowrouteid",
                LinkEntityTo = "msdyusd_windowrouteid",
                Columns = new List<string>() {
                    "msdyusd_action",
                    "msdyusd_nomatchesaction",
                    "msdyusd_singlematchaction",
                    "msdyusd_applicationaction",
                    "msdyusd_condition",
                    "msdyusd_nomatchdecision",
                    "msdyusd_multiplematchesdecision",
                    "msdyusd_singlematchdecision",
                    "msdyusd_destination",
                    "msdyusd_direction",
                    "msdyusd_entity",
                    "msdyusd_entitysearch",
                    "msdyusd_field",
                    "msdyusd_dashboardframe",
                    "msdyusd_from",
                    "msdyusd_fromsearch",
                    "msdyusd_hidenavbar",
                    "msdyusd_hideribbon",
                    "msdyusd_initiatingactivity",
                    "msdyusd_loadarea",
                    "msdyusd_showtab",
                    "msdyusd_sourceframe",
                    "msdyusd_url",
                }
            });
            
        }
    }
}
