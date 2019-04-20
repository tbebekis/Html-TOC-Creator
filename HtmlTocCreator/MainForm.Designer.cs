namespace HtmlTocCreator
{
    partial class MainForm
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
            this.Pager = new System.Windows.Forms.TabControl();
            this.tabInput = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.edtInput = new System.Windows.Forms.TextBox();
            this.tv = new System.Windows.Forms.TreeView();
            this.tabBrowser = new System.Windows.Forms.TabPage();
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.edtOutput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExecute = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chUnorderedLists = new System.Windows.Forms.CheckBox();
            this.Pager.SuspendLayout();
            this.tabInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabBrowser.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pager
            // 
            this.Pager.Controls.Add(this.tabInput);
            this.Pager.Controls.Add(this.tabBrowser);
            this.Pager.Controls.Add(this.tabOutput);
            this.Pager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pager.Location = new System.Drawing.Point(0, 0);
            this.Pager.Name = "Pager";
            this.Pager.SelectedIndex = 0;
            this.Pager.Size = new System.Drawing.Size(1008, 697);
            this.Pager.TabIndex = 3;
            // 
            // tabInput
            // 
            this.tabInput.Controls.Add(this.splitContainer1);
            this.tabInput.Location = new System.Drawing.Point(4, 22);
            this.tabInput.Name = "tabInput";
            this.tabInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabInput.Size = new System.Drawing.Size(1000, 671);
            this.tabInput.TabIndex = 0;
            this.tabInput.Text = "Input";
            this.tabInput.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.edtInput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tv);
            this.splitContainer1.Size = new System.Drawing.Size(994, 665);
            this.splitContainer1.SplitterDistance = 686;
            this.splitContainer1.TabIndex = 0;
            // 
            // edtInput
            // 
            this.edtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtInput.Font = new System.Drawing.Font("Courier New", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtInput.Location = new System.Drawing.Point(0, 0);
            this.edtInput.Multiline = true;
            this.edtInput.Name = "edtInput";
            this.edtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edtInput.Size = new System.Drawing.Size(686, 665);
            this.edtInput.TabIndex = 1;
            this.edtInput.Text = "<div id=\'TOC\'></div>\r\n<h1>1</h1>\r\n\t<h2>1.1</h2>\r\n<h1>2</h1>\r\n\t<h2>2.1</h2>\r\n\t\t<h3" +
    ">2.1.1</h3>\r\n\t<h2>2.2</h2>\r\n<h1>3</h1>\r\n\t<h2>3.1</h2>";
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(304, 665);
            this.tv.TabIndex = 3;
            // 
            // tabBrowser
            // 
            this.tabBrowser.Controls.Add(this.Browser);
            this.tabBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabBrowser.Name = "tabBrowser";
            this.tabBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tabBrowser.Size = new System.Drawing.Size(971, 663);
            this.tabBrowser.TabIndex = 1;
            this.tabBrowser.Text = "Browser";
            this.tabBrowser.UseVisualStyleBackColor = true;
            // 
            // Browser
            // 
            this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browser.Location = new System.Drawing.Point(3, 3);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(965, 657);
            this.Browser.TabIndex = 0;
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.edtOutput);
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Size = new System.Drawing.Size(971, 663);
            this.tabOutput.TabIndex = 2;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // edtOutput
            // 
            this.edtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtOutput.Font = new System.Drawing.Font("Courier New", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtOutput.Location = new System.Drawing.Point(0, 0);
            this.edtOutput.Multiline = true;
            this.edtOutput.Name = "edtOutput";
            this.edtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edtOutput.Size = new System.Drawing.Size(971, 663);
            this.edtOutput.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chUnorderedLists);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnExecute);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnSaveToFile);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnLoadFromFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 32);
            this.panel1.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(318, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(18, 32);
            this.panel4.TabIndex = 14;
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExecute.Location = new System.Drawing.Point(218, 0);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(100, 32);
            this.btnExecute.TabIndex = 13;
            this.btnExecute.Text = "Generate TOC";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(200, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(18, 32);
            this.panel5.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(890, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 32);
            this.panel3.TabIndex = 11;
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaveToFile.Location = new System.Drawing.Point(100, 0);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(100, 32);
            this.btnSaveToFile.TabIndex = 2;
            this.btnSaveToFile.Text = "Save to File";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Location = new System.Drawing.Point(908, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 32);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoadFromFile.Location = new System.Drawing.Point(0, 0);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(100, 32);
            this.btnLoadFromFile.TabIndex = 0;
            this.btnLoadFromFile.Text = "Load from File";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Pager);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 697);
            this.panel2.TabIndex = 5;
            // 
            // chUnorderedLists
            // 
            this.chUnorderedLists.AutoSize = true;
            this.chUnorderedLists.Checked = true;
            this.chUnorderedLists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chUnorderedLists.Location = new System.Drawing.Point(342, 9);
            this.chUnorderedLists.Name = "chUnorderedLists";
            this.chUnorderedLists.Size = new System.Drawing.Size(103, 17);
            this.chUnorderedLists.TabIndex = 15;
            this.chUnorderedLists.Text = "Un-ordered Lists";
            this.chUnorderedLists.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Html TOC Generator";
            this.Pager.ResumeLayout(false);
            this.tabInput.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabBrowser.ResumeLayout(false);
            this.tabOutput.ResumeLayout(false);
            this.tabOutput.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl Pager;
        private System.Windows.Forms.TabPage tabInput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabBrowser;
        private System.Windows.Forms.TextBox edtInput;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser Browser;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.TextBox edtOutput;
        private System.Windows.Forms.CheckBox chUnorderedLists;
    }
}

