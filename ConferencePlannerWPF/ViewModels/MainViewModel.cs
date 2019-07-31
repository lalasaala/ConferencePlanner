// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows.Input;
using ConferencePlannerLibrary.Contracts;
using ConferencePlannerWPF.Models;
using Microsoft.Win32;

namespace ConferencePlannerWPF.ViewModels
{
    [Export]
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IScheduleCreator _scheduleCreator;
        private readonly IInputReader _inputReader;
        private string _fileNameInput;
        private string _scheduleOutput;
        private bool _isFileInput;
        private bool _isTextInput;

        public ICommand BrowseCommand { get; set; }
        public ICommand CreateSchedule { get; set; }

        public bool IsFileInput
        {
            get { return _isFileInput; }
            set { _isFileInput = value; OnPropertyChanged(nameof(IsFileInput));}
        }

        public bool IsTextInput
        {
            get { return _isTextInput; }
            set { _isTextInput = value; OnPropertyChanged(nameof(IsTextInput)); }
        }

        public string TextInput { get; set; }
        public string FileNameInput
        {
            get
            {
                if (string.IsNullOrEmpty(_fileNameInput))
                {
                    string filename = @"Input\Input.txt";
                    var baseDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    if (baseDir != null) _fileNameInput = Path.Combine(baseDir, filename);
                    return _fileNameInput;
                }

                return _fileNameInput;
            }
            set {
                _fileNameInput = value;
                OnPropertyChanged(nameof(FileNameInput));
            }
        }

        public string ScheduleOutput
        {
            get { return _scheduleOutput; }
            set { _scheduleOutput = value; OnPropertyChanged(nameof(ScheduleOutput));}
        }

        [ImportingConstructor]
        public MainViewModel(IScheduleCreator scheduleCreator, IInputReader inputReader)
        {
            _scheduleCreator = scheduleCreator;
            _inputReader = inputReader;
            BrowseCommand = new RelayCommand(BrowseCommandExecute, BrowseCommandCanExecute);
            CreateSchedule = new RelayCommand(CreateScheduleExecute, CreateScheduleCanExecute);
            IsFileInput = true;
        }

        private void CreateScheduleExecute()
        {
            var input = IsFileInput ? _inputReader.ReadInputFromFile(_fileNameInput) : _inputReader.ReadInputFromString(TextInput);
            if (input.Length > 0)
            {
                ScheduleOutput = _scheduleCreator.CreateSchedule(input);
            }
        }

        private bool CreateScheduleCanExecute()
        {
            return !string.IsNullOrEmpty(_fileNameInput);
        }

        private bool BrowseCommandCanExecute()
        {
            return !string.IsNullOrEmpty(FileNameInput);
        }

        private void BrowseCommandExecute()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {Filter = "Text files(*.txt)|*.txt"};
            if (openFileDialog.ShowDialog() == true)
            {
                FileNameInput = openFileDialog.FileName;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
