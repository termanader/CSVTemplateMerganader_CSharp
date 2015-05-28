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
using System.Diagnostics;
using System.Threading;

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
                Int32 ColumnCount;
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
               csvDataGrid.DataSource= GetDataTableFromCSVFile(csvName);
               csvTable = GetDataTableFromCSVFile(csvName);
               ColumnCount = csvTable.Columns.Count;
           
            listVariables = GetColumnHeaders(csvName);
            listSize = listVariables.Count - 1;
            rowCount = csvTable.Rows.Count;
            varHeaderBox.Items.Clear();      
            for (int i = 0; i < ColumnCount; i++)
            {
                varHeaderBox.Items.Add("{{#" + listVariables[i] + "}}");
            }
            }

        private void varHeaderBox_DoubleClick(object sender, EventArgs e)
        {
            if (templateBox.ReadOnly == false)
            {
                templateBox.Text = templateBox.Text.Insert(0, varHeaderBox.SelectedItem.ToString());
            }
        }

        private void genresButton_Click(object sender, EventArgs e)
        {
            string temp = templateBox.Text;
            int outputboxLength = outputBox.Text.Length;
            string media = temp;
            List<string> arMedia = new List<string>();
            List<string> varUsed = new List<string>();
            List<int> varUsedIndex = new List<int>();
            int varUsedCount = 0;
            Stopwatch sw = new Stopwatch();

            if (temp != "" && listSize != 0)
            {
                for (int i = 0; i < listSize; i++)
                {
                    if (media.Contains(listVariables[i]))
                    {
                        varUsed.Add(listVariables[i]);
                        varUsedIndex.Add(listVariables.IndexOf(listVariables[i]));
                    }
                }
                varUsedCount = varUsed.Count;

                outputBox.Text = "";
                sw.Start();
                StatusLabel.Text = "Running for: ";
                for (int l = 0; l < rowCount; l++)
                {
                    List<string> arRow = new List<string>();
                    string[] rowItems = new string[rowCount];
                    //arRow[l] = Convert.ToString(csvTable.Rows[l].);
                    int rowLength = csvTable.Columns.Count - 1;
                    arMedia.Add(media);
                    media = temp;
                    foreach (var row in csvTable.Rows)
                    {
                       // var arRow = row.ToString();
                        //var tmp = row;
                       // tmp.ToList();
                        for (int r = 0; r < varUsedCount - 1; r++)
                        {
                            //arRow = Convert.ToString(csvTable.Rows[r]);
                            //arRow.ToString;

                            //media = media.Replace(listVariables[varUsedIndex[r]], row[varUsedIndex[r]]);
                        }


                    }

                    
                }

                arMedia.Add(media);

                for (int i = 1; i < rowCount; i++)
                {
                    outputBox.AppendText(arMedia[i]);
                    outputBox.Text = outputBox.Text + Environment.NewLine;
                    StatusLabel.Text = "Running for: " + (sw.ElapsedMilliseconds / 1000) + " seconds";
                    Application.DoEvents();
                }
                sw.Stop();
                StatusLabel.Text = "Finished! It took " + (sw.ElapsedMilliseconds / 1000) + " seconds to finish running.";



            }


        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
