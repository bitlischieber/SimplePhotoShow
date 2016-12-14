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
        }

        private void frmShow_SizeChanged(object sender, EventArgs e)
        {
            picShow.Size = this.Size;
            picShow.Location = new Point(0, 0);
        }

        public void SetPicture(String FileName)
        {
            try
            {
                if (picShow.Image != null)  picShow.Image.Dispose();
                picShow.Image = (Image)new Bitmap(FileName);
            } catch
            {

            }

        }

        private void picShow_Click(object sender, EventArgs e)
        {
            EventTogglePause arg = new EventTogglePause();
            EventHandler<EventTogglePause> handler = TogglePause;
            if (handler != null) handler(null, arg);
            if (arg.Pause) lblState.Text = "Paused"; else lblState.Text = "";
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
                EventNext arg = new SimplePhotoShow.EventNext();
                EventHandler<EventNext> handler = NextPic;
                if (handler != null) handler(null, arg);
                SetPicture(arg.FileName);
            }
            if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                // Previouse Picture
                EventPrev arg = new SimplePhotoShow.EventPrev();
                EventHandler<EventPrev> handler = PrevPic;
                if (handler != null) handler(null, arg);
                SetPicture(arg.FileName);
            }
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
