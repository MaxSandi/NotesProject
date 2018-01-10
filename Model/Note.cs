using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace NotesProject.Model
{
    public class Note
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        private BitmapSource _image;
        public BitmapSource Image { get => _image; set => _image = value; }

        private string _description;
        public string Description { get => _description; set => _description = value; }

        public Note(string name, BitmapSource image, string description)
        {
            Name = name;
            Image = image;
            Description = description;
        }
    }
}
