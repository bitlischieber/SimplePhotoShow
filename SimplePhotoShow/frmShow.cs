using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePhotoShow
{

    public partial class frmShow : Form
    {

        // Show events
        public event EventHandler<EventTogglePause> TogglePause;
        public event EventHandler<EventNext> NextPic;
        public event EventHandler<EventPrev> PrevPic;
        public event EventHandler<EventStop> StopShow;

        // WMP
        //WMPLib.WindowsMediaPlayer _video;
        
        public frmShow()
        {
            InitializeComponent();
            this.picShow.MouseWheel += picShow_MouseWheel;
            lblState.Text = "";
        }

        private void picShow_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                // Previouse Picture
                EventPrev arg = new SimplePhotoShow.EventPrev();
                EventHandler<EventPrev> handler = PrevPic;
                if (handler != null) handler(null, arg);
                SetPicture(arg.FileName);
            } else if (e.Delta < 0) {
                // Next Picture
                EventNext arg = new SimplePhotoShow.EventNext();
                EventHandler<EventNext> handler = NextPic;
                if (handler != null) handler(null, arg);
                SetPicture(arg.FileName);
            }
        }

        private void frmShow_Load(object sender, EventArgs e)
        {
            picShow.Size = this.Size;
            picShow.Location = new Point(0, 0);
            wmp.Size = this.Size;
            wmp.Location = new Point(0, 0);
        }

        private void frmShow_SizeChanged(object sender, EventArgs e)
        {
            picShow.Size = this.Size;
            picShow.Location = new Point(0, 0);
            wmp.Size = this.Size;
            wmp.Location = new Point(0, 0);
        }

        public void SetPicture(String FileName)
        {
            try
            {
                if (picShow.Image != null)  picShow.Image.Dispose();
                if (FileName.ToLower().EndsWith(".avi") || FileName.ToLower().EndsWith(".mov") || FileName.ToLower().EndsWith(".mpg") || FileName.ToLower().EndsWith(".mpeg") || FileName.ToLower().EndsWith(".mp4"))
                { // movie
                    bool pauseState = GetPause();
                    SetPause();
                    wmp.URL = FileName;
                    wmp.Visible = true;
                    wmp.uiMode = "none";
                    picShow.Visible = false;
                    wmp.Ctlcontrols.play();
                    while(wmp.playState != WMPLib.WMPPlayState.wmppsStopped) Application.DoEvents();
                    wmp.Visible = false;
                    if (pauseState) ResetPause();
                    GetNextPicture();
                }
                else
                { // picture
                    wmp.Visible = false;
                    picShow.Image = (Image)new Bitmap(FileName);
                    picShow.Visible = true;
                }
             }
            catch (Exception ex)
            {
                Console.WriteLine("Media exception: " + ex.ToString());
            }

        }

        private void picShow_Click(object sender, EventArgs e)
        {
            EventTogglePause arg = new EventTogglePause();
            EventHandler<EventTogglePause> handler = TogglePause;
            if (handler != null) handler(null, arg);
            if (arg.Pause) lblState.Text = "Paused"; else lblState.Text = "";
        }

        private void wmp_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            if (wmp.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                wmp.Ctlcontrols.pause();
            }
            else if (wmp.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                wmp.Ctlcontrols.play ();
            }
        }

        private void frmShow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // Stop
                EventHandler<EventStop> handler = StopShow;
                if (handler != null) handler(null, null);
            }
            if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                // Next Picture
                GetNextPicture();
            }
            if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                // Previouse Picture
                GetPreviousePicture();
            }
        }

        private void GetPreviousePicture()
        {
            if (wmp.playState != WMPLib.WMPPlayState.wmppsStopped)
            {
                wmp.Ctlcontrols.stop();
                wmp.Visible = false;
            }
            EventPrev arg = new SimplePhotoShow.EventPrev();
            EventHandler<EventPrev> handler = PrevPic;
            if (handler != null) handler(null, arg);
            SetPicture(arg.FileName);
        }

        private void GetNextPicture()
        {
            if (wmp.playState != WMPLib.WMPPlayState.wmppsStopped)
            {
                wmp.Ctlcontrols.stop();
                wmp.Visible = false;
            }
            EventNext arg = new SimplePhotoShow.EventNext();
            EventHandler<EventNext> handler = NextPic;
            if (handler != null) handler(null, arg);
            SetPicture(arg.FileName);
        }

        private void SetPause()
        {
            EventTogglePause arg = new EventTogglePause();
            EventHandler<EventTogglePause> handler = TogglePause;
            if (handler != null) handler(null, arg);
            if (!arg.Pause) handler(null, arg); // Currently running --> Set pause
        }

        private void ResetPause()
        {
            EventTogglePause arg = new EventTogglePause();
            EventHandler<EventTogglePause> handler = TogglePause;
            if (handler != null) handler(null, arg);
            if (arg.Pause) handler(null, arg);  // Currently paused --> Set running
        }

        private bool GetPause()
        {
            EventTogglePause arg = new EventTogglePause();
            EventHandler<EventTogglePause> handler = TogglePause;
            if (handler != null) handler(null, arg);
            return arg.Pause;
        }

        private void wmp_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e)
        {
            GetNextPicture();
        }

    } // form class

    public class EventTogglePause : EventArgs
    {
        public Boolean Pause{ get; set; }
    }
    public class EventNext : EventArgs
    {
        public string FileName { get; set; }
    }

    public class EventPrev : EventArgs
    {
        public string FileName { get; set; }
    }

    public class EventStop : EventArgs
    {
        public EventStop() { }
    }

}
