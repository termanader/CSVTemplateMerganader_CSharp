using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Microsoft;

namespace CSVTemplateMerganader
{
    public partial class MerganaderLibrary : Form
    {
        public string csvName = "";
        public int listSize = 0;
        public int rowCount = 0;
        public List<string> listVariables = new List<string>();
        public DataTable csvTable = new DataTable();


        public MerganaderLibrary()
        {
            InitializeComponent();
        }

        private void dataCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                //string csvName = "";
                //DataColumn Column = new DataColumn(column);
               // DataRow Row;
               // Int32 UpperBound;
                //Int32 ColumnCount;
                //List<string> CurrentRow = new List<string>();
                //List<string> pubHeaders = new List<string>();
                string csvName =  string.Empty;
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = "c:\temp";
                dialog.Filter = "CSV Files (*.csv)|*.csv";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    csvName = dialog.FileName;
                }
               csvDataGrid.DataSource= GetDataTabelFromCSVFile(csvName);
               csvTable = GetDataTabelFromCSVFile(csvName);
            }

       

        
    }
}
