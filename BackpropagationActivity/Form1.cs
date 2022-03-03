using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backprop;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace BackpropagationActivity
{
    public partial class Form1 : Form
    {
        NeuralNet bp;
        CsvData csvData;
        public Form1()
        {
            InitializeComponent();
            csvData = new CsvData();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bp = new NeuralNet(3,5,1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<BMI> data = csvData.getRecords();
            for (int i = 0; i < 1000; i++)
            {
                foreach(var d in data)
                {
                    bp.setInputs(0, csvData.ParseGender(d.Gender));
                    bp.setInputs(0, d.Height);
                    bp.setInputs(1, d.Weight);
                    switch (d.Index)
                    {
                        case 0:
                            bp.setDesiredOutput(0, 0.0);
                            break;
                        case 1:
                            bp.setDesiredOutput(0, 0.2);
                            break;
                        case 2:
                            bp.setDesiredOutput(0, 0.4);
                            break;
                        case 3:
                            bp.setDesiredOutput(0, 0.6);
                            break;
                        case 4:
                            bp.setDesiredOutput(0, 0.8);
                            break;
                        case 5:
                            bp.setDesiredOutput(0, 1.0);
                            break;
                        default:
                            bp.setDesiredOutput(0, 0.0);
                            break;
                    }
                    bp.learn();
                    //System.Windows.Forms.MessageBox.Show(" " + d.Height+ " " + d.Weight+ " " + d.Index);
                }
            }
            //System.Windows.Forms.MessageBox.Show("Training Done");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            bp.loadWeights(openFileDialog1.FileName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //double age = Convert.ToDouble(textBox1.Text);
            double gender = Convert.ToDouble(csvData.ParseGender(comboBox1.Text));
            double bp = Convert.ToDouble(textBox2.Text);
            double chol = Convert.ToDouble(textBox3.Text);

            this.bp.setInputs(0, gender);
            this.bp.setInputs(0, bp);
            this.bp.setInputs(1, chol);
            this.bp.run();
            //System.Windows.Forms.MessageBox.Show(" " +gender+ " " + bp+ " " + chol);
            textBox4.Text = "" + this.bp.getOuputData(0);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            bp.saveWeights(saveFileDialog1.FileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
