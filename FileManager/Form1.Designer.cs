
namespace FileManager
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backBtn = new System.Windows.Forms.Button();
            this.goBtn = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileExtension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.contextMSFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMSFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMSGeneral = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.holaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMSFolder.SuspendLayout();
            this.contextMSFile.SuspendLayout();
            this.contextMSGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            resources.ApplyResources(this.backBtn, "backBtn");
            this.backBtn.Name = "backBtn";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // goBtn
            // 
            resources.ApplyResources(this.goBtn, "goBtn");
            this.goBtn.Name = "goBtn";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // pathTextBox
            // 
            resources.ApplyResources(this.pathTextBox, "pathTextBox");
            this.pathTextBox.Name = "pathTextBox";
            // 
            // pathBtn
            // 
            this.pathBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.pathBtn, "pathBtn");
            this.pathBtn.Name = "pathBtn";
            this.pathBtn.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.fileExtension,
            this.fileSize,
            this.fileDate});
            this.listView1.HideSelection = false;
            this.listView1.LabelEdit = true;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.LargeImageList = this.iconList;
            this.listView1.Name = "listView1";
            this.listView1.SmallImageList = this.iconList;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // fileName
            // 
            resources.ApplyResources(this.fileName, "fileName");
            // 
            // fileExtension
            // 
            resources.ApplyResources(this.fileExtension, "fileExtension");
            // 
            // fileSize
            // 
            resources.ApplyResources(this.fileSize, "fileSize");
            // 
            // fileDate
            // 
            resources.ApplyResources(this.fileDate, "fileDate");
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "file.png");
            this.iconList.Images.SetKeyName(1, "folder.png");
            // 
            // contextMSFolder
            // 
            this.contextMSFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenu,
            this.renameFolderToolStripMenuItem,
            this.deleteFolderToolStripMenuItem});
            this.contextMSFolder.Name = "contextMSGeneral";
            this.contextMSFolder.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            resources.ApplyResources(this.contextMSFolder, "contextMSFolder");
            // 
            // newMenu
            // 
            this.newMenu.Name = "newMenu";
            resources.ApplyResources(this.newMenu, "newMenu");
            this.newMenu.Click += new System.EventHandler(this.CreateNewFolder_Click);
            // 
            // renameFolderToolStripMenuItem
            // 
            this.renameFolderToolStripMenuItem.Name = "renameFolderToolStripMenuItem";
            resources.ApplyResources(this.renameFolderToolStripMenuItem, "renameFolderToolStripMenuItem");
            this.renameFolderToolStripMenuItem.Click += new System.EventHandler(this.renameFolder_Click);
            // 
            // deleteFolderToolStripMenuItem
            // 
            this.deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
            resources.ApplyResources(this.deleteFolderToolStripMenuItem, "deleteFolderToolStripMenuItem");
            this.deleteFolderToolStripMenuItem.Click += new System.EventHandler(this.deleteFolder_Click);
            // 
            // contextMSFile
            // 
            this.contextMSFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.renameFileToolStripMenuItem,
            this.editFileToolStripMenuItem,
            this.deleteFileToolStripMenuItem});
            this.contextMSFile.Name = "contextMSFile";
            resources.ApplyResources(this.contextMSFile, "contextMSFile");
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            resources.ApplyResources(this.renameToolStripMenuItem, "renameToolStripMenuItem");
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.CreateNewFile_Click);
            // 
            // renameFileToolStripMenuItem
            // 
            this.renameFileToolStripMenuItem.Name = "renameFileToolStripMenuItem";
            resources.ApplyResources(this.renameFileToolStripMenuItem, "renameFileToolStripMenuItem");
            this.renameFileToolStripMenuItem.Click += new System.EventHandler(this.renameFile_Click);
            // 
            // editFileToolStripMenuItem
            // 
            this.editFileToolStripMenuItem.Name = "editFileToolStripMenuItem";
            resources.ApplyResources(this.editFileToolStripMenuItem, "editFileToolStripMenuItem");
            this.editFileToolStripMenuItem.Click += new System.EventHandler(this.editFile_Click);
            // 
            // deleteFileToolStripMenuItem
            // 
            this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            resources.ApplyResources(this.deleteFileToolStripMenuItem, "deleteFileToolStripMenuItem");
            this.deleteFileToolStripMenuItem.Click += new System.EventHandler(this.deleteFile_Click);
            // 
            // contextMSGeneral
            // 
            this.contextMSGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.holaToolStripMenuItem,
            this.createNewFolderToolStripMenuItem});
            this.contextMSGeneral.Name = "contextMSGeneral";
            resources.ApplyResources(this.contextMSGeneral, "contextMSGeneral");
            // 
            // holaToolStripMenuItem
            // 
            this.holaToolStripMenuItem.Name = "holaToolStripMenuItem";
            resources.ApplyResources(this.holaToolStripMenuItem, "holaToolStripMenuItem");
            this.holaToolStripMenuItem.Click += new System.EventHandler(this.createNewFileMSGeneral_Click);
            // 
            // createNewFolderToolStripMenuItem
            // 
            this.createNewFolderToolStripMenuItem.Name = "createNewFolderToolStripMenuItem";
            resources.ApplyResources(this.createNewFolderToolStripMenuItem, "createNewFolderToolStripMenuItem");
            this.createNewFolderToolStripMenuItem.Click += new System.EventHandler(this.createNewFolderMSGeneral_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pathBtn);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.backBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMSFolder.ResumeLayout(false);
            this.contextMSFile.ResumeLayout(false);
            this.contextMSGeneral.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button pathBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader fileExtension;
        private System.Windows.Forms.ColumnHeader fileSize;
        private System.Windows.Forms.ColumnHeader fileDate;
        private System.Windows.Forms.ContextMenuStrip contextMSFolder;
        private System.Windows.Forms.ToolStripMenuItem newMenu;
        private System.Windows.Forms.ContextMenuStrip contextMSFile;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMSGeneral;
        private System.Windows.Forms.ToolStripMenuItem holaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewFolderToolStripMenuItem;
    }
}

