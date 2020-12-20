using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Truth_Table_Generator
{
    public partial class Form1 : Form
    {
        int columns;
        string variables;
        public Form1()
        {
            InitializeComponent();
        }
        void TruthTable()
        {
            int rows = (int)Math.Pow(2, columns); //Number of Rows = 2^Number Of Variables(columns)
            for (int i = 0; i < columns; i++) //Adding Columns to table with header text extracted from expression (A,B,C...)
            {
                dataGridView1.Columns.Add("Column" + i, variables[i].ToString());
            }
            dataGridView1.Rows.Add(rows);
            for (int i = 0; i < rows; i++) //Generating Binary portion of the array
            {
                int quotient;
                string binaryTemp = "";
                int num = i;
                while (num > 0)
                {
                    quotient = num / 2;
                    binaryTemp += (num % 2).ToString();
                    num = quotient;
                }
                string binary = "";
                for (int j = binaryTemp.Length - 1; j >= 0; j--)
                {
                    binary = binary + binaryTemp[j];
                }
                binary = binary.PadLeft(variables.Length, '0');
                for (int j = 0; j < columns; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = binary[j];
                }
            }
        }
        private string removeDuplicateCharacters(string word)
        {
            string finalResult = "";
            foreach (var character in word)
            {
                if (finalResult.IndexOf(character) == -1)
                {
                    finalResult += character;
                }
            }
            return finalResult;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            string unfilteredVar = Regex.Replace(textBox1.Text, "[^a-zA-Z]", ""); //Search for every alphabet(variable) in Expression
            variables = removeDuplicateCharacters(unfilteredVar); //Removes Duplicates out of them.
            char[] myArr = variables.ToArray();
            Array.Sort(myArr);
            variables = "";
            for (int i = 0; i < myArr.Length; i++) //Converting Character array into a string
            {
                variables += myArr[i];
            }
            columns = variables.Length; //Number of Columns for datagridview
            TruthTable(); //Table Creator
            Algorithm postfixAlgo = new Algorithm(textBox1.Text); //Algorithm Class which converts Infix to PostFix
            char[] postfixExpr = postfixAlgo.Converter(); //Expression will be fetched in reverse order.
            for (int i = 0; i < postfixExpr.Length / 2; i++) //Changing reverse order to correct form (re-reversing)
            {
                char tmp = postfixExpr[i];
                postfixExpr[i] = postfixExpr[postfixExpr.Length - i - 1];
                postfixExpr[postfixExpr.Length - i - 1] = tmp;
            }
            dataGridView1.Columns.Add("Column","Result"); //Finally added result column to datagrid
            Unpack_Polish_Notation upn = new Unpack_Polish_Notation(postfixExpr, dataGridView1); //Class for Polish Notation Solver
            dataGridView1 = upn.PostfixSolver();
        }
    }
}
