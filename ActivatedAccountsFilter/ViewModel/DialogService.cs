using Microsoft.Win32;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace ActivatedAccountsFilter.ViewModel
{
    class DialogService : IDialogService
    {
        public string FilePathAllAccInfo { get; set; }
        public string FilePathSecondAccInfo { get; set; }
        public string FileDirectory { get; set; }

        public bool OpenFileDialog()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new OpenFileDialog();
            FolderBrowserDialog FileDir = new FolderBrowserDialog();
            if (FileDir.ShowDialog() == DialogResult.OK)
            {
                FileDirectory = FileDir.SelectedPath;
                FilePathAllAccInfo = FileDirectory + @"\allaccount.xlsx";
                FilePathSecondAccInfo = FileDirectory + @"\secondAccountInfo.xlsx";
                return true;
            }
            return false;






        }
    }
}
