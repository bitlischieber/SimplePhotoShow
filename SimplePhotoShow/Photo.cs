using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePhotoShow
{
    public class Photo
    {

        private string _path;
        public string Path
        {
            get { return _path;  }
            set {
                _path = value;
                string[] parts = _path.Split('\\');
                if (parts.Length > 0)
                {
                    _fileName = parts[parts.Length - 1];
                } else
                {
                    _fileName = value;
                }
            } // get
        }

        private string _fileName = "";
        public string FileName
        {
            get { return _fileName;  }
        }



    }
}
