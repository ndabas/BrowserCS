namespace Techinox.WebBrowser
{
  
  using System;
  using Microsoft.Win32;
  using System.Drawing;
  using System.ComponentModel;
  using System.WinForms;
  using AxSHDocVw;
  using MSHTML;
  using System.Runtime.InteropServices;

  public class WebBrowserForm : System.WinForms.Form
  {

    private Container m_Components;
    private System.Resources.ResourceManager m_Resources;
    private AxWebBrowser m_axWebBrowser;
    private System.WinForms.MainMenu m_mnuMain;
    private System.WinForms.StatusBarPanel m_stpSecure;
    private System.WinForms.StatusBarPanel m_stpZone;
    private System.WinForms.StatusBarPanel m_stpOffline;
    private System.WinForms.StatusBarPanel m_stpProgress;
    private System.WinForms.StatusBarPanel m_stpMessages;
    private System.WinForms.StatusBar m_barStatus;
    private System.WinForms.ToolBarButton m_tbtEdit;
    private System.WinForms.ToolBarButton m_Seperator3;
    private System.WinForms.ToolBarButton m_tbtPrint;
    private System.WinForms.ToolBarButton m_tbtMail;
    private System.WinForms.ToolBarButton m_tbtSeperator2;
    private System.WinForms.ToolBarButton m_tbtHistory;
    private System.WinForms.ToolBarButton m_tbtFavourites;
    private System.WinForms.ToolBarButton m_tbtSearch;
    private System.WinForms.ToolBarButton m_tbtSeperator1;
    private System.WinForms.ToolBarButton m_tbtHome;
    private System.WinForms.ToolBarButton m_tbtRefresh;
    private System.WinForms.ToolBarButton m_tbtStop;
    private System.WinForms.ToolBarButton m_tbtForward;
    private System.WinForms.ToolBarButton m_tbtBack;
    private System.WinForms.ToolBar m_barStandardTB;
    private System.WinForms.ImageList m_imlToolbarCold;
    private System.WinForms.ImageList m_imlToolbarHot;
    private System.WinForms.ComboBox m_cmbAddress;
    private System.WinForms.Button m_btnGo;
    private System.WinForms.Label m_lblAddress;
    private System.WinForms.Panel m_barAddress;

    public WebBrowserForm()
    {
      InitializeComponent();
    }

    public override void Dispose()
    {
      base.Dispose();
      m_Components.Dispose();
    }

    public static void Main(string[] args)
    {
      Application.Run(new WebBrowserForm());
    }
    
    private void InitializeComponent()
    {
      this.m_Resources = new System.Resources.ResourceManager(typeof(WebBrowserForm));
      this.m_Components = new Container();
      this.m_axWebBrowser = new AxWebBrowser();
      this.m_mnuMain = new MainMenu();
      this.m_barStatus = new StatusBar();
      this.m_stpZone = new StatusBarPanel();
      this.m_stpSecure = new StatusBarPanel();
      this.m_stpProgress = new StatusBarPanel();
      this.m_stpOffline = new StatusBarPanel();
      this.m_stpMessages = new StatusBarPanel();
      this.m_tbtStop = new System.WinForms.ToolBarButton();
      this.m_imlToolbarCold = new System.WinForms.ImageList();
      this.m_Seperator3 = new System.WinForms.ToolBarButton();
      this.m_tbtSeperator2 = new System.WinForms.ToolBarButton();
      this.m_tbtSeperator1 = new System.WinForms.ToolBarButton();
      this.m_tbtPrint = new System.WinForms.ToolBarButton();
      this.m_tbtFavourites = new System.WinForms.ToolBarButton();
      this.m_tbtBack = new System.WinForms.ToolBarButton();
      this.m_tbtForward = new System.WinForms.ToolBarButton();
      this.m_tbtHome = new System.WinForms.ToolBarButton();
      this.m_imlToolbarHot = new System.WinForms.ImageList();
      this.m_tbtEdit = new System.WinForms.ToolBarButton();
      this.m_tbtHistory = new System.WinForms.ToolBarButton();
      this.m_tbtSearch = new System.WinForms.ToolBarButton();
      this.m_tbtRefresh = new System.WinForms.ToolBarButton();
      this.m_tbtMail = new System.WinForms.ToolBarButton();
      this.m_barStandardTB = new System.WinForms.ToolBar();
      this.m_barAddress = new System.WinForms.Panel();
      this.m_btnGo = new System.WinForms.Button();
      this.m_cmbAddress = new System.WinForms.ComboBox();
      this.m_lblAddress = new System.WinForms.Label();
      
      m_stpProgress.BeginInit();
      m_stpOffline.BeginInit();
      m_axWebBrowser.BeginInit();
      m_stpMessages.BeginInit();
      m_stpZone.BeginInit();
      m_stpSecure.BeginInit();
      
      m_stpProgress.MinWidth = 0;
      m_stpProgress.Style = System.WinForms.StatusBarPanelStyle.OwnerDraw;
      
      m_stpOffline.MinWidth = 20;
      m_stpOffline.Width = 20;
      
      m_stpMessages.MinWidth = 100;
      m_stpMessages.Width = 136;
      m_stpMessages.AutoSize = System.WinForms.StatusBarPanelAutoSize.Spring;
      
      m_stpZone.MinWidth = 136;
      m_stpZone.Width = 136;
            
      m_stpSecure.MinWidth = 20;
      m_stpSecure.Width = 20;
      
      m_barStatus.Dock = DockStyle.Bottom;
      m_barStatus.BackColor = System.Drawing.SystemColors.Control;
      m_barStatus.Location = new System.Drawing.Point(0, 297);
      m_barStatus.Size = new System.Drawing.Size(392, 20);
      m_barStatus.TabIndex = 0;
      m_barStatus.ShowPanels = true;
      m_barStatus.PanelClick += new System.WinForms.StatusBarPanelClickEventHandler(barStatus_PanelClick);
      m_barStatus.DrawItem += new System.WinForms.StatusBarDrawItemEventHandler(barStatus_DrawItem);
      m_barStatus.Panels.All = new System.WinForms.StatusBarPanel[] {m_stpMessages,
         m_stpProgress,
         m_stpOffline,
         m_stpSecure,
         m_stpZone};
            
      m_axWebBrowser.Size = new System.Drawing.Size(392, 296);
      m_axWebBrowser.TabIndex = 1;
      //m_axWebBrowser.Anchor = System.WinForms.AnchorStyles.All;
      m_axWebBrowser.Dock = DockStyle.Fill;
      m_axWebBrowser.StatusTextChange += new DWebBrowserEvents2_StatusTextChangeEventHandler(m_axWebBrowser_StatusTextChange);
      m_axWebBrowser.ProgressChange += new DWebBrowserEvents2_ProgressChangeEventHandler(m_axWebBrowser_ProgressChange);
      m_axWebBrowser.PropertyChange += new DWebBrowserEvents2_PropertyChangeEventHandler(m_axWebBrowser_PropertyChange);
      m_axWebBrowser.WindowSetTop += new DWebBrowserEvents2_WindowSetTopEventHandler(m_axWebBrowser_WindowSetTop);
      m_axWebBrowser.WindowClosing += new DWebBrowserEvents2_WindowClosingEventHandler(m_axWebBrowser_WindowClosing);
      m_axWebBrowser.NavigateComplete2 += new DWebBrowserEvents2_NavigateComplete2EventHandler(m_axWebBrowser_NavigateComplete2);
      m_axWebBrowser.OnStatusBar += new DWebBrowserEvents2_OnStatusBarEventHandler(m_axWebBrowser_OnStatusBar);
      m_axWebBrowser.WindowSetLeft += new DWebBrowserEvents2_WindowSetLeftEventHandler(m_axWebBrowser_WindowSetLeft);
      m_axWebBrowser.DownloadBegin += new EventHandler(m_axWebBrowser_DownloadBegin);
      m_axWebBrowser.CommandStateChange += new DWebBrowserEvents2_CommandStateChangeEventHandler(m_axWebBrowser_CommandStateChange);
      m_axWebBrowser.WindowSetHeight += new DWebBrowserEvents2_WindowSetHeightEventHandler(m_axWebBrowser_WindowSetHeight);
      m_axWebBrowser.WindowSetResizable += new DWebBrowserEvents2_WindowSetResizableEventHandler(m_axWebBrowser_WindowSetResizable);
      m_axWebBrowser.SetSecureLockIcon += new DWebBrowserEvents2_SetSecureLockIconEventHandler(m_axWebBrowser_SetSecureLockIcon);
      m_axWebBrowser.TitleChange += new DWebBrowserEvents2_TitleChangeEventHandler(m_axWebBrowser_TitleChange);
      m_axWebBrowser.BeforeNavigate2 += new DWebBrowserEvents2_BeforeNavigate2EventHandler(m_axWebBrowser_BeforeNavigate2);
      m_axWebBrowser.OnTheaterMode += new DWebBrowserEvents2_OnTheaterModeEventHandler(m_axWebBrowser_OnTheaterMode);
      m_axWebBrowser.WindowSetWidth += new DWebBrowserEvents2_WindowSetWidthEventHandler(m_axWebBrowser_WindowSetWidth);
      m_axWebBrowser.OnFullScreen += new DWebBrowserEvents2_OnFullScreenEventHandler(m_axWebBrowser_OnFullScreen);
      m_axWebBrowser.OnQuit += new EventHandler(m_axWebBrowser_OnQuit);
      m_axWebBrowser.DownloadComplete += new EventHandler(m_axWebBrowser_DownloadComplete);
      m_axWebBrowser.ClientToHostWindow += new DWebBrowserEvents2_ClientToHostWindowEventHandler(m_axWebBrowser_ClientToHostWindow);
      m_axWebBrowser.OnToolBar += new DWebBrowserEvents2_OnToolBarEventHandler(m_axWebBrowser_OnToolBar);
      m_axWebBrowser.OnVisible += new DWebBrowserEvents2_OnVisibleEventHandler(m_axWebBrowser_OnVisible);
      m_axWebBrowser.FileDownload += new DWebBrowserEvents2_FileDownloadEventHandler(m_axWebBrowser_FileDownload);
      m_axWebBrowser.NewWindow2 += new DWebBrowserEvents2_NewWindow2EventHandler(m_axWebBrowser_NewWindow2);
      m_axWebBrowser.OnMenuBar += new DWebBrowserEvents2_OnMenuBarEventHandler(m_axWebBrowser_OnMenuBar);
      m_axWebBrowser.DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(m_axWebBrowser_DocumentComplete);
           
      MenuItem miFile = m_mnuMain.MenuItems.Add(m_Resources.GetString("MenuFile"));
      miFile.Popup += new EventHandler(mnuFile_Popup);
        MenuItem miFileNew = miFile.MenuItems.Add(m_Resources.GetString("MenuFileNew"));
          miFileNew.MenuItems.Add(m_Resources.GetString("MenuFileNewWindow"));
          //miFileNew.MenuItems.Add("-");
          //miFileNew.MenuItems.Add(m_Resources.GetString("MenuFileNewMessage"));
        miFile.MenuItems.Add(new MenuItem(m_Resources.GetString("MenuFileOpen"),
          new EventHandler(mnuFileOpen_Click), Shortcut.CtrlO));
        miFile.MenuItems.Add(m_Resources.GetString("MenuFileEdit"),
          new EventHandler(mnuFileEdit_Click));
        miFile.MenuItems.Add(new MenuItem(m_Resources.GetString("MenuFileSave"),
          new EventHandler(mnuFileSave_Click), Shortcut.CtrlS));
        miFile.MenuItems.Add(m_Resources.GetString("MenuFileSaveAs"),
          new EventHandler(mnuFileSaveAs_Click));
        miFile.MenuItems.Add("-");
        miFile.MenuItems.Add(m_Resources.GetString("MenuFilePageSetup"),
          new EventHandler(mnuFilePageSetup_Click));
        miFile.MenuItems.Add(new MenuItem(m_Resources.GetString("MenuFilePrint"),
          new EventHandler(mnuFilePrint_Click), Shortcut.CtrlP));
        miFile.MenuItems.Add(m_Resources.GetString("MenuFilePrintPreview"),
          new EventHandler(mnuFilePrintPreview_Click));
        miFile.MenuItems.Add("-");
        MenuItem miFileSend = miFile.MenuItems.Add(m_Resources.GetString("MenuFileSend"));
          miFileSend.MenuItems.Add(m_Resources.GetString("MenuFileSendPage"));
          miFileSend.MenuItems.Add(m_Resources.GetString("MenuFileSendLink"));
          miFileSend.MenuItems.Add(m_Resources.GetString("MenuFileSendShortcut"));
        miFile.MenuItems.Add(m_Resources.GetString("MenuFileImportExport"),
          new EventHandler(mnuFileImportExport_Click));
        miFile.MenuItems.Add("-");
        miFile.MenuItems.Add(m_Resources.GetString("MenuFileProperties"),
          new EventHandler(mnuFileProperties_Click));
        miFile.MenuItems.Add(m_Resources.GetString("MenuFileWorkOffline"),
          new EventHandler(mnuFileWorkOffline_Click));
        miFile.MenuItems.Add(m_Resources.GetString("MenuFileClose"),
          new EventHandler(mnuFileClose_Click));
      MenuItem miEdit = m_mnuMain.MenuItems.Add(m_Resources.GetString("MenuEdit"));
      miEdit.Popup += new EventHandler(mnuEdit_Popup);
        miEdit.MenuItems.Add(new MenuItem(m_Resources.GetString("MenuEditCut"),
          new EventHandler(mnuEditCut_Click), Shortcut.CtrlX));
        miEdit.MenuItems.Add(new MenuItem(m_Resources.GetString("MenuEditCopy"),
          new EventHandler(mnuEditCopy_Click), Shortcut.CtrlC));
        miEdit.MenuItems.Add(new MenuItem(m_Resources.GetString("MenuEditPaste"),
          new EventHandler(mnuEditPaste_Click), Shortcut.CtrlV));
        miEdit.MenuItems.Add("-");
        miEdit.MenuItems.Add(new MenuItem(m_Resources.GetString("MenuEditSelectAll"),
          new EventHandler(mnuEditSelectAll_Click), Shortcut.CtrlA));
        //miEdit.MenuItems.Add("-");
        //miEdit.MenuItems.Add(new MenuItem(m_Resources.GetString("MenuEditFind"),
          //new EventHandler(mnuEditFind_Click)));
      MenuItem miView = m_mnuMain.MenuItems.Add(m_Resources.GetString("MenuView"));
      miView.Popup += new EventHandler(mnuView_Popup);
        miView.MenuItems.Add(m_Resources.GetString("MenuViewToolbars"));
        miView.MenuItems.Add(m_Resources.GetString("MenuViewStatusBar"),
          new EventHandler(mnuViewStatusBar_Click));
        miView.MenuItems.Add("-");
        MenuItem miViewGoTo = miView.MenuItems.Add(m_Resources.GetString("MenuViewGoTo"));
          MenuItem miViewGoToBack = miViewGoTo.MenuItems.Add(m_Resources.GetString("MenuViewGoToBack"),
            new EventHandler(mnuViewGoToBack_Click));
            miViewGoToBack.Enabled = false;
          MenuItem miViewGoToForward = miViewGoTo.MenuItems.Add(m_Resources.GetString("MenuViewGoToForward"),
            new EventHandler(mnuViewGoToForward_Click));
            miViewGoToForward.Enabled = false;
          miViewGoTo.MenuItems.Add("-");
          miViewGoTo.MenuItems.Add(m_Resources.GetString("MenuViewGoToHomePage"),
            new EventHandler(mnuViewGoToHomePage_Click));
          miViewGoTo.MenuItems.Add(m_Resources.GetString("MenuViewGoToSearchPage"),
            new EventHandler(mnuViewGoToSearchPage_Click));
        miView.MenuItems.Add(m_Resources.GetString("MenuViewStop"),
          new EventHandler(mnuViewStop_Click));
        miView.MenuItems.Add(m_Resources.GetString("MenuViewRefresh"),
          new EventHandler(mnuViewRefresh_Click));
        miView.MenuItems.Add("-");
        MenuItem miViewTextSize = miView.MenuItems.Add(m_Resources.GetString("MenuViewTextSize"));
        miViewTextSize.Popup += new EventHandler(mnuViewTextSize_Popup);
          miViewTextSize.MenuItems.Add(m_Resources.GetString("MenuViewTextSizeLargest"),
            new EventHandler(mnuViewTextSizeLargest_Click));
          miViewTextSize.MenuItems.Add(m_Resources.GetString("MenuViewTextSizeLarger"),
            new EventHandler(mnuViewTextSizeLarger_Click));
          miViewTextSize.MenuItems.Add(m_Resources.GetString("MenuViewTextSizeMedium"),
            new EventHandler(mnuViewTextSizeMedium_Click));
          miViewTextSize.MenuItems.Add(m_Resources.GetString("MenuViewTextSizeSmaller"),
            new EventHandler(mnuViewTextSizeSmaller_Click));
          miViewTextSize.MenuItems.Add(m_Resources.GetString("MenuViewTextSizeSmallest"),
            new EventHandler(mnuViewTextSizeSmallest_Click));
        foreach(MenuItem mi in miViewTextSize.MenuItems)
          mi.RadioCheck = true;
        miView.MenuItems.Add("-");
        miView.MenuItems.Add(m_Resources.GetString("MenuViewSource"));
        miView.MenuItems.Add(m_Resources.GetString("MenuViewFullScreen"),
          new EventHandler(mnuViewFullScreen_Click));
      MenuItem miFavs = m_mnuMain.MenuItems.Add(m_Resources.GetString("MenuFavourites"));
      miFavs.Popup += new EventHandler(mnuFavourites_Popup);
        miFavs.MenuItems.Add(m_Resources.GetString("MenuFavouritesAdd"),
          new EventHandler(mnuFavouritesAdd_Click));
        miFavs.MenuItems.Add(m_Resources.GetString("MenuFavouritesOrganise"),
          new EventHandler(mnuFavouritesOrganise_Click));
      MenuItem miTools = m_mnuMain.MenuItems.Add(m_Resources.GetString("MenuTools"));
        miTools.MenuItems.Add(m_Resources.GetString("MenuToolsInternetOptions"));
      MenuItem miHelp = m_mnuMain.MenuItems.Add(m_Resources.GetString("MenuHelp"));
        miHelp.MenuItems.Add(m_Resources.GetString("MenuHelpAbout"),
          new EventHandler(mnuHelpAbout_Click));
      
      m_tbtStop.ImageIndex = 2;
      m_tbtStop.ToolTipText = "Stop";
      
      m_imlToolbarCold.Images.AddStrip((Image)m_Resources.GetObject("ImagesToolbarCold"));
      m_imlToolbarCold.ImageSize = new System.Drawing.Size(20, 20);
      m_imlToolbarCold.ColorDepth = System.WinForms.ColorDepth.Depth8Bit;
      m_imlToolbarCold.TransparentColor = System.Drawing.Color.Fuchsia;
      
      m_Seperator3.Style = System.WinForms.ToolBarButtonStyle.Separator;
      
      m_tbtSeperator2.Style = System.WinForms.ToolBarButtonStyle.Separator;
      
      m_tbtSeperator1.Style = System.WinForms.ToolBarButtonStyle.Separator;
      
      m_tbtPrint.ImageIndex = 7;
      m_tbtPrint.ToolTipText = "Print";
      
      m_tbtFavourites.ImageIndex = 6;
      m_tbtFavourites.ToolTipText = "Favourites";
      
      m_tbtBack.ImageIndex = 0;
      m_tbtBack.ToolTipText = "Back";
      m_tbtBack.Enabled = false;
      m_tbtBack.Style = System.WinForms.ToolBarButtonStyle.DropDownButton;
      
      m_tbtForward.ImageIndex = 1;
      m_tbtForward.ToolTipText = "Forward";
      m_tbtForward.Enabled = false;
      m_tbtForward.Style = System.WinForms.ToolBarButtonStyle.DropDownButton;
      
      m_tbtHome.ImageIndex = 4;
      m_tbtHome.ToolTipText = "Home";
      
      m_imlToolbarHot.Images.AddStrip((Image)m_Resources.GetObject("ImagesToolbarHot"));
      m_imlToolbarHot.ImageSize = new System.Drawing.Size(20, 20);
      m_imlToolbarHot.ColorDepth = System.WinForms.ColorDepth.Depth8Bit;
      m_imlToolbarHot.TransparentColor = System.Drawing.Color.Fuchsia;
      
      m_tbtEdit.ImageIndex = 9;
      m_tbtEdit.ToolTipText = "Edit";
      
      m_tbtHistory.ImageIndex = 12;
      m_tbtHistory.ToolTipText = "History";
      
      m_tbtSearch.ImageIndex = 5;
      m_tbtSearch.ToolTipText = "Search";
      
      m_tbtRefresh.ImageIndex = 3;
      m_tbtRefresh.ToolTipText = "Refresh";
      
      m_tbtMail.ImageIndex = 13;
      m_tbtMail.ToolTipText = "Mail";
      
      //m_barStandardTB.ImageList = m_imlToolbarCold;
      //m_barStandardTB.HotImageList = m_imlToolbarHot;
      m_barStandardTB.ImageList = m_imlToolbarHot;
      m_barStandardTB.Size = new System.Drawing.Size(384, 30);
      m_barStandardTB.Wrappable = false;
      //m_barStandardTB.ButtonSize = new System.Drawing.Size(20, 20);
      m_barStandardTB.DropDownArrows = true;
      m_barStandardTB.Appearance = System.WinForms.ToolBarAppearance.Flat;
      m_barStandardTB.TabIndex = 0;
      m_barStandardTB.ShowToolTips = true;
      m_barStandardTB.ButtonClick += new System.WinForms.ToolBarButtonClickEventHandler(tbStandard_ButtonClick);
      m_barStandardTB.ButtonDropDown += new System.WinForms.ToolBarButtonClickEventHandler(tbStandard_ButtonDropDown);
      m_barStandardTB.Buttons.All = new System.WinForms.ToolBarButton[] {m_tbtBack,
        m_tbtForward,
        m_tbtStop,
        m_tbtRefresh,
        m_tbtHome,
        m_tbtSeperator1,
        m_tbtSearch,
        m_tbtFavourites,
        m_tbtHistory,
        m_tbtSeperator2,
        m_tbtMail,
        m_tbtPrint,
        m_Seperator3,
        m_tbtEdit};
      
      m_barAddress.Dock = System.WinForms.DockStyle.Top;
      m_barAddress.Size = new System.Drawing.Size(392, 24);
      m_barAddress.TabIndex = 0;
      
      m_btnGo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      m_btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      m_btnGo.Image = (Image)m_Resources.GetObject("IconGo");
      m_btnGo.Location = new System.Drawing.Point(348, 0);
      m_btnGo.FlatStyle = System.WinForms.FlatStyle.Popup;
      m_btnGo.Size = new System.Drawing.Size(40, 21);
      m_btnGo.TabIndex = 1;
      m_btnGo.Anchor = System.WinForms.AnchorStyles.Right;
      m_btnGo.Text = "Go";
      m_btnGo.Click += new System.EventHandler(btnGo_Click);
      
      m_cmbAddress.Location = new System.Drawing.Point(64, 0);
      m_cmbAddress.Size = new System.Drawing.Size(280, 21);
      m_cmbAddress.TabIndex = 2;
      m_cmbAddress.Anchor = System.WinForms.AnchorStyles.LeftRight;
      m_cmbAddress.SelectionChangeCommitted += new System.EventHandler(cmbAddress_SelectionChangeCommited);
      m_cmbAddress.KeyPress += new KeyPressEventHandler(cmbAddress_KeyPress);
      m_cmbAddress.SelectedIndexChanged += new System.EventHandler(cmbAddress_SelectedIndexChanged);
      
      m_lblAddress.Location = new System.Drawing.Point(4, 4);
      m_lblAddress.Text = "Address: ";
      m_lblAddress.Size = new System.Drawing.Size(46, 13);
      m_lblAddress.AutoSize = true;
      m_lblAddress.TabIndex = 0;
      
      m_barAddress.Controls.Add(m_cmbAddress);
      m_barAddress.Controls.Add(m_btnGo);
      m_barAddress.Controls.Add(m_lblAddress);
      
      this.Text = m_Resources.GetString("AppTitle");
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.Menu = m_mnuMain;
      this.ClientSize = new System.Drawing.Size(392, 317);
      this.Icon = (System.Drawing.Icon)m_Resources.GetObject("AppIcon");
      
      this.Controls.Add(m_barStandardTB);
      this.Controls.Add(m_barAddress);
      this.Controls.Add(m_barStatus);
      this.Controls.Add(m_axWebBrowser);
      
      m_stpProgress.EndInit();
      m_stpOffline.EndInit();
      m_axWebBrowser.EndInit();
      m_stpMessages.EndInit();
      m_stpZone.EndInit();
      m_stpSecure.EndInit();
      
      //Add typed URLs to Address combo
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
        m_cmbAddress.Items.Add(sURL);
        nURL++;
      }
      
      //Show home page
      m_axWebBrowser.GoHome();
      Object o = null;
      
      //Update toolbar
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_UPDATECOMMANDS,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
        ref o, ref o);
      
      m_cmbAddress.Focus();
    }

    protected void barStatus_DrawItem(object sender, StatusBarDrawItemEventArgs sbdevent)
    {
      
    }
    protected void barStatus_PanelClick(object sender, StatusBarPanelClickEventArgs e)
    {
      
    }

    protected void m_axWebBrowser_WindowSetWidth(object sender, DWebBrowserEvents2_WindowSetWidthEvent e)
    {
      
    }
    protected void m_axWebBrowser_WindowSetTop(object sender, DWebBrowserEvents2_WindowSetTopEvent e)
    {
      
    }
    protected void m_axWebBrowser_WindowSetResizable(object sender, DWebBrowserEvents2_WindowSetResizableEvent e)
    {
      
    }
    protected void m_axWebBrowser_WindowSetLeft(object sender, DWebBrowserEvents2_WindowSetLeftEvent e)
    {
      
    }
    protected void m_axWebBrowser_WindowSetHeight(object sender, DWebBrowserEvents2_WindowSetHeightEvent e)
    {
      
    }
    protected void m_axWebBrowser_WindowClosing(object sender, DWebBrowserEvents2_WindowClosingEvent e)
    {
      
    }
    protected void m_axWebBrowser_TitleChange(object sender, DWebBrowserEvents2_TitleChangeEvent e)
    {
      this.Text = e.p_text + " - " + m_Resources.GetString("AppTitle");
    }
    protected void m_axWebBrowser_StatusTextChange(object sender, DWebBrowserEvents2_StatusTextChangeEvent e)
    {
      m_stpMessages.Text = e.p_text;
    }
    protected void m_axWebBrowser_SetSecureLockIcon(object sender, DWebBrowserEvents2_SetSecureLockIconEvent e)
    {
      
    }
    protected void m_axWebBrowser_PropertyChange(object sender, DWebBrowserEvents2_PropertyChangeEvent e)
    {
      
    }
    protected void m_axWebBrowser_ProgressChange(object sender, DWebBrowserEvents2_ProgressChangeEvent e)
    {
      
    }
    protected void m_axWebBrowser_OnVisible(object sender, DWebBrowserEvents2_OnVisibleEvent e)
    {
      
    }
    protected void m_axWebBrowser_OnToolBar(object sender, DWebBrowserEvents2_OnToolBarEvent e)
    {
      
    }
    protected void m_axWebBrowser_OnTheaterMode(object sender, DWebBrowserEvents2_OnTheaterModeEvent e)
    {
      
    }
    protected void m_axWebBrowser_OnStatusBar(object sender, DWebBrowserEvents2_OnStatusBarEvent e)
    {
      
    }
    protected void m_axWebBrowser_OnQuit(object sender, EventArgs e)
    {
      
    }
    protected void m_axWebBrowser_OnMenuBar(object sender, DWebBrowserEvents2_OnMenuBarEvent e)
    {
      
    }
    protected void m_axWebBrowser_OnFullScreen(object sender, DWebBrowserEvents2_OnFullScreenEvent e)
    {
      
    }
    protected void m_axWebBrowser_NewWindow2(object sender, DWebBrowserEvents2_NewWindow2Event e)
    {
      e.p_cancel = false;
    }
    protected void m_axWebBrowser_NavigateComplete2(object sender, DWebBrowserEvents2_NavigateComplete2Event e)
    {
      
    }
    protected void m_axWebBrowser_FileDownload(object sender, DWebBrowserEvents2_FileDownloadEvent e)
    {
      
    }
    protected void m_axWebBrowser_DownloadComplete(object sender, EventArgs e)
    {
      
    }
    protected void m_axWebBrowser_DownloadBegin(object sender, EventArgs   e)
    {
      
    }
    protected void m_axWebBrowser_DocumentComplete(object sender, DWebBrowserEvents2_DocumentCompleteEvent e)
    {
      String sURL = (String)e.p_uRL;
      int index = m_cmbAddress.FindStringExact(sURL);
      if(index == -1)
      {
        m_cmbAddress.Items.Add(sURL);
        m_cmbAddress.SelectedIndex = m_cmbAddress.FindStringExact(sURL);
      }
      else
      {
        m_cmbAddress.SelectedIndex = index;
      }
    }
    protected void m_axWebBrowser_CommandStateChange(object sender, DWebBrowserEvents2_CommandStateChangeEvent e)
    {
      if(e.p_command == SHDocVw.CommandStateChangeConstants.CSC_NAVIGATEBACK.ToInt32())
      {
        MenuItem miView = m_mnuMain.MenuItems[2];
        MenuItem miGoTo = miView.MenuItems[3];
        miGoTo.MenuItems[0].Enabled = e.p_enable;
        m_tbtBack.Enabled = e.p_enable;
      }
      if(e.p_command == SHDocVw.CommandStateChangeConstants.CSC_NAVIGATEFORWARD.ToInt32())
      {
        MenuItem miView = m_mnuMain.MenuItems[2];
        MenuItem miGoTo = miView.MenuItems[3];
        miGoTo.MenuItems[1].Enabled = e.p_enable;
        m_tbtForward.Enabled = e.p_enable;
      }
      if(e.p_command == SHDocVw.CommandStateChangeConstants.CSC_UPDATECOMMANDS.ToInt32())
      {
        Int32 nEnabledTest = SHDocVw.OLECMDF.OLECMDF_SUPPORTED.ToInt32()
          + SHDocVw.OLECMDF.OLECMDF_ENABLED.ToInt32();
        m_tbtStop.Enabled = m_axWebBrowser.Busy;
        m_tbtRefresh.Enabled = (m_axWebBrowser.QueryStatusWB //Refresh
          (SHDocVw.OLECMDID.OLECMDID_REFRESH).ToInt32() == nEnabledTest);
        m_tbtMail.Enabled = (m_axWebBrowser.QueryStatusWB //Refresh test for Mail
          (SHDocVw.OLECMDID.OLECMDID_REFRESH).ToInt32() == nEnabledTest);
        m_tbtPrint.Enabled = (m_axWebBrowser.QueryStatusWB
          (SHDocVw.OLECMDID.OLECMDID_PRINT).ToInt32() == nEnabledTest);
        m_tbtEdit.Enabled = (m_axWebBrowser.QueryStatusWB //Refresh test for Edit
        (SHDocVw.OLECMDID.OLECMDID_REFRESH).ToInt32() == nEnabledTest);
      }
    }
    protected void m_axWebBrowser_ClientToHostWindow(object sender, DWebBrowserEvents2_ClientToHostWindowEvent e)
    {
      
    }
    protected void m_axWebBrowser_BeforeNavigate2(object sender, DWebBrowserEvents2_BeforeNavigate2Event e)
    {
      e.p_cancel = false;
    }
    protected void mnuFile_Popup(object sender, EventArgs e)
    {
      MenuItem miFile = m_mnuMain.MenuItems[0];
      miFile.MenuItems[14].Checked = m_axWebBrowser.Offline;
      Int32 nEnabledTest = SHDocVw.OLECMDF.OLECMDF_SUPPORTED.ToInt32()
        + SHDocVw.OLECMDF.OLECMDF_ENABLED.ToInt32();      
      miFile.MenuItems[2].Enabled = (m_axWebBrowser.QueryStatusWB //Refresh test for Edit
        (SHDocVw.OLECMDID.OLECMDID_REFRESH).ToInt32() == nEnabledTest);
      miFile.MenuItems[3].Enabled = (m_axWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_SAVE).ToInt32() == nEnabledTest);
      miFile.MenuItems[4].Enabled = (m_axWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_SAVEAS).ToInt32() == nEnabledTest);
      miFile.MenuItems[6].Enabled = (m_axWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_PAGESETUP).ToInt32() == nEnabledTest);
      miFile.MenuItems[7].Enabled = (m_axWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_PRINT).ToInt32() == nEnabledTest);
      miFile.MenuItems[8].Enabled = (m_axWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_PRINTPREVIEW).ToInt32() == nEnabledTest);
      miFile.MenuItems[13].Enabled = (m_axWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_PROPERTIES).ToInt32() == nEnabledTest);
    }
    protected void mnuFileOpen_Click(object sender, EventArgs e)
    {
      OpenForm frmOpen = new OpenForm();
      frmOpen.ShowDialog(this);
      if(frmOpen.DialogResult == DialogResult.OK)
      {
        Object o = null;
        m_axWebBrowser.Navigate(frmOpen.m_sAddress, ref o, ref o, ref o, ref o);
      }
    }
    protected void mnuFileEdit_Click(object sender, EventArgs e)
    {
      IHTMLDocument2 doc;
      object boxDoc = m_axWebBrowser.Document;
      doc = (IHTMLDocument2)boxDoc;
      doc.designMode = "On";
    }
    protected void mnuFileSave_Click(object sender, EventArgs e)
    {
      Object o = null;
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVE,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
        ref o, ref o);
    }
    protected void mnuFileSaveAs_Click(object sender, EventArgs e)
    {
      Object o = null;
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
        ref o, ref o);
    }
    protected void mnuFilePageSetup_Click(object sender, EventArgs e)
    {
      Object o = null;
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PAGESETUP,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
        ref o, ref o);
    }
    protected void mnuFilePrint_Click(object sender, EventArgs e)
    {
      Object o = null;
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
        ref o, ref o);
    }
    protected void mnuFilePrintPreview_Click(object sender, EventArgs e)
    {
      Object o = null;
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINTPREVIEW,
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
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PROPERTIES,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
        ref o, ref o);
    }
    protected void mnuFileWorkOffline_Click(object sender, EventArgs e)
    {
      m_axWebBrowser.Offline = !m_axWebBrowser.Offline;
    }
    protected void mnuFileClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    protected void mnuEdit_Popup(object sender, EventArgs e)
    {
      Int32 nEnabledTest = SHDocVw.OLECMDF.OLECMDF_SUPPORTED.ToInt32()
        + SHDocVw.OLECMDF.OLECMDF_ENABLED.ToInt32();
      MenuItem miEdit = m_mnuMain.MenuItems[1];
      miEdit.MenuItems[0].Enabled = (m_axWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_CUT).ToInt32() == nEnabledTest);
      miEdit.MenuItems[1].Enabled = (m_axWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_COPY).ToInt32() == nEnabledTest);
      miEdit.MenuItems[2].Enabled = (m_axWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_PASTE).ToInt32() == nEnabledTest);
      miEdit.MenuItems[4].Enabled = (m_axWebBrowser.QueryStatusWB
        (SHDocVw.OLECMDID.OLECMDID_SELECTALL).ToInt32() == nEnabledTest);
    }
    protected void mnuEditCut_Click(object sender, EventArgs e)
    {
      Object o = null;
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_CUT,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
        ref o, ref o);
    }
    protected void mnuEditCopy_Click(object sender, EventArgs e)
    {
      Object o = null;
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_COPY,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
        ref o, ref o);
    }
    protected void mnuEditPaste_Click(object sender, EventArgs e)
    {
      Object o = null;
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PASTE,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
        ref o, ref o);
    }
    protected void mnuEditSelectAll_Click(object sender, EventArgs e)
    {
      Object o = null;
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_SELECTALL,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
        ref o, ref o);
    }
    protected void mnuEditFind_Click(object sender, EventArgs e)
    {
      /* Object o = null;
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_SHOWFIND,
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
      Int32 nEnabledTest = SHDocVw.OLECMDF.OLECMDF_SUPPORTED.ToInt32()
        + SHDocVw.OLECMDF.OLECMDF_ENABLED.ToInt32();
      MenuItem miView = m_mnuMain.MenuItems[2];
      miView.MenuItems[1].Checked = m_barStatus.Visible; //Status Bar
      miView.MenuItems[4].Enabled = m_axWebBrowser.Busy; //Stop
      miView.MenuItems[5].Enabled = (m_axWebBrowser.QueryStatusWB //Refresh
        (SHDocVw.OLECMDID.OLECMDID_REFRESH).ToInt32() == nEnabledTest);
      miView.MenuItems[7].Enabled = (m_axWebBrowser.QueryStatusWB //Text Size
        (SHDocVw.OLECMDID.OLECMDID_ZOOM).ToInt32()
          == SHDocVw.OLECMDF.OLECMDF_SUPPORTED.ToInt32());
    }
    protected void mnuViewStatusBar_Click(object sender, EventArgs e)
    {
      m_barStatus.Visible = !m_barStatus.Visible;
    }
    protected void mnuViewGoToBack_Click(object sender, EventArgs e)
    {
      m_axWebBrowser.GoBack();
    }
    protected void mnuViewGoToForward_Click(object sender, EventArgs e)
    {
      m_axWebBrowser.GoForward();
    }
    protected void mnuViewGoToHomePage_Click(object sender, EventArgs e)
    {
      m_axWebBrowser.GoHome();
    }
    protected void mnuViewGoToSearchPage_Click(object sender, EventArgs e)
    {
      m_axWebBrowser.GoSearch();
    }
    protected void mnuViewStop_Click(object sender, EventArgs e)
    {
      m_axWebBrowser.Stop();
    }
    protected void mnuViewRefresh_Click(object sender, EventArgs e)
    {
      Object o = null;
      m_axWebBrowser.Refresh2(ref o);
    }
    private void SetFontSize(Int32 nNewSize)
    {
      Object o = null;
      Object size = (object)nNewSize;
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_ZOOM,
        SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
        ref size, ref o);
    }
    protected void mnuViewTextSize_Popup(object sender, EventArgs e)
    {
      Object o = null;
      Object size = null;
      Int32 nSize;
      MenuItem miView = m_mnuMain.MenuItems[2];
      MenuItem miViewTextSize = miView.MenuItems[7];
      foreach(MenuItem mi in miViewTextSize.MenuItems)
        mi.Checked = false;
      
      m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_ZOOM,
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
      m_axWebBrowser.FullScreen = true;
    }
    protected void mnuFavourites_Popup(object sender, EventArgs e)
    {
      Int32 nEnabledTest = SHDocVw.OLECMDF.OLECMDF_SUPPORTED.ToInt32()
        + SHDocVw.OLECMDF.OLECMDF_ENABLED.ToInt32();
      MenuItem miFavs = m_mnuMain.MenuItems[3];
      miFavs.MenuItems[0].Enabled = (m_axWebBrowser.QueryStatusWB //Add to favourites
        (SHDocVw.OLECMDID.OLECMDID_REFRESH).ToInt32() == nEnabledTest);
    }
    protected void mnuFavouritesAdd_Click(object sender, EventArgs e)
    {
      SHDocVw.ShellUIHelper shl;
      shl = new SHDocVw.ShellUIHelper();
      Object title = (object)m_axWebBrowser.LocationName;
      shl.AddFavorite(m_axWebBrowser.LocationURL, ref title);
    }
    protected void mnuFavouritesOrganise_Click(object sender, EventArgs e)
    {
      //Supposed to work but does not.
      /* SHDocVw.ShellUIHelper shl;
      shl = new SHDocVw.ShellUIHelper();
      Object o = null;
      shl.ShowBrowserUI("OrganizeFavorites", ref o); */
    }
    protected void tbStandard_ButtonDropDown(object sender, System.WinForms.ToolBarButtonClickEventArgs e)
    {
      
    }
    protected void tbStandard_ButtonClick(object sender, System.WinForms.ToolBarButtonClickEventArgs e)
    {
      if(e.button == m_tbtBack)
        { m_axWebBrowser.GoBack(); }
      if(e.button == m_tbtForward)
        { m_axWebBrowser.GoForward(); }
      if(e.button == m_tbtStop)
        { m_axWebBrowser.Stop(); }
      if(e.button == m_tbtRefresh)
      {
        Object o = null;
        m_axWebBrowser.Refresh2(ref o);
      }
      if(e.button == m_tbtHome)
        { m_axWebBrowser.GoHome(); }
      if(e.button == m_tbtSearch)
        { m_axWebBrowser.GoSearch(); }
      if(e.button == m_tbtPrint)
      {
        Object o = null;
        m_axWebBrowser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT,
          SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
          ref o, ref o);
      }
      if(e.button == m_tbtEdit)
      {
        IHTMLDocument2 doc;
        object boxDoc = m_axWebBrowser.Document;
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
      String sURL = m_cmbAddress.Items[m_cmbAddress.SelectedIndex].ToString();
      m_axWebBrowser.Navigate(sURL, ref o, ref o, ref o, ref o);
    }
    protected void cmbAddress_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = false;
      if(e.KeyChar == '\r')
      {
        String sURL = m_cmbAddress.Text;
        int index = m_cmbAddress.FindStringExact(sURL);
        if(index == -1)
        {
          m_cmbAddress.Items.Add(sURL);
          m_cmbAddress.SelectedIndex = m_cmbAddress.FindStringExact(sURL);
        }
        else
        {
          m_cmbAddress.SelectedIndex = index;
        }
      }
    }
    protected void btnGo_Click(object sender, System.EventArgs e)
    {
      String sURL = m_cmbAddress.Text;
      int index = m_cmbAddress.FindStringExact(sURL);
      if(index == -1)
      {
        m_cmbAddress.Items.Add(sURL);
        m_cmbAddress.SelectedIndex = m_cmbAddress.FindStringExact(sURL);
      }
      else
      {
        m_cmbAddress.SelectedIndex = index;
      }
    }

  }
}
