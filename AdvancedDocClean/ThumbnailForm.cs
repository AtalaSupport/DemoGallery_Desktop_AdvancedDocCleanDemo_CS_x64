using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedDocClean
{
	/// <summary>
	/// Summary description for ThumbnailForm.
	/// </summary>
	public class ThumbnailForm : System.Windows.Forms.Form
	{
		public Atalasoft.Imaging.WinControls.ThumbnailView thumbnailView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ThumbnailForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.thumbnailView1 = new Atalasoft.Imaging.WinControls.ThumbnailView();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// thumbnailView1
			// 
			this.thumbnailView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.thumbnailView1.BackColor = System.Drawing.Color.Silver;
			this.thumbnailView1.DragSelectionColor = System.Drawing.Color.Red;
			this.thumbnailView1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.thumbnailView1.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
			this.thumbnailView1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
			this.thumbnailView1.LoadErrorMessage = "";
			this.thumbnailView1.Location = new System.Drawing.Point(8, 32);
			this.thumbnailView1.Margins = new Atalasoft.Imaging.WinControls.Margin(4, 4, 4, 4);
			this.thumbnailView1.Name = "thumbnailView1";
			this.thumbnailView1.SelectedItemStyle = Atalasoft.Imaging.WinControls.SelectedItemRenderStyle.Extended;
			this.thumbnailView1.SelectionRectangleBackColor = System.Drawing.Color.Transparent;
			this.thumbnailView1.SelectionRectangleDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.thumbnailView1.SelectionRectangleLineColor = System.Drawing.Color.Black;
			this.thumbnailView1.Size = new System.Drawing.Size(424, 400);
			this.thumbnailView1.TabIndex = 0;
			this.thumbnailView1.Text = "thumbnailView1";
			this.thumbnailView1.ThumbnailBackground = null;
			this.thumbnailView1.ThumbnailOffset = new System.Drawing.Point(0, 0);
			this.thumbnailView1.ThumbnailSize = new System.Drawing.Size(120, 120);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(244, 448);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(71, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "OK";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Please Select a frame Index to Open:";
			// 
			// ThumbnailForm
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 478);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.thumbnailView1);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ThumbnailForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Open Multipage Image";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
