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

            Update();
        }

        public Note GetRandomNote()
        {
            try
            {
                if (notes.Count == 0)
                    throw new Exception("Отсутствуют элементы для показа");

                return notes.ElementAt(GenerateRandom(0, notes.Count));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Update()
        {
            notes.Clear();

            Properties.Settings settings = Properties.Settings.Default;

            if (settings.useNotes)
            {
                notes.Add(new Note("C", BitmapToBitmapSource(Properties.Resources.note_C), "до"));
                notes.Add(new Note("D", BitmapToBitmapSource(Properties.Resources.note_D), "ре"));
                notes.Add(new Note("E", BitmapToBitmapSource(Properties.Resources.note_E), "ми"));
                notes.Add(new Note("F", BitmapToBitmapSource(Properties.Resources.note_F), "фа"));
                notes.Add(new Note("G", BitmapToBitmapSource(Properties.Resources.note_G), "соль"));
                notes.Add(new Note("A", BitmapToBitmapSource(Properties.Resources.note_A), "ля"));
                notes.Add(new Note("B", BitmapToBitmapSource(Properties.Resources.note_B), "си"));

                if(settings.useDiezNotes)
                {
                    notes.Add(new Note("C#", BitmapToBitmapSource(Properties.Resources.note_C_diez), "до диез"));
                    notes.Add(new Note("D#", BitmapToBitmapSource(Properties.Resources.note_D_diez), "ре диез"));
                    notes.Add(new Note("F#", BitmapToBitmapSource(Properties.Resources.note_F_diez), "фа диез"));
                    notes.Add(new Note("G#", BitmapToBitmapSource(Properties.Resources.note_G_diez), "соль диез"));
                    notes.Add(new Note("A#", BitmapToBitmapSource(Properties.Resources.note_A_diez), "ля диез"));
                }

                if(settings.useBemolNotes)
                {
                    //TODO: добавить бемоли
                }
            }

            if(settings.useChords)
            {
                if(settings.useMajorTriad)
                {
                    notes.Add(new Note("C", BitmapToBitmapSource(Properties.Resources.chord_C), "до мажор"));
                    notes.Add(new Note("D", BitmapToBitmapSource(Properties.Resources.chord_D), "ре мажор"));
                    notes.Add(new Note("E", BitmapToBitmapSource(Properties.Resources.chord_E), "ми мажор"));
                    notes.Add(new Note("F", BitmapToBitmapSource(Properties.Resources.chord_F), "фа мажор"));
                    notes.Add(new Note("G", BitmapToBitmapSource(Properties.Resources.chord_G), "соль мажор"));
                    notes.Add(new Note("A", BitmapToBitmapSource(Properties.Resources.chord_A), "ля мажор"));
                    notes.Add(new Note("B", BitmapToBitmapSource(Properties.Resources.chord_B), "си мажор"));
                }

                if (settings.useMinorTriad)
                {
                    notes.Add(new Note("Cm", BitmapToBitmapSource(Properties.Resources.chord_Cm), "до минор"));
                    notes.Add(new Note("Dm", BitmapToBitmapSource(Properties.Resources.chord_Dm), "ре минор"));
                    notes.Add(new Note("Em", BitmapToBitmapSource(Properties.Resources.chord_Em), "ми минор"));
                    notes.Add(new Note("Fm", BitmapToBitmapSource(Properties.Resources.chord_Fm), "фа минор"));
                    notes.Add(new Note("Gm", BitmapToBitmapSource(Properties.Resources.chord_Gm), "соль минор"));
                    notes.Add(new Note("Am", BitmapToBitmapSource(Properties.Resources.chord_Am), "ля минор"));
                    notes.Add(new Note("Bm", BitmapToBitmapSource(Properties.Resources.chord_Bm), "си минор"));
                }
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
