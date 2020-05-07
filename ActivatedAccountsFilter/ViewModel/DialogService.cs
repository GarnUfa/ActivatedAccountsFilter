using Microsoft.Win32;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace ActivatedAccountsFilter.ViewModel
{
    class DialogService : IDialogService
    {
        public string FilePath { get; set; }
        public string FileDirectory { get; set; }

        public bool OpenFileDialog()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new OpenFileDialog();
            FolderBrowserDialog FileDir = new FolderBrowserDialog();
            if (FileDir.ShowDialog() == DialogResult.OK)
            {
                FileDirectory = FileDir.SelectedPath;
                FilePath = FileDirectory + @"\allaccount.xlsx";
                return true;
            }
            return false;






        }
    }
}
