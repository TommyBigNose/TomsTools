using TomsTools.Commands;
using TomsTools.Formatters;
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
		public IClipboardTool ClipboardTool { get; }
		public IGuidGenerator GuidGenerator { get; }
		public IStringReplacer StringReplacer { get; }
		public IEnumerable<IStringFormatter> StringFormatters { get; }
		
		public Form1(CommandManager commandManager, IClipboardTool clipboardTool, IGuidGenerator guidGenerator, IStringReplacer stringReplacer, IEnumerable<IStringFormatter> stringFormatters)
		{
			InitializeComponent();
			CommandManager = commandManager;
			ClipboardTool = clipboardTool;
			GuidGenerator = guidGenerator;
			StringReplacer = stringReplacer;
			StringFormatters = stringFormatters;
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.btnGenerateGuid = new System.Windows.Forms.Button();
			this.txtCommandHistory = new System.Windows.Forms.TextBox();
			this.lblCommandHistory = new System.Windows.Forms.Label();
			this.btnFormatJson = new System.Windows.Forms.Button();
			this.btnReplace = new System.Windows.Forms.Button();
			this.txtReplaceOld = new System.Windows.Forms.TextBox();
			this.txtReplaceNew = new System.Windows.Forms.TextBox();
			this.lblWith = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnGenerateGuid
			// 
			this.btnGenerateGuid.Location = new System.Drawing.Point(12, 12);
			this.btnGenerateGuid.Name = "btnGenerateGuid";
			this.btnGenerateGuid.Size = new System.Drawing.Size(100, 23);
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
			// btnFormatJson
			// 
			this.btnFormatJson.Location = new System.Drawing.Point(12, 41);
			this.btnFormatJson.Name = "btnFormatJson";
			this.btnFormatJson.Size = new System.Drawing.Size(100, 23);
			this.btnFormatJson.TabIndex = 3;
			this.btnFormatJson.Text = "Format JSON";
			this.btnFormatJson.UseVisualStyleBackColor = true;
			this.btnFormatJson.Click += new System.EventHandler(this.btnFormatJson_Click);
			// 
			// btnReplace
			// 
			this.btnReplace.Location = new System.Drawing.Point(12, 71);
			this.btnReplace.Name = "btnReplace";
			this.btnReplace.Size = new System.Drawing.Size(100, 23);
			this.btnReplace.TabIndex = 4;
			this.btnReplace.Text = "Replace";
			this.btnReplace.UseVisualStyleBackColor = true;
			this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
			// 
			// txtReplaceOld
			// 
			this.txtReplaceOld.Location = new System.Drawing.Point(118, 71);
			this.txtReplaceOld.Name = "txtReplaceOld";
			this.txtReplaceOld.PlaceholderText = "Old Character";
			this.txtReplaceOld.Size = new System.Drawing.Size(100, 23);
			this.txtReplaceOld.TabIndex = 5;
			// 
			// txtReplaceNew
			// 
			this.txtReplaceNew.Location = new System.Drawing.Point(269, 71);
			this.txtReplaceNew.Name = "txtReplaceNew";
			this.txtReplaceNew.PlaceholderText = "New Character";
			this.txtReplaceNew.Size = new System.Drawing.Size(100, 23);
			this.txtReplaceNew.TabIndex = 6;
			// 
			// lblWith
			// 
			this.lblWith.AutoSize = true;
			this.lblWith.Location = new System.Drawing.Point(224, 75);
			this.lblWith.Name = "lblWith";
			this.lblWith.Size = new System.Drawing.Size(39, 15);
			this.lblWith.TabIndex = 7;
			this.lblWith.Text = "with...";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lblWith);
			this.Controls.Add(this.txtReplaceNew);
			this.Controls.Add(this.txtReplaceOld);
			this.Controls.Add(this.btnReplace);
			this.Controls.Add(this.btnFormatJson);
			this.Controls.Add(this.lblCommandHistory);
			this.Controls.Add(this.txtCommandHistory);
			this.Controls.Add(this.btnGenerateGuid);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Tom\'s Tools";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button btnGenerateGuid;
		private TextBox txtCommandHistory;
		private Label lblCommandHistory;
		private Button btnFormatJson;
		private Button btnReplace;
		private TextBox txtReplaceOld;
		private TextBox txtReplaceNew;
		private Label lblWith;
	}
}