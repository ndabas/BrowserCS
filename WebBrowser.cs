namespace ND.WebBrowser
{
  
  using System;
  using System.Drawing;
  using System.ComponentModel;
  using System.Windows.Forms;
  using Microsoft.Win32;
  using AxSHDocVw;
  using MSHTML;
  
  public class WebBrowserForm : Form
  {
    private System.Resources.ResourceManager Resourcer;
    private AxWebBrowser AxWebBrowser;
    private MainMenu MenuMain;
    private StatusBarPanel StatusSecure;
    private StatusBarPanel StatusZone;
    private StatusBarPanel StatusOffline;
    private StatusBarPanel StatusProgress;
    private StatusBarPanel StatusMessages;
    private StatusBar BarStatus;
    private ToolBarButton TbEdit;
    private ToolBarButton TbSeperator3;
    private ToolBarButton TbPrint;
    private ToolBarButton TbMail;
    private ToolBarButton TbSeperator2;
    private ToolBarButton TbHistory;
    private ToolBarButton TbFavorites;
    private ToolBarButton TbSearch;
    private ToolBarButton TbSeperator1;
    private ToolBarButton TbHome;
    private ToolBarButton TbRefresh;
    private ToolBarButton TbStop;
    private ToolBarButton TbForward;
    private ToolBarButton TbBack;
    private ToolBar BarStandardToolbar;
    private ImageList ImagesToolbar;
    private ComboBox ComboAddress;
    private Button ButtonGo;
    private Label LabelAddress;
    private Panel BarAddress;

    public WebBrowserForm()
    {
      InitializeComponent();
    }
    
    [STAThread]
    public static void Main(string[] args)
    {
      Application.Run(new WebBrowserForm());
    }
    
    private void InitializeComponent()
    {
      this.Resourcer = new System.Resources.ResourceManager(typeof(WebBrowserForm));
      this.AxWebBrowser = new AxWebBrowser();
      this.MenuMain = new MainMenu();
      this.BarStatus = new StatusBar();
      this.StatusZone = new StatusBarPanel();
      this.StatusSecure = new StatusBarPanel();
      this.StatusProgress = new StatusBarPanel();
      this.StatusOffline = new StatusBarPanel();
      this.StatusMessages = new StatusBarPanel();
      this.TbStop = new ToolBarButton();
      this.TbSeperator3 = new ToolBarButton();
      this.TbSeperator2 = new ToolBarButton();
      this.TbSeperator1 = new ToolBarButton();
      this.TbPrint = new ToolBarButton();
      this.TbFavorites = new ToolBarButton();
      this.TbBack = new ToolBarButton();
      this.TbForward = new ToolBarButton();
      this.TbHome = new ToolBarButton();
      this.ImagesToolbar = new ImageList();
      this.TbEdit = new ToolBarButton();
      this.TbHistory = new ToolBarButton();
      this.TbSearch = new ToolBarButton();
      this.TbRefresh = new ToolBarButton();
      this.TbMail = new ToolBarButton();
      this.BarStandardToolbar = new ToolBar();
      this.BarAddress = new Panel();
      this.ButtonGo = new Button();
      this.ComboAddress = new ComboBox();
      this.LabelAddress = new Label();
      
      AxWebBrowser.BeginInit();
      
      StatusProgress.MinWidth = 0;
      StatusProgress.Style = StatusBarPanelStyle.OwnerDraw;
      
      StatusOffline.MinWidth = 20;
      StatusOffline.Width = 20;
      
      StatusMessages.MinWidth = 100;
      StatusMessages.Width = 136;
      StatusMessages.AutoSize = StatusBarPanelAutoSize.Spring;
      
      StatusZone.MinWidth = 136;
      StatusZone.Width = 136;
            
      StatusSecure.MinWidth = 20;
      StatusSecure.Width = 20;
      
      BarStatus.Dock = DockStyle.Bottom;
      BarStatus.BackColor = System.Drawing.SystemColors.Control;
      BarStatus.Location = new System.Drawing.Point(0, 297);
      BarStatus.Size = new System.Drawing.Size(392, 20);
      BarStatus.TabIndex = 0;
      BarStatus.ShowPanels = true;
      BarStatus.PanelClick += new StatusBarPanelClickEventHandler(barStatus_PanelClick);
      BarStatus.DrawItem += new StatusBarDrawItemEventHandler(barStatus_DrawItem);
      BarStatus.Panels.Add(StatusMessages);
      BarStatus.Panels.Add(StatusProgress);
      BarStatus.Panels.Add(StatusOffline);
      BarStatus.Panels.Add(StatusSecure);
      BarStatus.Panels.Add(StatusZone);
            
      AxWebBrowser.Size = new System.Drawing.Size(392, 296);
      AxWebBrowser.TabIndex = 1;
      //AxWebBrowser.Anchor = AnchorStyles.All;
      AxWebBrowser.Dock = DockStyle.Fill;
      AxWebBrowser.StatusTextChange += new DWebBrowserEvents2_StatusTextChangeEventHandler(AxWebBrowser_StatusTextChange);
      //AxWebBrowser.ProgressChange += new DWebBrowserEvents2_ProgressChangeEventHandler(AxWebBrowser_ProgressChange);
      //AxWebBrowser.PropertyChange += new DWebBrowserEvents2_PropertyChangeEventHandler(AxWebBrowser_PropertyChange);
      //AxWebBrowser.WindowSetTop += new DWebBrowserEvents2_WindowSetTopEventHandler(AxWebBrowser_WindowSetTop);
      //AxWebBrowser.WindowClosing += new DWebBrowserEvents2_WindowClosingEventHandler(AxWebBrowser_WindowClosing);
      //AxWebBrowser.NavigateComplete2 += new DWebBrowserEvents2_NavigateComplete2EventHandler(AxWebBrowser_NavigateComplete2);
      //AxWebBrowser.OnStatusBar += new DWebBrowserEvents2_OnStatusBarEventHandler(AxWebBrowser_OnStatusBar);
      //AxWebBrowser.WindowSetLeft += new DWebBrowserEvents2_WindowSetLeftEventHandler(AxWebBrowser_WindowSetLeft);
      //AxWebBrowser.DownloadBegin += new EventHandler(AxWebBrowser_DownloadBegin);
      AxWebBrowser.CommandStateChange += new DWebBrowserEvents2_CommandStateChangeEventHandler(AxWebBrowser_CommandStateChange);
      //AxWebBrowser.WindowSetHeight += new DWebBrowserEvents2_WindowSetHeightEventHandler(AxWebBrowser_WindowSetHeight);
      //AxWebBrowser.WindowSetResizable += new DWebBrowserEvents2_WindowSetResizableEventHandler(AxWebBrowser_WindowSetResizable);
      //AxWebBrowser.SetSecureLockIcon += new DWebBrowserEvents2_SetSecureLockIconEventHandler(AxWebBrowser_SetSecureLockIcon);
      AxWebBrowser.TitleChange += new DWebBrowserEvents2_TitleChangeEventHandler(AxWebBrowser_TitleChange);
      //AxWebBrowser.BeforeNavigate2 += new DWebBrowserEvents2_BeforeNavigate2EventHandler(AxWebBrowser_BeforeNavigate2);
      //AxWebBrowser.OnTheaterMode += new DWebBrowserEvents2_OnTheaterModeEventHandler(AxWebBrowser_OnTheaterMode);
      //AxWebBrowser.WindowSetWidth += new DWebBrowserEvents2_WindowSetWidthEventHandler(AxWebBrowser_WindowSetWidth);
      //AxWebBrowser.OnFullScreen += new DWebBrowserEvents2_OnFullScreenEventHandler(AxWebBrowser_OnFullScreen);
      //AxWebBrowser.OnQuit += new EventHandler(AxWebBrowser_OnQuit);
      //AxWebBrowser.DownloadComplete += new EventHandler(AxWebBrowser_DownloadComplete);
      //AxWebBrowser.ClientToHostWindow += new DWebBrowserEvents2_ClientToHostWindowEventHandler(AxWebBrowser_ClientToHostWindow);
      //AxWebBrowser.OnToolBar += new DWebBrowserEvents2_OnToolBarEventHandler(AxWebBrowser_OnToolBar);
      //AxWebBrowser.OnVisible += new DWebBrowserEvents2_OnVisibleEventHandler(AxWebBrowser_OnVisible);
      //AxWebBrowser.FileDownload += new DWebBrowserEvents2_FileDownloadEventHandler(AxWebBrowser_FileDownload);
      //AxWebBrowser.NewWindow2 += new DWebBrowserEvents2_NewWindow2EventHandler(AxWebBrowser_NewWindow2);
      //AxWebBrowser.OnMenuBar += new DWebBrowserEvents2_OnMenuBarEventHandler(AxWebBrowser_OnMenuBar);
      AxWebBrowser.DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(AxWebBrowser_DocumentComplete);
      
      MenuItem miFile = MenuMain.MenuItems.Add(Resourcer.GetString("MenuFile"));
      miFile.Popup += new EventHandler(mnuFile_Popup);
        MenuItem miFileNew = miFile.MenuItems.Add(Resourcer.GetString("MenuFileNew"));
          miFileNew.MenuItems.Add(Resourcer.GetString("MenuFileNewWindow"));
          //miFileNew.MenuItems.Add("-");
          //miFileNew.MenuItems.Add(Resourcer.GetString("MenuFileNewMessage"));
        miFile.MenuItems.Add(new MenuItem(Resourcer.GetString("MenuFileOpen"),
          new EventHandler(mnuFileOpen_Click), Shortcut.CtrlO));
        miFile.MenuItems.Add(Resourcer.GetString("MenuFileEdit"),
          new EventHandler(mnuFileEdit_Click));
        miFile.MenuItems.Add(new MenuItem(Resourcer.GetString("MenuFileSave"),
          new EventHandler(mnuFileSave_Click), Shortcut.CtrlS));
        miFile.MenuItems.Add(Resourcer.GetString("MenuFileSaveAs"),
          new EventHandler(mnuFileSaveAs_Click));
        miFile.MenuItems.Add("-");
        miFile.MenuItems.Add(Resourcer.GetString("MenuFilePageSetup"),
          new EventHandler(mnuFilePageSetup_Click));
        miFile.MenuItems.Add(new MenuItem(Resourcer.GetString("MenuFilePrint"),
          new EventHandler(mnuFilePrint_Click), Shortcut.CtrlP));
        miFile.MenuItems.Add(Resourcer.GetString("MenuFilePrintPreview"),
          new EventHandler(mnuFilePrintPreview_Click));
        miFile.MenuItems.Add("-");
        MenuItem miFileSend = miFile.MenuItems.Add(Resourcer.GetString("MenuFileSend"));
          miFileSend.MenuItems.Add(Resourcer.GetString("MenuFileSendPage"));
          miFileSend.MenuItems.Add(Resourcer.GetString("MenuFileSendLink"));
          miFileSend.MenuItems.Add(Resourcer.GetString("MenuFileSendShortcut"));
        miFile.MenuItems.Add(Resourcer.GetString("MenuFileImportExport"),
          new EventHandler(mnuFileImportExport_Click));
        miFile.MenuItems.Add("-");
        miFile.MenuItems.Add(Resourcer.GetString("MenuFileProperties"),
          new EventHandler(mnuFileProperties_Click));
        miFile.MenuItems.Add(Resourcer.GetString("MenuFileWorkOffline"),
          new EventHandler(mnuFileWorkOffline_Click));
        miFile.MenuItems.Add(Resourcer.GetString("MenuFileClose"),
          new EventHandler(mnuFileClose_Click));
      MenuItem miEdit = MenuMain.MenuItems.Add(Resourcer.GetString("MenuEdit"));
      miEdit.Popup += new EventHandler(mnuEdit_Popup);
        miEdit.MenuItems.Add(new MenuItem(Resourcer.GetString("MenuEditCut"),
          new EventHandler(mnuEditCut_Click), Shortcut.CtrlX));
        miEdit.MenuItems.Add(new MenuItem(Resourcer.GetString("MenuEditCopy"),
          new EventHandler(mnuEditCopy_Click), Shortcut.CtrlC));
        miEdit.MenuItems.Add(new MenuItem(Resourcer.GetString("MenuEditPaste"),
          new EventHandler(mnuEditPaste_Click), Shortcut.CtrlV));
        miEdit.MenuItems.Add("-");
        miEdit.MenuItems.Add(new MenuItem(Resourcer.GetString("MenuEditSelectAll"),
          new EventHandler(mnuEditSelectAll_Click), Shortcut.CtrlA));
        //miEdit.MenuItems.Add("-");
        //miEdit.MenuItems.Add(new MenuItem(Resourcer.GetString("MenuEditFind"),
          //new EventHandler(mnuEditFind_Click)));
      MenuItem miView = MenuMain.MenuItems.Add(Resourcer.GetString("MenuView"));
      miView.Popup += new EventHandler(mnuView_Popup);
        miView.MenuItems.Add(Resourcer.GetString("MenuViewToolbars"));
        miView.MenuItems.Add(Resourcer.GetString("MenuViewStatusBar"),
          new EventHandler(mnuViewStatusBar_Click));
        miView.MenuItems.Add("-");
        MenuItem miViewGoTo = miView.MenuItems.Add(Resourcer.GetString("MenuViewGoTo"));
          MenuItem miViewGoToBack = miViewGoTo.MenuItems.Add(Resourcer.GetString("MenuViewGoToBack"),
            new EventHandler(mnuViewGoToBack_Click));
            miViewGoToBack.Enabled = false;
          MenuItem miViewGoToForward = miViewGoTo.MenuItems.Add(Resourcer.GetString("MenuViewGoToForward"),
            new EventHandler(mnuViewGoToForward_Click));
            miViewGoToForward.Enabled = false;
          miViewGoTo.MenuItems.Add("-");
          miViewGoTo.MenuItems.Add(Resourcer.GetString("MenuViewGoToHomePage"),
            new EventHandler(mnuViewGoToHomePage_Click));
          miViewGoTo.MenuItems.Add(Resourcer.GetString("MenuViewGoToSearchPage"),
            new EventHandler(mnuViewGoToSearchPage_Click));
        miView.MenuItems.Add(Resourcer.GetString("MenuViewStop"),
          new EventHandler(mnuViewStop_Click));
        miView.MenuItems.Add(Resourcer.GetString("MenuViewRefresh"),
          new EventHandler(mnuViewRefresh_Click));
        miView.MenuItems.Add("-");
        MenuItem miViewTextSize = miView.MenuItems.Add(Resourcer.GetString("MenuViewTextSize"));
        miViewTextSize.Popup += new EventHandler(mnuViewTextSize_Popup);
          miViewTextSize.MenuItems.Add(Resourcer.GetString("MenuViewTextSizeLargest"),
            new EventHandler(mnuViewTextSizeLargest_Click));
          miViewTextSize.MenuItems.Add(Resourcer.GetString("MenuViewTextSizeLarger"),
            new EventHandler(mnuViewTextSizeLarger_Click));
          miViewTextSize.MenuItems.Add(Resourcer.GetString("MenuViewTextSizeMedium"),
            new EventHandler(mnuViewTextSizeMedium_Click));
          miViewTextSize.MenuItems.Add(Resourcer.GetString("MenuViewTextSizeSmaller"),
            new EventHandler(mnuViewTextSizeSmaller_Click));
          miViewTextSize.MenuItems.Add(Resourcer.GetString("MenuViewTextSizeSmallest"),
            new EventHandler(mnuViewTextSizeSmallest_Click));
        foreach(MenuItem mi in miViewTextSize.MenuItems)
          mi.RadioCheck = true;
        miView.MenuItems.Add("-");
        miView.MenuItems.Add(Resourcer.GetString("MenuViewSource"));
        miView.MenuItems.Add(Resourcer.GetString("MenuViewFullScreen"),
          new EventHandler(mnuViewFullScreen_Click));
      MenuItem miFavs = MenuMain.MenuItems.Add(Resourcer.GetString("MenuFavourites"));
      miFavs.Popup += new EventHandler(mnuFavourites_Popup);
        miFavs.MenuItems.Add(Resourcer.GetString("MenuFavouritesAdd"),
          new EventHandler(mnuFavouritesAdd_Click));
        miFavs.MenuItems.Add(Resourcer.GetString("MenuFavouritesOrganise"),
          new EventHandler(mnuFavouritesOrganise_Click));
      MenuItem miTools = MenuMain.MenuItems.Add(Resourcer.GetString("MenuTools"));
        miTools.MenuItems.Add(Resourcer.GetString("MenuToolsInternetOptions"));
      MenuItem miHelp = MenuMain.MenuItems.Add(Resourcer.GetString("MenuHelp"));
        miHelp.MenuItems.Add(Resourcer.GetString("MenuHelpAbout"),
          new EventHandler(mnuHelpAbout_Click));
      
      TbStop.ImageIndex = 2;
      TbStop.ToolTipText = "Stop";
      
      TbSeperator3.Style = ToolBarButtonStyle.Separator;
      
      TbSeperator2.Style = ToolBarButtonStyle.Separator;
      
      TbSeperator1.Style = ToolBarButtonStyle.Separator;
      
      TbPrint.ImageIndex = 7;
      TbPrint.ToolTipText = "Print";
      
      TbFavorites.ImageIndex = 6;
      TbFavorites.ToolTipText = "Favourites";
      
      TbBack.ImageIndex = 0;
      TbBack.ToolTipText = "Back";
      TbBack.Enabled = false;
      TbBack.Style = ToolBarButtonStyle.DropDownButton;
      
      TbForward.ImageIndex = 1;
      TbForward.ToolTipText = "Forward";
      TbForward.Enabled = false;
      TbForward.Style = ToolBarButtonStyle.DropDownButton;
      
      TbHome.ImageIndex = 4;
      TbHome.ToolTipText = "Home";
      
      ImagesToolbar.ImageSize = new System.Drawing.Size(20, 20);
      ImagesToolbar.ColorDepth = ColorDepth.Depth24Bit;
      ImagesToolbar.TransparentColor = System.Drawing.Color.Fuchsia;
      ImagesToolbar.Images.AddStrip((Image)Resourcer.GetObject("ImagesToolbar"));
      
      TbEdit.ImageIndex = 15;
      TbEdit.ToolTipText = "Edit";
      
      TbHistory.ImageIndex = 12;
      TbHistory.ToolTipText = "History";
      
      TbSearch.ImageIndex = 5;
      TbSearch.ToolTipText = "Search";
      
      TbRefresh.ImageIndex = 3;
      TbRefresh.ToolTipText = "Refresh";
      
      TbMail.ImageIndex = 13;
      TbMail.ToolTipText = "Mail";
      
      BarStandardToolbar.ImageList = ImagesToolbar;
      BarStandardToolbar.Size = new System.Drawing.Size(384, 30);
      BarStandardToolbar.Wrappable = false;
      //BarStandardToolbar.ButtonSize = new System.Drawing.Size(20, 20);
      BarStandardToolbar.DropDownArrows = true;
      BarStandardToolbar.Appearance = ToolBarAppearance.Flat;
      BarStandardToolbar.TabIndex = 0;
      BarStandardToolbar.ShowToolTips = true;
      BarStandardToolbar.ButtonClick += new ToolBarButtonClickEventHandler(tbStandard_ButtonClick);
      BarStandardToolbar.ButtonDropDown += new ToolBarButtonClickEventHandler(tbStandard_ButtonDropDown);
      BarStandardToolbar.Buttons.AddRange(new ToolBarButton[]
       {TbBack,
        TbForward,
        TbStop,
        TbRefresh,
        TbHome,
        TbSeperator1,
        TbSearch,
        TbFavorites,
        TbHistory,
        TbSeperator2,
        TbMail,
        TbPrint,
        TbSeperator3,
        TbEdit} );
      
      BarAddress.Dock = DockStyle.Top;
      BarAddress.Size = new System.Drawing.Size(392, 24);
      BarAddress.TabIndex = 0;
      
      ButtonGo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      ButtonGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      ButtonGo.Image = (Image)Resourcer.GetObject("IconGo");
      ButtonGo.Location = new System.Drawing.Point(348, 0);
      ButtonGo.FlatStyle = FlatStyle.Popup;
      ButtonGo.Size = new System.Drawing.Size(40, 21);
      ButtonGo.TabIndex = 1;
      ButtonGo.Anchor = AnchorStyles.Right;
      ButtonGo.Text = "Go";
      ButtonGo.Click += new System.EventHandler(btnGo_Click);
      
      ComboAddress.Location = new System.Drawing.Point(64, 0);
      ComboAddress.Size = new System.Drawing.Size(280, 21);
      ComboAddress.TabIndex = 2;
      ComboAddress.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      ComboAddress.SelectionChangeCommitted += new System.EventHandler(cmbAddress_SelectionChangeCommited);
      ComboAddress.KeyPress += new KeyPressEventHandler(cmbAddress_KeyPress);
      ComboAddress.SelectedIndexChanged += new System.EventHandler(cmbAddress_SelectedIndexChanged);
      
      LabelAddress.Location = new System.Drawing.Point(4, 4);
      LabelAddress.Text = "Address: ";
      LabelAddress.Size = new System.Drawing.Size(46, 13);
      LabelAddress.AutoSize = true;
      LabelAddress.TabIndex = 0;
      
      BarAddress.Controls.Add(ComboAddress);
      BarAddress.Controls.Add(ButtonGo);
      BarAddress.Controls.Add(LabelAddress);
      
      this.Text = Resourcer.GetString("AppTitle");
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.Menu = MenuMain;
      this.ClientSize = new System.Drawing.Size(392, 317);
      this.Icon = (System.Drawing.Icon)Resourcer.GetObject("AppIcon");
      
      this.Controls.Add(AxWebBrowser);
      this.Controls.Add(BarStandardToolbar);
      this.Controls.Add(BarAddress);
      this.Controls.Add(BarStatus);
      
      // Add typed URLs to Address combobox
      String sKey = "Software\\Microsoft\\Internet Explorer\\TypedURLs";
      RegistryKey kURLs = Registry.CurrentUser.OpenSubKey(sKey);
      String sURL;
      int nURL = 1;
      while(true)
      {
        String sValName = "url" + nURL.ToString();
        sURL = (String)kURLs.GetValue(sValName);
        if((object)sURL == null)
          break;
        ComboAddress.Items.Add(sURL);
        nURL++;
      }
      
      AxWebBrowser.EndInit();
      
      AxWebBrowser.RegisterAsBrowser = true;
      AxWebBrowser.RegisterAsDropTarget = true;
      AxWebBrowser.Silent = false;
      
      //Show home page
      AxWebBrowser.GoHome();
      Object o = null;
      
      //Update toolbar
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_UPDATECOMMANDS,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
        ref o, ref o);
      
      ComboAddress.Focus();
    }

    protected void barStatus_DrawItem(object sender, StatusBarDrawItemEventArgs sbdevent)
    {
      
    }
    protected void barStatus_PanelClick(object sender, StatusBarPanelClickEventArgs e)
    {
      
    }

    protected void AxWebBrowser_WindowSetWidth(object sender, DWebBrowserEvents2_WindowSetWidthEvent e)
    {
      
    }
    protected void AxWebBrowser_WindowSetTop(object sender, DWebBrowserEvents2_WindowSetTopEvent e)
    {
      
    }
    protected void AxWebBrowser_WindowSetResizable(object sender, DWebBrowserEvents2_WindowSetResizableEvent e)
    {
      
    }
    protected void AxWebBrowser_WindowSetLeft(object sender, DWebBrowserEvents2_WindowSetLeftEvent e)
    {
      
    }
    protected void AxWebBrowser_WindowSetHeight(object sender, DWebBrowserEvents2_WindowSetHeightEvent e)
    {
      
    }
    protected void AxWebBrowser_WindowClosing(object sender, DWebBrowserEvents2_WindowClosingEvent e)
    {
      
    }
    protected void AxWebBrowser_TitleChange(object sender, DWebBrowserEvents2_TitleChangeEvent e)
    {
      this.Text = e.text + " - " + Resourcer.GetString("AppTitle");
    }
    protected void AxWebBrowser_StatusTextChange(object sender, DWebBrowserEvents2_StatusTextChangeEvent e)
    {
      StatusMessages.Text = e.text;
    }
    protected void AxWebBrowser_SetSecureLockIcon(object sender, DWebBrowserEvents2_SetSecureLockIconEvent e)
    {
      
    }
    protected void AxWebBrowser_PropertyChange(object sender, DWebBrowserEvents2_PropertyChangeEvent e)
    {
      
    }
    protected void AxWebBrowser_ProgressChange(object sender, DWebBrowserEvents2_ProgressChangeEvent e)
    {
      
    }
    protected void AxWebBrowser_OnVisible(object sender, DWebBrowserEvents2_OnVisibleEvent e)
    {
      
    }
    protected void AxWebBrowser_OnToolBar(object sender, DWebBrowserEvents2_OnToolBarEvent e)
    {
      
    }
    protected void AxWebBrowser_OnTheaterMode(object sender, DWebBrowserEvents2_OnTheaterModeEvent e)
    {
      
    }
    protected void AxWebBrowser_OnStatusBar(object sender, DWebBrowserEvents2_OnStatusBarEvent e)
    {
      
    }
    protected void AxWebBrowser_OnQuit(object sender, EventArgs e)
    {
      
    }
    protected void AxWebBrowser_OnMenuBar(object sender, DWebBrowserEvents2_OnMenuBarEvent e)
    {
      
    }
    protected void AxWebBrowser_OnFullScreen(object sender, DWebBrowserEvents2_OnFullScreenEvent e)
    {
      
    }
    protected void AxWebBrowser_NewWindow2(object sender, DWebBrowserEvents2_NewWindow2Event e)
    {
      e.cancel = true;
    }
    protected void AxWebBrowser_NavigateComplete2(object sender, DWebBrowserEvents2_NavigateComplete2Event e)
    {
      IHTMLDocument4 id4;
      object boxID4 = AxWebBrowser.Document;
      id4 = (IHTMLDocument4)boxID4;

      // For testing only...

    }
    protected void AxWebBrowser_FileDownload(object sender, DWebBrowserEvents2_FileDownloadEvent e)
    {
      
    }
    protected void AxWebBrowser_DownloadComplete(object sender, EventArgs e)
    {
      
    }
    protected void AxWebBrowser_DownloadBegin(object sender, EventArgs   e)
    {
      
    }
    protected void AxWebBrowser_DocumentComplete(object sender, DWebBrowserEvents2_DocumentCompleteEvent e)
    {
      String sURL = (String)e.uRL;
      int index = ComboAddress.FindStringExact(sURL);
      if(index == -1)
      {
        ComboAddress.Items.Add(sURL);
        ComboAddress.SelectedIndex = ComboAddress.FindStringExact(sURL);
      }
      else
      {
        ComboAddress.SelectedIndex = index;
      }
    }
    protected void AxWebBrowser_CommandStateChange(object sender, DWebBrowserEvents2_CommandStateChangeEvent e)
    {
      if(e.command.Equals(SHDocVw.CommandStateChangeConstants.CSC_NAVIGATEBACK))
      {
        MenuItem miView = MenuMain.MenuItems[2];
        MenuItem miGoTo = miView.MenuItems[3];
        miGoTo.MenuItems[0].Enabled = e.enable;
        TbBack.Enabled = e.enable;
      }
      if(e.command.Equals(SHDocVw.CommandStateChangeConstants.CSC_NAVIGATEFORWARD))
      {
        MenuItem miView = MenuMain.MenuItems[2];
        MenuItem miGoTo = miView.MenuItems[3];
        miGoTo.MenuItems[1].Enabled = e.enable;
        TbForward.Enabled = e.enable;
      }
      if(e.command.Equals(SHDocVw.CommandStateChangeConstants.CSC_UPDATECOMMANDS))
      {
        Int32 EnabledTest = Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_SUPPORTED)
          + Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_ENABLED);
        bool RefreshTest = EnabledTest.Equals(AxWebBrowser.QueryStatusWB //Refresh
          (SHDocVw.OLECMDID.OLECMDID_REFRESH));
        
        TbRefresh.Enabled = RefreshTest;
        TbMail.Enabled = RefreshTest;
        TbEdit.Enabled = RefreshTest;
        TbStop.Enabled = AxWebBrowser.Busy;
        TbPrint.Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB
          (SHDocVw.OLECMDID.OLECMDID_PRINT));
      }
    }
    protected void AxWebBrowser_ClientToHostWindow(object sender, DWebBrowserEvents2_ClientToHostWindowEvent e)
    {
      
    }
    protected void AxWebBrowser_BeforeNavigate2(object sender, DWebBrowserEvents2_BeforeNavigate2Event e)
    {

    }
    protected void mnuFile_Popup(object sender, EventArgs e)
    {
      MenuItem miFile = MenuMain.MenuItems[0];
      miFile.MenuItems[14].Checked = AxWebBrowser.Offline;
      
      Int32 EnabledTest = Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_SUPPORTED)
          + Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_ENABLED);
      
      miFile.MenuItems[2].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB //Refresh test for Edit
        (SHDocVw.OLECMDID.OLECMDID_REFRESH));
      miFile.MenuItems[3].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_SAVE));
      miFile.MenuItems[4].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_SAVEAS));
      miFile.MenuItems[6].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_PAGESETUP));
      miFile.MenuItems[7].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_PRINT));
      miFile.MenuItems[8].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_PRINTPREVIEW));
      miFile.MenuItems[13].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_PROPERTIES));
    }
    protected void mnuFileOpen_Click(object sender, EventArgs e)
    {
      OpenForm frmOpen = new OpenForm();
      frmOpen.ShowDialog(this);
      if(frmOpen.DialogResult == DialogResult.OK)
      {
        Object o = null;
        AxWebBrowser.Navigate(frmOpen.Address, ref o, ref o, ref o, ref o);
      }
    }
    protected void mnuFileEdit_Click(object sender, EventArgs e)
    {
      IHTMLDocument2 doc;
      object boxDoc = AxWebBrowser.Document;
      doc = (IHTMLDocument2)boxDoc;
      doc.designMode = "On";
    }
    protected void mnuFileSave_Click(object sender, EventArgs e)
    {
      Object o = null;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVE,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
        ref o, ref o);
    }
    protected void mnuFileSaveAs_Click(object sender, EventArgs e)
    {
      Object o = null;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
        ref o, ref o);
    }
    protected void mnuFilePageSetup_Click(object sender, EventArgs e)
    {
      Object o = null;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PAGESETUP,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
        ref o, ref o);
    }
    protected void mnuFilePrint_Click(object sender, EventArgs e)
    {
      Object o = null;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
        ref o, ref o);
    }
    protected void mnuFilePrintPreview_Click(object sender, EventArgs e)
    {
      Object o = null;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINTPREVIEW,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
        ref o, ref o);
    }
    protected void mnuFileImportExport_Click(object sender, EventArgs e)
    {
      ImportExportForm frmImEx = new ImportExportForm();
      frmImEx.ShowDialog();
    }
    protected void mnuFileProperties_Click(object sender, EventArgs e)
    {
      Object o = null;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PROPERTIES,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
        ref o, ref o);
    }
    protected void mnuFileWorkOffline_Click(object sender, EventArgs e)
    {
      AxWebBrowser.Offline = !AxWebBrowser.Offline;
    }
    protected void mnuFileClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    protected void mnuEdit_Popup(object sender, EventArgs e)
    {
      Int32 EnabledTest = Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_SUPPORTED)
          + Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_ENABLED);
      
      MenuItem miEdit = MenuMain.MenuItems[1];
      miEdit.MenuItems[0].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_CUT));
      miEdit.MenuItems[1].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_COPY));
      miEdit.MenuItems[2].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_PASTE));
      miEdit.MenuItems[4].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_SELECTALL));
    }
    protected void mnuEditCut_Click(object sender, EventArgs e)
    {
      Object o = null;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_CUT,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
        ref o, ref o);
    }
    protected void mnuEditCopy_Click(object sender, EventArgs e)
    {
      Object o = null;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_COPY,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
        ref o, ref o);
    }
    protected void mnuEditPaste_Click(object sender, EventArgs e)
    {
      Object o = null;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PASTE,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
        ref o, ref o);
    }
    protected void mnuEditSelectAll_Click(object sender, EventArgs e)
    {
      Object o = null;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_SELECTALL,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
        ref o, ref o);
    }
    protected void mnuEditFind_Click(object sender, EventArgs e)
    {
      /* Object o = null;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_SHOWFIND,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
        ref o, ref o); */
    }
    protected void mnuHelpAbout_Click(object sender, EventArgs e)
    {
      AboutForm frmAbout = new AboutForm();
      frmAbout.ShowDialog(this);
    }
    protected void mnuView_Popup(object sender, EventArgs e)
    {
      Int32 EnabledTest = Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_SUPPORTED)
          + Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_ENABLED);
      
      MenuItem miView = MenuMain.MenuItems[2];
      miView.MenuItems[1].Checked = BarStatus.Visible; //Status Bar
      miView.MenuItems[4].Enabled = AxWebBrowser.Busy; //Stop
      miView.MenuItems[5].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB //Refresh
        (SHDocVw.OLECMDID.OLECMDID_REFRESH));
      miView.MenuItems[7].Enabled = AxWebBrowser.QueryStatusWB //Text Size
        (SHDocVw.OLECMDID.OLECMDID_ZOOM)
          == SHDocVw.OLECMDF.OLECMDF_SUPPORTED;
    }
    protected void mnuViewStatusBar_Click(object sender, EventArgs e)
    {
      BarStatus.Visible = !BarStatus.Visible;
    }
    protected void mnuViewGoToBack_Click(object sender, EventArgs e)
    {
      AxWebBrowser.GoBack();
    }
    protected void mnuViewGoToForward_Click(object sender, EventArgs e)
    {
      AxWebBrowser.GoForward();
    }
    protected void mnuViewGoToHomePage_Click(object sender, EventArgs e)
    {
      AxWebBrowser.GoHome();
    }
    protected void mnuViewGoToSearchPage_Click(object sender, EventArgs e)
    {
      AxWebBrowser.GoSearch();
    }
    protected void mnuViewStop_Click(object sender, EventArgs e)
    {
      AxWebBrowser.Stop();
    }
    protected void mnuViewRefresh_Click(object sender, EventArgs e)
    {
      Object o = null;
      AxWebBrowser.Refresh2(ref o);
    }
    private void SetFontSize(Int32 nNewSize)
    {
      Object o = null;
      Object size = (object)nNewSize;
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_ZOOM,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
        ref size, ref o);
    }
    protected void mnuViewTextSize_Popup(object sender, EventArgs e)
    {
      Object o = null;
      Object size = null;
      Int32 nSize;
      MenuItem miView = MenuMain.MenuItems[2];
      MenuItem miViewTextSize = miView.MenuItems[7];
      foreach(MenuItem mi in miViewTextSize.MenuItems)
        mi.Checked = false;
      
      AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_ZOOM,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
        ref o, ref size);
      nSize = (Int32)size;
      switch(nSize)
      {
        case 4:
          miViewTextSize.MenuItems[0].Checked = true;
          break;
        case 3:
          miViewTextSize.MenuItems[1].Checked = true;
          break;
        case 2:
          miViewTextSize.MenuItems[2].Checked = true;
          break;
        case 1:
          miViewTextSize.MenuItems[3].Checked = true;
          break;
        case 0:
          miViewTextSize.MenuItems[4].Checked = true;
          break;
      }
    }
    protected void mnuViewTextSizeLargest_Click(object sender, EventArgs e)
    {
      SetFontSize(4);
    }
    protected void mnuViewTextSizeLarger_Click(object sender, EventArgs e)
    {
      SetFontSize(3);
    }
    protected void mnuViewTextSizeMedium_Click(object sender, EventArgs e)
    {
      SetFontSize(2);
    }
    protected void mnuViewTextSizeSmaller_Click(object sender, EventArgs e)
    {
      SetFontSize(1);
    }
    protected void mnuViewTextSizeSmallest_Click(object sender, EventArgs e)
    {
      SetFontSize(0);
    }
    protected void mnuViewFullScreen_Click(object sender, EventArgs e)
    {
      AxWebBrowser.FullScreen = true;
    }
    protected void mnuFavourites_Popup(object sender, EventArgs e)
    {
      Int32 EnabledTest = Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_SUPPORTED)
          + Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_ENABLED);
      
      MenuItem miFavs = MenuMain.MenuItems[3];
      miFavs.MenuItems[0].Enabled = EnabledTest.Equals(AxWebBrowser.QueryStatusWB //Add to favourites
        (SHDocVw.OLECMDID.OLECMDID_REFRESH));
    }
    protected void mnuFavouritesAdd_Click(object sender, EventArgs e)
    {
      SHDocVw.ShellUIHelper shl;
      shl = new SHDocVw.ShellUIHelper();
      Object title = (object)AxWebBrowser.LocationName;
      shl.AddFavorite(AxWebBrowser.LocationURL, ref title);
    }
    protected void mnuFavouritesOrganise_Click(object sender, EventArgs e)
    {
      //Supposed to work but does not.
      /* SHDocVw.ShellUIHelper shl;
      shl = new SHDocVw.ShellUIHelper();
      Object o = null;
      shl.ShowBrowserUI("OrganizeFavorites", ref o); */
    }
    protected void tbStandard_ButtonDropDown(object sender, ToolBarButtonClickEventArgs e)
    {
      
    }
    protected void tbStandard_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
      if(e.Button == TbBack)
        { AxWebBrowser.GoBack(); }
      if(e.Button == TbForward)
        { AxWebBrowser.GoForward(); }
      if(e.Button == TbStop)
        { AxWebBrowser.Stop(); }
      if(e.Button == TbRefresh)
      {
        Object o = null;
        AxWebBrowser.Refresh2(ref o);
      }
      if(e.Button == TbHome)
        { AxWebBrowser.GoHome(); }
      if(e.Button == TbSearch)
        { AxWebBrowser.GoSearch(); }
      if(e.Button == TbPrint)
      {
        Object o = null;
        AxWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT,
          SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
          ref o, ref o);
      }
      if(e.Button == TbEdit)
      {
        IHTMLDocument2 doc;
        object boxDoc = AxWebBrowser.Document;
        doc = (IHTMLDocument2)boxDoc;
        doc.designMode = "On";
      }
    }
    
    protected void cmbAddress_SelectionChangeCommited(object sender, System.EventArgs e)
    {
      
    }
    protected void cmbAddress_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      Object o = null;
      String sURL = ComboAddress.Items[ComboAddress.SelectedIndex].ToString();
      AxWebBrowser.Navigate(sURL, ref o, ref o, ref o, ref o);
    }
    protected void cmbAddress_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = false;
      if(e.KeyChar == '\r')
      {
        String sURL = ComboAddress.Text;
        int index = ComboAddress.FindStringExact(sURL);
        if(index == -1)
        {
          ComboAddress.Items.Add(sURL);
          ComboAddress.SelectedIndex = ComboAddress.FindStringExact(sURL);
        }
        else
        {
          ComboAddress.SelectedIndex = index;
        }
      }
    }
    protected void btnGo_Click(object sender, System.EventArgs e)
    {
      String sURL = ComboAddress.Text;
      int index = ComboAddress.FindStringExact(sURL);
      if(index == -1)
      {
        ComboAddress.Items.Add(sURL);
        ComboAddress.SelectedIndex = ComboAddress.FindStringExact(sURL);
      }
      else
      {
        ComboAddress.SelectedIndex = index;
      }
    }

  }
}
