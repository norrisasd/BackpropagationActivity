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
            bp = new NeuralNet(4,1,1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<HeartDisease> data = csvData.getRecords();
            for (int i = 0; i < 1000; i++)
            {
                foreach(var d in data)
                {
                    bp.setInputs(0, csvData.RangeAge(d.age));
                    bp.setInputs(1, d.sex);
                    bp.setInputs(2, csvData.RangeBloodPressure(d.BP));
                    bp.setInputs(3, csvData.RangeCholesterol(d.cholestrol));
                    bp.setDesiredOutput(0, d.heart_disease);
                    bp.learn();
                    //System.Windows.Forms.MessageBox.Show(" " + d.age + " " + d.sex + " " + d.BP + " " + d.cholestrol);
                }
            }
            System.Windows.Forms.MessageBox.Show("Training Done");
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
            double age = Convert.ToDouble(textBox1.Text);
            double gender = Convert.ToDouble(csvData.ParseGender(comboBox1.Text));
            double bp = Convert.ToDouble(textBox2.Text);
            double chol = Convert.ToDouble(textBox3.Text);

            this.bp.setInputs(0, csvData.RangeAge(age));
            this.bp.setInputs(1, gender);
            this.bp.setInputs(2, csvData.RangeBloodPressure(bp));
            this.bp.setInputs(3, csvData.RangeCholesterol(chol));
            this.bp.run();

            textBox4.Text = "" + this.bp.getOuputData(0);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            bp.saveWeights(saveFileDialog1.FileName);
        }
    }
}
