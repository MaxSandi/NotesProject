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

        public OptionsViewModel()
        {
            TimeDelayNextElem = Properties.Settings.Default.timeDelayNextElem;
            TimeDelayShowImage = Properties.Settings.Default.timeDelayShowImage;
            ShowDescription = Properties.Settings.Default.showNoteDescription;
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
                        Properties.Settings.Default.timeDelayNextElem = TimeDelayNextElem;
                        Properties.Settings.Default.timeDelayShowImage = TimeDelayShowImage;
                        Properties.Settings.Default.showNoteDescription = ShowDescription;

                        Properties.Settings.Default.Save();
                    }));
            }
        }
    }
}
