using Microsoft.Win32;
using System.Windows;

namespace AssemblyBrowserGUI.ViewModel
{
    /// <summary>
    /// Default Win32 implementation of IDialogService
    /// </summary>
    class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.exe | *.dll";
            if(openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
