namespace Techinox.WebBrowser
{
  
  using System;
  using System.Drawing;
  using System.ComponentModel;
  using System.WinForms;
  
  public class AboutForm : System.WinForms.Form
  {
    
    private System.ComponentModel.Container m_Components;
    private System.Resources.ResourceManager m_Resources;
    private System.WinForms.Button m_btnOK;
    private System.WinForms.LinkLabel m_lnkTechinox;
    private System.WinForms.Panel m_imgIcon;
    private System.WinForms.Label m_lblCopyright;
    private System.WinForms.Label m_lblVersion;
    private System.WinForms.Label m_lblTitle;

    public AboutForm()
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
      this.m_Components = new System.ComponentModel.Container();
      this.m_Resources = new System.Resources.ResourceManager(typeof(WebBrowserForm));
      this.m_imgIcon = new System.WinForms.Panel();
      this.m_lblTitle = new System.WinForms.Label();
      this.m_btnOK = new System.WinForms.Button();
      this.m_lnkTechinox = new System.WinForms.LinkLabel();
      this.m_lblCopyright = new System.WinForms.Label();
      this.m_lblVersion = new System.WinForms.Label();
      
      m_imgIcon.Location = new System.Drawing.Point(8, 8);
      m_imgIcon.BackgroundImage = (System.Drawing.Image)m_Resources.GetObject("IconOpen");
      m_imgIcon.Size = new System.Drawing.Size(32, 32);
      m_imgIcon.TabIndex = 3;
      
      m_lblTitle.Location = new System.Drawing.Point(56, 8);
      m_lblTitle.Text = m_Resources.GetString("AppTitle");
      m_lblTitle.Size = new System.Drawing.Size(256, 16);
      m_lblTitle.TabIndex = 0;
      
      m_btnOK.Location = new System.Drawing.Point(216, 104);
      m_btnOK.DialogResult = System.WinForms.DialogResult.OK;
      m_btnOK.Size = new System.Drawing.Size(96, 24);
      m_btnOK.TabIndex = 5;
      m_btnOK.Text = m_Resources.GetString("ButtonOK");
      
      m_lnkTechinox.Text = "http://www.techinox.com/";
      m_lnkTechinox.Size = new System.Drawing.Size(304, 16);
      m_lnkTechinox.TabIndex = 4;
      m_lnkTechinox.TabStop = true;
      m_lnkTechinox.Location = new System.Drawing.Point(8, 80);
      m_lnkTechinox.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkTechinox_LinkClicked);
      
      m_lblCopyright.Location = new System.Drawing.Point(8, 56);
      m_lblCopyright.Text = m_Resources.GetString("AppCopyright");
      m_lblCopyright.Size = new System.Drawing.Size(304, 16);
      m_lblCopyright.TabIndex = 2;
      
      m_lblVersion.Location = new System.Drawing.Point(56, 24);
      m_lblVersion.Text = "Version 1.0.462.33592";
      m_lblVersion.Size = new System.Drawing.Size(256, 16);
      m_lblVersion.TabIndex = 1;
      
      this.Text = m_Resources.GetString("DialogAbout");
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(322, 135);
      this.BorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      
      this.Controls.Add(m_btnOK);
      this.Controls.Add(m_lnkTechinox);
      this.Controls.Add(m_imgIcon);
      this.Controls.Add(m_lblCopyright);
      this.Controls.Add(m_lblVersion);
      this.Controls.Add(m_lblTitle);
    }

    protected void lnkTechinox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      
    }

  }
}
