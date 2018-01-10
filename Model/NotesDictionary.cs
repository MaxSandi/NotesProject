using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace NotesProject.Model
{
    public class NotesDictionary
    {
        private List<Note> notes;

        public NotesDictionary()
        {
            notes = new List<Note>();

            notes.Add(new Note("C", BitmapToBitmapSource(Properties.Resources.note_C), "до"));
        }

        public Note GetRandomNote()
        {
            try
            {
                return notes.ElementAt(GenerateRandom(0, notes.Count));
            }
            catch(IndexOutOfRangeException e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        private BitmapSource BitmapToBitmapSource(Bitmap source)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          source.GetHbitmap(),
                          IntPtr.Zero,
                          Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());
        }
        private int GenerateRandom(int min, int max)
        {
            var seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);
            return new Random(seed).Next(min, max);
        }
    }
}
