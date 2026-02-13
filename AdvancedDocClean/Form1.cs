using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Atalasoft.Imaging;
using Atalasoft.Imaging.ImageProcessing;
using Atalasoft.Imaging.ImageProcessing.Document;
using Atalasoft.Imaging.Codec;
using Atalasoft.Utils;
using Atalasoft.Utils.Geometry;
using WinDemoHelperMethods;

namespace AdvancedDocClean
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

		#region Processing Commands

		private Atalasoft.Imaging.ImageProcessing.Document.BinarizeCommand _autoBinarize;
		private Atalasoft.Imaging.ImageProcessing.Document.AutoBorderCropCommand _autoBorderCrop;
		private Atalasoft.Imaging.ImageProcessing.Document.AutoInvertTextCommand _autoInverseTextCorrection;
		private Atalasoft.Imaging.ImageProcessing.Document.AutoNegateCommand _autoNegate;
		private Atalasoft.Imaging.ImageProcessing.Document.BlankPageDetectionCommand _blankPageDetection;
		private Atalasoft.Imaging.ImageProcessing.Document.BlobRemovalCommand _blobRemoval;
		private Atalasoft.Imaging.ImageProcessing.Document.AdvancedBorderRemovalCommand _borderRemoval;
		private Atalasoft.Imaging.ImageProcessing.Document.HolePunchRemovalCommand _holePunchRemoval;
		private Atalasoft.Imaging.ImageProcessing.Document.LineRemovalCommand _lineRemoval;
		private Atalasoft.Imaging.ImageProcessing.Document.SpeckRemovalCommand _speckRemoval;
		private Atalasoft.Imaging.ImageProcessing.Document.MarginCropCommand _marginCrop;
		private Atalasoft.Imaging.ImageProcessing.Document.DocumentDespeckleCommand _despeckle;
		private Atalasoft.Imaging.ImageProcessing.Document.AutoDeskewCommand _deskew;
		private Atalasoft.Imaging.ImageProcessing.Document.HalftoneRemovalCommand _halftoneremoval;

		#endregion

		private bool _selectionMessageShown;
		private bool _watchSelection;

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListBox listCommands;
		private System.Windows.Forms.ComboBox cboFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelViewers;
		private Atalasoft.Imaging.WinControls.WorkspaceViewer wvOriginal;
		private Atalasoft.Imaging.WinControls.WorkspaceViewer wvProcessed;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuFileOpen;
		private System.Windows.Forms.MenuItem menuFileSave;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuProcess;
		private System.Windows.Forms.MenuItem menuProcessImage;
		private System.Windows.Forms.MenuItem menuProcessSelection;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Panel panelGrid;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.StatusBarPanel statusFilename;
		private System.Windows.Forms.StatusBarPanel statusImageSize;
		private System.Windows.Forms.StatusBarPanel statusDpi;
		private System.Windows.Forms.StatusBarPanel statusPixelFormat;
		private System.Windows.Forms.StatusBarPanel statusPosition;
		private System.Windows.Forms.StatusBarPanel statusTime;
		private System.Windows.Forms.StatusBarPanel statusInfo;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuHelpAbout;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//Ensure we list/support licensed types
			HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders);		
			this.openFileDialog1.Filter = HelperMethods.CreateDialogFilter(true);

			CreateCommands();
			this.cboFilter.SelectedIndex = 0;

			// This should point to the "DotImage x.x\Images\Documents" folder.
			this.openFileDialog1.FileName = System.IO.Path.GetFullPath(@"..\..\Images\Documents\HolePunchBorderRemovalDeskewSample.tif");
			if (!System.IO.File.Exists(this.openFileDialog1.FileName))
			{
				this.openFileDialog1.FileName = System.IO.Path.GetFullPath(@"..\..\..\..\..\Images\Documents\HolePunchBorderRemovalDeskewSample.tif");
				if (!System.IO.File.Exists(this.openFileDialog1.FileName))	
					this.openFileDialog1.FileName = "";
			}
		}

		private void CreateCommands()
		{
			_autoBinarize = new BinarizeCommand();
			_autoBorderCrop = new AutoBorderCropCommand();
			_autoInverseTextCorrection = new AutoInvertTextCommand();
			_autoNegate = new AutoNegateCommand();
			_blankPageDetection = new BlankPageDetectionCommand();
			_blobRemoval = new BlobRemovalCommand();
			_borderRemoval = new AdvancedBorderRemovalCommand();
			_holePunchRemoval = new HolePunchRemovalCommand();
			_lineRemoval = new LineRemovalCommand();
			_speckRemoval = new SpeckRemovalCommand();
			_marginCrop = new MarginCropCommand();
			_despeckle = new DocumentDespeckleCommand();
			_deskew = new AutoDeskewCommand();
			_halftoneremoval = new HalftoneRemovalCommand();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuFileOpen = new System.Windows.Forms.MenuItem();
			this.menuFileSave = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.menuProcess = new System.Windows.Forms.MenuItem();
			this.menuProcessImage = new System.Windows.Forms.MenuItem();
			this.menuProcessSelection = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.menuHelpAbout = new System.Windows.Forms.MenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panelGrid = new System.Windows.Forms.Panel();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.btnProcess = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.listCommands = new System.Windows.Forms.ListBox();
			this.cboFilter = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panelViewers = new System.Windows.Forms.Panel();
			this.wvProcessed = new Atalasoft.Imaging.WinControls.WorkspaceViewer();
			this.wvOriginal = new Atalasoft.Imaging.WinControls.WorkspaceViewer();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusFilename = new System.Windows.Forms.StatusBarPanel();
			this.statusImageSize = new System.Windows.Forms.StatusBarPanel();
			this.statusDpi = new System.Windows.Forms.StatusBarPanel();
			this.statusPixelFormat = new System.Windows.Forms.StatusBarPanel();
			this.statusPosition = new System.Windows.Forms.StatusBarPanel();
			this.statusTime = new System.Windows.Forms.StatusBarPanel();
			this.statusInfo = new System.Windows.Forms.StatusBarPanel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1.SuspendLayout();
			this.panelGrid.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panelViewers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusFilename)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusImageSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusDpi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusPixelFormat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusPosition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusInfo)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuFile,
																					  this.menuProcess,
																					  this.menuHelp});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFileOpen,
																					 this.menuFileSave,
																					 this.menuItem4,
																					 this.menuExit});
			this.menuFile.Text = "&File";
			// 
			// menuFileOpen
			// 
			this.menuFileOpen.Index = 0;
			this.menuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuFileOpen.Text = "&Open";
			this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
			// 
			// menuFileSave
			// 
			this.menuFileSave.Enabled = false;
			this.menuFileSave.Index = 1;
			this.menuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuFileSave.Text = "&Save Result...";
			this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// menuExit
			// 
			this.menuExit.Index = 3;
			this.menuExit.Text = "E&xit";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// menuProcess
			// 
			this.menuProcess.Enabled = false;
			this.menuProcess.Index = 1;
			this.menuProcess.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuProcessImage,
																						this.menuProcessSelection});
			this.menuProcess.Text = "&Process";
			// 
			// menuProcessImage
			// 
			this.menuProcessImage.Index = 0;
			this.menuProcessImage.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
			this.menuProcessImage.Text = "&Entire Image";
			this.menuProcessImage.Click += new System.EventHandler(this.menuProcessImage_Click);
			// 
			// menuProcessSelection
			// 
			this.menuProcessSelection.Index = 1;
			this.menuProcessSelection.Text = "&Selection...";
			this.menuProcessSelection.Click += new System.EventHandler(this.menuProcessSelection_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Index = 2;
			this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuHelpAbout});
			this.menuHelp.Text = "Help";
			// 
			// menuHelpAbout
			// 
			this.menuHelpAbout.Index = 0;
			this.menuHelpAbout.Text = "About";
			this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.panelGrid);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(216, 584);
			this.panel1.TabIndex = 0;
			// 
			// panelGrid
			// 
			this.panelGrid.Controls.Add(this.propertyGrid1);
			this.panelGrid.Controls.Add(this.btnProcess);
			this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelGrid.Location = new System.Drawing.Point(0, 271);
			this.panelGrid.Name = "panelGrid";
			this.panelGrid.Size = new System.Drawing.Size(212, 309);
			this.panelGrid.TabIndex = 4;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 35);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			this.propertyGrid1.Size = new System.Drawing.Size(212, 274);
			this.propertyGrid1.TabIndex = 1;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ToolbarVisible = false;
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// btnProcess
			// 
			this.btnProcess.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnProcess.Enabled = false;
			this.btnProcess.Location = new System.Drawing.Point(0, 0);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(212, 35);
			this.btnProcess.TabIndex = 0;
			this.btnProcess.Text = "Click Here To Process";
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.listCommands);
			this.panel2.Controls.Add(this.cboFilter);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(212, 271);
			this.panel2.TabIndex = 2;
			// 
			// listCommands
			// 
			this.listCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listCommands.IntegralHeight = false;
			this.listCommands.Location = new System.Drawing.Point(0, 42);
			this.listCommands.Name = "listCommands";
			this.listCommands.Size = new System.Drawing.Size(211, 228);
			this.listCommands.TabIndex = 2;
			this.listCommands.SelectedIndexChanged += new System.EventHandler(this.listCommands_SelectedIndexChanged);
			// 
			// cboFilter
			// 
			this.cboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFilter.Items.AddRange(new object[] {
														   "All",
														   "Feature Detection/Removal",
														   "Image Enhancement",
														   });
			this.cboFilter.Location = new System.Drawing.Point(48, 16);
			this.cboFilter.Name = "cboFilter";
			this.cboFilter.Size = new System.Drawing.Size(156, 21);
			this.cboFilter.Sorted = true;
			this.cboFilter.TabIndex = 0;
			this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Filters:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelViewers
			// 
			this.panelViewers.BackColor = System.Drawing.SystemColors.Control;
			this.panelViewers.Controls.Add(this.wvProcessed);
			this.panelViewers.Controls.Add(this.wvOriginal);
			this.panelViewers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelViewers.Location = new System.Drawing.Point(216, 0);
			this.panelViewers.Name = "panelViewers";
			this.panelViewers.Size = new System.Drawing.Size(672, 584);
			this.panelViewers.TabIndex = 1;
			this.panelViewers.Layout += new System.Windows.Forms.LayoutEventHandler(this.panelViewers_Layout);
			// 
			// wvProcessed
			// 
			this.wvProcessed.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.Full;
			this.wvProcessed.AutoZoom = Atalasoft.Imaging.WinControls.AutoZoomMode.BestFitShrinkOnly;
			this.wvProcessed.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.wvProcessed.Centered = true;
			this.wvProcessed.DisplayProfile = null;
			this.wvProcessed.Location = new System.Drawing.Point(377, 8);
			this.wvProcessed.Magnifier.BackColor = System.Drawing.Color.White;
			this.wvProcessed.Magnifier.BorderColor = System.Drawing.Color.Black;
			this.wvProcessed.Magnifier.Size = new System.Drawing.Size(100, 100);
			this.wvProcessed.Magnifier.Zoom = 2;
			this.wvProcessed.Name = "wvProcessed";
			this.wvProcessed.OutputProfile = null;
			this.wvProcessed.Selection = null;
			this.wvProcessed.Size = new System.Drawing.Size(292, 593);
			this.wvProcessed.TabIndex = 1;
			this.wvProcessed.Text = "workspaceViewer2";
			this.wvProcessed.MouseMovePixel += new System.Windows.Forms.MouseEventHandler(this.wvProcessed_MouseMovePixel);
			this.wvProcessed.Paint += new System.Windows.Forms.PaintEventHandler(this.wvProcessed_Paint);
			// 
			// wvOriginal
			// 
			this.wvOriginal.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.Full;
			this.wvOriginal.AutoZoom = Atalasoft.Imaging.WinControls.AutoZoomMode.BestFitShrinkOnly;
			this.wvOriginal.BackColor = System.Drawing.Color.DodgerBlue;
			this.wvOriginal.Centered = true;
			this.wvOriginal.DisplayProfile = null;
			this.wvOriginal.Location = new System.Drawing.Point(8, 9);
			this.wvOriginal.Magnifier.BackColor = System.Drawing.Color.White;
			this.wvOriginal.Magnifier.BorderColor = System.Drawing.Color.Black;
			this.wvOriginal.Magnifier.Size = new System.Drawing.Size(100, 100);
			this.wvOriginal.Magnifier.Zoom = 2;
			this.wvOriginal.Name = "wvOriginal";
			this.wvOriginal.OutputProfile = null;
			this.wvOriginal.Selection = null;
			this.wvOriginal.Size = new System.Drawing.Size(355, 588);
			this.wvOriginal.TabIndex = 0;
			this.wvOriginal.Text = "workspaceViewer1";
			this.wvOriginal.MouseMovePixel += new System.Windows.Forms.MouseEventHandler(this.wvProcessed_MouseMovePixel);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 584);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusFilename,
																						  this.statusImageSize,
																						  this.statusDpi,
																						  this.statusPixelFormat,
																						  this.statusPosition,
																						  this.statusTime,
																						  this.statusInfo});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(888, 22);
			this.statusBar1.TabIndex = 2;
			this.statusBar1.Text = "statusBar1";
			// 
			// statusFilename
			// 
			this.statusFilename.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusFilename.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusFilename.Text = "-";
			this.statusFilename.ToolTipText = "Filename";
			this.statusFilename.Width = 272;
			// 
			// statusImageSize
			// 
			this.statusImageSize.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusImageSize.Text = "-";
			this.statusImageSize.ToolTipText = "Image Size";
			// 
			// statusDpi
			// 
			this.statusDpi.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusDpi.Text = "-";
			this.statusDpi.ToolTipText = "Image Resolution";
			// 
			// statusPixelFormat
			// 
			this.statusPixelFormat.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusPixelFormat.Text = "-";
			this.statusPixelFormat.ToolTipText = "Pixel Format";
			// 
			// statusPosition
			// 
			this.statusPosition.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusPosition.Text = "-";
			this.statusPosition.ToolTipText = "Cursor Position";
			// 
			// statusTime
			// 
			this.statusTime.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusTime.Text = "-";
			this.statusTime.ToolTipText = "Processing Time";
			// 
			// statusInfo
			// 
			this.statusInfo.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Images|*.jpg;*.tif;*.png";
			// 
			// Form1
			// 
			this.AcceptButton = this.btnProcess;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(888, 606);
			this.Controls.Add(this.panelViewers);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusBar1);
			this.Menu = this.mainMenu1;
			this.MinimumSize = new System.Drawing.Size(400, 400);
			this.Name = "Form1";
			this.Text = "Atalasoft Advanced Document Cleanup Demo";
			this.panel1.ResumeLayout(false);
			this.panelGrid.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panelViewers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusFilename)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusImageSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusDpi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusPixelFormat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusPosition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusInfo)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			if (HelperMethods.HaveDotImage() && HelperMethods.HaveADC())
				Application.Run(new Form1());
		}

		private void cboFilter_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string[] items = null;

			switch (this.cboFilter.Text)
			{
				case "All":
					items = new string[] {
											"Automatic Document Negation",
											"Binary Segmentation",
											"Black Border Crop",
											"Blank Page Detection",
											"Blob Removal",
											"Border Removal",
											"Deskew",
											"Despeckle",
											"Halftone Removal",
											"Hole Punch Removal",
											"Inverted Text Correction",
											"Line Removal",
											"Speck Removal",
											"White Margin Crop",
											};
					break;
				case "Feature Detection/Removal":
					items = new string[] {
											 "Blank Page Detection",
											 "Blob Removal",
											"Border Removal",
											"Halftone Removal",
											"Hole Punch Removal",
											"Line Removal",
											"Speck Removal",
											 "White Margin Crop",
					};
					break;
				case "Image Enhancement":
					items = new string[] {
											 "Automatic Document Negation",
											 "Deskew",
											 "Despeckle",
											 "Inverted Text Correction",
					};
					break;
				case "Segmentation":
					items = new string[] {
											 "Binary Segmentation",
										};
					break;
			}

			this.listCommands.Items.Clear();
			this.listCommands.Items.AddRange(items);
		}

		private void panelViewers_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
		{
			// Make both viewers the same size.
			int w = (this.panelViewers.ClientSize.Width - 24) / 2;
			int h = this.panelViewers.ClientSize.Height - 24;

			this.wvOriginal.SetBounds(8, 8, w, h);
			this.wvProcessed.SetBounds(w + 16, 8, w, h);

			// Set the magnifier zoom.
			this.wvOriginal.Magnifier.Zoom = this.wvOriginal.Zoom * 4;
			this.wvProcessed.Magnifier.Zoom = this.wvOriginal.Zoom * 4;
		}

		private void listCommands_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (this.listCommands.Text)
			{
				case "Binary Segmentation":
					this.propertyGrid1.SelectedObject = this._autoBinarize;
					break;
				case "Black Border Crop":
					this.propertyGrid1.SelectedObject = this._autoBorderCrop;
					break;
				case "Inverted Text Correction":
					this.propertyGrid1.SelectedObject = this._autoInverseTextCorrection;
					break;
				case "Automatic Document Negation":
					this.propertyGrid1.SelectedObject = this._autoNegate;
					break;
				case "Blank Page Detection":
					this.propertyGrid1.SelectedObject = this._blankPageDetection;
					break;
				case "Blob Removal":
					this.propertyGrid1.SelectedObject = this._blobRemoval;
					break;
				case "Border Removal":
					this.propertyGrid1.SelectedObject = this._borderRemoval;
					break;
				case "Deskew":
					this.propertyGrid1.SelectedObject = this._deskew;
					break;
				case "Despeckle":
					this.propertyGrid1.SelectedObject = this._despeckle;
					break;
				case "Hole Punch Removal":
					this.propertyGrid1.SelectedObject = this._holePunchRemoval;
					break;
				case "White Margin Crop":
					this.propertyGrid1.SelectedObject = this._marginCrop;
					break;
				case "Line Removal":
					this.propertyGrid1.SelectedObject = this._lineRemoval;
					break;
				case "Speck Removal":
					this.propertyGrid1.SelectedObject = this._speckRemoval;
					break;
				case "Halftone Removal":
					this.propertyGrid1.SelectedObject = this._halftoneremoval;
					break;
			}

			EnableProcessing((this.listCommands.SelectedIndex != -1) && this.wvOriginal.Image != null);
		}

		private void EnableProcessing(bool enabled)
		{
			this.btnProcess.Enabled = enabled;
			this.menuProcess.Enabled = enabled;
		}

		private void menuFileOpen_Click(object sender, System.EventArgs e)
		{
			try
			{
				// try to locate images folder
				string imagesFolder = Application.ExecutablePath; //System.IO.Directory.GetCurrentDirectory();
				// we assume we are running under the DotImage install folder
				int pos = imagesFolder.IndexOf("DotImage ");
				if (pos != -1)
				{
					imagesFolder = imagesFolder.Substring(0,imagesFolder.IndexOf(@"\",pos)) + @"\Images\Documents";
				}

				//use this folder as starting point			
				this.openFileDialog1.InitialDirectory = imagesFolder;

				if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
				{
					this.wvProcessed.Images.Clear();
					this.wvProcessed.MouseTool = Atalasoft.Imaging.WinControls.MouseToolType.None;

					//is this a multiframe document?
					int frameCount = RegisteredDecoders.GetImageInfo(this.openFileDialog1.FileName).FrameCount;
					int frameNum = 0;

					// show all pages and let user pick
					if (frameCount > 1)
					{
						ThumbnailForm tf = new ThumbnailForm();
						tf.thumbnailView1.Items.Add(this.openFileDialog1.FileName, -1, "");
						if (tf.ShowDialog() != DialogResult.OK)
							return;
						frameNum = tf.thumbnailView1.SelectedIndices[0];
					}

					this.wvOriginal.Open(this.openFileDialog1.FileName, frameNum);
					Application.DoEvents();
					this.wvOriginal.MouseTool = Atalasoft.Imaging.WinControls.MouseToolType.Magnifier;

					this.statusFilename.Text = Path.GetFileName(this.openFileDialog1.FileName);
					this.statusImageSize.Text = this.wvOriginal.Image.Width.ToString() + ", " + this.wvOriginal.Image.Height.ToString();
					this.statusInfo.Text = "";
					this.statusPixelFormat.Text = this.wvOriginal.Image.PixelFormat.ToString();
					this.statusDpi.Text = this.wvOriginal.Image.Resolution.X.ToString() + ", " + this.wvOriginal.Image.Resolution.Y.ToString();
					this.statusTime.Text = "-";

					this.menuFileSave.Enabled = false;
					EnableProcessing(this.listCommands.SelectedIndex != -1);
					
					// Set the magnifier zoom.
					this.wvOriginal.Magnifier.Zoom = this.wvOriginal.Zoom * 4;
					this.wvProcessed.Magnifier.Zoom = this.wvOriginal.Zoom * 4;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.ToString(), "Exception");
			}
		}

		private void menuFileSave_Click(object sender, System.EventArgs e)
		{
			if (this.wvProcessed.Image == null) return;

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "TIFF (*.tif)|*.tif";

			try
			{
				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					Atalasoft.Imaging.Codec.TiffEncoder tif = new Atalasoft.Imaging.Codec.TiffEncoder(Atalasoft.Imaging.Codec.TiffCompression.Group4FaxEncoding, false);
					if (this.wvProcessed.Image.PixelFormat != PixelFormat.Pixel1bppIndexed)
						tif.Compression = Atalasoft.Imaging.Codec.TiffCompression.Lzw;
					
					this.wvProcessed.Save(dlg.FileName, tif);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.ToString(), "Exception");
			}
			finally
			{
				dlg.Dispose();
			}
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuProcessImage_Click(object sender, System.EventArgs e)
		{
			if (this.wvOriginal.Image == null || this.propertyGrid1.SelectedObject == null) return;

			this.wvProcessed.Images.Clear();
			this.wvProcessed.MouseTool = Atalasoft.Imaging.WinControls.MouseToolType.None;
			this.wvProcessed.Refresh();

			if (this._watchSelection)
			{
				this._watchSelection = false;
				
				Atalasoft.Imaging.ImageProcessing.ImageRegionCommand cmd = this.propertyGrid1.SelectedObject as Atalasoft.Imaging.ImageProcessing.ImageRegionCommand;
				if (cmd != null)
				{
					cmd.RegionOfInterest = new Atalasoft.Imaging.ImageProcessing.RegionOfInterest(this.wvOriginal.Selection.Bounds);
					ProcessCommand(cmd);
				}
				else
					ProcessCommand((Atalasoft.Imaging.ImageProcessing.ImageCommand)this.propertyGrid1.SelectedObject);
				
				this.wvOriginal.Selection.Visible = false;
				this.wvOriginal.MouseTool = Atalasoft.Imaging.WinControls.MouseToolType.Magnifier;
			}
			else
				ProcessCommand((Atalasoft.Imaging.ImageProcessing.ImageCommand)this.propertyGrid1.SelectedObject);
		}

		private void menuProcessSelection_Click(object sender, System.EventArgs e)
		{
			if (this.wvOriginal.Image == null || this.propertyGrid1.SelectedObject == null) return;

			this.wvProcessed.Images.Clear();

			if (!this._selectionMessageShown)
			{
				MessageBox.Show(this, "Use the mouse to select an area of the image the click the 'Process' button.", "Select Area", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this._selectionMessageShown = true;
			}

			this.wvOriginal.MouseTool = Atalasoft.Imaging.WinControls.MouseToolType.Selection;
			this._watchSelection = true;
		}

		private void ProcessCommand(Atalasoft.Imaging.ImageProcessing.ImageCommand cmd)
		{
			this.Cursor = Cursors.WaitCursor;
			int t1 = 0, t2 = 0;
			ImageResults icResults = null;
			this.statusInfo.Text = null;

			try
			{
				if (cmd.InPlaceProcessing)
				{
					AtalaImage img = (AtalaImage)this.wvOriginal.Image.Clone();
					t1 = System.Environment.TickCount;
					icResults = cmd.Apply(img);
					t2 = System.Environment.TickCount - t1;
					this.wvProcessed.Images.Add(img);
				}
				else
				{
					t1 = System.Environment.TickCount;
					icResults = cmd.Apply(this.wvOriginal.Image);
					AtalaImage img = icResults.Image;
					if (img != null)
						wvProcessed.Images.Add(img);
					t2 = System.Environment.TickCount - t1;
				}

				switch (cmd.GetType().Name)
				{
					case "BlankPageDetectionCommand":
						BlankPageDetectionResults bpdResults = (BlankPageDetectionResults)icResults;
						this.statusInfo.Text = (bpdResults.IsImageBlank ? "BLANK" : "NOT BLANK");
						break;
					case "AutoNegateCommand":
						AutoNegateResults anResults = (AutoNegateResults)icResults;
						this.statusInfo.Text = (anResults.IsInverted ? "INVERTED" : "NOT INVERTED");
						break;
					case "AutoDeskewCommand":
						AutoDeskewResults adResults = (AutoDeskewResults)icResults;
						this.statusInfo.Text = adResults.SkewAngle.ToString() + " deg";
						break;
				}

			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
			finally
			{
				this.Cursor = Cursors.Default;
				this.wvProcessed.MouseTool = Atalasoft.Imaging.WinControls.MouseToolType.Magnifier;
				this.statusTime.Text = t2.ToString() + " msec";
				this.menuFileSave.Enabled = true;
			}
		}

		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			this.menuProcessImage_Click(sender, e);
		}

		private void wvProcessed_MouseMovePixel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.statusPosition.Text = e.X.ToString() + ", " + e.Y.ToString();
		}

		private void menuHelpAbout_Click(object sender, System.EventArgs e)
		{
			AtalaDemos.AboutBox.About aboutBox = new AtalaDemos.AboutBox.About("About Atalasoft DotImage Advanced Document Cleanup Demo", "Advanced Document Cleanup Demo");
			aboutBox.Description = @"Demonstrates each of the Document Cleanup and processing commands available in the DotImage Advanced Document Cleanup Module.  Shows the before and after images side by side and provides access to each property of each available command.  Requires a license of DotImage Document Imaging and DotImage Advanced Document Cleanup to run the compiled demo.";
			aboutBox.ShowDialog();
		}

		private Pen GetRegionSpecificPen(int index)
		{
			return new Pen(_pal.GetEntry(index), 2.0f);
		}
		private Point GetScrolledPoint(PointF p, Point sp, double zoomX, double zoomY)
		{
			return new Point(sp.X + (int)(p.X * zoomX), sp.Y + (int)(p.Y * zoomY));
		}
		private Rectangle GetScrolledRectangle(Rectangle r, Point sp, double zoomX, double zoomY)
		{
			return new Rectangle(sp.X + (int)(r.Left * zoomX), sp.Y + (int)(r.Top * zoomY), (int)(r.Width * zoomX), (int)(r.Height * zoomY));
		}

		private Palette _pal = null;
//
		private void wvProcessed_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (this.wvProcessed.Image == null) return;
			Size controlSize = this.wvProcessed.ScrollSize;
			double zoomx = (double)controlSize.Width / (double)this.wvProcessed.Image.Size.Width;
			double zoomy = (double)controlSize.Height / (double)this.wvProcessed.Image.Size.Height;
			Point sp = wvProcessed.ScrollPosition;
			if (_pal == null)
				_pal = new Palette(PaletteType.WebExtended);

		}
	}
}
