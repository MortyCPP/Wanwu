namespace WindowsFormsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSendRequest;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.txtShow = new System.Windows.Forms.TextBox();
            this.txtAPIKey = new System.Windows.Forms.TextBox();
            this.APITitle = new System.Windows.Forms.TextBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.APIKeylink = new System.Windows.Forms.LinkLabel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtInput.Location = new System.Drawing.Point(12, 12);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(340, 50);
            this.txtInput.TabIndex = 0;
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSendRequest.Location = new System.Drawing.Point(12, 68);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(100, 30);
            this.btnSendRequest.TabIndex = 1;
            this.btnSendRequest.Text = "发送请求";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // txtShow
            // 
            this.txtShow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShow.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtShow.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtShow.Location = new System.Drawing.Point(12, 110);
            this.txtShow.Multiline = true;
            this.txtShow.Name = "txtShow";
            this.txtShow.ReadOnly = true;
            this.txtShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShow.Size = new System.Drawing.Size(640, 240);
            this.txtShow.TabIndex = 2;
            this.txtShow.TabStop = false;
            this.txtShow.Text = "响应将返回在此处";
            // 
            // txtAPIKey
            // 
            this.txtAPIKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAPIKey.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAPIKey.Location = new System.Drawing.Point(418, 27);
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Size = new System.Drawing.Size(234, 23);
            this.txtAPIKey.TabIndex = 3;
            // 
            // APITitle
            // 
            this.APITitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.APITitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.APITitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.APITitle.Location = new System.Drawing.Point(359, 29);
            this.APITitle.Name = "APITitle";
            this.APITitle.ReadOnly = true;
            this.APITitle.Size = new System.Drawing.Size(53, 16);
            this.APITitle.TabIndex = 4;
            this.APITitle.TabStop = false;
            this.APITitle.Text = "API Key：";
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSettings.Location = new System.Drawing.Point(425, 68);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(85, 30);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "设置API Key";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(560, 68);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 30);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "重置Key";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // APIKeylink
            // 
            this.APIKeylink.AutoSize = true;
            this.APIKeylink.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.APIKeylink.Location = new System.Drawing.Point(552, 5);
            this.APIKeylink.Name = "APIKeylink";
            this.APIKeylink.Size = new System.Drawing.Size(100, 17);
            this.APIKeylink.TabIndex = 7;
            this.APIKeylink.TabStop = true;
            this.APIKeylink.Text = "点击获取API Key";
            this.APIKeylink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.APIKeylink_LinkClicked);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.Transparent;
            this.btnCopy.BackgroundImage = global::Wanwu.Properties.Resources.CopyImg;
            this.btnCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btnCopy.ForeColor = System.Drawing.Color.Black;
            this.btnCopy.Location = new System.Drawing.Point(600, 112);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(32, 32);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.TabStop = false;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Visible = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(664, 361);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.APIKeylink);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.APITitle);
            this.Controls.Add(this.txtAPIKey);
            this.Controls.Add(this.txtShow);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.txtInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "万物AI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.TextBox txtAPIKey;
        private System.Windows.Forms.TextBox APITitle;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.LinkLabel APIKeylink;
        private System.Windows.Forms.Button btnCopy;
    }
}
