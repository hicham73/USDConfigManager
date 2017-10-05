using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USDManager.Connection;
using USDManager.Data;
using USDManager.Model;
using static System.Windows.Forms.ListViewItem;

namespace USDManager
{
    public partial class MainForm : Form
    {
        #region "Variables"
        string _configurationName = "Prod Configuration";
        List<USDEntity> entities;
        List<USDRelationship> relationships;
        OrganizationServiceProxy leftProxy;
        OrganizationServiceProxy rightProxy;
        #endregion

        #region "Constructors"
        public MainForm()
        {
            InitializeComponent();
            ConnectionManager.LoadConfiguration(tvConnections);
            entities = new USDMeta().Entities;

        }
        #endregion

        #region "Methods"
        public void WorkAsync(WorkAsyncInfo info)
        {
            var _worker = new BackgroundWorker
            {
                WorkerReportsProgress = info.ProgressChanged != null,
                WorkerSupportsCancellation = info.IsCancelable
            };
            _worker.DoWork += info.PerformWork;

            if (_worker.WorkerReportsProgress && info.ProgressChanged != null)
            {
                _worker.ProgressChanged += info.PerformProgressChange;
            }

            _worker.RunWorkerCompleted += (s, e) =>
            {
                info.PostWorkCallBack?.Invoke(e);
            };
            _worker.RunWorkerAsync(info.AsyncArgument);
        }
        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressbarMain.Maximum = 100;
            progressbarMain.Step = 1;

            // Run operation in another thread
            WorkAsync(new WorkAsyncInfo
            {
                Host = this,
                Message = "Retrieving Workflows...",
                Work = (bw, ea) =>
                {
                    if (ConnectionManager.LeftConn == null || ConnectionManager.RightConn == null)
                    {
                        MessageBox.Show("You will need 2 connections to perform a Diff");
                        return;
                    }

                    leftProxy = ConnectionManager.LeftConn.Proxy;
                    rightProxy = ConnectionManager.RightConn.Proxy;

                    var leftConfig = Helper.GetConfigurationByName(_configurationName, leftProxy);
                    var rightConfig = Helper.GetConfigurationByName(_configurationName, rightProxy);

                    var nodes = new List<TreeNode>();

                    int index = 0;

                    foreach (var entity in entities)
                    {
                        entity.LeftConfiguration = leftConfig;
                        entity.RightConfiguration = rightConfig;

                        var node = new TreeNode(entity.DisplayName);
                        nodes.Add(node);
                        entity.GetData(leftProxy, rightProxy, index++ == 0, node);

                        int leftCount = entity.LeftCount;
                        int rightCount = entity.RightCount;

                        node.Text = node.Text + $"[{leftCount}-{rightCount}]";

                        bw.ReportProgress(100 * index / entities.Count);
                    }
                    ea.Result = nodes;
                },
                PostWorkCallBack = ea =>
                {
                    List<TreeNode> nodes = (List<TreeNode>)ea.Result;
                    tvDiffRecords.Nodes.Clear();
                    foreach (var node in nodes)
                    {
                        tvDiffRecords.Nodes.Add(node);
                    }
                },
                ProgressChanged = ea =>
                {
                    progressbarMain.Value = ea.ProgressPercentage;
                },

                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });

        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView2.Columns[1].Text = leftProxy.ServiceConfiguration.CurrentServiceEndpoint.Name;
            listView2.Columns[2].Text = rightProxy.ServiceConfiguration.CurrentServiceEndpoint.Name;

            try
            {
                listView2.Items.Clear();

                var rp = (RecordPair)((TreeView)sender).SelectedNode;
                ListViewItem item;

                foreach (var c in rp.Entity.Columns)
                {
                    var lv = rp.LRecord.Attributes.ContainsKey(c) ? rp.LRecord.Attributes[c].Name : "";
                    var rv = rp.RRecord.Attributes.ContainsKey(c) ? rp.RRecord.Attributes[c].Name : "";
                    item = new ListViewItem(new[] { c, lv, rv } );
                    listView2.Items.Add(item);
                }

                item = new ListViewItem(new[] { "Last Modified On/By", rp.LastModifiedOn.ToString(), rp.LastModifiedBy.Name });
                item.BackColor = Color.LightBlue;
                listView2.Items.Add(item);

                listView2.View = View.Details;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in MainForm.treeView1_AfterSelect, Message {ex.Message}");
            }
        }

        private void tvConnections_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = (CRMConnection)((TreeView)sender).SelectedNode;

            ConnectionManager.ToggleConnectionState(selectedItem);

            if (selectedItem.BackColor == Color.White)
                selectedItem.BackColor = Color.Pink;
            else
                selectedItem.BackColor = Color.LightGray;

        }

        private void ViewRecords(RecordPair rp)
        {
            var orgUrl = string.Empty;
            var recordId = string.Empty;

            if (rp == null)
            {
                MessageBox.Show("You need to select a record");
                return;
            }

            var entityLogicalName = rp.Entity.LogicalName;

            try
            {
                if (rp.LRecord.Id != null)
                {
                    orgUrl = GetUrl(leftProxy.ServiceConfiguration.CurrentServiceEndpoint.Address.ToString());
                    recordId = rp.LRecord.Id.ToString();
                    wbLeftRecord.Navigate(new Uri($"{orgUrl}main.aspx?etn={entityLogicalName}&pagetype=entityrecord&id=%7B{recordId}%7D"));
                }
                else
                {
                    wbLeftRecord.Navigate(new Uri("about:blank"));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"[MainForm.BtnViewRecords]) Coudln't view left record, Message: {ex.Message}");
            }

            try
            {
                if (rp.RRecord.Id != null)
                {
                    orgUrl = GetUrl(rightProxy.ServiceConfiguration.CurrentServiceEndpoint.Address.ToString());
                    recordId = rp.RRecord.Id.ToString();
                    wbRightRecord.Navigate(new Uri($"{orgUrl}main.aspx?etn={entityLogicalName}&pagetype=entityrecord&id=%7B{recordId}%7D"));
                }
                else
                {
                    wbRightRecord.Navigate(new Uri("about:blank"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[MainForm.BtnViewRecords]) Coudln't view right record, Message: {ex.Message}");
            }
        }
        private void btnViewRecords_Click(object sender, EventArgs e)
        {
            var rp = (RecordPair)tvDiffRecords.SelectedNode;
            ViewRecords(rp);
        }
        string GetUrl(string serviceUrl)
        {
            return serviceUrl.ToLower().Replace("xrmservices/2011/organization.svc", "");
        }

        #endregion

        private void relationshipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            relationships = new List<USDRelationship>();
            relationships.Add(new USDRelationship()
            {
                Name = "msdyusd_toolbarbutton_agentscriptaction",
                FromEntityName = "msdyusd_toolbarbutton",
                FromEntityPrimaryName = "msdyusd_name",
                ToEntityName = "msdyusd_agentscriptaction",
                ToEntityPrimaryName = "msdyusd_name"
            });
            relationships.Add(new USDRelationship()
            {
                Name = "msdyusd_answer_agentscriptaction",
                FromEntityName = "msdyusd_answer",
                FromEntityPrimaryName = "msdyusd_name",
                ToEntityName = "msdyusd_agentscriptaction",
                ToEntityPrimaryName = "msdyusd_name"
            });

            progressbarMain.Maximum = 100;
            progressbarMain.Step = 1;

            // Run operation in another thread
            WorkAsync(new WorkAsyncInfo
            {
                Host = this,
                Message = "Retrieving Workflows...",
                Work = (bw, ea) =>
                {
                    if (ConnectionManager.LeftConn == null || ConnectionManager.RightConn == null)
                    {
                        MessageBox.Show("You will need 2 connections to perform a Diff");
                        return;
                    }

                    leftProxy = ConnectionManager.LeftConn.Proxy;
                    rightProxy = ConnectionManager.RightConn.Proxy;

                    var leftConfig = Helper.GetConfigurationByName(_configurationName, leftProxy);
                    var rightConfig = Helper.GetConfigurationByName(_configurationName, rightProxy);

                    var nodes = new List<TreeNode>();

                    int index = 0;

                    foreach (var relationship in relationships)
                    {
                        var node = new TreeNode(relationship.Name);
                        nodes.Add(node);

                        relationship.GetData(node, leftProxy, rightProxy);
                        bw.ReportProgress(100 * index / entities.Count);
                    }
                    ea.Result = nodes;
                },
                PostWorkCallBack = ea =>
                {
                    List<TreeNode> nodes = (List<TreeNode>)ea.Result;
                    tvDiffAssociations.Nodes.Clear();
                    foreach (var node in nodes)
                    {
                        tvDiffAssociations.Nodes.Add(node);
                    }
                },
                ProgressChanged = ea =>
                {
                    progressbarMain.Value = ea.ProgressPercentage;
                },

                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });





        }

        private void DiffTreeNodeDoubleClickHandler(object sender, EventArgs e)
        {
            var rp = (RecordPair)tvDiffRecords.SelectedNode;
            ViewRecords(rp);

        }
    }
}
