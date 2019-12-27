namespace IntegrateMission
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Label_MissionPath = new System.Windows.Forms.Label();
            this.DataGridView_ModelList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBox_MissionPath = new System.Windows.Forms.TextBox();
            this.Button_MissionPathBrowser = new System.Windows.Forms.Button();
            this.Button_StartAnalysis = new System.Windows.Forms.Button();
            this.ListBox_MissionList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_ModelList)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_MissionPath
            // 
            this.Label_MissionPath.AutoSize = true;
            this.Label_MissionPath.Location = new System.Drawing.Point(55, 57);
            this.Label_MissionPath.Name = "Label_MissionPath";
            this.Label_MissionPath.Size = new System.Drawing.Size(66, 13);
            this.Label_MissionPath.TabIndex = 0;
            this.Label_MissionPath.Text = "Mission path";
            // 
            // DataGridView_ModelList
            // 
            this.DataGridView_ModelList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_ModelList.Location = new System.Drawing.Point(201, 222);
            this.DataGridView_ModelList.Name = "DataGridView_ModelList";
            this.DataGridView_ModelList.Size = new System.Drawing.Size(578, 150);
            this.DataGridView_ModelList.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Model list";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mission list";
            // 
            // TextBox_MissionPath
            // 
            this.TextBox_MissionPath.Location = new System.Drawing.Point(146, 49);
            this.TextBox_MissionPath.Name = "TextBox_MissionPath";
            this.TextBox_MissionPath.Size = new System.Drawing.Size(192, 20);
            this.TextBox_MissionPath.TabIndex = 4;
            this.TextBox_MissionPath.Text = "D:\\BZVisualInspect\\UserData\\Mission";
            // 
            // Button_MissionPathBrowser
            // 
            this.Button_MissionPathBrowser.Location = new System.Drawing.Point(356, 45);
            this.Button_MissionPathBrowser.Name = "Button_MissionPathBrowser";
            this.Button_MissionPathBrowser.Size = new System.Drawing.Size(127, 23);
            this.Button_MissionPathBrowser.TabIndex = 5;
            this.Button_MissionPathBrowser.Text = "Browser";
            this.Button_MissionPathBrowser.UseVisualStyleBackColor = true;
            this.Button_MissionPathBrowser.Click += new System.EventHandler(this.Button_MissionPathBrowser_Click);
            // 
            // Button_StartAnalysis
            // 
            this.Button_StartAnalysis.Location = new System.Drawing.Point(262, 105);
            this.Button_StartAnalysis.Name = "Button_StartAnalysis";
            this.Button_StartAnalysis.Size = new System.Drawing.Size(113, 23);
            this.Button_StartAnalysis.TabIndex = 6;
            this.Button_StartAnalysis.Text = "Start Analysis";
            this.Button_StartAnalysis.UseVisualStyleBackColor = true;
            this.Button_StartAnalysis.Click += new System.EventHandler(this.Button_StartAnalysis_Click);
            // 
            // ListBox_MissionList
            // 
            this.ListBox_MissionList.FormattingEnabled = true;
            this.ListBox_MissionList.Location = new System.Drawing.Point(29, 225);
            this.ListBox_MissionList.Name = "ListBox_MissionList";
            this.ListBox_MissionList.Size = new System.Drawing.Size(132, 147);
            this.ListBox_MissionList.TabIndex = 3;
            this.ListBox_MissionList.SelectedIndexChanged += new System.EventHandler(this.ListBox_MissionList_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Button_StartAnalysis);
            this.Controls.Add(this.Button_MissionPathBrowser);
            this.Controls.Add(this.TextBox_MissionPath);
            this.Controls.Add(this.ListBox_MissionList);
            this.Controls.Add(this.DataGridView_ModelList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label_MissionPath);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_ModelList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_MissionPath;
        private System.Windows.Forms.DataGridView DataGridView_ModelList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBox_MissionPath;
        private System.Windows.Forms.Button Button_MissionPathBrowser;
        private System.Windows.Forms.Button Button_StartAnalysis;
        private System.Windows.Forms.ListBox ListBox_MissionList;
    }
}

