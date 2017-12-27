namespace IISInfo
{
    partial class IISInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IISInfo));
            this.dgvIssInfo = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSiteNameSearch = new System.Windows.Forms.TextBox();
            this.lblSiteSearch = new System.Windows.Forms.Label();
            this.lblAppSearch = new System.Windows.Forms.Label();
            this.txtAppSearch = new System.Windows.Forms.TextBox();
            this.lblAppPoolSearch = new System.Windows.Forms.Label();
            this.txtAppPoolSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIssInfo
            // 
            this.dgvIssInfo.AllowUserToAddRows = false;
            this.dgvIssInfo.AllowUserToDeleteRows = false;
            this.dgvIssInfo.AllowUserToOrderColumns = true;
            this.dgvIssInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvIssInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvIssInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvIssInfo.Location = new System.Drawing.Point(0, 65);
            this.dgvIssInfo.Name = "dgvIssInfo";
            this.dgvIssInfo.Size = new System.Drawing.Size(944, 468);
            this.dgvIssInfo.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(857, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSiteNameSearch
            // 
            this.txtSiteNameSearch.Location = new System.Drawing.Point(84, 6);
            this.txtSiteNameSearch.Name = "txtSiteNameSearch";
            this.txtSiteNameSearch.Size = new System.Drawing.Size(175, 20);
            this.txtSiteNameSearch.TabIndex = 2;
            this.txtSiteNameSearch.TextChanged += new System.EventHandler(this.txtSiteNameSearch_TextChanged);
            // 
            // lblSiteSearch
            // 
            this.lblSiteSearch.AutoSize = true;
            this.lblSiteSearch.Location = new System.Drawing.Point(12, 9);
            this.lblSiteSearch.Name = "lblSiteSearch";
            this.lblSiteSearch.Size = new System.Drawing.Size(25, 13);
            this.lblSiteSearch.TabIndex = 3;
            this.lblSiteSearch.Text = "Site";
            // 
            // lblAppSearch
            // 
            this.lblAppSearch.AutoSize = true;
            this.lblAppSearch.Location = new System.Drawing.Point(274, 12);
            this.lblAppSearch.Name = "lblAppSearch";
            this.lblAppSearch.Size = new System.Drawing.Size(59, 13);
            this.lblAppSearch.TabIndex = 5;
            this.lblAppSearch.Text = "Application";
            // 
            // txtAppSearch
            // 
            this.txtAppSearch.Location = new System.Drawing.Point(346, 9);
            this.txtAppSearch.Name = "txtAppSearch";
            this.txtAppSearch.Size = new System.Drawing.Size(175, 20);
            this.txtAppSearch.TabIndex = 4;
            this.txtAppSearch.TextChanged += new System.EventHandler(this.txtAppSearch_TextChanged);
            // 
            // lblAppPoolSearch
            // 
            this.lblAppPoolSearch.AutoSize = true;
            this.lblAppPoolSearch.Location = new System.Drawing.Point(539, 9);
            this.lblAppPoolSearch.Name = "lblAppPoolSearch";
            this.lblAppPoolSearch.Size = new System.Drawing.Size(83, 13);
            this.lblAppPoolSearch.TabIndex = 7;
            this.lblAppPoolSearch.Text = "Application Pool";
            // 
            // txtAppPoolSearch
            // 
            this.txtAppPoolSearch.Location = new System.Drawing.Point(630, 6);
            this.txtAppPoolSearch.Name = "txtAppPoolSearch";
            this.txtAppPoolSearch.Size = new System.Drawing.Size(175, 20);
            this.txtAppPoolSearch.TabIndex = 6;
            this.txtAppPoolSearch.TextChanged += new System.EventHandler(this.txtAppPoolSearch_TextChanged);
            // 
            // IISInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 533);
            this.Controls.Add(this.lblAppPoolSearch);
            this.Controls.Add(this.txtAppPoolSearch);
            this.Controls.Add(this.lblAppSearch);
            this.Controls.Add(this.txtAppSearch);
            this.Controls.Add(this.lblSiteSearch);
            this.Controls.Add(this.txtSiteNameSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvIssInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IISInfo";
            this.Text = "IISInfo";
            this.Load += new System.EventHandler(this.IISInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIssInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSiteNameSearch;
        private System.Windows.Forms.Label lblSiteSearch;
        private System.Windows.Forms.Label lblAppSearch;
        private System.Windows.Forms.TextBox txtAppSearch;
        private System.Windows.Forms.Label lblAppPoolSearch;
        private System.Windows.Forms.TextBox txtAppPoolSearch;
    }
}