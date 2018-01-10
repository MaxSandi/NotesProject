using GalaSoft.MvvmLight;
using NotesProject.Model;
using System.Windows.Media.Imaging;

namespace NotesProject.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private NotesDictionary _notesDictionary;

        private string _textNote;
        public string TextNote
        {
            get { return _textNote; }
            set
            {
                if(_textNote != value)
                {
                    _textNote = value;
                    RaisePropertyChanged("TextNote");
                }
            }
        }
        private BitmapSource _imageNote;
        public BitmapSource ImageNote
        {
            get { return _imageNote; }
            set
            {
                if(_imageNote != value)
                {
                    _imageNote = value;
                    RaisePropertyChanged("ImageNote");
                }
            }
        }

        public MainViewModel(NotesDictionary notesDictionary)
        {
            _notesDictionary = notesDictionary;

            Note note = _notesDictionary.GetRandomNote();
            TextNote = "TEST";
            ImageNote = note.Image;
        }
    }
}