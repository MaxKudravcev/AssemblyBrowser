using System.ComponentModel;
using System.Windows.Input;
using AssemblyBrowserLib;

namespace AssemblyBrowserGUI.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        private AssemblyDO assembly = null;
        public AssemblyDO Assembly
        {
            get { return assembly; }
            private set
            {
                assembly = value;
                OnPropertyChanged(nameof(Assembly));
            }
        }

        private IDialogService dialogService;
        private Model.Model model;
        


        private void Load()
        {
            if (dialogService.OpenFileDialog())
                Assembly = model.LoadAssembly(dialogService.FilePath);
        }

        public ICommand LoadCommand { get; set; }

        public ViewModel()
        {
            model = new Model.Model();
            dialogService = new DefaultDialogService();
            LoadCommand = new RelayCommand<object>(_ => Load());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
