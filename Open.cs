namespace ND.WebBrowser
{
  
  using System;
  using System.Drawing;
  using System.ComponentModel;
  using System.Windows.Forms;
  using Microsoft.Win32;

  public class OpenForm : Form
  {
    private System.Resources.ResourceManager Resources;
    private Button ButtonBrowse;
    private Button ButtonCancel;
    private Button ButtonOK;
    private ComboBox ComboAddress;
    private Label LabelOpen;
    private Label LabelText;
    private Panel PanelIcon;
    public String Address;

    public OpenForm()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      this.Resources = new System.Resources.ResourceManager(typeof(WebBrowserForm));
      this.ButtonBrowse = new Button();
      this.LabelOpen = new Label();
      this.ButtonOK = new Button();
      this.ButtonCancel = new Button();
      this.LabelText = new Label();
      this.PanelIcon = new Panel();
      this.ComboAddress = new ComboBox();
      
      ButtonBrowse.Location = new System.Drawing.Point(256, 88);
      ButtonBrowse.Size = new System.Drawing.Size(80, 24);
      ButtonBrowse.TabIndex = 6;
      ButtonBrowse.Text = Resources.GetString("ButtonBrowse");
      ButtonBrowse.Click += new EventHandler(btnBrowse_Click);
      
      LabelOpen.Location = new System.Drawing.Point(8, 56);
      LabelOpen.Text = Resources.GetString("LabelOpen");
      LabelOpen.Size = new System.Drawing.Size(48, 24);
      LabelOpen.TabIndex = 2;
      
      ButtonOK.Location = new System.Drawing.Point(80, 88);
      ButtonOK.Size = new System.Drawing.Size(80, 24);
      ButtonOK.TabIndex = 4;
      ButtonOK.DialogResult = DialogResult.OK;
      ButtonOK.Text = Resources.GetString("ButtonOK");
      
      ButtonCancel.Location = new System.Drawing.Point(168, 88);
      ButtonCancel.Size = new System.Drawing.Size(80, 24);
      ButtonCancel.TabIndex = 5;
      ButtonCancel.DialogResult = DialogResult.Cancel;
      ButtonCancel.Text = Resources.GetString("ButtonCancel");
      
      LabelText.Location = new System.Drawing.Point(72, 16);
      LabelText.Text = Resources.GetString("LabelOpenText");
      LabelText.Size = new System.Drawing.Size(264, 40);
      LabelText.TabIndex = 1;
      
      PanelIcon.Location = new System.Drawing.Point(16, 16);
      PanelIcon.Size = new System.Drawing.Size(32, 32);
      PanelIcon.TabIndex = 0;
      PanelIcon.TabStop = false;
      //PanelIcon.AllowTransparency = true;
      PanelIcon.BackgroundImage = (System.Drawing.Image)Resources.GetObject("IconOpen");
      
      ComboAddress.Location = new System.Drawing.Point(64, 56);
      ComboAddress.Size = new System.Drawing.Size(272, 21);
      ComboAddress.TabIndex = 3;
      ComboAddress.TextChanged += new EventHandler(cmbAddress_TextChanged);
      
      this.TransparencyKey = Color.FromArgb(253, 0, 253);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Text = Resources.GetString("DialogOpen");
      this.Icon = (System.Drawing.Icon)Resources.GetObject("AppIcon");
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.AcceptButton = ButtonOK;
      this.CancelButton = ButtonCancel;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
   
      this.ClientSize = new System.Drawing.Size(344, 117);
      
      this.Controls.Add(ButtonBrowse);
      this.Controls.Add(ButtonCancel);
      this.Controls.Add(ButtonOK);
      this.Controls.Add(ComboAddress);
      this.Controls.Add(LabelOpen);
      this.Controls.Add(LabelText);
      this.Controls.Add(PanelIcon);
      
      // Add typed URLs to Address combo
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
    }
    protected void btnBrowse_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.AddExtension = true;
      openFileDialog.Filter = "HTML Files|*.htm;*.html|Text Files|" +
        "*.txt|GIF Files|*.gif|JPEG Files|*.jpg;*.jpeg|" +
        "PNG Files|*.png|ART Files|*.art|AU Files|*.au|" +
        "AIFF Files|*.aiff;*.aif|XBM Files|*.xbm|All Files|*.*";
      openFileDialog.FilterIndex = 1 ;
      openFileDialog.RestoreDirectory = true ;

      if(openFileDialog.ShowDialog() == DialogResult.OK)
      {
        ComboAddress.Text = openFileDialog.FileName;
        Address = openFileDialog.FileName;
      }
    }
    protected void cmbAddress_TextChanged(object sender, EventArgs e)
    {
      Address = ComboAddress.Text;
    }

  }
}
