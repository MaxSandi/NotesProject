using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NotesProject.Model;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace NotesProject.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private NotesDictionary _notesDictionary;
        private Note currentNote;

        private DispatcherTimer timerShowNextElem;
        private DispatcherTimer timerShowNoteImage;
        private bool isProcessing;

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

            isProcessing = false;

            timerShowNextElem = new DispatcherTimer();
            timerShowNextElem.Tick += (sender, args) =>
            {
                currentNote = _notesDictionary.GetRandomNote();
                TextNote = currentNote.Name;
                ImageNote = null;

                timerShowNoteImage.Start();
            };

            timerShowNoteImage = new DispatcherTimer();
            timerShowNoteImage.Tick += (sender, args) =>
            {
                if(currentNote != null)
                    ImageNote = currentNote.Image;

                timerShowNoteImage.Stop();
            };
        }

        private RelayCommand _startCommand;
        public RelayCommand StartCommand
        {
            get
            {
                return _startCommand
                  ?? (_startCommand = new RelayCommand(
                    () =>
                    {
                        isProcessing = true;

                        TextNote = string.Empty;
                        ImageNote = null;

                        timerShowNextElem.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.timeDelayNextElem);
                        timerShowNoteImage.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.timeDelayShowImage);

                        timerShowNextElem.Start();

                        _startCommand.RaiseCanExecuteChanged();
                        _stopCommand.RaiseCanExecuteChanged();
                        _optionsCommand.RaiseCanExecuteChanged();

                    }, () => !isProcessing));
            }
        }

        private RelayCommand _stopCommand;
        public RelayCommand StopCommand
        {
            get
            {
                return _stopCommand
                  ?? (_stopCommand = new RelayCommand(
                    () =>
                    {
                        isProcessing = false;

                        timerShowNextElem.Stop();
                        timerShowNoteImage.Stop();

                        _startCommand.RaiseCanExecuteChanged();
                        _stopCommand.RaiseCanExecuteChanged();
                        _optionsCommand.RaiseCanExecuteChanged();
                    }, () => isProcessing));
            }
        }

        private RelayCommand _optionsCommand;
        public RelayCommand OptionsCommand
        {
            get
            {
                return _optionsCommand
                  ?? (_optionsCommand = new RelayCommand(
                    () =>
                    {
                        Options optionsView = new Options(new OptionsViewModel());
                        optionsView.Owner = Application.Current.MainWindow;
                        optionsView.ShowDialog();
                    }, () => !isProcessing));
            }
        }

    }
}