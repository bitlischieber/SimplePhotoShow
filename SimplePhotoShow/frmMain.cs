using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack;

namespace SimplePhotoShow
{
    public partial class frmMain : Form
    {

        public List<Photo> _photos = new List<Photo>();

        frmShow _showForm;
        Screen _showScreen;
        int _showScreenIdx = 0;
        Boolean _saved = true;
        int _intervalSec = 4;
        int _showIndex = 0;
        string _loadedFilename = "";

        public Boolean Saved
        {
            get { return _saved; }
            set
            {
                _saved = value;
                if (_saved) mnuSave.Enabled = false; else mnuSave.Enabled = true;
            }
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void setInterval4SecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Insert interval in sec.", "Set interval", _intervalSec.ToString(), -1, -1);
            int interval;

            if (int.TryParse(input, out interval))
            {
                if (interval > 0 && interval < 6000)
                {
                    _intervalSec = interval;
                    mnuInteval.Text = "Set inter&val: " + interval.ToString() + " sec";
                }
                else
                {
                    MessageBox.Show("Please enter a reasonable interval time in sec. (1-6000)", "Invalid interval", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // is numeric
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Get nofs screens
            Screen[] screens = Screen.AllScreens;
            _showScreen = screens[0];
            _showScreenIdx = 0;
            if (screens.Length > 1 && screens[0].Primary)
            {
                _showScreen = screens[1];
                _showScreenIdx = 1;
            }
            btnStop.Enabled = false;
        }

        private void mnuShowScreen_Click(object sender, EventArgs e)
        {
            Screen[] screens = Screen.AllScreens;

            if (_showScreen.Primary)
            {
                _showScreenIdx = _showScreenIdx == 0 ? 1 : 0;
                _showScreen = screens[_showScreenIdx];
                mnuShowScreen.Text = "Show screen: Secondary";
            }
            else
            {
                for (int i = 0; i < screens.Length; i++)
                {
                    if (screens[i].Primary)
                    {
                        _showScreenIdx = i;
                        _showScreen = screens[i];
                    }
                }
                mnuShowScreen.Text = "Show screen: Primary";
            } // if currently primary screen 
        }

        private void lstFiles_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (files != null)
            {
                if (files.Length == 0) return; // No files, abort
                // Add new files from external
                foreach (string fileName in files)
                {
                    Photo photo = new Photo();
                    photo.Path = fileName;
                    _photos.Add(photo);
                    lstFiles.Items.Add(photo.FileName);
                }
                lstFiles.SelectedItems.Clear();
                lstFiles.SelectedIndex = lstFiles.Items.Count - 1;
                Saved = false;
            }
        }

        private void lstFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            } // if
        }
        private void lstFiles_Click(object sender, EventArgs e)
        {
            UpdatePrevPic();
        }

        private void UpdatePrevPic()
        {
            if (lstFiles.SelectedIndex >= 0)
            {
                String filename;

                if (picCurr.Image != null) picCurr.Image.Dispose();
                filename = _photos[lstFiles.SelectedIndex].Path.ToLower();
                if (filename.ToLower().EndsWith(".avi") || filename.ToLower().EndsWith(".mov") || filename.ToLower().EndsWith(".mpg") || filename.ToLower().EndsWith(".mpeg") || filename.ToLower().EndsWith(".mp4"))
                {
                    ShellFile shellFile = ShellFile.FromFilePath(_photos[lstFiles.SelectedIndex].Path);
                    picCurr.Image = (Image)shellFile.Thumbnail.ExtraLargeBitmap;
                }
                else
                {
                    picCurr.Image = (Image)new Bitmap(_photos[lstFiles.SelectedIndex].Path);

                }
                // show prev/next
                if (lstFiles.SelectedIndex == 0)
                {
                    picLast.Image = null;
                }
                else
                {
                    if (picLast.Image != null) picLast.Image.Dispose();
                    filename = _photos[lstFiles.SelectedIndex - 1].Path.ToLower();
                    if (filename.ToLower().EndsWith(".avi") || filename.ToLower().EndsWith(".mov") || filename.ToLower().EndsWith(".mpg") || filename.ToLower().EndsWith(".mpeg") || filename.ToLower().EndsWith(".mp4"))
                    {
                        ShellFile shellFile = ShellFile.FromFilePath(_photos[lstFiles.SelectedIndex - 1].Path);
                        picLast.Image = (Image)shellFile.Thumbnail.ExtraLargeBitmap;
                    }
                    else
                    {
                        picLast.Image = (Image)new Bitmap(_photos[lstFiles.SelectedIndex - 1].Path);
                    }
                } // if first image
                if (lstFiles.SelectedIndex == _photos.Count - 1)
                {
                    picNext.Image = null;
                }
                else
                {
                    if (picNext.Image != null) picNext.Image.Dispose();
                    filename = _photos[lstFiles.SelectedIndex + 1].Path.ToLower();
                    if (filename.ToLower().EndsWith(".avi") || filename.ToLower().EndsWith(".mov") || filename.ToLower().EndsWith(".mpg") || filename.ToLower().EndsWith(".mpeg") || filename.ToLower().EndsWith(".mp4"))
                    {
                        ShellFile shellFile = ShellFile.FromFilePath(_photos[lstFiles.SelectedIndex + 1].Path);
                        picNext.Image = (Image)shellFile.Thumbnail.ExtraLargeBitmap;
                    }
                    else
                    {
                        picNext.Image = (Image)new Bitmap(_photos[lstFiles.SelectedIndex + 1].Path);
                    }
                } // if last image
                // show full path in label
                txtFullPath.Text = _photos[lstFiles.SelectedIndex].Path;
                txtFullPath.Select(txtFullPath.TextLength - 1, 0);
            } // if index > 0
        }

        private void UpdatePrevPic(int Index)
        {
            lstFiles.ClearSelected();
            lstFiles.SelectedIndex = Index;
            UpdatePrevPic();
        }

        private void lstFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // remove selected item
                foreach (int idx in lstFiles.SelectedIndices)
                {
                    lstFiles.Items.RemoveAt(idx);
                    _photos.RemoveAt(idx);
                } // foreach
                Saved = false;
            } // key == delte
            if (e.Control && e.KeyCode == Keys.Up) {
                MoveItem(-1, lstFiles.SelectedIndex + 1);
            }
            if (e.Control && e.KeyCode == Keys.Down)
            {
                MoveItem(1, lstFiles.SelectedIndex - 1);
            }
            UpdatePrevPic();
        }

        public void MoveItem(int direction, int CurrIdx)
        {
            
            // Checking selected item
            if (lstFiles.SelectedItem == null || CurrIdx < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = CurrIdx + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= lstFiles.Items.Count)
                return; // Index out of range - nothing to do

            object selected = lstFiles.Items[CurrIdx];
            Photo selectedp = _photos[CurrIdx];
            // Removing removable element
            lstFiles.Items.RemoveAt(CurrIdx);
            _photos.RemoveAt(CurrIdx);
            // Insert it in new position
            lstFiles.Items.Insert(newIndex, selected);
            _photos.Insert(newIndex, selectedp);
            // Restore selection
            lstFiles.ClearSelected();
            lstFiles.SetSelected(newIndex, true);

            Saved = false;
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog filopen = new OpenFileDialog();
            filopen.Filter = "SimplePhotoShow XML (*.xml)|*.xml";
            filopen.RestoreDirectory = true;
            filopen.Title = "Open photo list...";

            if (filopen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // flush
                    mnuNew_Click(null, null);
                    // Load file content
                    StringReader stringReader = new StringReader(File.ReadAllText(filopen.FileName));
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Photo>));
                    _photos = (List<Photo>)serializer.Deserialize(stringReader);
                    // remember file
                    _loadedFilename = filopen.FileName;
                    this.Text = "Simple Photo Show - " + _loadedFilename;
                    // insert photos in to list
                    foreach (Photo photo in _photos)
                    {
                        lstFiles.Items.Add(photo.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No valid SimplePhotoShow formated file!\n\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } // file picker
            } // filopen ok
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog filesave = new SaveFileDialog();
            filesave.Filter = "SimplePhotoShow XML (*.xml)|*.xml";
            filesave.RestoreDirectory = true;
            filesave.Title = "Save photo list...";

            if (_loadedFilename == "")
            {
                // Not saved until now -> Show dialog
                if ((filesave.ShowDialog() == DialogResult.OK))
                {
                    try
                    {
                        _loadedFilename = filesave.FileName;
                        this.Text = "Simple Photo Show - " + _loadedFilename;
                        StringWriter stringWriter = new StringWriter();
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Photo>));
                        serializer.Serialize(stringWriter, _photos);
                        File.WriteAllText(_loadedFilename, stringWriter.ToString());
                        Saved = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No valid SimplePhotoShow formated file!\n\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // file picker
                } // filsave ok
            } else
            {
                // Already saved once -> overwrite
                StringWriter stringWriter = new StringWriter();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Photo>));
                serializer.Serialize(stringWriter, _photos);
                File.WriteAllText(_loadedFilename, stringWriter.ToString());
                Saved = true;
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            if (Saved == false ) { 
                DialogResult res = MessageBox.Show("There are unsaved changes.\nDo you want save the changes?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel) return;
                if (res == DialogResult.Yes) mnuSave_Click(null, null);
            }

            picCurr.Image = null;
            picLast.Image = null;
            picNext.Image = null;
            txtFullPath.Text = "";
            _photos.Clear();
            lstFiles.Items.Clear();
            _loadedFilename = "";
            this.Text = "Simple Photo Show";
            Saved = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartShow(0);
        }

        private void StartShow(int StartIndex)
        {
            if (lstFiles.Items.Count == 0)
            {
                // Nothing to show
                MessageBox.Show("No pictures to show. Please drop some files to the list.", "Nothing to show", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnStop.Enabled = true;
            _showIndex = StartIndex;
            _showForm = new frmShow();
            _showForm.NextPic += _showForm_NextPic;
            _showForm.PrevPic += _showForm_PrevPic;
            _showForm.StopShow += _showForm_StopShow;
            _showForm.TogglePause += _showForm_TogglePause;
            _showForm.StartPosition = FormStartPosition.Manual;
            _showForm.Left = _showScreen.WorkingArea.Left;
            _showForm.Top = _showScreen.WorkingArea.Top;
            _showForm.Show();
            if (mnuTimer.Checked)
            {
                tmrShow.Interval = _intervalSec * 1000;
                tmrShow.Enabled = true;
            }
            _showForm.SetPicture(_photos[_showIndex].Path);
            UpdatePrevPic(_showIndex);
        }

        private void _showForm_TogglePause(object sender, EventTogglePause e)
        {
            if (mnuTimer.Checked)
            {
                tmrShow.Enabled = !tmrShow.Enabled;
                e.Pause = !tmrShow.Enabled;
            }
            else
            {
                e.Pause = false;
            }
        }

        private void _showForm_StopShow(object sender, EventStop e)
        {
            _showForm.NextPic -= _showForm_NextPic;
            _showForm.PrevPic -= _showForm_PrevPic;
            _showForm.StopShow -= _showForm_StopShow;
            _showForm.TogglePause -= _showForm_TogglePause;
            _showForm.Close();
            _showForm = null;
            if (mnuTimer.Checked) tmrShow.Enabled = false;
        }

        private void _showForm_PrevPic(object sender, EventPrev e)
        {
            if (_showIndex > 0)
            {
                _showIndex--;
                e.FileName = _photos[_showIndex].Path;
                UpdatePrevPic(_showIndex);
            }
        }

        private void _showForm_NextPic(object sender, EventNext e)
        {
            if (_showIndex < _photos.Count - 1)
            {
                _showIndex++;
                e.FileName = _photos[_showIndex].Path;
                UpdatePrevPic(_showIndex);
            }
        }

        private void tmrShow_Tick(object sender, EventArgs e)
        {
            if (_showIndex < _photos.Count - 1)
            {
                _showIndex++;
                _showForm.SetPicture(_photos[_showIndex].Path);
                UpdatePrevPic(_showIndex);
            }
            else
            {
                _showForm_StopShow(null, null);
                btnStop.Enabled = false;
                btnStart.Text = "Start";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _showForm_StopShow(null, null);
            btnStop.Enabled = false;
            btnStart.Text = "Start";
        }

        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            StartShow(lstFiles.SelectedIndex);
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            _loadedFilename = "";
            this.Text = "Simple Photo Show";
            mnuSave_Click(null, null);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Saved == false)
            {
                DialogResult res = MessageBox.Show("There are unsaved changes.\nDo you want save the changes?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel) e.Cancel = true;
                if (res == DialogResult.Yes) mnuSave_Click(null, null);
            }
        }
    }
}
