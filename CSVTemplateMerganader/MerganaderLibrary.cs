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
    public partial class MerganaderLibrary
    {

        private static DataTable GetDataTabelFromCSVFile(string csvName)
        {
            DataTable csvData = new DataTable();
            TextFieldParser csvReader = new TextFieldParser(csvName);
            csvReader.Delimiters = new string[] { "," };
            //read column names
            csvReader.HasFieldsEnclosedInQuotes = true;
            string[] colFields = csvReader.ReadFields();
            foreach (string column in colFields)
            {
                DataColumn colData = new DataColumn(column);
                colData.AllowDBNull = true;
                csvData.Columns.Add(colData);
            }
            while (!csvReader.EndOfData)
            {
                string[] fieldData = csvReader.ReadFields();
                for (int i = 0; i < fieldData.Length; i++)
                {
                    if (fieldData[i] == "")
                    {
                        fieldData[i] = null;
                    }

                }
                csvData.Rows.Add(fieldData);
            }


            return csvData;

        }
    }
}
