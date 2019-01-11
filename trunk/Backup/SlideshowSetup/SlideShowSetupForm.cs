using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using TSOP;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class SlideShowSetupForm : System.Windows.Forms.Form, ISlideShowForm
	{

		#region Windows Form Designer generated code

		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.ListView _listViewScripts;
		private System.Windows.Forms.ColumnHeader ScriptFileName;
		private System.Windows.Forms.ListView _listViewImages;
		private System.Windows.Forms.ColumnHeader FileName;
		private System.Windows.Forms.ColumnHeader FilePath;
		private System.Windows.Forms.GroupBox _groupScripts;
		private System.Windows.Forms.Button _buttonScriptAdd;
		private System.Windows.Forms.MainMenu _menuMain;
		private System.Windows.Forms.StatusBar _statusBar;
		private System.Windows.Forms.ToolBar _toolBar;
		private System.Windows.Forms.ToolBarButton toolBarButtonNew;
		private System.Windows.Forms.ToolBarButton toolBarButtonOpen;
		private System.Windows.Forms.ToolBarButton toolBarButtonSave;
		private System.Windows.Forms.ColumnHeader IncludeFlag;
		private System.Windows.Forms.ColumnHeader Keywords;
		private System.Windows.Forms.ColumnHeader DisplayTextFlag;
		private System.Windows.Forms.MenuItem _menuItemFile;
		private System.Windows.Forms.MenuItem _menuItemFile_New;
		private System.Windows.Forms.MenuItem _menuItemFile_Open;
		private System.Windows.Forms.MenuItem _menuItemFile_Close;
		private System.Windows.Forms.MenuItem _menuItemFile_Save;
		private System.Windows.Forms.MenuItem _menuItemFile_SaveAs;
		private System.Windows.Forms.MenuItem _menuItemFile_SaveToRegistry;
		private System.Windows.Forms.MenuItem _menuItemFile_Recent;
		private System.Windows.Forms.MenuItem _menuItemView;
		private System.Windows.Forms.MenuItem _menuItemTools;
		private System.Windows.Forms.MenuItem _menuItemTools_Options;
		private System.Windows.Forms.MenuItem _menuItemHelp;
		private System.Windows.Forms.MenuItem _menuItemHelp_Help;
		private System.Windows.Forms.MenuItem _menuItemHelp_About;
		private System.Windows.Forms.ColumnHeader StretchFlag;
		private System.Windows.Forms.ContextMenu _menuImagesContext;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem _mnuItemCtxtStretch;
		private System.Windows.Forms.MenuItem _mnuItemCtxtStretchNone;
		private System.Windows.Forms.MenuItem _mnuItemCtxtStretchKAR;
		private System.Windows.Forms.MenuItem _mnuItemCtxtStretchToFit;
		private System.Windows.Forms.MenuItem _mnuItemCtxtStretchScale;
		private System.Windows.Forms.MenuItem _mnuItemCtxtStretchDefault;
		private System.Windows.Forms.MenuItem _mnuItemCtxtOffset;
		private System.Windows.Forms.MenuItem _mnuItemCtxtDispTxt;
		private System.Windows.Forms.MenuItem _mnuItemCtxtDispTxtYes;
		private System.Windows.Forms.MenuItem _mnuItemCtxtDispTxtNo;
		private System.Windows.Forms.MenuItem _mnuItemCtxtDispTxtDefault;
		private System.Windows.Forms.MenuItem _mnuItemCtxtInclude;
		private System.Windows.Forms.MenuItem _mnuItemCtxtIncludeInclude;
		private System.Windows.Forms.MenuItem _mnuItemCtxtIncludeExclude;
		private System.Windows.Forms.MenuItem _mnuItemCtxtIncludeClear;
		private System.Windows.Forms.MenuItem _mnuItemCtxtEditKW;
		private System.Windows.Forms.MenuItem _mnuItemCtxtAddKW;
		private System.Windows.Forms.ColumnHeader CreateDate;
		private System.Windows.Forms.MenuItem _mnuItemCtxtRemoveKW;
		private System.Windows.Forms.ToolBarButton toolBarButtonPreview;
		private System.Windows.Forms.MenuItem menuItemFile_LoadRegistry;
		private System.Windows.Forms.ColumnHeader Offset;
		private System.Windows.Forms.ColumnHeader ModifyDate;
		private System.Windows.Forms.ColumnHeader ScaleFactor;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem _menuItemFile_Add;
		private System.Windows.Forms.MenuItem _menuItemFile_Add_Search;
		private System.Windows.Forms.MenuItem _menuItemFile_Add_File;
		private System.Windows.Forms.MenuItem _menuItemFile_Remove;
		private System.Windows.Forms.MenuItem _menuItemTools_Options_Remember;
        private System.Windows.Forms.MenuItem _menuItemTools_Options_ThumbnailData;
        private BackgroundWorker backgroundWorkerLoad;
        private ProgressBar progressBarStatus;
        private MenuItem _menuItemFile_Add_SearchRecursive;
        private StatusBarPanel statusBarPanelProgress;
        private StatusBarPanel statusBarPanelInfo;
        private Label _lblImageCount;
        private Button _btnScriptRemove;
        private Button _btnScriptNew;
        private Button _btnScriptDelete;
        private Button _btnScriptSaveAs;
        private Button _btnScriptSave;
        private Label _lblStatusMessage;
        private NumericUpDown _txtSlideDuration;
        private Label _lblSlideDuration;
        private GroupBox _grpDefaultSettings;
        private CheckBox _chkDefaultShowInfo;
        private CheckBox _chkDefaultShowText;
        private BindingSource slideShowSetupFormBindingSource;
        private ComboBox _cboDefaultStretch;
        private Label _lblDefaultStretch;
        private CheckBox _chkMouseWakeUp;
        private CheckBox _chkRandom;
        private BindingSource configFileBindingSource;
        private ToolBarButton toolBarButtonScan;
        private MenuItem menuItem2;
        private MenuItem _mnuItemCtxtCopy;
        private MenuItem _mnuItemCtxtMove;
        private MenuItem _mnuItemCtxtDelete;
        private IContainer components;
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this._menuMain = new System.Windows.Forms.MainMenu(this.components);
            this._menuItemFile = new System.Windows.Forms.MenuItem();
            this._menuItemFile_New = new System.Windows.Forms.MenuItem();
            this._menuItemFile_Open = new System.Windows.Forms.MenuItem();
            this.menuItemFile_LoadRegistry = new System.Windows.Forms.MenuItem();
            this._menuItemFile_Close = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this._menuItemFile_Add = new System.Windows.Forms.MenuItem();
            this._menuItemFile_Add_Search = new System.Windows.Forms.MenuItem();
            this._menuItemFile_Add_SearchRecursive = new System.Windows.Forms.MenuItem();
            this._menuItemFile_Add_File = new System.Windows.Forms.MenuItem();
            this._menuItemFile_Remove = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this._menuItemFile_Save = new System.Windows.Forms.MenuItem();
            this._menuItemFile_SaveAs = new System.Windows.Forms.MenuItem();
            this._menuItemFile_SaveToRegistry = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this._menuItemFile_Recent = new System.Windows.Forms.MenuItem();
            this._menuItemView = new System.Windows.Forms.MenuItem();
            this._menuItemTools = new System.Windows.Forms.MenuItem();
            this._menuItemTools_Options = new System.Windows.Forms.MenuItem();
            this._menuItemTools_Options_Remember = new System.Windows.Forms.MenuItem();
            this._menuItemTools_Options_ThumbnailData = new System.Windows.Forms.MenuItem();
            this._menuItemHelp = new System.Windows.Forms.MenuItem();
            this._menuItemHelp_Help = new System.Windows.Forms.MenuItem();
            this._menuItemHelp_About = new System.Windows.Forms.MenuItem();
            this._listViewScripts = new System.Windows.Forms.ListView();
            this.ScriptFileName = new System.Windows.Forms.ColumnHeader();
            this._listViewImages = new System.Windows.Forms.ListView();
            this.IncludeFlag = new System.Windows.Forms.ColumnHeader();
            this.FileName = new System.Windows.Forms.ColumnHeader();
            this.Keywords = new System.Windows.Forms.ColumnHeader();
            this.FilePath = new System.Windows.Forms.ColumnHeader();
            this.StretchFlag = new System.Windows.Forms.ColumnHeader();
            this.DisplayTextFlag = new System.Windows.Forms.ColumnHeader();
            this.Offset = new System.Windows.Forms.ColumnHeader();
            this.ScaleFactor = new System.Windows.Forms.ColumnHeader();
            this.CreateDate = new System.Windows.Forms.ColumnHeader();
            this.ModifyDate = new System.Windows.Forms.ColumnHeader();
            this._menuImagesContext = new System.Windows.Forms.ContextMenu();
            this._mnuItemCtxtStretch = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtStretchNone = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtStretchKAR = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtStretchToFit = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtStretchScale = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtStretchDefault = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtOffset = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtDispTxt = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtDispTxtYes = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtDispTxtNo = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtDispTxtDefault = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtInclude = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtIncludeInclude = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtIncludeExclude = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtIncludeClear = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtEditKW = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtAddKW = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtRemoveKW = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtCopy = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtMove = new System.Windows.Forms.MenuItem();
            this._mnuItemCtxtDelete = new System.Windows.Forms.MenuItem();
            this._groupScripts = new System.Windows.Forms.GroupBox();
            this._btnScriptSaveAs = new System.Windows.Forms.Button();
            this._btnScriptSave = new System.Windows.Forms.Button();
            this._btnScriptNew = new System.Windows.Forms.Button();
            this._btnScriptDelete = new System.Windows.Forms.Button();
            this._btnScriptRemove = new System.Windows.Forms.Button();
            this._buttonScriptAdd = new System.Windows.Forms.Button();
            this._statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanelProgress = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelInfo = new System.Windows.Forms.StatusBarPanel();
            this._toolBar = new System.Windows.Forms.ToolBar();
            this.toolBarButtonNew = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonOpen = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonSave = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonPreview = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonScan = new System.Windows.Forms.ToolBarButton();
            this.backgroundWorkerLoad = new System.ComponentModel.BackgroundWorker();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this._lblImageCount = new System.Windows.Forms.Label();
            this._lblStatusMessage = new System.Windows.Forms.Label();
            this._txtSlideDuration = new System.Windows.Forms.NumericUpDown();
            this._lblSlideDuration = new System.Windows.Forms.Label();
            this._grpDefaultSettings = new System.Windows.Forms.GroupBox();
            this._chkMouseWakeUp = new System.Windows.Forms.CheckBox();
            this._chkRandom = new System.Windows.Forms.CheckBox();
            this._lblDefaultStretch = new System.Windows.Forms.Label();
            this._cboDefaultStretch = new System.Windows.Forms.ComboBox();
            this._chkDefaultShowInfo = new System.Windows.Forms.CheckBox();
            this._chkDefaultShowText = new System.Windows.Forms.CheckBox();
            this.configFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.slideShowSetupFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._groupScripts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._txtSlideDuration)).BeginInit();
            this._grpDefaultSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configFileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideShowSetupFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _menuMain
            // 
            this._menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFile,
            this._menuItemView,
            this._menuItemTools,
            this._menuItemHelp});
            // 
            // _menuItemFile
            // 
            this._menuItemFile.Index = 0;
            this._menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFile_New,
            this._menuItemFile_Open,
            this.menuItemFile_LoadRegistry,
            this._menuItemFile_Close,
            this.menuItem11,
            this._menuItemFile_Add,
            this._menuItemFile_Remove,
            this.menuItem1,
            this._menuItemFile_Save,
            this._menuItemFile_SaveAs,
            this._menuItemFile_SaveToRegistry,
            this.menuItem13,
            this._menuItemFile_Recent});
            this._menuItemFile.Text = "File";
            // 
            // _menuItemFile_New
            // 
            this._menuItemFile_New.Index = 0;
            this._menuItemFile_New.Text = "New";
            this._menuItemFile_New.Click += new System.EventHandler(this._menuItemFile_New_Click);
            // 
            // _menuItemFile_Open
            // 
            this._menuItemFile_Open.Index = 1;
            this._menuItemFile_Open.Text = "Open";
            this._menuItemFile_Open.Click += new System.EventHandler(this._menuItemFile_Open_Click);
            // 
            // menuItemFile_LoadRegistry
            // 
            this.menuItemFile_LoadRegistry.Index = 2;
            this.menuItemFile_LoadRegistry.Text = "LoadRegistry";
            this.menuItemFile_LoadRegistry.Click += new System.EventHandler(this.menuItemFile_LoadRegistry_Click);
            // 
            // _menuItemFile_Close
            // 
            this._menuItemFile_Close.Index = 3;
            this._menuItemFile_Close.Text = "Close";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 4;
            this.menuItem11.Text = "-";
            // 
            // _menuItemFile_Add
            // 
            this._menuItemFile_Add.Index = 5;
            this._menuItemFile_Add.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFile_Add_Search,
            this._menuItemFile_Add_SearchRecursive,
            this._menuItemFile_Add_File});
            this._menuItemFile_Add.Text = "Add Image Files";
            // 
            // _menuItemFile_Add_Search
            // 
            this._menuItemFile_Add_Search.Index = 0;
            this._menuItemFile_Add_Search.Text = "By Searching Computer...";
            this._menuItemFile_Add_Search.Click += new System.EventHandler(this._menuItemFile_Add_Search_Click);
            // 
            // _menuItemFile_Add_SearchRecursive
            // 
            this._menuItemFile_Add_SearchRecursive.Index = 1;
            this._menuItemFile_Add_SearchRecursive.Text = "By Searching Recursive...";
            this._menuItemFile_Add_SearchRecursive.Click += new System.EventHandler(this._menuItemFile_Add_SearchRecursive_Click);
            // 
            // _menuItemFile_Add_File
            // 
            this._menuItemFile_Add_File.Index = 2;
            this._menuItemFile_Add_File.Text = "Add File(s)...";
            this._menuItemFile_Add_File.Click += new System.EventHandler(this._menuItemFile_Add_File_Click);
            // 
            // _menuItemFile_Remove
            // 
            this._menuItemFile_Remove.Index = 6;
            this._menuItemFile_Remove.Text = "Remove Files";
            this._menuItemFile_Remove.Click += new System.EventHandler(this._menuItemFile_Remove_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 7;
            this.menuItem1.Text = "-";
            // 
            // _menuItemFile_Save
            // 
            this._menuItemFile_Save.Index = 8;
            this._menuItemFile_Save.Text = "Save";
            this._menuItemFile_Save.Click += new System.EventHandler(this._menuItemFile_Save_Click);
            // 
            // _menuItemFile_SaveAs
            // 
            this._menuItemFile_SaveAs.Index = 9;
            this._menuItemFile_SaveAs.Text = "SaveAs...";
            this._menuItemFile_SaveAs.Click += new System.EventHandler(this._menuItemFile_SaveAs_Click);
            // 
            // _menuItemFile_SaveToRegistry
            // 
            this._menuItemFile_SaveToRegistry.Index = 10;
            this._menuItemFile_SaveToRegistry.Text = "SaveToRegistry";
            this._menuItemFile_SaveToRegistry.Click += new System.EventHandler(this._menuItemFile_SaveToRegistry_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 11;
            this.menuItem13.Text = "-";
            // 
            // _menuItemFile_Recent
            // 
            this._menuItemFile_Recent.Index = 12;
            this._menuItemFile_Recent.Text = "Recent Files";
            // 
            // _menuItemView
            // 
            this._menuItemView.Index = 1;
            this._menuItemView.Text = "View";
            // 
            // _menuItemTools
            // 
            this._menuItemTools.Index = 2;
            this._menuItemTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemTools_Options});
            this._menuItemTools.Text = "Tools";
            // 
            // _menuItemTools_Options
            // 
            this._menuItemTools_Options.Index = 0;
            this._menuItemTools_Options.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemTools_Options_Remember,
            this._menuItemTools_Options_ThumbnailData});
            this._menuItemTools_Options.Text = "Options...";
            // 
            // _menuItemTools_Options_Remember
            // 
            this._menuItemTools_Options_Remember.Checked = true;
            this._menuItemTools_Options_Remember.Index = 0;
            this._menuItemTools_Options_Remember.Text = "Remember Folders";
            this._menuItemTools_Options_Remember.Click += new System.EventHandler(this._menuItemTools_Options_Remember_Click);
            // 
            // _menuItemTools_Options_ThumbnailData
            // 
            this._menuItemTools_Options_ThumbnailData.Checked = true;
            this._menuItemTools_Options_ThumbnailData.Index = 1;
            this._menuItemTools_Options_ThumbnailData.Text = "Load Thumbnail Data";
            this._menuItemTools_Options_ThumbnailData.Click += new System.EventHandler(this._menuItemTools_Options_ThumbnailData_Click);
            // 
            // _menuItemHelp
            // 
            this._menuItemHelp.Index = 3;
            this._menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemHelp_Help,
            this._menuItemHelp_About});
            this._menuItemHelp.Text = "Help";
            // 
            // _menuItemHelp_Help
            // 
            this._menuItemHelp_Help.Index = 0;
            this._menuItemHelp_Help.Text = "SlideShow.Net Help";
            // 
            // _menuItemHelp_About
            // 
            this._menuItemHelp_About.Index = 1;
            this._menuItemHelp_About.Text = "About SlideShow.Net";
            this._menuItemHelp_About.Click += new System.EventHandler(this._menuItemHelp_About_Click);
            // 
            // _listViewScripts
            // 
            this._listViewScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._listViewScripts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this._listViewScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ScriptFileName});
            this._listViewScripts.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._listViewScripts.ForeColor = System.Drawing.Color.MidnightBlue;
            this._listViewScripts.FullRowSelect = true;
            this._listViewScripts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this._listViewScripts.Location = new System.Drawing.Point(123, 16);
            this._listViewScripts.Name = "_listViewScripts";
            this._listViewScripts.Size = new System.Drawing.Size(527, 68);
            this._listViewScripts.TabIndex = 16;
            this._listViewScripts.UseCompatibleStateImageBehavior = false;
            this._listViewScripts.View = System.Windows.Forms.View.Details;
            this._listViewScripts.SelectedIndexChanged += new System.EventHandler(this._listViewScripts_SelectedIndexChanged);
            // 
            // ScriptFileName
            // 
            this.ScriptFileName.Text = "ScriptFileName";
            this.ScriptFileName.Width = 460;
            // 
            // _listViewImages
            // 
            this._listViewImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._listViewImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this._listViewImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IncludeFlag,
            this.FileName,
            this.Keywords,
            this.FilePath,
            this.StretchFlag,
            this.DisplayTextFlag,
            this.Offset,
            this.ScaleFactor,
            this.CreateDate,
            this.ModifyDate});
            this._listViewImages.ContextMenu = this._menuImagesContext;
            this._listViewImages.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._listViewImages.ForeColor = System.Drawing.Color.MidnightBlue;
            this._listViewImages.FullRowSelect = true;
            this._listViewImages.GridLines = true;
            this._listViewImages.Location = new System.Drawing.Point(8, 181);
            this._listViewImages.Name = "_listViewImages";
            this._listViewImages.Size = new System.Drawing.Size(658, 149);
            this._listViewImages.TabIndex = 17;
            this._listViewImages.UseCompatibleStateImageBehavior = false;
            this._listViewImages.View = System.Windows.Forms.View.Details;
            this._listViewImages.KeyDown += new System.Windows.Forms.KeyEventHandler(this._listViewImages_KeyDown);
            this._listViewImages.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this._listViewImages_ColumnClick);
            this._listViewImages.KeyUp += new System.Windows.Forms.KeyEventHandler(this._listViewImages_KeyUp);
            this._listViewImages.Click += new System.EventHandler(this._listViewImages_Click);
            // 
            // IncludeFlag
            // 
            this.IncludeFlag.Text = "+";
            this.IncludeFlag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IncludeFlag.Width = 18;
            // 
            // FileName
            // 
            this.FileName.Text = "FileName";
            this.FileName.Width = 130;
            // 
            // Keywords
            // 
            this.Keywords.Text = "Keywords";
            this.Keywords.Width = 185;
            // 
            // FilePath
            // 
            this.FilePath.Text = "Path";
            this.FilePath.Width = 173;
            // 
            // StretchFlag
            // 
            this.StretchFlag.Text = "Stretch";
            this.StretchFlag.Width = 90;
            // 
            // DisplayTextFlag
            // 
            this.DisplayTextFlag.Text = "Display Text?";
            this.DisplayTextFlag.Width = 90;
            // 
            // Offset
            // 
            this.Offset.Text = "Offset";
            this.Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ScaleFactor
            // 
            this.ScaleFactor.Text = "Scale";
            this.ScaleFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CreateDate
            // 
            this.CreateDate.Text = "Create Date";
            this.CreateDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CreateDate.Width = 130;
            // 
            // ModifyDate
            // 
            this.ModifyDate.Text = "Last Modified";
            this.ModifyDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ModifyDate.Width = 130;
            // 
            // _menuImagesContext
            // 
            this._menuImagesContext.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._mnuItemCtxtStretch,
            this._mnuItemCtxtOffset,
            this._mnuItemCtxtDispTxt,
            this._mnuItemCtxtInclude,
            this.menuItem17,
            this._mnuItemCtxtEditKW,
            this._mnuItemCtxtAddKW,
            this._mnuItemCtxtRemoveKW,
            this.menuItem2,
            this._mnuItemCtxtCopy,
            this._mnuItemCtxtMove,
            this._mnuItemCtxtDelete});
            this._menuImagesContext.Popup += new System.EventHandler(this._menuImagesContext_Popup);
            // 
            // _mnuItemCtxtStretch
            // 
            this._mnuItemCtxtStretch.Index = 0;
            this._mnuItemCtxtStretch.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._mnuItemCtxtStretchNone,
            this._mnuItemCtxtStretchKAR,
            this._mnuItemCtxtStretchToFit,
            this._mnuItemCtxtStretchScale,
            this._mnuItemCtxtStretchDefault});
            this._mnuItemCtxtStretch.Text = "Stretch";
            // 
            // _mnuItemCtxtStretchNone
            // 
            this._mnuItemCtxtStretchNone.Index = 0;
            this._mnuItemCtxtStretchNone.Text = "None";
            this._mnuItemCtxtStretchNone.Click += new System.EventHandler(this.StretchContext_Click);
            // 
            // _mnuItemCtxtStretchKAR
            // 
            this._mnuItemCtxtStretchKAR.Index = 1;
            this._mnuItemCtxtStretchKAR.Text = "Keep A/R";
            this._mnuItemCtxtStretchKAR.Click += new System.EventHandler(this.StretchContext_Click);
            // 
            // _mnuItemCtxtStretchToFit
            // 
            this._mnuItemCtxtStretchToFit.Index = 2;
            this._mnuItemCtxtStretchToFit.Text = "Stretch To Fit";
            this._mnuItemCtxtStretchToFit.Click += new System.EventHandler(this.StretchContext_Click);
            // 
            // _mnuItemCtxtStretchScale
            // 
            this._mnuItemCtxtStretchScale.Index = 3;
            this._mnuItemCtxtStretchScale.Text = "Scale Factor...";
            this._mnuItemCtxtStretchScale.Click += new System.EventHandler(this.StretchContext_Click);
            // 
            // _mnuItemCtxtStretchDefault
            // 
            this._mnuItemCtxtStretchDefault.Index = 4;
            this._mnuItemCtxtStretchDefault.Text = "Use Default";
            this._mnuItemCtxtStretchDefault.Click += new System.EventHandler(this.StretchContext_Click);
            // 
            // _mnuItemCtxtOffset
            // 
            this._mnuItemCtxtOffset.Index = 1;
            this._mnuItemCtxtOffset.Text = "Offset...";
            this._mnuItemCtxtOffset.Click += new System.EventHandler(this._mnuItemCtxtOffset_Click);
            // 
            // _mnuItemCtxtDispTxt
            // 
            this._mnuItemCtxtDispTxt.Index = 2;
            this._mnuItemCtxtDispTxt.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._mnuItemCtxtDispTxtYes,
            this._mnuItemCtxtDispTxtNo,
            this._mnuItemCtxtDispTxtDefault});
            this._mnuItemCtxtDispTxt.Text = "Display Image Text";
            // 
            // _mnuItemCtxtDispTxtYes
            // 
            this._mnuItemCtxtDispTxtYes.Index = 0;
            this._mnuItemCtxtDispTxtYes.Text = "Yes";
            this._mnuItemCtxtDispTxtYes.Click += new System.EventHandler(this.DisplayTextContext_Click);
            // 
            // _mnuItemCtxtDispTxtNo
            // 
            this._mnuItemCtxtDispTxtNo.Index = 1;
            this._mnuItemCtxtDispTxtNo.Text = "No";
            this._mnuItemCtxtDispTxtNo.Click += new System.EventHandler(this.DisplayTextContext_Click);
            // 
            // _mnuItemCtxtDispTxtDefault
            // 
            this._mnuItemCtxtDispTxtDefault.Index = 2;
            this._mnuItemCtxtDispTxtDefault.Text = "Default";
            this._mnuItemCtxtDispTxtDefault.Click += new System.EventHandler(this.DisplayTextContext_Click);
            // 
            // _mnuItemCtxtInclude
            // 
            this._mnuItemCtxtInclude.Index = 3;
            this._mnuItemCtxtInclude.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._mnuItemCtxtIncludeInclude,
            this._mnuItemCtxtIncludeExclude,
            this._mnuItemCtxtIncludeClear});
            this._mnuItemCtxtInclude.Text = "Include/ Exclude";
            // 
            // _mnuItemCtxtIncludeInclude
            // 
            this._mnuItemCtxtIncludeInclude.Index = 0;
            this._mnuItemCtxtIncludeInclude.Text = "Include (+) File";
            this._mnuItemCtxtIncludeInclude.Click += new System.EventHandler(this.IncludeFlagContext_Click);
            // 
            // _mnuItemCtxtIncludeExclude
            // 
            this._mnuItemCtxtIncludeExclude.Index = 1;
            this._mnuItemCtxtIncludeExclude.Text = "Exclude (-) File";
            this._mnuItemCtxtIncludeExclude.Click += new System.EventHandler(this.IncludeFlagContext_Click);
            // 
            // _mnuItemCtxtIncludeClear
            // 
            this._mnuItemCtxtIncludeClear.Index = 2;
            this._mnuItemCtxtIncludeClear.Text = "Clear Flag";
            this._mnuItemCtxtIncludeClear.Click += new System.EventHandler(this.IncludeFlagContext_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 4;
            this.menuItem17.Text = "-";
            // 
            // _mnuItemCtxtEditKW
            // 
            this._mnuItemCtxtEditKW.Index = 5;
            this._mnuItemCtxtEditKW.Text = "Edit Keywords...";
            this._mnuItemCtxtEditKW.Click += new System.EventHandler(this._mnuItemCtxtEditKW_Click);
            // 
            // _mnuItemCtxtAddKW
            // 
            this._mnuItemCtxtAddKW.Index = 6;
            this._mnuItemCtxtAddKW.Text = "Add Keyword(s)...";
            this._mnuItemCtxtAddKW.Click += new System.EventHandler(this._mnuItemCtxtAddKW_Click);
            // 
            // _mnuItemCtxtRemoveKW
            // 
            this._mnuItemCtxtRemoveKW.Index = 7;
            this._mnuItemCtxtRemoveKW.Text = "Remove Keyword(s)...";
            this._mnuItemCtxtRemoveKW.Click += new System.EventHandler(this._mnuItemCtxtRemoveKW_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 8;
            this.menuItem2.Text = "-";
            // 
            // _mnuItemCtxtCopy
            // 
            this._mnuItemCtxtCopy.Index = 9;
            this._mnuItemCtxtCopy.Text = "Copy File(s)...";
            this._mnuItemCtxtCopy.Click += new System.EventHandler(this._mnuItemCtxtCopy_Click);
            // 
            // _mnuItemCtxtMove
            // 
            this._mnuItemCtxtMove.Index = 10;
            this._mnuItemCtxtMove.Text = "Move File(s)...";
            this._mnuItemCtxtMove.Click += new System.EventHandler(this._mnuItemCtxtMove_Click);
            // 
            // _mnuItemCtxtDelete
            // 
            this._mnuItemCtxtDelete.Index = 11;
            this._mnuItemCtxtDelete.Text = "Delete File(s)...";
            this._mnuItemCtxtDelete.Click += new System.EventHandler(this._mnuItemCtxtDelete_Click);
            // 
            // _groupScripts
            // 
            this._groupScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._groupScripts.Controls.Add(this._btnScriptSaveAs);
            this._groupScripts.Controls.Add(this._btnScriptSave);
            this._groupScripts.Controls.Add(this._btnScriptNew);
            this._groupScripts.Controls.Add(this._btnScriptDelete);
            this._groupScripts.Controls.Add(this._btnScriptRemove);
            this._groupScripts.Controls.Add(this._buttonScriptAdd);
            this._groupScripts.Controls.Add(this._listViewScripts);
            this._groupScripts.Location = new System.Drawing.Point(8, 87);
            this._groupScripts.Name = "_groupScripts";
            this._groupScripts.Size = new System.Drawing.Size(658, 90);
            this._groupScripts.TabIndex = 18;
            this._groupScripts.TabStop = false;
            this._groupScripts.Text = "Scripts";
            // 
            // _btnScriptSaveAs
            // 
            this._btnScriptSaveAs.Location = new System.Drawing.Point(63, 62);
            this._btnScriptSaveAs.Name = "_btnScriptSaveAs";
            this._btnScriptSaveAs.Size = new System.Drawing.Size(56, 22);
            this._btnScriptSaveAs.TabIndex = 22;
            this._btnScriptSaveAs.Text = "SaveAs";
            this._btnScriptSaveAs.Click += new System.EventHandler(this._btnScriptSaveAs_Click);
            // 
            // _btnScriptSave
            // 
            this._btnScriptSave.Location = new System.Drawing.Point(8, 62);
            this._btnScriptSave.Name = "_btnScriptSave";
            this._btnScriptSave.Size = new System.Drawing.Size(56, 22);
            this._btnScriptSave.TabIndex = 21;
            this._btnScriptSave.Text = "Save";
            this._btnScriptSave.Click += new System.EventHandler(this._btnScriptSave_Click);
            // 
            // _btnScriptNew
            // 
            this._btnScriptNew.Location = new System.Drawing.Point(63, 16);
            this._btnScriptNew.Name = "_btnScriptNew";
            this._btnScriptNew.Size = new System.Drawing.Size(56, 22);
            this._btnScriptNew.TabIndex = 20;
            this._btnScriptNew.Text = "New";
            this._btnScriptNew.Click += new System.EventHandler(this._btnScriptNew_Click);
            // 
            // _btnScriptDelete
            // 
            this._btnScriptDelete.Location = new System.Drawing.Point(63, 39);
            this._btnScriptDelete.Name = "_btnScriptDelete";
            this._btnScriptDelete.Size = new System.Drawing.Size(56, 22);
            this._btnScriptDelete.TabIndex = 19;
            this._btnScriptDelete.Text = "Delete";
            this._btnScriptDelete.UseVisualStyleBackColor = false;
            this._btnScriptDelete.Click += new System.EventHandler(this._btnScriptDelete_Click);
            // 
            // _btnScriptRemove
            // 
            this._btnScriptRemove.Location = new System.Drawing.Point(8, 39);
            this._btnScriptRemove.Name = "_btnScriptRemove";
            this._btnScriptRemove.Size = new System.Drawing.Size(56, 22);
            this._btnScriptRemove.TabIndex = 18;
            this._btnScriptRemove.Text = "Remove";
            this._btnScriptRemove.UseVisualStyleBackColor = false;
            this._btnScriptRemove.Click += new System.EventHandler(this._btnScriptRemove_Click);
            // 
            // _buttonScriptAdd
            // 
            this._buttonScriptAdd.Location = new System.Drawing.Point(8, 16);
            this._buttonScriptAdd.Name = "_buttonScriptAdd";
            this._buttonScriptAdd.Size = new System.Drawing.Size(56, 22);
            this._buttonScriptAdd.TabIndex = 17;
            this._buttonScriptAdd.Text = "Add";
            this._buttonScriptAdd.Click += new System.EventHandler(this._buttonScriptAdd_Click);
            // 
            // _statusBar
            // 
            this._statusBar.Location = new System.Drawing.Point(0, 336);
            this._statusBar.Name = "_statusBar";
            this._statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanelProgress,
            this.statusBarPanelInfo});
            this._statusBar.Size = new System.Drawing.Size(674, 26);
            this._statusBar.TabIndex = 19;
            this._statusBar.Text = "Status";
            // 
            // statusBarPanelProgress
            // 
            this.statusBarPanelProgress.Name = "statusBarPanelProgress";
            this.statusBarPanelProgress.Text = "statusBarPanel1";
            this.statusBarPanelProgress.Width = 300;
            // 
            // statusBarPanelInfo
            // 
            this.statusBarPanelInfo.Name = "statusBarPanelInfo";
            this.statusBarPanelInfo.Text = "statusBarPanel1";
            this.statusBarPanelInfo.Width = 300;
            // 
            // _toolBar
            // 
            this._toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButtonNew,
            this.toolBarButtonOpen,
            this.toolBarButtonSave,
            this.toolBarButtonPreview,
            this.toolBarButtonScan});
            this._toolBar.DropDownArrows = true;
            this._toolBar.Location = new System.Drawing.Point(0, 0);
            this._toolBar.Name = "_toolBar";
            this._toolBar.ShowToolTips = true;
            this._toolBar.Size = new System.Drawing.Size(674, 43);
            this._toolBar.TabIndex = 20;
            this._toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this._toolBar_ButtonClick);
            // 
            // toolBarButtonNew
            // 
            this.toolBarButtonNew.Name = "toolBarButtonNew";
            this.toolBarButtonNew.Text = "New";
            this.toolBarButtonNew.ToolTipText = "Click to create a new Config File";
            // 
            // toolBarButtonOpen
            // 
            this.toolBarButtonOpen.Name = "toolBarButtonOpen";
            this.toolBarButtonOpen.Text = "Open";
            this.toolBarButtonOpen.ToolTipText = "Click to open an existing Config File";
            // 
            // toolBarButtonSave
            // 
            this.toolBarButtonSave.Name = "toolBarButtonSave";
            this.toolBarButtonSave.Text = "Save";
            this.toolBarButtonSave.ToolTipText = "Click to save current Config File";
            // 
            // toolBarButtonPreview
            // 
            this.toolBarButtonPreview.Name = "toolBarButtonPreview";
            this.toolBarButtonPreview.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.toolBarButtonPreview.Text = "Preview";
            this.toolBarButtonPreview.ToolTipText = "Click to show a preview window";
            // 
            // toolBarButtonScan
            // 
            this.toolBarButtonScan.Name = "toolBarButtonScan";
            this.toolBarButtonScan.Text = "ScanThumbnails";
            this.toolBarButtonScan.ToolTipText = "Updates keywords and display settings based on thumbnail data";
            // 
            // backgroundWorkerLoad
            // 
            this.backgroundWorkerLoad.WorkerReportsProgress = true;
            this.backgroundWorkerLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoad_DoWork);
            this.backgroundWorkerLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoad_RunWorkerCompleted);
            this.backgroundWorkerLoad.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerLoad_ProgressChanged);
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBarStatus.Location = new System.Drawing.Point(40, 347);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(240, 10);
            this.progressBarStatus.TabIndex = 21;
            // 
            // _lblImageCount
            // 
            this._lblImageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblImageCount.AutoSize = true;
            this._lblImageCount.BackColor = System.Drawing.SystemColors.Control;
            this._lblImageCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblImageCount.Location = new System.Drawing.Point(300, 345);
            this._lblImageCount.Name = "_lblImageCount";
            this._lblImageCount.Size = new System.Drawing.Size(50, 14);
            this._lblImageCount.TabIndex = 22;
            this._lblImageCount.Text = "0 Images";
            // 
            // _lblStatusMessage
            // 
            this._lblStatusMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblStatusMessage.AutoSize = true;
            this._lblStatusMessage.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatusMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatusMessage.Location = new System.Drawing.Point(410, 345);
            this._lblStatusMessage.Name = "_lblStatusMessage";
            this._lblStatusMessage.Size = new System.Drawing.Size(0, 14);
            this._lblStatusMessage.TabIndex = 23;
            // 
            // _txtSlideDuration
            // 
            this._txtSlideDuration.Location = new System.Drawing.Point(77, 16);
            this._txtSlideDuration.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this._txtSlideDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._txtSlideDuration.Name = "_txtSlideDuration";
            this._txtSlideDuration.Size = new System.Drawing.Size(40, 20);
            this._txtSlideDuration.TabIndex = 24;
            this._txtSlideDuration.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // _lblSlideDuration
            // 
            this._lblSlideDuration.AutoSize = true;
            this._lblSlideDuration.BackColor = System.Drawing.Color.CornflowerBlue;
            this._lblSlideDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this._lblSlideDuration.Location = new System.Drawing.Point(3, 19);
            this._lblSlideDuration.Name = "_lblSlideDuration";
            this._lblSlideDuration.Size = new System.Drawing.Size(73, 14);
            this._lblSlideDuration.TabIndex = 25;
            this._lblSlideDuration.Text = "Slide Duration";
            // 
            // _grpDefaultSettings
            // 
            this._grpDefaultSettings.BackColor = System.Drawing.Color.CornflowerBlue;
            this._grpDefaultSettings.Controls.Add(this._chkMouseWakeUp);
            this._grpDefaultSettings.Controls.Add(this._chkRandom);
            this._grpDefaultSettings.Controls.Add(this._lblDefaultStretch);
            this._grpDefaultSettings.Controls.Add(this._cboDefaultStretch);
            this._grpDefaultSettings.Controls.Add(this._chkDefaultShowInfo);
            this._grpDefaultSettings.Controls.Add(this._chkDefaultShowText);
            this._grpDefaultSettings.Controls.Add(this._txtSlideDuration);
            this._grpDefaultSettings.Controls.Add(this._lblSlideDuration);
            this._grpDefaultSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this._grpDefaultSettings.Location = new System.Drawing.Point(8, 49);
            this._grpDefaultSettings.Name = "_grpDefaultSettings";
            this._grpDefaultSettings.Size = new System.Drawing.Size(658, 39);
            this._grpDefaultSettings.TabIndex = 26;
            this._grpDefaultSettings.TabStop = false;
            this._grpDefaultSettings.Text = "Default Settings";
            // 
            // _chkMouseWakeUp
            // 
            this._chkMouseWakeUp.Appearance = System.Windows.Forms.Appearance.Button;
            this._chkMouseWakeUp.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkMouseWakeUp.Location = new System.Drawing.Point(306, 15);
            this._chkMouseWakeUp.Margin = new System.Windows.Forms.Padding(2);
            this._chkMouseWakeUp.Name = "_chkMouseWakeUp";
            this._chkMouseWakeUp.Size = new System.Drawing.Size(80, 22);
            this._chkMouseWakeUp.TabIndex = 33;
            this._chkMouseWakeUp.Text = "Mouse Wake";
            this._chkMouseWakeUp.UseVisualStyleBackColor = true;
            // 
            // _chkRandom
            // 
            this._chkRandom.Appearance = System.Windows.Forms.Appearance.Button;
            this._chkRandom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkRandom.Location = new System.Drawing.Point(251, 15);
            this._chkRandom.Margin = new System.Windows.Forms.Padding(2);
            this._chkRandom.Name = "_chkRandom";
            this._chkRandom.Size = new System.Drawing.Size(56, 22);
            this._chkRandom.TabIndex = 32;
            this._chkRandom.Text = "Random";
            this._chkRandom.UseVisualStyleBackColor = true;
            // 
            // _lblDefaultStretch
            // 
            this._lblDefaultStretch.AutoSize = true;
            this._lblDefaultStretch.BackColor = System.Drawing.Color.CornflowerBlue;
            this._lblDefaultStretch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this._lblDefaultStretch.Location = new System.Drawing.Point(391, 19);
            this._lblDefaultStretch.Name = "_lblDefaultStretch";
            this._lblDefaultStretch.Size = new System.Drawing.Size(79, 14);
            this._lblDefaultStretch.TabIndex = 31;
            this._lblDefaultStretch.Text = "Default Stretch";
            // 
            // _cboDefaultStretch
            // 
            this._cboDefaultStretch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._cboDefaultStretch.FormattingEnabled = true;
            this._cboDefaultStretch.Location = new System.Drawing.Point(471, 14);
            this._cboDefaultStretch.Name = "_cboDefaultStretch";
            this._cboDefaultStretch.Size = new System.Drawing.Size(179, 22);
            this._cboDefaultStretch.TabIndex = 30;
            this._cboDefaultStretch.SelectedIndexChanged += new System.EventHandler(this._cboDefaultStretch_SelectedIndexChanged);
            // 
            // _chkDefaultShowInfo
            // 
            this._chkDefaultShowInfo.Appearance = System.Windows.Forms.Appearance.Button;
            this._chkDefaultShowInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkDefaultShowInfo.Location = new System.Drawing.Point(187, 15);
            this._chkDefaultShowInfo.Margin = new System.Windows.Forms.Padding(2);
            this._chkDefaultShowInfo.Name = "_chkDefaultShowInfo";
            this._chkDefaultShowInfo.Size = new System.Drawing.Size(65, 22);
            this._chkDefaultShowInfo.TabIndex = 29;
            this._chkDefaultShowInfo.Text = "Show Info";
            this._chkDefaultShowInfo.UseVisualStyleBackColor = true;
            // 
            // _chkDefaultShowText
            // 
            this._chkDefaultShowText.Appearance = System.Windows.Forms.Appearance.Button;
            this._chkDefaultShowText.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkDefaultShowText.Location = new System.Drawing.Point(120, 15);
            this._chkDefaultShowText.Margin = new System.Windows.Forms.Padding(2);
            this._chkDefaultShowText.Name = "_chkDefaultShowText";
            this._chkDefaultShowText.Size = new System.Drawing.Size(68, 22);
            this._chkDefaultShowText.TabIndex = 28;
            this._chkDefaultShowText.Text = "Show Text";
            this._chkDefaultShowText.UseVisualStyleBackColor = true;
            // 
            // configFileBindingSource
            // 
            this.configFileBindingSource.DataSource = typeof(TSOP.SlideShow.ConfigFile);
            // 
            // slideShowSetupFormBindingSource
            // 
            this.slideShowSetupFormBindingSource.DataSource = typeof(TSOP.SlideShow.SlideShowSetupForm);
            // 
            // SlideShowSetupForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(674, 362);
            this.Controls.Add(this._grpDefaultSettings);
            this.Controls.Add(this._lblStatusMessage);
            this.Controls.Add(this._lblImageCount);
            this.Controls.Add(this.progressBarStatus);
            this.Controls.Add(this._toolBar);
            this.Controls.Add(this._statusBar);
            this.Controls.Add(this._groupScripts);
            this.Controls.Add(this._listViewImages);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this.Menu = this._menuMain;
            this.Name = "SlideShowSetupForm";
            this.Text = "SlideShow.Net Setup Manager";
            this.ResizeEnd += new System.EventHandler(this.SlideShowSetupForm_ResizeEnd);
            this._groupScripts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._txtSlideDuration)).EndInit();
            this._grpDefaultSettings.ResumeLayout(false);
            this._grpDefaultSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configFileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideShowSetupFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main(string[] args) 
		{
            if (args.Length > 0)
            {
                if (args[0].ToLower().Trim().Substring(0, 2) == "/r")
                {
                    Application.Run(new SlideShowSetupForm(true));
                }
            }
            else
                Application.Run(new SlideShowSetupForm(false));

		}

		#region Members

            private delegate bool CopyDel(string srcPath, string destPath);

			private ConfigFile _configFile;

			private Graphics _formGraphics;

			private string _lastFileName;

			private ArrayList _allKeywords;

			private int _imageIndex;

			private RegistrySettings _regSettings;

			private AppLog _appLog;

            private PreviewForm _preview;

		#endregion		// members

		#region Properties

		public System.Windows.Forms.ContextMenu CtxtMenu
		{
			get
			{
				return _menuImagesContext;
			}
		}

		private Boolean RememberFolders
		{
			get
			{
				return _menuItemTools_Options_Remember.Checked;
			}
		}

		private Boolean LoadThumbnailData
		{
			get
			{
				return _menuItemTools_Options_ThumbnailData.Checked;
			}
		}

        protected ConfigFile CurrentConfigFile
        {
            get
            {
                if (_configFile == null)
                    _configFile = new ConfigFile();
                return _configFile;
            }
            set
            {
                _configFile = value;
            }
        }

		#endregion		// properties

		#region Constructors

		public SlideShowSetupForm(bool loadFromRegistry)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_appLog = new AppLog();
			_formGraphics = this.CreateGraphics();

			this._mnuItemCtxtStretchDefault.Text = Utilities.GetStretchTypeString(StretchTypes.UseDefault);
			this._mnuItemCtxtStretchKAR.Text = Utilities.GetStretchTypeString(StretchTypes.StretchKeepAspectRatio);
			this._mnuItemCtxtStretchNone.Text = Utilities.GetStretchTypeString(StretchTypes.NoStretch);
			this._mnuItemCtxtStretchScale.Text = Utilities.GetStretchTypeString(StretchTypes.ScaleFactor);
			this._mnuItemCtxtStretchToFit.Text = Utilities.GetStretchTypeString(StretchTypes.StretchToFit);

            _cboDefaultStretch.Items.Add(StretchTypes.NoStretch);
            _cboDefaultStretch.Items.Add(StretchTypes.ScaleFactor);
            _cboDefaultStretch.Items.Add(StretchTypes.StretchKeepAspectRatio);
            _cboDefaultStretch.Items.Add(StretchTypes.StretchToFit);

			_allKeywords = new ArrayList(23);

			_regSettings = new RegistrySettings();

            //_suppressImageChangedEvent = false;

			BuildMRUList();

            if (loadFromRegistry)
            {
                this._lastFileName = StringConstants.REGISTRY_FILENAME;
                DisableControls(ControlSets.All, false);
                Cursor.Current = Cursors.WaitCursor;

                backgroundWorkerLoad.RunWorkerAsync();

            }


		}

		#endregion		// constructors

		#region Destructors

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

		#endregion		// destructors

		#region Methods

		private void DisableControls(ControlSets controlSet, bool enabled)
		{
			switch (controlSet)
			{
				case ControlSets.All:
				default:
					foreach (System.Windows.Forms.Control ctrl in this.Controls)
					{
						ctrl.Enabled = enabled;
					}
					break;
			}
		}

		private void PopulateControls()
		{

			// clear any existing contents first
			this._listViewImages.Items.Clear();
			this._listViewScripts.Items.Clear();

			// populate the script list view
			for (int i = 0; i < CurrentConfigFile.ScriptFileList.Count; i++)
			{
					
				ListViewItem item = new ListViewItem(CurrentConfigFile.ScriptFileList[i].PathAndFileName);
				item.Tag = CurrentConfigFile.ScriptFileList[i].PathAndFileName;
				item.Text = TSOP.Utilities.TruncateString(item.Tag.ToString(), 
					(float) _listViewScripts.Columns[0].Width, 
					_listViewScripts.Font, 
					_formGraphics);         
				item.ForeColor = TSOP.ColorArray.GetAt(i);
				this._listViewScripts.Items.Add(item);
			}

			// populate the options menu
			_menuItemTools_Options_ThumbnailData.Checked = CurrentConfigFile.ReadKeywordsOnLoad;

            // bind the configuration settings controls
            _txtSlideDuration.DataBindings.Clear();
            _txtSlideDuration.DataBindings.Add("Value", CurrentConfigFile, "IntervalTime");
            _cboDefaultStretch.Text = CurrentConfigFile.StretchDefault.ToString();
            _chkDefaultShowInfo.DataBindings.Clear();
            _chkDefaultShowInfo.DataBindings.Add("Checked", CurrentConfigFile, "DisplayFileInfoDefault");
            _chkDefaultShowText.DataBindings.Clear();
            _chkDefaultShowText.DataBindings.Add("Checked", CurrentConfigFile, "DisplayTextDefault");
            _chkMouseWakeUp.DataBindings.Clear();
            _chkMouseWakeUp.DataBindings.Add("Checked", CurrentConfigFile, "MouseWakeup");
            _chkRandom.DataBindings.Clear();
            _chkRandom.DataBindings.Add("Checked", CurrentConfigFile, "Randomize");

		}

        private void UpdateConfigFile()
        {
            CurrentConfigFile.IntervalTime = (uint) _txtSlideDuration.Value;
            CurrentConfigFile.StretchDefault = (StretchTypes) Enum.Parse(typeof(StretchTypes), _cboDefaultStretch.Text);
            CurrentConfigFile.DisplayFileInfoDefault = _chkDefaultShowInfo.Checked;
            CurrentConfigFile.DisplayTextDefault = _chkDefaultShowText.Checked;
            CurrentConfigFile.MouseWakeup = _chkMouseWakeUp.Checked;
            CurrentConfigFile.Randomize = _chkRandom.Checked;

        }

		private bool ChangeContextProperty(ICollection itemArray, ContextProperties property, object propValue)
		{
			bool success = true;

			try
			{

				foreach (ListViewItem lvi in itemArray)
				{
					ImageItem ii = GetImageItem((ImageID) lvi.Tag);	

					// update the listview
					switch (property)
					{
						case ContextProperties.IncludeFlag:
							lvi.SubItems[(int)ListViewColumns.IncludeFlag].Text = Utilities.GetIncludeFlagString((IncludeFlags) propValue);
							break;
						case ContextProperties.StretchType:
							lvi.SubItems[(int)ListViewColumns.StretchFlag].Text = Utilities.GetStretchTypeString((StretchTypes) propValue);
							break;
						case ContextProperties.DisplayTextFlag:
							lvi.SubItems[(int)ListViewColumns.DisplayTextFlag].Text = Utilities.GetThreeWayFlagString((ThreeWayFlags) propValue);
							break;

					}


					// update the image item
					switch (property)
					{
						case ContextProperties.IncludeFlag:
							ii.IncludeFlag = (IncludeFlags) propValue;
							return true;	// include flag is not persisted in the image item file
						case ContextProperties.StretchType:
							ii.StretchType = (StretchTypes) propValue;
							break;
						case ContextProperties.DisplayTextFlag:
							ii.TextDisplayFlag = (ThreeWayFlags) propValue;
							break;
					}
					

					if (!ii.WriteThumbnailData())
						success = false;  
				}

				return success;

			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				_appLog.LogError("failed to change context property", ex, "SlideShowSetupForm", "ChangeContextProperty");
				return false;
			}
		}

		private void BuildMRUList()
		{

			_menuItemFile_Recent.MenuItems.Clear();

			ArrayList mruList = _regSettings.GetMRUList();
			if (mruList.Count == 0) 
			{
				_menuItemFile_Recent.Enabled = false;
				return;
			}

			foreach (string fileName in mruList)
			{
				MenuItem mi = new MenuItem(TSOP.Utilities.ShortenPath(fileName, 40), new System.EventHandler(_menuItemFile_Recent_Click));
				_menuItemFile_Recent.MenuItems.Add(mi);
			}
			this._menuItemFile_Recent.Enabled = true;

		}

		private ImageItem GetImageItem(ImageID imageID)
		{
		
			return CurrentConfigFile.ScriptFileList.GetScriptByName(imageID.ScriptFile).ImageItemCollection.GetImageItem(imageID.Index);

		}

		private string GetSelectedValue(int columnIndex)
		{
			string valString = _listViewImages.SelectedItems[0].SubItems[columnIndex].Text;
			foreach (ListViewItem lvi in this._listViewImages.SelectedItems)
			{
				if (lvi.SubItems[columnIndex].Text != valString)
				{
					// make sure all stretch types are the same, if not break;
					valString = "";
					break;
				}
			}
			
			return valString;
		}

		private void CheckContextMenu(ListViewColumns column)
		{
			string valueStr = GetSelectedValue((int) column);
			// if all value strings are not the same, don't check anything
			if (valueStr == "")
				return;

			switch (column)
			{
				case ListViewColumns.DisplayTextFlag:

					if (valueStr == Utilities.GetThreeWayFlagString(ThreeWayFlags.False))
						this._mnuItemCtxtDispTxtNo.Checked = true;
					if (valueStr == Utilities.GetThreeWayFlagString(ThreeWayFlags.True))
						this._mnuItemCtxtDispTxtYes.Checked = true;
					if (valueStr == Utilities.GetThreeWayFlagString(ThreeWayFlags.UseDefault))
						this._mnuItemCtxtDispTxtDefault.Checked = true;
					break;

				case ListViewColumns.StretchFlag:

					if (valueStr == Utilities.GetStretchTypeString(StretchTypes.NoStretch))
						this._mnuItemCtxtStretchNone.Checked = true;
					if (valueStr == Utilities.GetStretchTypeString(StretchTypes.ScaleFactor))
						this._mnuItemCtxtStretchScale.Checked = true;
					if (valueStr == Utilities.GetStretchTypeString(StretchTypes.StretchKeepAspectRatio))
						this._mnuItemCtxtStretchKAR.Checked = true;
					if (valueStr == Utilities.GetStretchTypeString(StretchTypes.StretchToFit))
						this._mnuItemCtxtStretchToFit.Checked = true;
					if (valueStr == Utilities.GetStretchTypeString(StretchTypes.UseDefault))
						this._mnuItemCtxtStretchDefault.Checked = true;
					break;

				case ListViewColumns.IncludeFlag:

					if (valueStr == Utilities.GetIncludeFlagString(IncludeFlags.Exclude))
						this._mnuItemCtxtIncludeExclude.Checked = true;
					if (valueStr == Utilities.GetIncludeFlagString(IncludeFlags.Include))
						this._mnuItemCtxtIncludeInclude.Checked = true;
					break;

			}

		}

		private void ClearContextChecks()
		{
			this._mnuItemCtxtStretchNone.Checked = false;
			this._mnuItemCtxtStretchScale.Checked = false;
			this._mnuItemCtxtStretchKAR.Checked = false;
			this._mnuItemCtxtStretchToFit.Checked = false;
			this._mnuItemCtxtStretchDefault.Checked = false;

			this._mnuItemCtxtDispTxtDefault.Checked = false;
			this._mnuItemCtxtDispTxtNo.Checked = false;
			this._mnuItemCtxtDispTxtYes.Checked = false;

			this._mnuItemCtxtIncludeClear.Checked = false;
			this._mnuItemCtxtIncludeExclude.Checked = false;
			this._mnuItemCtxtIncludeInclude.Checked = false;

		}

		private void AddKeyword(string keyword)
		{
			if (keyword.Trim() != "" && !_allKeywords.Contains(keyword))
			{
				_allKeywords.Add(keyword);
				_allKeywords.Sort();
			}
		}

		private void RemoveKeyword(string keyword)
		{
			_allKeywords.Remove(keyword);
		}

		private void AddKeywords(ArrayList keywords)
		{
			foreach (string keyword in keywords)
				AddKeyword(keyword);
		}

		private void RemoveKeywords(ArrayList keywords)
		{
			foreach (string keyword in keywords)
				RemoveKeyword(keyword);
		}

		private void UpdateKeywords()
		{
			_allKeywords.Clear();
			foreach (ScriptFile sf in CurrentConfigFile.ScriptFileList)
			{
				foreach (ImageItem ii in sf.ImageItemCollection)
					AddKeywords(ii.KeywordList);
			}
		}

		private void Promote(bool promote)
		{
			bool failure = false;

			foreach (ListViewItem lvi in _listViewImages.SelectedItems)
			{   // todo: there is a bug here.  when selecting an image item by using up/down arrows,
                // the new image item is not being returned, the previous one is
                // 
				ImageItem ii = GetImageItem((ImageID)lvi.Tag);
				if (promote)
					ii.Promote();
				else
					ii.Demote();
				if (!ii.WriteThumbnailData())
					failure = true;
				else
					lvi.SubItems[(int) ListViewColumns.Keywords].Text = ii.KeywordString;
			}

			if (failure)
				Microsoft.VisualBasic.Interaction.Beep();
		}

		#endregion		// methods	

		#region Main Menu Events

		private void _menuItemFile_Open_Click(object sender, System.EventArgs e)
		{
		
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Config Files (*.ssc)|*.SSC|Script Files (*.sss)|*.SSS|Text Files (*.txt)|*.txt";

			if (ofd.ShowDialog(this) == DialogResult.OK)
			{

				this._lastFileName = ofd.FileName;	
				DisableControls(ControlSets.All, false);
				Cursor.Current = Cursors.WaitCursor;

                backgroundWorkerLoad.RunWorkerAsync();
 
			}

		}

		private void _menuItemFile_Recent_Click(object sender, System.EventArgs e)
		{

			MenuItem mi = (MenuItem) sender;
			//this._lastFileName = mi.Text;
			ArrayList mruList = _regSettings.GetMRUList();
			this._lastFileName = (string) mruList[mi.Index];
			DisableControls(ControlSets.All, false);
			Cursor.Current = Cursors.WaitCursor;

            backgroundWorkerLoad.RunWorkerAsync();

		}

		private void _menuItemFile_SaveToRegistry_Click(object sender, System.EventArgs e)
		{
			try
			{
                UpdateConfigFile();
				RegistrySettings rs = new RegistrySettings();
				rs.SetConfigSettings(CurrentConfigFile);

			}
			catch (Exception ex)
			{
			
				MessageBox.Show("An error was encountered:\n" + ex.Message);
				_appLog.LogError("failed to save to registry", ex, "SlideShowSetupForm", "_menuItemFile_SaveToRegistry_Click");
			}

		}

        private void _menuItemFile_New_Click(object sender, EventArgs e)
        {
            _configFile = new ConfigFile();
            PopulateControls();
            this.Text = "Untitled SlideShow";
        }

		private void _menuItemFile_Save_Click(object sender, System.EventArgs e)
		{
            // if it came from the registry, it needs a file name
            if (_lastFileName == StringConstants.REGISTRY_FILENAME || _lastFileName == "")
            {
                _menuItemFile_SaveAs_Click(sender, e);
                return;
            }

            UpdateConfigFile();
			if (!CurrentConfigFile.Save())
				MessageBox.Show("Error saving config file", "Error");
		
		}

		private void _menuItemFile_SaveAs_Click(object sender, System.EventArgs e)
		{

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Config Files (*.ssc)|*.SSC|Script Files (*.sss)|*.SSS|Text Files (*.txt)|*.txt";

			if (sfd.ShowDialog(this) == DialogResult.OK)
			{

                UpdateConfigFile();
				if (!CurrentConfigFile.Save(sfd.FileName))
					MessageBox.Show("Error saving config file", "Error");
				else
				{
					_regSettings.AddMRUFile(sfd.FileName);
					BuildMRUList();
                    CurrentConfigFile.SetPathAndFilename(sfd.FileName);
                    this.Text = CurrentConfigFile.FileName;
				}

			}
		}

		private void menuItemFile_LoadRegistry_Click(object sender, System.EventArgs e)
		{
            this._lastFileName = StringConstants.REGISTRY_FILENAME;
            DisableControls(ControlSets.All, false);
            Cursor.Current = Cursors.WaitCursor;

            backgroundWorkerLoad.RunWorkerAsync();

		}

		private void _menuItemFile_Add_Search_Click(object sender, System.EventArgs e)
		{
            AddFilesBySearch(false);
		}

        private void _menuItemFile_Add_SearchRecursive_Click(object sender, EventArgs e)
        {
            AddFilesBySearch(true);
        }

		private void _menuItemFile_Add_File_Click(object sender, System.EventArgs e)
		{
			AddFiles();
		}

		private void _menuItemFile_Remove_Click(object sender, System.EventArgs e)
		{
			RemoveFiles();
		}

		private void _menuItemTools_Options_Remember_Click(object sender, System.EventArgs e)
		{
			_menuItemTools_Options_Remember.Checked = !_menuItemTools_Options_Remember.Checked;
		}

		private void _menuItemTools_Options_ThumbnailData_Click(object sender, System.EventArgs e)
		{
			_menuItemTools_Options_ThumbnailData.Checked = !_menuItemTools_Options_ThumbnailData.Checked;
			if (_configFile != null)
				_configFile.ReadKeywordsOnLoad = _menuItemTools_Options_ThumbnailData.Checked;
		}

        private void _menuItemHelp_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version " + Application.ProductVersion);
        }

		#endregion	// main menu events

		#region Context Menu Events
        
        private void _mnuItemCtxtCopy_Click(object sender, EventArgs e)
        {
            CopyImageFiles(true);
        }

        private void _mnuItemCtxtMove_Click(object sender, EventArgs e)
        {
            CopyImageFiles(false);
        }

        private void _mnuItemCtxtDelete_Click(object sender, EventArgs e)
        {
            DeleteImageFiles();
        }
        
        private void _menuImagesContext_Popup(object sender, System.EventArgs e)
		{
			ClearContextChecks();

			// don't allow the context menu to display when nothing is selected
			if (_listViewImages.SelectedItems.Count == 0)
			{
				foreach (MenuItem mi in _menuImagesContext.MenuItems)
					mi.Visible = false;
				return;
			}
			else
				foreach (MenuItem mi in _menuImagesContext.MenuItems)
					mi.Visible = true;


			// set the check for Stretch Type
			CheckContextMenu(ListViewColumns.StretchFlag);
				
			// set the check for Display Text
			CheckContextMenu(ListViewColumns.DisplayTextFlag);

			// set the check for Include Flag
			CheckContextMenu(ListViewColumns.IncludeFlag);

		}

		private void _mnuItemCtxtOffset_Click(object sender, System.EventArgs e)
		{

			OffsetEntryForm oef = new OffsetEntryForm();
            List<ListViewItem> selectedItems = GetSelectedListViewItems(sender);

			if (selectedItems.Count == 1)
				oef.Offset = GetImageItem((ImageID) selectedItems[0].Tag).Offset;
			bool failure = false;
			if (oef.ShowDialog() == DialogResult.OK)
			{
				foreach (ListViewItem lvi in selectedItems)
				{
					ImageItem ii = GetImageItem((ImageID)lvi.Tag);
					ii.Offset = oef.Offset;
					lvi.SubItems[(int) ListViewColumns.Offset].Text = TSOP.Utilities.GetPointString(ii.Offset);
					if (!ii.WriteThumbnailData())
						failure = true;
				}
				if (failure)
					Microsoft.VisualBasic.Interaction.Beep();
			}

            // repaint the preview image, if necessary
            if (_preview != null)
            {
                _preview.Refresh();
                _preview.Focus();
                if (((ContextMenu)((MenuItem)sender).Parent).SourceControl.Name != "PreviewForm")
                    Focus();
            }

		}

		private void _mnuItemCtxtEditKW_Click(object sender, System.EventArgs e)
		{

			KeywordEditForm kf = new KeywordEditForm();

            List<ListViewItem> selectedLVIs = GetSelectedListViewItems(sender);
            List<ImageItem> selectedImageItems = new List<ImageItem>();

            foreach (ListViewItem lvi in selectedLVIs)
                selectedImageItems.Add(GetImageItem((ImageID)lvi.Tag));


			kf.Keywords = _allKeywords;
			kf.SelectedKeywords = Utilities.BuildDistinctKeywords(ref selectedImageItems);
			kf.ShowDialog();

			if (kf.DialogResult == DialogResult.OK)
			{
				bool failure = false;
			    foreach (ListViewItem lvi in selectedLVIs)
			    {
				    ImageItem ii = GetImageItem((ImageID)lvi.Tag);
				    ii.KeywordList = kf.SelectedKeywords;
				    if (!ii.WriteThumbnailData())
					    failure = true;
				    else
					    lvi.SubItems[(int) ListViewColumns.Keywords].Text = ii.KeywordString;
			    }

				UpdateKeywords();
                WriteDiagnostics();
				if (failure)
					Microsoft.VisualBasic.Interaction.Beep();
			}


		}

		private void _mnuItemCtxtAddKW_Click(object sender, System.EventArgs e)
		{
		
			KeywordEditForm kf = new KeywordEditForm();

            List<ListViewItem> selectedLVIs = GetSelectedListViewItems(sender);
			ArrayList selectedImageItems = new ArrayList(13);
			foreach (ListViewItem lvi in selectedLVIs)
			{
				selectedImageItems.Add(GetImageItem((ImageID)lvi.Tag));
			}

			kf.Keywords = _allKeywords;
			kf.Text = "Add Keywords";
			kf.ShowDialog();

			if (kf.DialogResult == DialogResult.OK)
			{
				bool failure = false;
				foreach (ListViewItem lvi in selectedLVIs)
				{
					ImageItem ii = GetImageItem((ImageID)lvi.Tag);
					ii.AddKeywords(kf.SelectedKeywords);
					if (!ii.WriteThumbnailData())
						failure = true;
					else
						lvi.SubItems[(int) ListViewColumns.Keywords].Text = ii.KeywordString;
				}
				UpdateKeywords();
                WriteDiagnostics();
				if (failure)
					Microsoft.VisualBasic.Interaction.Beep();
			}

		}

		private void _mnuItemCtxtRemoveKW_Click(object sender, System.EventArgs e)
		{

			KeywordEditForm kf = new KeywordEditForm();

            List<ListViewItem> selectedLVIs = GetSelectedListViewItems(sender);
			List<ImageItem> selectedImageItems = new List<ImageItem>(13);
			foreach (ListViewItem lvi in selectedLVIs)
			{
				selectedImageItems.Add(GetImageItem((ImageID)lvi.Tag));
			}

			kf.Keywords = Utilities.BuildDistinctKeywords(ref selectedImageItems);
			kf.Text = "Remove Keywords";
			kf.ShowTextBox = false;
			kf.ShowDialog();

			if (kf.DialogResult == DialogResult.OK)
			{
				bool failure = false;
				foreach (ListViewItem lvi in selectedLVIs)
				{
					ImageItem ii = GetImageItem((ImageID)lvi.Tag);
					ii.RemoveKeywords(kf.SelectedKeywords);
					if (!ii.WriteThumbnailData())
						failure = true;
					else
						lvi.SubItems[(int) ListViewColumns.Keywords].Text = ii.KeywordString;
				}
				UpdateKeywords();
				if (failure)
					Microsoft.VisualBasic.Interaction.Beep();
			}

		}

		private void StretchContext_Click(object sender, System.EventArgs e)
		{
            System.Windows.Forms.MenuItem selectedItem = (MenuItem)sender;
            StretchTypes sType = Utilities.ParseStretchType(selectedItem.Text);

            List<ListViewItem> selectedLVIs = GetSelectedListViewItems(sender);

            if (sType == StretchTypes.ScaleFactor)
            {
                ScaleEntryForm sef = new ScaleEntryForm();

                if (selectedLVIs.Count == 1)
                    sef.ScaleFactor = GetImageItem((ImageID)selectedLVIs[0].Tag).ScaleFactor;

                bool failure = false;

                if (sef.ShowDialog() == DialogResult.OK)
                {
                    foreach (ListViewItem lvi in selectedLVIs)
                    {
                        lvi.SubItems[(int)ListViewColumns.ScaleFactor].Text = sef.ScaleFactor.ToString("#0.00");
                        ImageItem ii = GetImageItem((ImageID)lvi.Tag);
                        ii.ScaleFactor = sef.ScaleFactor;
                        if (!ii.WriteThumbnailData())
                            failure = true;
                    }
                    if (failure)
                    {
                        Microsoft.VisualBasic.Interaction.Beep();
                        return;
                    }
                }
            }

			if (!ChangeContextProperty(selectedLVIs, ContextProperties.StretchType, sType))
				MessageBox.Show("There were errors updating the thumbnail file(s)", "Error");

            // repaint the preview image, if necessary
            if (_preview != null)
            {
                _preview.Refresh();
                _preview.Focus();
                if (((ContextMenu)((MenuItem)((MenuItem)sender).Parent).Parent).SourceControl.Name != "PreviewForm")
                    Focus();
            }
		}

		private void DisplayTextContext_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.MenuItem selectedItem = (MenuItem) sender;

			ThreeWayFlags displayText = Utilities.ParseThreeWayFlag(selectedItem.Text);
			ChangeContextProperty(this._listViewImages.SelectedItems, ContextProperties.DisplayTextFlag, displayText);
	
		}

		private void IncludeFlagContext_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.MenuItem selectedItem = (MenuItem) sender;
		
			IncludeFlags includeText = Utilities.ParseIncludeFlag(selectedItem.Text);   
			ChangeContextProperty(this._listViewImages.SelectedItems, ContextProperties.IncludeFlag, includeText);

		}

		#endregion	// context menu events

		#region ListView Events

        private void _listViewImages_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string colName = _listViewImages.Columns[e.Column].Text.ToLower();
            bool isDate = (colName.IndexOf("date") != -1 || colName.IndexOf("modified") != -1);
            if (_listViewImages.Columns[e.Column].Text.IndexOf(TSOP.UI.ListViewItemComparer.DownArrow) != -1)
            {
                RemoveAllSortIndicators(_listViewImages);
                _listViewImages.ListViewItemSorter = new TSOP.UI.ListViewItemComparer(e.Column, true, isDate);
                _listViewImages.Columns[e.Column].Text += TSOP.UI.ListViewItemComparer.UpArrow;
            }
            else
            {
                RemoveAllSortIndicators(_listViewImages);
                _listViewImages.ListViewItemSorter = new TSOP.UI.ListViewItemComparer(e.Column, false, isDate);
                _listViewImages.Columns[e.Column].Text += TSOP.UI.ListViewItemComparer.DownArrow;
            }


        }

        private void RemoveAllSortIndicators(ListView lv)
        {
            foreach (ColumnHeader col in lv.Columns)
            {
                col.Text = col.Text.Replace(TSOP.UI.ListViewItemComparer.DownArrow, "").Replace(TSOP.UI.ListViewItemComparer.UpArrow, "");
            }
        }

        private void _listViewScripts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateImagesList();
		}

        private void _listViewImages_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Promote(true);
                    e.Handled = true;
                    break;
                case Keys.Right:
                    Promote(false);
                    e.Handled = true;
                    break;
            }
        }

		private void _listViewImages_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (_imageIndex <= _listViewImages.Items.Count - 2 && _listViewImages.SelectedIndices.Count > 0)
                    {
                        CleanupImageMemory();
                        _imageIndex = _listViewImages.SelectedIndices[_listViewImages.SelectedIndices.Count - 1];
                        if (_preview != null)
                            _preview.Refresh();
                    }
                    else
                        Microsoft.VisualBasic.Interaction.Beep();
                    WriteDiagnostics();
                    break;
                case Keys.Up:
                    if (_imageIndex > 0 && _listViewImages.SelectedIndices.Count > 0)
                    {
                        CleanupImageMemory();
                        _imageIndex = _listViewImages.SelectedIndices[_listViewImages.SelectedIndices.Count - 1];
                        if (_preview != null)
                            _preview.Refresh();
                    }
                    else
                        Microsoft.VisualBasic.Interaction.Beep();
                    WriteDiagnostics();
                    break;
                case Keys.Delete:
                    RemoveFiles();
                    break;
                case Keys.A:
                    if (e.Control)
                        SelectAll();
                    break;
            }
		}

		private void _listViewImages_Click(object sender, System.EventArgs e)
		{
            if (_listViewImages.SelectedIndices.Count > 0 && _listViewImages.SelectedIndices[_listViewImages.SelectedIndices.Count - 1] != _imageIndex)
            {
                if (_preview != null)
                {
                    CleanupImageMemory();
                    _imageIndex = _listViewImages.SelectedIndices[_listViewImages.SelectedIndices.Count - 1];
                    _preview.Refresh();
                }
            }
            WriteDiagnostics();
        }

		#endregion		// listview events

        #region BackgroundWorker Events

        private void backgroundWorkerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (_lastFileName == StringConstants.REGISTRY_FILENAME)    
            {
                _configFile = new ConfigFile(true);
                if (!_configFile.LoadFromRegistry())    // todo: add progress reporting
                    MessageBox.Show("Error loading registry", "Error");
            }
            else
            {
                _configFile = new ConfigFile(this._lastFileName);
                if (!_configFile.Load(new ProgressChangedEventHandler(UpdateLoadProgress)))
                    MessageBox.Show("Error opening file", "Error");
             }

         }

        private void UpdateLoadProgress(int percent)
        {
            backgroundWorkerLoad.ReportProgress(percent);
        }

        private void backgroundWorkerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PopulateControls();
            UpdateKeywords();
            Cursor.Current = Cursors.Default;
            DisableControls(ControlSets.All, true);
            if (_lastFileName != StringConstants.REGISTRY_FILENAME)    
                _regSettings.AddMRUFile(_lastFileName);
            BuildMRUList();
            progressBarStatus.Value = 100;
            this.Text = CurrentConfigFile.FileName;
        }

        private void backgroundWorkerLoad_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarStatus.Value = e.ProgressPercentage;
        }

        #endregion  

		#region ISlideShowForm Members

		public void PreviousImage()
		{
			SaveThumbnailChanges();
			if (_imageIndex > 0)
			{
                CleanupImageMemory();
                //_suppressImageChangedEvent = true;
				_listViewImages.Items[_imageIndex].Selected = false;
				_imageIndex--;
				_listViewImages.Items[_imageIndex].Selected = true;
				_listViewImages.Select();
                //_suppressImageChangedEvent = false;
			}
			else
				Microsoft.VisualBasic.Interaction.Beep();
            WriteDiagnostics();
		}

		public void NextImage()
		{
			SaveThumbnailChanges();
			if (_imageIndex <= _listViewImages.Items.Count - 2)
			{
                CleanupImageMemory();
                //_suppressImageChangedEvent = true;
				_listViewImages.Items[_imageIndex].Selected = false;
				_imageIndex++;
				_listViewImages.Items[_imageIndex].Selected = true;
				_listViewImages.Select();
                //_suppressImageChangedEvent = false;
			}
			else
				Microsoft.VisualBasic.Interaction.Beep();
            WriteDiagnostics();
		}

		public ImageItem GetCurrentImageItem()
		{
			if (_listViewImages.Items.Count == 0)
				return null;
			else
				if (_imageIndex >= 0)
					return GetImageItem((ImageID)_listViewImages.Items[_imageIndex].Tag);
				else
					return null;
		}

		public void ClosePreview()
		{
			_toolBar.Buttons[(int)ToolBarButtons.Preview].Pushed = false;
			// Save any updates to the thumbnail file
			SaveThumbnailChanges();

		}

		public void UpdateOffset(int X, int Y)
		{
			ImageItem ii = GetCurrentImageItem();
            if (ii == null) return;
                Point currOff = ii.Offset;
                ii.Offset = new Point(currOff.X + X, currOff.Y + Y);
                ii.ChangesMade = true;
                _listViewImages.Items[_imageIndex].SubItems[(int)ListViewColumns.Offset].Text = TSOP.Utilities.GetPointString(ii.Offset);
 		}

		public void UpdateScaleFactor(bool increase)
		{
			ImageItem ii = GetCurrentImageItem();
            if (ii == null) return;
			if (increase)
				ii.ScaleFactor += 0.10f;
			else
				ii.ScaleFactor -= 0.10f;
			
			// make the stretch type scale factor in case it isn't already
			ii.StretchType = StretchTypes.ScaleFactor;	
			_listViewImages.Items[_imageIndex].SubItems[(int) ListViewColumns.StretchFlag].Text = Utilities.GetStretchTypeString(StretchTypes.ScaleFactor);

			ii.ChangesMade = true;
			_listViewImages.Items[_imageIndex].SubItems[(int) ListViewColumns.ScaleFactor].Text = ii.ScaleFactor.ToString("#0.00");
		}

		#endregion

        #region Misc Events

        private void SlideShowSetupForm_ResizeEnd(object sender, EventArgs e)
        {
            if (_listViewScripts.Width > 300)
                _listViewScripts.Columns[0].Width = _listViewScripts.Width - 10;
            else
                _listViewScripts.Columns[0].Width = 300;

            foreach (ListViewItem lvi in _listViewScripts.Items)
            {
                lvi.Text = TSOP.Utilities.TruncateString(lvi.Tag.ToString(),
                    (float)_listViewScripts.Columns[0].Width,
                    _listViewScripts.Font,
                    _formGraphics);
            }
        }

        private void _cboDefaultStretch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cboDefaultStretch.SelectedText == "")
                CurrentConfigFile.StretchDefault = StretchTypes.NoStretch;
            else
                CurrentConfigFile.StretchDefault = (StretchTypes)Enum.Parse(typeof(StretchTypes), _cboDefaultStretch.SelectedText);
        }

        #endregion

        #region Helper Methods

        // todo: apply this method everywhere that context menu operations are performed on listview items
        private List<ListViewItem> GetSelectedListViewItems(object sender)
        {
            List<ListViewItem> selectedImageItems = new List<ListViewItem>();

            // if the sender is the preview form, only apply the change to the displayed image item
//            if (((ContextMenu)((MenuItem)sender).Parent).SourceControl.Name == "PreviewForm")
            if (((MenuItem)sender).GetContextMenu().SourceControl.Name == "PreviewForm")
            {
                selectedImageItems.Add(_listViewImages.Items[_imageIndex]);
                return selectedImageItems;
            }
            else
            {
                foreach (ListViewItem lvi in _listViewImages.SelectedItems)
                    selectedImageItems.Add(lvi);
                return selectedImageItems;
            }

        }

        private void SelectAll()
        {
            _listViewImages.BeginUpdate();

            foreach (ListViewItem lvi in _listViewImages.Items)
            {
                lvi.Selected = true;
            }

            _listViewImages.EndUpdate();
        }

        private void RescanThumbnails()
        {
            if (_listViewImages.SelectedItems.Count == 0)
            {
                MessageBoxes.ShowWarning(StringConstants.GetString(StringNames.IMAGES_NONE_SELECTED));
                return;
            }

            foreach (ListViewItem lvi in _listViewImages.SelectedItems)
            {
                ImageItem ii = GetImageItem((ImageID)lvi.Tag);
                ii.ReadThumbnailDataFromFile();
            }

            PopulateImagesList();
        }

        private void CopyImageFiles(bool copy)
        {
            CopyDel copyMethod;
            string verb;
            if (copy)
            {
                copyMethod = new CopyDel(Utilities.TryCopy);
                verb = "Copy";
            }
            else
            {
                copyMethod = new CopyDel(Utilities.TryMove);
                verb = "Move";
            }

            List<string> errorMsgs = new List<string>();
            // build a list of unique source filenames
            List<string> srcFiles = new List<string>();
            foreach (ListViewItem lvi in _listViewImages.SelectedItems)
            {
                string srcPath = System.IO.Path.Combine(lvi.SubItems[(int) ListViewColumns.FilePath].Text, lvi.SubItems[(int) ListViewColumns.FileName].Text);
                if (!srcFiles.Contains(srcPath))
                    srcFiles.Add(srcPath);
            }

            // prompt the user for the destination directory
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Select the destination folder";
            dlg.SelectedPath = _regSettings.GetCopyToDir();
            dlg.ShowNewFolderButton = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (RememberFolders)
                    _regSettings.SetCopyToDir(dlg.SelectedPath);
                string destPath;
                if (!copy && MessageBoxes.ShowConfirm("Are you sure you want to move the selected file(s)?") != DialogResult.Yes)
                    return;
                foreach (string srcPath in srcFiles)
                {
                    destPath = System.IO.Path.Combine(dlg.SelectedPath, System.IO.Path.GetFileName(srcPath));
                    if (!copyMethod(srcPath, destPath))
                        errorMsgs.Add(String.Format("Failed to {0} {1}", verb, srcPath));
                }
                if (errorMsgs.Count == 0)
                {
                    _lblStatusMessage.Text = verb + " successful";
                }
                else
                {
                    _lblStatusMessage.Text = verb + " exceptions encountered";
                    MessageBoxes.ShowInfo("The following exceptions occured:", errorMsgs.ToArray());
                }
                // if moved, remove the entries from the listview
                if (!copy)
                    RemoveFiles();
            }
            //todo: make this more robust.  if some succeed and some fail, only remove the successful ones

        }

        private void DeleteImageFiles()
        {
            if (MessageBoxes.ShowConfirm("Are you sure you want to delete the selected files?") != DialogResult.Yes)
                return;

            List<string> errorMsgs = new List<string>();

            // build a list of unique source filenames
            List<string> srcFiles = new List<string>();
            foreach (ListViewItem lvi in _listViewImages.SelectedItems)
            {
                string srcPath = System.IO.Path.Combine(lvi.SubItems[(int)ListViewColumns.FilePath].Text, lvi.SubItems[(int)ListViewColumns.FileName].Text);
                if (!srcFiles.Contains(srcPath))
                    srcFiles.Add(srcPath);
            }

            foreach (string srcPath in srcFiles)
            {
                if (!Utilities.TryDelete(srcPath))
                    errorMsgs.Add(String.Format("Failed to Delete {0}", srcPath));
            }
            if (errorMsgs.Count == 0)
            {
                _lblStatusMessage.Text = "Delete successful";
            }
            else
            {
                _lblStatusMessage.Text = "Delete exceptions encountered";
                MessageBoxes.ShowInfo("The following exceptions occured:", errorMsgs.ToArray());
            }

            RemoveFiles();
            //todo: make this more robust.  if some succeed and some fail, only remove the successful ones

        }

        private void CleanupImageMemory()
        {
            ImageItem i = GetCurrentImageItem();
            if (i != null)
                i.UnloadImageObject();
        }

		private void RemoveFiles()
		{
            // can't just walk backward throught the selected indices because the ID indices may not be in the same order
            ArrayList Tags = new ArrayList(_listViewImages.SelectedItems.Count);
            for (int i = 0; i < _listViewImages.SelectedItems.Count; i++)
            {
                Tags.Add(((ImageID)((ListViewItem)_listViewImages.SelectedItems[i]).Tag));

            }
            Tags.Sort();
            for (int i = Tags.Count - 1; i >= 0; i--)
            {
                ImageID id = (ImageID)Tags[i];
                ScriptFile sf = CurrentConfigFile.ScriptFileList.GetScriptByName(id.ScriptFile);
                sf.ImageItemCollection.RemoveImageItem(id.Index);
                if (i < _imageIndex)
                    _imageIndex--;
            }
            PopulateImagesList();
            UpdateKeywords();
		}

        private void AddFilesBySearch(bool recursive)
        {
            if (_listViewScripts.SelectedItems.Count == 0)
            {
                MessageBoxes.ShowError(StringConstants.GetString(StringNames.SCRIPT_NOT_SELECTED));
                return;
            }

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = _regSettings.GetOpenDir();

            System.IO.SearchOption opt = recursive ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                if (RememberFolders)
                    _regSettings.SetOpenDir(dlg.SelectedPath);
                ArrayList notAdded = new ArrayList();
                float scriptProgressInterval = 100 / _listViewScripts.SelectedIndices.Count;
                ArrayList allFiles = new ArrayList();
                allFiles.AddRange(System.IO.Directory.GetFiles(dlg.SelectedPath, "*.JPG", opt));
                allFiles.AddRange(System.IO.Directory.GetFiles(dlg.SelectedPath, "*.BMP", opt));
                allFiles.AddRange(System.IO.Directory.GetFiles(dlg.SelectedPath, "*.GIF", opt));
                int fileCount = allFiles.Count;
                float fileProgressInterval = scriptProgressInterval / fileCount;
                allFiles.Sort();
                for (int i = 0; i < _listViewScripts.SelectedItems.Count; i++)
                {
                   String scriptName = CurrentConfigFile.ScriptFileList[_listViewScripts.SelectedIndices[i]].PathAndFileName;
                   ScriptFile sf = CurrentConfigFile.ScriptFileList.GetScriptByName(scriptName);

                   int fileIndex = 0;
                   foreach (string fileName in allFiles)
                   {
                        ImageItem ii = new ImageItem(fileName);
                        if (LoadThumbnailData)
                            ii.ReadThumbnailDataFromFile();
                        if (sf.ImageItemCollection.AddImageItem(ref ii) == -1)
                            notAdded.Add(ii.PathAndFileName);
                        progressBarStatus.Value = (int)Math.Round(((i * scriptProgressInterval) + ((fileIndex + 1) * fileProgressInterval)));
                        fileIndex++;
                   }
                }
                PopulateImagesList();
                UpdateKeywords();
                if (notAdded.Count > 0)
                {
                    string[] items = new string[notAdded.Count];
                    notAdded.CopyTo(items);
                    MessageBoxes.ShowInfo(StringConstants.GetString(StringNames.DUPLICATE_IMAGES_NOT_ADDED), items);
                }
            }
        }

		private void AddFiles()
		{
            if (_listViewScripts.SelectedItems.Count == 0)
            {
                MessageBoxes.ShowError(StringConstants.GetString(StringNames.SCRIPT_NOT_SELECTED));
                return;
            }

			OpenFileDialog dlg = new OpenFileDialog();
			dlg.InitialDirectory = _regSettings.GetOpenDir();
			dlg.Multiselect = true;
			dlg.RestoreDirectory = true;
			dlg.Filter = "All Image Files|*.JPG; *.JPEG; *.JPE; *.JFIF; *.GIF; *BMP|JPEG (*.JPG, *.JPEG, *.JPE, *.JFIF)|*.JPG; *.JPEG; *.JPE; *.JFIF|GIF (*.GIF)|*.GIF|Bitmap (*.BMP)|*.BMP";   

 			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				if (RememberFolders)
					_regSettings.SetOpenDir(System.IO.Path.GetDirectoryName(dlg.FileName));
                ArrayList notAdded = new ArrayList();
                float scriptProgressInterval = 100 / _listViewScripts.SelectedIndices.Count;
                float fileProgressInterval = scriptProgressInterval / dlg.FileNames.GetLength(0);
 				for (int i = 0; i < _listViewScripts.SelectedItems.Count; i++)
				{
					String scriptName = CurrentConfigFile.ScriptFileList[_listViewScripts.SelectedIndices[i]].PathAndFileName;
					ScriptFile sf = CurrentConfigFile.ScriptFileList.GetScriptByName(scriptName);

                    for (int j = 0; j < dlg.FileNames.GetLength(0); j++)
					{
                       ImageItem ii = new ImageItem(dlg.FileNames[j]);
						if (LoadThumbnailData)
							ii.ReadThumbnailDataFromFile();
						if (sf.ImageItemCollection.AddImageItem(ref ii) == -1)
                            notAdded.Add(ii.PathAndFileName);
                        progressBarStatus.Value = (int) Math.Round(((i * scriptProgressInterval) + ((j + 1) * fileProgressInterval)));
 					}
				}
				PopulateImagesList();
                UpdateKeywords();
                if (notAdded.Count > 0)
                {
                    string[] items = new string[notAdded.Count];
                    notAdded.CopyTo(items);
                    MessageBoxes.ShowInfo(StringConstants.GetString(StringNames.DUPLICATE_IMAGES_NOT_ADDED), items);
                }
			}
		}

		private void SaveThumbnailChanges()
		{

			ImageItem ii = GetCurrentImageItem();
			if (ii == null) return;
			if (ii.ChangesMade) 
				if (!ii.WriteThumbnailData())
					Microsoft.VisualBasic.Interaction.Beep();
				else
					ii.ChangesMade = false;

		}

		private void PopulateImagesList()
		{
            // todo: if any items were selected, save the selections, then after re-populating, re-select any items that still exist
            // should probably add a parameter to disable this feature
 			_listViewImages.Items.Clear();
            Cursor.Current = Cursors.WaitCursor;
            _listViewImages.BeginUpdate();

			for (int i = 0; i < _listViewScripts.SelectedIndices.Count; i++)
			{

				String scriptName = CurrentConfigFile.ScriptFileList[_listViewScripts.SelectedIndices[i]].PathAndFileName;
				ScriptFile sf = CurrentConfigFile.ScriptFileList.GetScriptByName(scriptName);

				//foreach (ImageItem ii in sf.ImageItemCollection)
                ListViewItem[] lvItems = new ListViewItem[sf.ImageItemCollection.Count];
                for (int index = 0; index < sf.ImageItemCollection.Count; index++)
				{
                    ImageItem ii = (ImageItem) sf.ImageItemCollection[index];
					ListViewItem lvi = new ListViewItem(new String[] {
																		 Utilities.GetIncludeFlagString(ii.IncludeFlag),
																		 ii.FileName, 
																		 ii.KeywordString, 
																		 ii.FilePath, 
																		 Utilities.GetStretchTypeString(ii.StretchType), 
																		 Utilities.GetThreeWayFlagString(ii.TextDisplayFlag),
																		 TSOP.Utilities.GetPointString(ii.Offset),
																		 ii.ScaleFactor.ToString("#0.00"),
																		 ii.CreateDateStr,
																		 ii.ModifyDateStr
																	 });
					lvi.Tag = new ImageID(scriptName, ii.Index);
					lvi.ForeColor = ColorArray.GetAt(_listViewScripts.SelectedIndices[i]);
                    // TODO: this is not staying, window needs to be repainted to see the colors
					//_listViewImages.Items.Add(lvi);
                    lvItems[index] = lvi;
				}
                _listViewImages.Items.AddRange(lvItems);
			}
 
            _listViewImages.EndUpdate();
            Cursor.Current = Cursors.Default;
			//_listViewImages.Refresh();

            CleanupImageMemory();
            _lblImageCount.Text = String.Format("{0} Images", _listViewImages.Items.Count);
			_imageIndex = -1;

		}

        private DialogResult ShowSaveScriptDialog(out SaveFileDialog dlg)
        {
            dlg = new SaveFileDialog();
            dlg.Title = "Enter Script Filename";
            dlg.OverwritePrompt = true;
            dlg.Filter = "Script Files|*.sss";
            return dlg.ShowDialog();
        }

		#endregion

        #region ToolBar Events

        private void _toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (_toolBar.Buttons.IndexOf(e.Button))
			{
				case (int) ToolBarButtons.Preview:
					if (e.Button.Pushed)
					{
                        CleanupImageMemory();
						if (_listViewImages.SelectedItems.Count > 0)
							_imageIndex = _listViewImages.SelectedIndices[0];
						else
							_imageIndex = 0;
						_preview = new PreviewForm(this);
						_preview.Show();
					}
					else
					{
						_preview.Close();
					}
					break;
                case (int) ToolBarButtons.Scan:
                    RescanThumbnails();
                    break;
                case (int) ToolBarButtons.New:
                    _menuItemFile_New_Click(sender, e);
                    break;
                case (int) ToolBarButtons.Open:
                    _menuItemFile_Open_Click(sender, e);
                    break;
                case (int) ToolBarButtons.Save:
                     _menuItemFile_Save_Click(sender, e);
                     break;
			}
        }

        #endregion

        #region Button Events

        private void _btnScriptRemove_Click(object sender, EventArgs e)
        {
            if (_listViewScripts.SelectedIndices.Count == 0)
            {
                MessageBoxes.ShowWarning(StringConstants.GetString(StringNames.SCRIPT_NOT_SELECTED));
                return;
            }

            for (int i = _listViewScripts.SelectedIndices.Count - 1; i >= 0; i--)
            {
                CurrentConfigFile.ScriptFileList.RemoveAt(_listViewScripts.SelectedIndices[i]);
            }

            PopulateControls();
            UpdateKeywords();

        }

        private void _btnScriptDelete_Click(object sender, EventArgs e)
        {
            if (_listViewScripts.SelectedIndices.Count == 0)
            {
                MessageBoxes.ShowWarning(StringConstants.GetString(StringNames.SCRIPT_NOT_SELECTED));
                return;
            }

            try
            {
                for (int i = _listViewScripts.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    string filename = (string)_listViewScripts.Items[_listViewScripts.SelectedIndices[i]].Tag;
                    System.IO.File.Delete(filename);
                    _lblStatusMessage.Text = StringConstants.GetString(StringNames.SCRIPT_DELETE_SUCCEEDED);
                    CurrentConfigFile.ScriptFileList.Remove(CurrentConfigFile.ScriptFileList.GetScriptByName(filename));
                 }

                 PopulateControls();
                 UpdateKeywords();
             }
             catch 
             {
                 MessageBoxes.ShowError(StringConstants.GetString(StringNames.SCRIPT_DELETE_FAILED));
             }

        }

        private void _btnScriptNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg;
            if (ShowSaveScriptDialog(out dlg) == DialogResult.OK)
            {
                ScriptFile sf = new ScriptFile(dlg.FileName);
                CurrentConfigFile.ScriptFileList.Add(sf);
                PopulateControls();
            }
        }

        private void _buttonScriptAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Script File";
            dlg.Filter = "Script Files|*.sss";
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ScriptFile sf = new ScriptFile(dlg.FileName);
                if (!sf.Load(LoadThumbnailData))
                    MessageBoxes.ShowError(StringConstants.GetString(StringNames.SCRIPT_LOAD_FAILED));
                else
                {
                    _lblStatusMessage.Text = StringConstants.GetString(StringNames.SCRIPT_LOAD_SUCCEEDED);
                    CurrentConfigFile.ScriptFileList.Add(sf);
                    PopulateControls();
                    UpdateKeywords();
                }
            }

        }

        private void _btnScriptSave_Click(object sender, EventArgs e)
        {
            if (_listViewScripts.SelectedIndices.Count == 0)
            {
                MessageBoxes.ShowWarning(StringConstants.GetString(StringNames.SCRIPT_NOT_SELECTED));
                return;
            }

            foreach (int index in _listViewScripts.SelectedIndices)
            {
                string filename = (string) _listViewScripts.Items[index].Tag;
                ScriptFile sf = CurrentConfigFile.ScriptFileList.GetScriptByName(filename);
                if (!sf.Save())
                    MessageBoxes.ShowError(StringConstants.GetString(StringNames.SCRIPT_SAVE_FAILED));
                else
                    _lblStatusMessage.Text = StringConstants.GetString(StringNames.SCRIPT_SAVE_SUCCEEDED);
            }
        }

        private void _btnScriptSaveAs_Click(object sender, EventArgs e)
        {
            if (_listViewScripts.SelectedIndices.Count == 0)
            {
                MessageBoxes.ShowWarning(StringConstants.GetString(StringNames.SCRIPT_NOT_SELECTED));
                return;
            }

            if (_listViewScripts.SelectedIndices.Count > 1)
            {
                MessageBoxes.ShowWarning(StringConstants.GetString(StringNames.SCRIPT_MULTI_SELECTED));
                return;
            }

            SaveFileDialog dlg;
            if (ShowSaveScriptDialog(out dlg) == DialogResult.OK)
            {
                ScriptFile sf = CurrentConfigFile.ScriptFileList.GetScriptByName((string) _listViewScripts.SelectedItems[0].Tag);
                ScriptFile newSF = new ScriptFile(sf, dlg.FileName);
                if (!newSF.Save())
                    MessageBoxes.ShowError(StringConstants.GetString(StringNames.SCRIPT_SAVE_FAILED));
                else
                    _lblStatusMessage.Text = StringConstants.GetString(StringNames.SCRIPT_SAVE_SUCCEEDED);
            }
        }

        #endregion

        // todo: find a permanent home for this method.  Utilities?
        private void WriteDiagnostics()
        {
            if (_listViewImages.SelectedItems.Count == 0)
                return;

            System.Diagnostics.StackFrame frame = (new System.Diagnostics.StackTrace()).GetFrame(1);
            System.Reflection.MethodBase method = frame.GetMethod();
            System.Diagnostics.Debug.WriteLine("*** " + method.DeclaringType.Name + " - " + method.Name + " ***");

            for (int i = 0; i < _listViewImages.SelectedIndices.Count; i++)
            {
                ImageID iid = (ImageID)_listViewImages.SelectedItems[i].Tag;
                ImageItem ii = GetImageItem(iid);

                System.Text.StringBuilder sBldr = new System.Text.StringBuilder("Selected[" + i + "]: ");
                sBldr.Append("_imageIndex = " + _imageIndex.ToString());
                sBldr.Append(": ImageID = " + iid.ScriptFile + " " + iid.Index);
                sBldr.Append(": LV Index = " + _listViewImages.SelectedIndices[i].ToString());
                sBldr.Append(": FileName = " + ii.FileName);
                sBldr.Append(": KW = " + ii.KeywordString);
                System.Diagnostics.Debug.WriteLine(sBldr.ToString());
            }
 
        }

        private enum ControlSets
		{
			All
		}

		private enum ContextProperties
		{
			StretchType,
			DisplayTextFlag,
			IncludeFlag
		}

		private enum ListViewColumns
		{
			IncludeFlag = 0,
			FileName = 1,
			Keywords = 2,
			FilePath = 3,
			StretchFlag = 4,
			DisplayTextFlag = 5,
			Offset = 6,
			ScaleFactor = 7,
			CreateDate = 8,
			ModifyDate = 9
		}

		private enum ToolBarButtons
		{
			New = 0,
			Open = 1,
			Save = 2,
			Preview = 3,
            Scan = 4
		}


   	}

	public struct ImageID : IComparable
	{
		public ImageID(string scriptFile, int index)
		{
			ScriptFile = scriptFile;
			Index = index;
		}

		public string ScriptFile;
		public int Index;

        public int CompareTo(object obj)
        {
            ImageID idObj = (ImageID) obj;
            if (ScriptFile == idObj.ScriptFile)
            {
                return Index.CompareTo(idObj.Index);
            }
            else
                return ScriptFile.CompareTo(idObj.ScriptFile);
        }
	}

    

}
