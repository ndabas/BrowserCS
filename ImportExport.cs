namespace Techinox.WebBrowser
{
  
  using System;
  using System.Drawing;
  using System.ComponentModel;
  using System.WinForms;

  public class ImportExportForm : System.WinForms.Form
  {
  
    private System.ComponentModel.Container m_Components;
    private System.Resources.ResourceManager m_Resources;
    private System.WinForms.Button m_btnCancel;
    private System.WinForms.Button m_btnOK;
    private System.WinForms.Button m_btnBrowse;
    private System.WinForms.TextBox m_txtPath;
    private System.WinForms.Label m_lblWhere;
    private System.WinForms.RadioButton m_radExport;
    private System.WinForms.RadioButton m_radImport;
    private System.WinForms.Label m_lblWhat;
    private System.WinForms.Label m_lblDescription;
    private String m_sPath;
    
    public ImportExportForm()
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
      this.m_lblWhat = new System.WinForms.Label();
      this.m_btnCancel = new System.WinForms.Button();
      this.m_btnOK = new System.WinForms.Button();
      this.m_radImport = new System.WinForms.RadioButton();
      this.m_btnBrowse = new System.WinForms.Button();
      this.m_lblDescription = new System.WinForms.Label();
      this.m_lblWhere = new System.WinForms.Label();
      this.m_radExport = new System.WinForms.RadioButton();
      this.m_txtPath = new System.WinForms.TextBox();
      
      m_lblWhat.Location = new System.Drawing.Point(8, 64);
      m_lblWhat.Text = m_Resources.GetString("LabelImportExportWhat");
      m_lblWhat.Size = new System.Drawing.Size(376, 24);
      m_lblWhat.TabIndex = 1;
      
      m_btnCancel.Location = new System.Drawing.Point(184, 240);
      m_btnCancel.DialogResult = System.WinForms.DialogResult.Cancel;
      m_btnCancel.Size = new System.Drawing.Size(96, 24);
      m_btnCancel.TabIndex = 8;
      m_btnCancel.Text = m_Resources.GetString("ButtonCancel");
      
      m_btnOK.Location = new System.Drawing.Point(288, 240);
      m_btnOK.Size = new System.Drawing.Size(96, 24);
      m_btnOK.TabIndex = 7;
      m_btnOK.Text = m_Resources.GetString("ButtonOK");
      m_btnOK.Click += new System.EventHandler(btnOK_Click);
      
      m_radImport.Location = new System.Drawing.Point(8, 96);
      m_radImport.Text = m_Resources.GetString("LabelImportBookmarks");
      m_radImport.Size = new System.Drawing.Size(376, 24);
      m_radImport.TabIndex = 2;
      
      m_btnBrowse.Location = new System.Drawing.Point(288, 208);
      m_btnBrowse.Size = new System.Drawing.Size(96, 24);
      m_btnBrowse.TabIndex = 6;
      m_btnBrowse.Text = m_Resources.GetString("ButtonBrowse");
      m_btnBrowse.Click += new System.EventHandler(btnBrowse_Click);
      
      m_lblDescription.Location = new System.Drawing.Point(8, 8);
      m_lblDescription.Text = m_Resources.GetString("LabelImportExportDescription");
      m_lblDescription.Size = new System.Drawing.Size(376, 48);
      m_lblDescription.TabIndex = 0;
      
      m_lblWhere.Location = new System.Drawing.Point(8, 160);
      m_lblWhere.Text = m_Resources.GetString("LabelImportExportWhere");
      m_lblWhere.Size = new System.Drawing.Size(376, 16);
      m_lblWhere.TabIndex = 4;
      
      m_radExport.Checked = true;
      m_radExport.Location = new System.Drawing.Point(8, 120);
      m_radExport.Text = m_Resources.GetString("LabelExportFavourites");
      m_radExport.Size = new System.Drawing.Size(376, 24);
      m_radExport.TabIndex = 3;
      m_radExport.TabStop = true;
      
      m_txtPath.Location = new System.Drawing.Point(8, 176);
      m_txtPath.TabIndex = 5;
      m_txtPath.Size = new System.Drawing.Size(376, 20);
      m_txtPath.TextChanged += new System.EventHandler(txtPath_TextChanged);
      
      this.Text = m_Resources.GetString("DialogImportExport");
      this.Icon = (System.Drawing.Icon)m_Resources.GetObject("AppIcon");
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.CancelButton = m_btnCancel;
      this.AcceptButton = m_btnOK;
      this.ClientSize = new System.Drawing.Size(392, 269);
      this.BorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      
      this.Controls.Add(m_btnCancel);
      this.Controls.Add(m_btnOK);
      this.Controls.Add(m_btnBrowse);
      this.Controls.Add(m_txtPath);
      this.Controls.Add(m_lblWhere);
      this.Controls.Add(m_radExport);
      this.Controls.Add(m_radImport);
      this.Controls.Add(m_lblWhat);
      this.Controls.Add(m_lblDescription);
    }
    protected void btnBrowse_Click(object sender, System.EventArgs e)
    {
      if(m_radExport.Checked)
      {
        SaveFileDialog saveFileDlg = new SaveFileDialog();
        saveFileDlg.Filter = "HTML Files (*.htm)|*.htm|All files (*.*)|*.*";
        saveFileDlg.FilterIndex = 1;
        saveFileDlg.RestoreDirectory = true ;
        if(saveFileDlg.ShowDialog() == DialogResult.OK)
        {
          m_txtPath.Text = saveFileDlg.FileName;
          m_sPath = saveFileDlg.FileName;
        }
      }
      else
      {
        OpenFileDialog openFileDlg = new OpenFileDialog();
        openFileDlg.Filter = "HTML Files (*.htm)|*.htm|All files (*.*)|*.*";
        openFileDlg.FilterIndex = 1;
        openFileDlg.RestoreDirectory = true ;
        if(openFileDlg.ShowDialog() == DialogResult.OK)
        {
          m_txtPath.Text = openFileDlg.FileName;
          m_sPath = openFileDlg.FileName;
        }
      }
    }
    protected void btnOK_Click(object sender, System.EventArgs e)
    {
      SHDocVw.ShellUIHelper shl = new SHDocVw.ShellUIHelper();
      shl.ImportExportFavorites(m_radImport.Checked, m_sPath);
      this.Close();
    }
    protected void txtPath_TextChanged(object sender, System.EventArgs e)
    {
      m_sPath = m_txtPath.Text;
    }

  }
}
