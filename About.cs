namespace ND.WebBrowser
{
  
  using System;
  using System.Drawing;
  using System.ComponentModel;
  using System.Windows.Forms;
  
  public class AboutForm : Form
  {
    
    private System.Resources.ResourceManager Resources;
    private Button ButtonOK;
    private Panel ImageIcon;
    private Label LabelCopyright;
    private Label LabelVersion;
    private Label LabelTitle;

    public AboutForm()
    {
      InitializeComponent();
    }
    
    private void InitializeComponent()
    {
      this.Resources = new System.Resources.ResourceManager(typeof(WebBrowserForm));
      this.ImageIcon = new Panel();
      this.LabelTitle = new Label();
      this.ButtonOK = new Button();
      this.LabelCopyright = new Label();
      this.LabelVersion = new Label();
      
      ImageIcon.Location = new System.Drawing.Point(8, 8);
      ImageIcon.BackgroundImage = (System.Drawing.Image)Resources.GetObject("IconOpen");
      ImageIcon.Size = new System.Drawing.Size(32, 32);
      ImageIcon.TabIndex = 3;
      
      LabelTitle.Location = new System.Drawing.Point(56, 8);
      LabelTitle.Text = Resources.GetString("AppTitle");
      LabelTitle.Size = new System.Drawing.Size(256, 16);
      LabelTitle.TabIndex = 0;
      
      ButtonOK.Location = new System.Drawing.Point(216, 104);
      ButtonOK.DialogResult = DialogResult.OK;
      ButtonOK.Size = new System.Drawing.Size(96, 24);
      ButtonOK.TabIndex = 5;
      ButtonOK.Text = Resources.GetString("ButtonOK");
      
      LabelCopyright.Location = new System.Drawing.Point(8, 56);
      LabelCopyright.Text = Resources.GetString("AppCopyright");
      LabelCopyright.Size = new System.Drawing.Size(304, 16);
      LabelCopyright.TabIndex = 2;
      
      LabelVersion.Location = new System.Drawing.Point(56, 24);
      LabelVersion.Text = "Version 1.0";
      LabelVersion.Size = new System.Drawing.Size(256, 16);
      LabelVersion.TabIndex = 1;
      
      this.Text = Resources.GetString("DialogAbout");
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(322, 135);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      
      this.Controls.Add(ButtonOK);
      this.Controls.Add(ImageIcon);
      this.Controls.Add(LabelCopyright);
      this.Controls.Add(LabelVersion);
      this.Controls.Add(LabelTitle);
    }

  }
}
