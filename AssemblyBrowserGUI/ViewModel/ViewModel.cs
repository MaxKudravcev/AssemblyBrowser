using System.ComponentModel;
using System.Windows.Input;
using AssemblyBrowserLib;

namespace AssemblyBrowserGUI.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public AssemblyDO assembly;

        private IDialogService dialogService;
        private Model.Model model;
        


        private void Load()
        {
            if (dialogService.OpenFileDialog())
                assembly = model.LoadAssembly(dialogService.FilePath);
        }

        public ICommand LoadCommand { get; set; }

        public ViewModel()
        {
            model = new Model.Model();
            dialogService = new DefaultDialogService();
            LoadCommand = new RelayCommand<object>(_ => Load());
        }
    }
}
