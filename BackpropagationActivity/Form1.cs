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
            bp = new NeuralNet(4,3,1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<HeartDisease> data = csvData.getRecords();
            for (int i = 1; i < 10000; i++)
            {
                foreach(var d in data)
                {
                    bp.setInputs(0, d.age);
                    bp.setInputs(1, csvData.ParseGender(d.sex));
                    bp.setInputs(2, d.BP);
                    bp.setInputs(3, d.cholestrol);
                    bp.setDesiredOutput(0, d.heart_disease);
                    bp.learn();
                    
                }
            }
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
            int age = Convert.ToInt32(textBox1.Text);
            int gender = csvData.ParseGender(comboBox1.Text);
            int bp = Convert.ToInt32(textBox2.Text);
            int chol = Convert.ToInt32(textBox3.Text);

            this.bp.setInputs(0, age);
            this.bp.setInputs(1, gender);
            this.bp.setInputs(2, bp);
            this.bp.setInputs(3, chol);
            this.bp.run();

            textBox4.Text = "" + this.bp.getOuputData(0);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            bp.saveWeights(saveFileDialog1.FileName);
        }
    }
}
