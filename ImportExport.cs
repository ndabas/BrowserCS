namespace ND.WebBrowser
{
  
  using System;
  using System.Drawing;
  using System.ComponentModel;
  using System.Windows.Forms;

  public class ImportExportForm : Form
  {
    private System.Resources.ResourceManager Resources;
    private Button ButtonCancel;
    private Button ButtonOK;
    private Button ButtonBrowse;
    private TextBox TextPath;
    private Label LabelWhere;
    private RadioButton RadioExport;
    private RadioButton RadioImport;
    private Label LabelWhat;
    private Label LabelDescription;
    private String Path;
    
    public ImportExportForm()
    {
      InitializeComponent();
    }
    
    private void InitializeComponent()
    {
      this.Resources = new System.Resources.ResourceManager(typeof(WebBrowserForm));
      this.LabelWhat = new Label();
      this.ButtonCancel = new Button();
      this.ButtonOK = new Button();
      this.RadioImport = new RadioButton();
      this.ButtonBrowse = new Button();
      this.LabelDescription = new Label();
      this.LabelWhere = new Label();
      this.RadioExport = new RadioButton();
      this.TextPath = new TextBox();
      
      LabelWhat.Location = new System.Drawing.Point(8, 64);
      LabelWhat.Text = Resources.GetString("LabelImportExportWhat");
      LabelWhat.Size = new System.Drawing.Size(376, 24);
      LabelWhat.TabIndex = 1;
      
      ButtonCancel.Location = new System.Drawing.Point(184, 240);
      ButtonCancel.DialogResult = DialogResult.Cancel;
      ButtonCancel.Size = new System.Drawing.Size(96, 24);
      ButtonCancel.TabIndex = 8;
      ButtonCancel.Text = Resources.GetString("ButtonCancel");
      
      ButtonOK.Location = new System.Drawing.Point(288, 240);
      ButtonOK.Size = new System.Drawing.Size(96, 24);
      ButtonOK.TabIndex = 7;
      ButtonOK.Text = Resources.GetString("ButtonOK");
      ButtonOK.Click += new System.EventHandler(btnOK_Click);
      
      RadioImport.Location = new System.Drawing.Point(8, 96);
      RadioImport.Text = Resources.GetString("LabelImportBookmarks");
      RadioImport.Size = new System.Drawing.Size(376, 24);
      RadioImport.TabIndex = 2;
      
      ButtonBrowse.Location = new System.Drawing.Point(288, 208);
      ButtonBrowse.Size = new System.Drawing.Size(96, 24);
      ButtonBrowse.TabIndex = 6;
      ButtonBrowse.Text = Resources.GetString("ButtonBrowse");
      ButtonBrowse.Click += new System.EventHandler(btnBrowse_Click);
      
      LabelDescription.Location = new System.Drawing.Point(8, 8);
      LabelDescription.Text = Resources.GetString("LabelImportExportDescription");
      LabelDescription.Size = new System.Drawing.Size(376, 48);
      LabelDescription.TabIndex = 0;
      
      LabelWhere.Location = new System.Drawing.Point(8, 160);
      LabelWhere.Text = Resources.GetString("LabelImportExportWhere");
      LabelWhere.Size = new System.Drawing.Size(376, 16);
      LabelWhere.TabIndex = 4;
      
      RadioExport.Checked = true;
      RadioExport.Location = new System.Drawing.Point(8, 120);
      RadioExport.Text = Resources.GetString("LabelExportFavourites");
      RadioExport.Size = new System.Drawing.Size(376, 24);
      RadioExport.TabIndex = 3;
      RadioExport.TabStop = true;
      
      TextPath.Location = new System.Drawing.Point(8, 176);
      TextPath.TabIndex = 5;
      TextPath.Size = new System.Drawing.Size(376, 20);
      TextPath.TextChanged += new System.EventHandler(txtPath_TextChanged);
      
      this.Text = Resources.GetString("DialogImportExport");
      this.Icon = (System.Drawing.Icon)Resources.GetObject("AppIcon");
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.CancelButton = ButtonCancel;
      this.AcceptButton = ButtonOK;
      this.ClientSize = new System.Drawing.Size(392, 269);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      
      this.Controls.Add(ButtonCancel);
      this.Controls.Add(ButtonOK);
      this.Controls.Add(ButtonBrowse);
      this.Controls.Add(TextPath);
      this.Controls.Add(LabelWhere);
      this.Controls.Add(RadioExport);
      this.Controls.Add(RadioImport);
      this.Controls.Add(LabelWhat);
      this.Controls.Add(LabelDescription);
    }
    protected void btnBrowse_Click(object sender, System.EventArgs e)
    {
      if(RadioExport.Checked)
      {
        SaveFileDialog saveFileDlg = new SaveFileDialog();
        saveFileDlg.Filter = "HTML Files (*.htm)|*.htm|All files (*.*)|*.*";
        saveFileDlg.FilterIndex = 1;
        saveFileDlg.RestoreDirectory = true ;
        if(saveFileDlg.ShowDialog() == DialogResult.OK)
        {
          TextPath.Text = saveFileDlg.FileName;
          Path = saveFileDlg.FileName;
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
          TextPath.Text = openFileDlg.FileName;
          Path = openFileDlg.FileName;
        }
      }
    }
    protected void btnOK_Click(object sender, System.EventArgs e)
    {
      SHDocVw.ShellUIHelper shl = new SHDocVw.ShellUIHelper();
      shl.ImportExportFavorites(RadioImport.Checked, Path);
      this.Close();
    }
    protected void txtPath_TextChanged(object sender, System.EventArgs e)
    {
      Path = TextPath.Text;
    }

  }
}
