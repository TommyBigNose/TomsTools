using System.ComponentModel.Design;
using TomsTools.Commands;
using TomsTools.General;
using TomsTools.Guids;

namespace TomsTools.App.Forms
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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

		public CommandManager CommandManager { get; }
		public IGuidGenerator GuidGenerator { get; }
		public IClipboardTool ClipboardTool { get; }

		public Form1(CommandManager commandManager, IGuidGenerator guidGenerator, IClipboardTool clipboardTool)
		{
			InitializeComponent();
			CommandManager = commandManager;
			GuidGenerator = guidGenerator;
			ClipboardTool = clipboardTool;

			//ICommand command = new GenerateGuidCommand(guidGenerator, clipboardTool);
			//commandManager.Invoke(command);
			//MessageBox.Show(command.ToString());
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnGenerateGuid = new System.Windows.Forms.Button();
			this.txtCommandHistory = new System.Windows.Forms.TextBox();
			this.lblCommandHistory = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnGenerateGuid
			// 
			this.btnGenerateGuid.Location = new System.Drawing.Point(12, 12);
			this.btnGenerateGuid.Name = "btnGenerateGuid";
			this.btnGenerateGuid.Size = new System.Drawing.Size(96, 23);
			this.btnGenerateGuid.TabIndex = 0;
			this.btnGenerateGuid.Text = "Generate Guid";
			this.btnGenerateGuid.UseVisualStyleBackColor = true;
			this.btnGenerateGuid.Click += new System.EventHandler(this.btnGenerateGuid_Click);
			// 
			// txtCommandHistory
			// 
			this.txtCommandHistory.Location = new System.Drawing.Point(446, 34);
			this.txtCommandHistory.Multiline = true;
			this.txtCommandHistory.Name = "txtCommandHistory";
			this.txtCommandHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtCommandHistory.Size = new System.Drawing.Size(342, 232);
			this.txtCommandHistory.TabIndex = 1;
			this.txtCommandHistory.WordWrap = false;
			// 
			// lblCommandHistory
			// 
			this.lblCommandHistory.AutoSize = true;
			this.lblCommandHistory.Location = new System.Drawing.Point(446, 16);
			this.lblCommandHistory.Name = "lblCommandHistory";
			this.lblCommandHistory.Size = new System.Drawing.Size(105, 15);
			this.lblCommandHistory.TabIndex = 2;
			this.lblCommandHistory.Text = "Command History";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lblCommandHistory);
			this.Controls.Add(this.txtCommandHistory);
			this.Controls.Add(this.btnGenerateGuid);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button btnGenerateGuid;
		private TextBox txtCommandHistory;
		private Label lblCommandHistory;
	}
}