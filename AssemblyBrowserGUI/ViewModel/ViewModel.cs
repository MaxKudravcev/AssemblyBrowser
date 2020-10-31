using System;
using System.ComponentModel;
using System.Windows.Input;
using AssemblyBrowserLib;

namespace AssemblyBrowserGUI.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {

        #region Private members

        private AssemblyDO assembly = null;
        private IDialogService dialogService;
        private Model.Model model;

        #endregion

        #region Properties

        public AssemblyDO Assembly
        {
            get { return assembly; }
            private set
            {
                assembly = value;
                OnPropertyChanged(nameof(Assembly));
            }
        }

        #endregion

        #region Helper methods

        private void Load()
        {
            if (dialogService.OpenFileDialog())
                Assembly = model.LoadAssembly(dialogService.FilePath);
        }

        #endregion

        #region Commands

        public ICommand LoadCommand { get; set; }

        #endregion

        #region Ctor

        public ViewModel()
        {
            model = new Model.Model();
            dialogService = new DefaultDialogService();
            LoadCommand = new RelayCommand<object>(_ => Load());
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
