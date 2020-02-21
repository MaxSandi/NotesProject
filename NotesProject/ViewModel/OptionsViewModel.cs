using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesProject.ViewModel
{
    public class OptionsViewModel : ViewModelBase
    {
        #region Общие
        private uint _timeDelayNextElem;
        public uint TimeDelayNextElem
        {
            get { return _timeDelayNextElem; }
            set
            {
                _timeDelayNextElem = value;
                RaisePropertyChanged("TimeDelayNextElem");
            }
        }

        private uint _timeDelayShowImage;
        public uint TimeDelayShowImage
        {
            get { return _timeDelayShowImage; }
            set
            {
                _timeDelayShowImage = value;
                RaisePropertyChanged("TimeDelayShowImage");
            }
        }

        private bool _showDescription;
        public bool ShowDescription
        {
            get { return _showDescription; }
            set
            {
                _showDescription = value;
                RaisePropertyChanged("ShowDescription");
            }
        }
        #endregion
        #region Ноты
        private bool _useNotes;
        public bool UseNotes
        {
            get { return _useNotes; }
            set
            {
                _useNotes = value;
                RaisePropertyChanged("UseNotes");
            }
        }

        private bool _useDiezNotes;
        public bool UseDiezNotes
        {
            get { return _useDiezNotes; }
            set
            {
                _useDiezNotes = value;
                RaisePropertyChanged("UseDiezNotes");
            }
        }

        private bool _useBemolNotes;
        public bool UseBemolNotes
        {
            get { return _useBemolNotes; }
            set
            {
                _useBemolNotes = value;
                RaisePropertyChanged("UseBemolNotes");
            }
        }
        #endregion
        #region Аккорды
        private bool _useChords;
        public bool UseChords
        {
            get { return _useChords; }
            set
            {
                _useChords = value;
                RaisePropertyChanged("UseChords");
            }
        }

        private bool _useMajorTriad;
        public bool UseMajorTriad
        {
            get { return _useMajorTriad; }
            set
            {
                _useMajorTriad = value;
                RaisePropertyChanged("UseMajorTriad");
            }
        }

        private bool _useMinorTriad;
        public bool UseMinorTriad
        {
            get { return _useMinorTriad; }
            set
            {
                _useMinorTriad = value;
                RaisePropertyChanged("UseMinorTriad");
            }
        }
        #endregion
        public OptionsViewModel()
        {
            // общие
            TimeDelayNextElem = Properties.Settings.Default.timeDelayNextElem;
            TimeDelayShowImage = Properties.Settings.Default.timeDelayShowImage;
            ShowDescription = Properties.Settings.Default.showNoteDescription;

            // ноты
            UseNotes = Properties.Settings.Default.useNotes;
            UseDiezNotes = Properties.Settings.Default.useDiezNotes;
            UseBemolNotes = Properties.Settings.Default.useBemolNotes;

            // аккорды
            UseChords = Properties.Settings.Default.useChords;
            UseMajorTriad = Properties.Settings.Default.useMajorTriad;
            UseMinorTriad = Properties.Settings.Default.useMinorTriad;
        }

        private RelayCommand _okCommand;
        public RelayCommand OkCommand
        {
            get
            {
                return _okCommand
                  ?? (_okCommand = new RelayCommand(
                    () =>
                    {
                        // общие
                        Properties.Settings.Default.timeDelayNextElem = TimeDelayNextElem;
                        Properties.Settings.Default.timeDelayShowImage = TimeDelayShowImage;
                        Properties.Settings.Default.showNoteDescription = ShowDescription;

                        // ноты
                        Properties.Settings.Default.useNotes = UseNotes;
                        Properties.Settings.Default.useDiezNotes = UseDiezNotes;
                        Properties.Settings.Default.useBemolNotes = UseBemolNotes;

                        // аккорды
                        Properties.Settings.Default.useChords = UseChords;
                        Properties.Settings.Default.useMajorTriad = UseMajorTriad;
                        Properties.Settings.Default.useMinorTriad = UseMinorTriad;

                        Properties.Settings.Default.Save();
                    }));
            }
        }
    }
}
