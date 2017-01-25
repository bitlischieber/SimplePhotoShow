using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePhotoShow
{
    public partial class frmRename : Form
    {

        List<Photo> _photos;
        bool _copyInProgress = false;
        bool _abortCopy = false;
        Thread _thdCopy;

        public void SetPhoto(ref List<Photo> photo)
        {
            _photos = photo;
        }

        public frmRename()
        {
            InitializeComponent();
        }

        private void chkPrefix_CheckedChanged(object sender, EventArgs e)
        {
            txtPrefix.Enabled = chkPrefix.Checked;
        }

        private void chkSuffix_CheckedChanged(object sender, EventArgs e)
        {
            txtSufix.Enabled = chkSuffix.Checked;
        }

        private void txtStartNum_KeyDown(object sender, KeyEventArgs e)
        {
            bool suppress = true;
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                suppress = false;
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                suppress = false;
            }
            else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right )
            {
                suppress = false;
            }
            e.SuppressKeyPress = suppress;
        }

        private void btnFolderBrowser_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(txtFolder.Text)) fbdTarget.SelectedPath = txtFolder.Text;
            if (fbdTarget.ShowDialog() == DialogResult.OK )
            {
                txtFolder.Text = fbdTarget.SelectedPath;
                txtFolder.Select(txtFolder.Text.Length - 1, 0); // scroll to the right
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!_copyInProgress)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                _abortCopy = true;
                btnCopy.Enabled = true;
            }
        }

        private void thdCopy()
        {
            String target = "";
            int startnumber = 0;

            if (!txtStartNum.InvokeRequired)
            {
                startnumber = System.Convert.ToInt32(txtStartNum.Text);
            }
            else
            {
                txtStartNum.Invoke(new MethodInvoker(delegate { startnumber = System.Convert.ToInt32(txtStartNum.Text); }));
            }
           
            int number = startnumber;
            int cnt = 0;
            //List<String> fileList;

            foreach(Photo file in _photos) {

                // compile target filename/path
                //    Folder
                if (!txtFolder.InvokeRequired)
                {
                    target = txtFolder.Text;
                }
                else
                {
                    txtFolder.Invoke(new MethodInvoker(delegate { target = txtFolder.Text; }));
                }

                if (!target.EndsWith("\\")) target += "\\";
                //    Prefix
                if (!chkPrefix.InvokeRequired)
                {
                    if (chkPrefix.Checked) target += txtPrefix.Text;
                }
                else
                {
                    txtFolder.Invoke(new MethodInvoker(delegate { if(chkPrefix.Checked) target += txtPrefix.Text; }));
                }
                //    Number
                bool fillChecked = false;
                if (!chkFill.InvokeRequired)
                {
                    fillChecked = chkFill.Checked;
                }
                else
                {
                    txtFolder.Invoke(new MethodInvoker(delegate { fillChecked = chkFill.Checked; }));
                }
                if (fillChecked)
                {
                    target += number.ToString(new string('0', (_photos.Count + startnumber).ToString().Length));
                }
                else
                {
                    target += number.ToString();
                }
                //    Suffix
                if (!chkSuffix.InvokeRequired)
                {
                    if (chkSuffix.Checked) target += txtSufix.Text;
                }
                else
                {
                    txtFolder.Invoke(new MethodInvoker(delegate { if (chkSuffix.Checked) target += txtSufix.Text; }));
                }
                //    File Extension
                string[] parts = file.Path.Split('.');
                if (parts.Length > 0) target += "." + parts[parts.Length - 1];
               
                // copy file
                try
                {
                    System.IO.File.Copy(file.Path, target);
                } 
                catch(Exception ex)
                {
                    MessageBox.Show("Copy error:\n\n" + ex.ToString(), "Copy error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _abortCopy = true ;
                }
             
                // Update progress and counters
                number++;
                cnt++;
                if (!pgbCopy.InvokeRequired)
                {
                    pgbCopy.Value = (int)(cnt * 100 / _photos.Count);
                }
                else
                {
                    pgbCopy.Invoke(new MethodInvoker(delegate { pgbCopy.Value = (int)(cnt * 100 / _photos.Count); }));
                }
                Application.DoEvents();
         
                // check for cancelation
                if (_abortCopy) break;

            } // for each
            _copyInProgress = false;
            _abortCopy = false;
            if (!btnCopy.InvokeRequired)
            {
                btnCopy.Enabled = true;
            }
            else
            {
                btnCopy.Invoke(new MethodInvoker(delegate { btnCopy.Enabled = true; }));
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(txtFolder.Text ))
            {
                MessageBox.Show("The target directory does not exist!", "Target dir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pgbCopy.Value = 0;
            btnCopy.Enabled = false;
            _copyInProgress = true;
            _abortCopy = false;
            _thdCopy = new Thread(thdCopy);
            _thdCopy.Start();
        }

        private void frmRename_Load(object sender, EventArgs e)
        {
            txtPrefix.Enabled = chkPrefix.Checked;
            txtSufix.Enabled = chkSuffix.Checked;
        }

    }
}
