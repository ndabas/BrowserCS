namespace Techinox.WebBrowser
{
  
  using System;
  using System.Drawing;
  using System.ComponentModel;
  using System.WinForms;
  using Microsoft.Win32;

  public class OpenForm : Form
  {
    private System.ComponentModel.Container m_Components;
    private System.Resources.ResourceManager m_Resources;
    private System.WinForms.Button m_btnBrowse;
    private System.WinForms.Button m_btnCancel;
    private System.WinForms.Button m_btnOK;
    private System.WinForms.ComboBox m_cmbAddress;
    private System.WinForms.Label m_lblOpen;
    private System.WinForms.Label m_lblText;
    private System.WinForms.Panel m_picIcon;
    public String m_sAddress;

    public OpenForm()
    {
      InitializeComponent();
    }

    public override void Dispose()
    {
      base.Dispose();
      m_Components.Dispose();
    }

    private void InitializeComponent()
    {
      this.m_Resources = new System.Resources.ResourceManager(typeof(WebBrowserForm));
      this.m_Components = new System.ComponentModel.Container();
      this.m_btnBrowse = new System.WinForms.Button();
      this.m_lblOpen = new System.WinForms.Label();
      this.m_btnOK = new System.WinForms.Button();
      this.m_btnCancel = new System.WinForms.Button();
      this.m_lblText = new System.WinForms.Label();
      this.m_picIcon = new System.WinForms.Panel();
      this.m_cmbAddress = new System.WinForms.ComboBox();
      
      m_btnBrowse.Location = new System.Drawing.Point(256, 88);
      m_btnBrowse.Size = new System.Drawing.Size(80, 24);
      m_btnBrowse.TabIndex = 6;
      m_btnBrowse.Text = m_Resources.GetString("ButtonBrowse");
      m_btnBrowse.Click += new EventHandler(btnBrowse_Click);
      
      m_lblOpen.Location = new System.Drawing.Point(8, 56);
      m_lblOpen.Text = m_Resources.GetString("LabelOpen");
      m_lblOpen.Size = new System.Drawing.Size(48, 24);
      m_lblOpen.TabIndex = 2;
      
      m_btnOK.Location = new System.Drawing.Point(80, 88);
      m_btnOK.Size = new System.Drawing.Size(80, 24);
      m_btnOK.TabIndex = 4;
      m_btnOK.DialogResult = DialogResult.OK;
      m_btnOK.Text = m_Resources.GetString("ButtonOK");
      
      m_btnCancel.Location = new System.Drawing.Point(168, 88);
      m_btnCancel.Size = new System.Drawing.Size(80, 24);
      m_btnCancel.TabIndex = 5;
      m_btnCancel.DialogResult = DialogResult.Cancel;
      m_btnCancel.Text = m_Resources.GetString("ButtonCancel");
      
      m_lblText.Location = new System.Drawing.Point(72, 16);
      m_lblText.Text = m_Resources.GetString("LabelOpenText");
      m_lblText.Size = new System.Drawing.Size(264, 40);
      m_lblText.TabIndex = 1;
      
      m_picIcon.Location = new System.Drawing.Point(16, 16);
      m_picIcon.Size = new System.Drawing.Size(32, 32);
      m_picIcon.TabIndex = 0;
      m_picIcon.TabStop = false;
      m_picIcon.AllowTransparency = true;
      m_picIcon.BackgroundImage = (System.Drawing.Image)m_Resources.GetObject("IconOpen");
      
      m_cmbAddress.Location = new System.Drawing.Point(64, 56);
      m_cmbAddress.Size = new System.Drawing.Size(272, 21);
      m_cmbAddress.TabIndex = 3;
      m_cmbAddress.TextChanged += new EventHandler(cmbAddress_TextChanged);
      
      this.TransparencyKey = Color.FromARGB(253, 0, 253);
      this.BorderStyle = FormBorderStyle.FixedDialog;
      this.Text = m_Resources.GetString("DialogOpen");
      this.Icon = (System.Drawing.Icon)m_Resources.GetObject("AppIcon");
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.AcceptButton = m_btnOK;
      this.CancelButton = m_btnCancel;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
   
      this.ClientSize = new System.Drawing.Size(344, 117);
      
      this.Controls.Add(m_btnBrowse);
      this.Controls.Add(m_btnCancel);
      this.Controls.Add(m_btnOK);
      this.Controls.Add(m_cmbAddress);
      this.Controls.Add(m_lblOpen);
      this.Controls.Add(m_lblText);
      this.Controls.Add(m_picIcon);
      
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
        m_cmbAddress.Text = openFileDialog.FileName;
        m_sAddress = openFileDialog.FileName;
      }
    }
    protected void cmbAddress_TextChanged(object sender, EventArgs e)
    {
      m_sAddress = m_cmbAddress.Text;
    }

  }
}
