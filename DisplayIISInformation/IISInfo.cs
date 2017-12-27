using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.Administration;
using Application = Microsoft.Web.Administration.Application;
using System.IO;


namespace IISInfo
{
    public partial class IISInfo : Form
    {
        public IISInfo()
        {
            InitializeComponent();
        }


        private void IISInfo_Load(object sender, EventArgs e)
        {
            if (DateTime.Now > (new DateTime(2018, 1, 15)))
            {
                this.Close();
            }
            FetchAndBind();
        }

        DataTable sitesInfoTable;
        private void FetchAndBind()
        {
            using (var serverManager = new ServerManager())
            {
                //This is changes.
                 sitesInfoTable = GetIISInfoTableInstance();


                foreach (var site in serverManager.Sites)
                {
                    foreach (var appl in site.Applications)
                    {
                        
                        foreach (var virtDir in appl.VirtualDirectories)
                        {
                            DataRow row = sitesInfoTable.NewRow();

                            row["SiteName"] = site.Name;
                            row["AppName"] = appl.Path;
                            row["AppPoolName"] = appl.ApplicationPoolName;

                            var applicationPool = serverManager.ApplicationPools[appl.ApplicationPoolName];
                            row["AppPoolStatus"] = applicationPool.State.ToString();
                            row["RuntimeVersion"] = applicationPool.ManagedRuntimeVersion;
                            row["VirtualDirPath"] = virtDir.Path;
                            row["PhysicalPath"] = virtDir.PhysicalPath;
                            sitesInfoTable.Rows.Add(row);
                        }
                    }
                }
                dgvIssInfo.DataSource = sitesInfoTable;

                // Create ContextMenu and set event
                ContextMenuStrip cMenu = new ContextMenuStrip();
                ToolStripItem mItem = cMenu.Items.Add("Export to CSV");

                mItem.Click += mItem_Click;
                mItem.Click += (o, e) => { /* Do Something */ };

                dgvIssInfo.ContextMenuStrip = cMenu;

            }
        }

        void mItem_Click(object sender, EventArgs e)
        {
            var source = dgvIssInfo.DataSource;

            var view = source as DataView;

            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog(this);
            string folderPath = fbd.SelectedPath;
            string fileFullPath = Path.Combine(folderPath, "IISInfo_" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv");
            if (view !=null)
            {
                ToCSV(view.ToTable(), fileFullPath);
            }
            else
            {
                var dataTable = source as DataTable;
                if (dataTable != null)
                {
                    ToCSV(dataTable, fileFullPath);
                }
            }

        }

        private void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            var sw = new StreamWriter(strFilePath, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }  

        private static DataTable GetIISInfoTableInstance()
        {
            DataTable table = new DataTable();
            table.Columns.Add("SiteName", typeof(string));
            table.Columns.Add("AppName", typeof(string));
            table.Columns.Add("AppPoolName", typeof(string));
            table.Columns.Add("AppPoolStatus", typeof(string));
            table.Columns.Add("RuntimeVersion", typeof(string));
            table.Columns.Add("VirtualDirPath", typeof(string));
            table.Columns.Add("PhysicalPath", typeof(string));
            return table;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FetchAndBind();
        }

        private void txtSiteNameSearch_TextChanged(object sender, EventArgs e)
        {
            FilterAndRebind();

        }

        private void FilterAndRebind()
        {
            var siteView = sitesInfoTable.DefaultView;

            var searchText = new System.Text.StringBuilder();

            if (!string.IsNullOrWhiteSpace(txtSiteNameSearch.Text))
            {
                searchText.Append("SiteName LIKE '%" + txtSiteNameSearch.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtAppSearch.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtSiteNameSearch.Text))
                {
                    searchText.Append(" AND ");
                }
                searchText.Append("AppName LIKE '%" + txtAppSearch.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtAppPoolSearch.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtSiteNameSearch.Text) || !string.IsNullOrWhiteSpace(txtAppSearch.Text))
                {
                    searchText.Append(" AND ");
                }
                searchText.Append("AppPoolName LIKE '%" + txtAppPoolSearch.Text + "%'");
            }

            siteView.RowFilter = searchText.ToString();
            dgvIssInfo.DataSource = siteView;
        }

        private void txtAppSearch_TextChanged(object sender, EventArgs e)
        {
            FilterAndRebind();
        }

        private void txtAppPoolSearch_TextChanged(object sender, EventArgs e)
        {
            FilterAndRebind();
        }
    }
}
