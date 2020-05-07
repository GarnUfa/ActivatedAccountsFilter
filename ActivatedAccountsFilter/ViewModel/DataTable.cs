using System;
using System.IO;
using System.Windows;
using OfficeOpenXml;
using System.Collections.Generic;


namespace ActivatedAccountsFilter.ViewModel
{
    class DataTable
    {
        private IDialogService dialog;
        public string ID2 {get; set;}
        private string login;
        List<List<string>> EnableAccountList;
        public List<string> loginList = new List<string>();
        
        public DataTable(IDialogService dialog)
        {
            this.dialog = dialog;
        }

        public void ReturnID()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //Исключение если выбрана не выбрана папка
            using (ExcelPackage pakage = new ExcelPackage(new FileInfo(dialog.FilePath)))
            {
                //Исключение если выбран не тот файл
                ExcelWorksheet sheet = pakage.Workbook.Worksheets[0];
                for (int i = 2; !(string.IsNullOrEmpty(sheet.Cells[i, 1].Value.ToString())) && !(sheet.Cells[i, 3].Value.ToString().Trim() == "block acc"); i++)
                {
                    if (!(sheet.Cells[i, 5].Value == null) && string.IsNullOrEmpty(sheet.Cells[i, 5].Value.ToString()))
                    {
                        loginList.Add(sheet.Cells[i, 1].Value.ToString());
                        //MessageBox.Show(sheet.Cells[i, 1].Value.ToString());
                    }

                }
                ID2 = sheet.Cells[2,1].Value.ToString();
                
            }
        }

    }
}
