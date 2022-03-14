using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form1 : Form
    {
        //Global var
        //private string filePath = "C:/Users/hcolin/Documents/FileManagerBP/TestFolder";
        private string filePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).Replace("\\","/");
        private bool isFile = false;
        private string currentSelectedItemName = "";
        private string extension = "", oldFileName = "";
        private int editedFile = 0, editedFolder = 0;
        private Point? mouseWasDown = null;
        private EventHandler UnClicked;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pathTextBox.Text = filePath;
            loadFilesAndDirs();
        }

        private void loadButtonAction()
        {
            removeBackSlash();
            filePath = pathTextBox.Text;
            loadFilesAndDirs();
            isFile = false;
        }
        
        private void loadFilesAndDirs()
        {
            DirectoryInfo fileList;
            string tempFilePath = "";
            string[] rowListViewFile;
            string[] rowListViewDir;
            FileAttributes fileAttr;
            try
            {
                if (isFile)
                {
                    tempFilePath = filePath + "/" + currentSelectedItemName;
                    fileAttr = File.GetAttributes(tempFilePath);
                    //Process.Start(tempFilePath);
                }
                else
                {
                    fileAttr = File.GetAttributes(filePath);
                }
                if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    fileList = new DirectoryInfo(filePath);
                    FileInfo[] files = fileList.GetFiles("*.txt"); //Getting all the files (just .txt)
                    DirectoryInfo[] dirs = fileList.GetDirectories(); // Getting all the folders

                    listView1.Items.Clear();

                    foreach (var dir in dirs)
                    {
                        rowListViewDir = new string[] { dir.Name, dir.Extension, "<DIR>", dir.CreationTime.ToString() };
                        var listViewItem = new ListViewItem(rowListViewDir, 1);
                        listView1.Items.Add(listViewItem);
                        //listView1.Items.Add(dir.Name, 1);
                    }

                    foreach (var file in files)
                    {
                        rowListViewFile = new string[] { file.Name.Substring(0,file.Name.LastIndexOf(".")), file.Extension, file.Length.ToString(), file.CreationTime.ToString() };
                        var listViewItem = new ListViewItem(rowListViewFile, 0);
                        listView1.Items.Add(listViewItem);
                        //listView1.Items.Add(file.Name, 0);
                    }

                }
            }
            catch (FileNotFoundException)
            {
                // Here throw exception when file is deleted
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        
        private void removeBackSlash()
        {
            string path = pathTextBox.Text;

            if (pathTextBox.Text.Length - 1 == 1)
            {
                pathTextBox.Text = pathTextBox.Text + "//";
            }

                if (path.LastIndexOf("/") == path.Length - 1)
            {
                pathTextBox.Text = path.Substring(0, path.Length - 1);
            }
        }
        
        private void goBack()
        {
            try
            {
                removeBackSlash();
                string path = pathTextBox.Text;
                path = path.Substring(0, path.LastIndexOf("/"));
                this.isFile = false;
                pathTextBox.Text = path;
                removeBackSlash();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (pathTextBox.Text.Length - 1 == 2)
            {
                backBtn.Enabled = false;
            }
            else if (pathTextBox.Text.Length - 1 == 1)
            {
                pathTextBox.Text = pathTextBox.Text + "//";
                backBtn.Enabled = false;
            }
            else
            {
                backBtn.Enabled = true;
            }

            if (backBtn.Enabled)
            {
                goBack();
                loadButtonAction();
            }
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            loadButtonAction();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            DirectoryInfo fileList;
            FileInfo fileInfo;
            DirectoryInfo folderInfo;

            fileList = new DirectoryInfo(filePath);
            FileInfo[] files = fileList.GetFiles("*.txt"); //Getting all the files (just .txt)
            DirectoryInfo[] dirs = fileList.GetDirectories(); // Getting all the folders

            foreach (var dir in dirs)
            {
                if (dir.Name == e.Item.Text)
                {
                    extension = "";
                    break;
                }
            }

            foreach (var file in files)
            {
                if (file.Name.Substring(0, file.Name.LastIndexOf(".")) == e.Item.Text)
                {
                    extension = ".txt";
                    pathTextBox.Text = filePath;
                    break;
                }
            }

            if (editedFile == 1)
            {
                try
                {
                    //File.Move(filePath + "/" + oldFileName + extension, filePath + "/" + e.Item.Text + extension);
                    //loadButtonAction();
                    fileInfo = new FileInfo(filePath + "/" + oldFileName + extension);
                    if (fileInfo.Exists)
                    {
                        fileInfo.MoveTo(@filePath + "/" + e.Item.Text + extension);
                        loadButtonAction();
                    }
                }
                catch (Exception)
                {
                    //Here exception is throwed when file exists but not showing
                }
            }

            if (editedFolder == 1)
            {
                try
                {
                    folderInfo = new DirectoryInfo(filePath + "/" + oldFileName);
                    if (folderInfo.Exists)
                    {
                        //MessageBox.Show(filePath + "/" + oldFileName);
                        //MessageBox.Show(filePath + "/" + e.Item.Text);
                        Directory.Move(filePath + "/" + oldFileName, filePath + "/" + e.Item.Text);
                    }
                }
                catch (Exception)
                {
                    //Here exception is throwed when file exists but not showing
                }
            }

            currentSelectedItemName = e.Item.Text + extension;
            FileAttributes fileAttr = File.GetAttributes(filePath + "/" + currentSelectedItemName);

            if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                isFile = false;
                //pathTextBox.Text = filePath + "/" + currentSelectedItemName;
                pathTextBox.Text = (filePath + "/" + currentSelectedItemName).Replace("//", "/");
            }
            else
            {
                isFile = true;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            backBtn.Enabled = true;
            if (isFile)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    Process.Start(filePath + "/" + listView1.SelectedItems[0].Text + ".txt");
                }
            }
            else
            {
                loadButtonAction();
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            var focusedItem = listView1.FocusedItem;
            mouseWasDown = null;

            if (e.Button == MouseButtons.Right)
            {
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    if (isFile)
                    {
                        contextMSFile.Show(Cursor.Position);
                        loadButtonAction();
                    }
                    else
                    {
                        contextMSFolder.Show(Cursor.Position);
                        //loadButtonAction();
                    }
                }
            }
        }

        private void CreateNewFile_Click(object sender, EventArgs e)
        {
            try
            {
                string newFileName = "New Text Document.txt";
                int i = 0;

                while (File.Exists(filePath + "/" + newFileName))
                {
                    i += 1;
                    newFileName = "New Text Document (" + i.ToString() + ").txt";
                }

                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(filePath + "/" + newFileName))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(filePath + "/" + newFileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }

                loadButtonAction();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreateNewFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string newFolderName = "New Folder";
                int i = 1;

                while (Directory.Exists(filePath + "/" + newFolderName))
                {
                    i += 1;
                    newFolderName = "New Folder (" + i.ToString() + ")";
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(filePath + "/" + newFolderName);

                loadButtonAction();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void editFile_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Process.Start(filePath + "/" + listView1.SelectedItems[0].Text + ".txt");
            }
        }

        private void deleteFile_Click(object sender, EventArgs e)
        {
            string fileName;
            int itemIndex;
            if (listView1.SelectedItems.Count > 0)
            {
                fileName = listView1.SelectedItems[0].Text;
                itemIndex = listView1.SelectedItems[0].Index;
                if (listView1.Items[itemIndex].Selected)
                {
                    listView1.Items[itemIndex].Remove();
                    try
                    {
                        //fileInfo = new FileInfo(filePath + "/" + fileName + extension);
                        if (File.Exists(filePath + "/" + fileName + extension))
                        {
                            File.Delete(filePath + "/" + fileName + extension);
                                //Delete(@filePath + "/" + fileName + extension);
                            loadButtonAction();
                        }
                    }
                    catch (Exception)
                    {
                        //Here exception is throwed when file exists but not showing
                    }
                }
            }
        }

        private void renameFolder_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                oldFileName = listView1.SelectedItems[0].Text;
                listView1.SelectedItems[0].BeginEdit();
                editedFolder = 1;
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseWasDown = e.Location;
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseWasDown != null)
            {
                var diff = new Point(System.Math.Abs(e.Location.X - mouseWasDown.Value.X), System.Math.Abs(e.Location.Y - mouseWasDown.Value.Y));
                if (diff.X <= 2 && diff.Y <= 2)
                {
                    // Handling event when mouse click is outside listview items
                    OnUnClicked(EventArgs.Empty, e);
                }
            }
        }

        private void OnUnClicked(EventArgs e, MouseEventArgs m)
        {
            EventHandler handler = UnClicked;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
            else
            {
                if (m.Button == MouseButtons.Right)
                {
                    contextMSGeneral.Show(Cursor.Position);
                }                   
            }
        }

        private void createNewFolderMSGeneral_Click(object sender, EventArgs e)
        {
            CreateNewFolder_Click(sender, e);
        }

        private void createNewFileMSGeneral_Click(object sender, EventArgs e)
        {
            CreateNewFile_Click(sender, e);
        }

        private void deleteFolder_Click(object sender, EventArgs e)
        {
            string pathFolder;
            DirectoryInfo directory;
            DirectoryInfo[] subdirs;
            string folderName;
            int itemIndex;
            try
            {
                pathFolder = pathTextBox.Text;
                directory = new DirectoryInfo(pathFolder);
                subdirs = directory.GetDirectories();
                if (subdirs.Length != 0)
                {
                    var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                         "Confirm Delete!!",
                         MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        if (listView1.SelectedItems.Count > 0)
                        {
                            folderName = listView1.SelectedItems[0].Text;
                            itemIndex = listView1.SelectedItems[0].Index;
                            if (listView1.Items[itemIndex].Selected)
                            {
                                listView1.Items[itemIndex].Remove();
                                try
                                {
                                    Directory.Delete(pathFolder, recursive: true);
                                    loadButtonAction();
                                }
                                catch (Exception)
                                {
                                    //Here exception is throwed when file exists but not showing
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (listView1.SelectedItems.Count > 0)
                    {
                        folderName = listView1.SelectedItems[0].Text;
                        itemIndex = listView1.SelectedItems[0].Index;
                        if (listView1.Items[itemIndex].Selected)
                        {
                            listView1.Items[itemIndex].Remove();
                            try
                            {
                                Directory.Delete(pathFolder);
                                loadButtonAction();
                            }
                            catch (Exception)
                            {
                                //Here exception is throwed when file exists but not showing
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.Message);
            }

        }

        private void renameFile_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                oldFileName = listView1.SelectedItems[0].Text;
                listView1.SelectedItems[0].BeginEdit();
                editedFile = 1;
                extension = ".txt";
            }
        }
    }
}
