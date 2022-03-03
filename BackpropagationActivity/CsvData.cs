using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace BackpropagationActivity
{
    enum Genders
    {
        Male,
        Female,
    }

    class CsvData
    {
        public List<BMI> getRecords()
        {
            using (var reader = new StreamReader("C:\\Users\\norrisasd\\source\\repos\\BackpropagationActivity\\BackpropagationActivity\\bmi.csv"))
            
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                List<BMI> records = csv.GetRecords<BMI>().ToList();


                return records;
            }
        }
        public int ParseGender(String g)
        {
            Genders result;
            if (Enum.TryParse(g, out result))
            {
                switch (result)
                {
                    case Genders.Male:
                        return 1;
                }
            }
            return 0;
        }
        public double RangeCholesterol(double n)
        {
            if (n >= 500)
            {
                return 1.0;
            } else if (n < 500 && n >= 200)
            {
                return 0.75;
            }
            else if (n < 200 && n >151)
            {
                return 0.5;
            }
            else
            {
                return 0.0;
            }
        }
        public double RangeBloodPressure(double n)
        {
            if (n >= 180)
            {
                return 1.0;
            }
            else if (n < 180 && n >= 140)
            {
                return 0.90;
            }
            else if (n < 140 && n >= 130)
            {
                return 0.70;
            }
            else if (n < 130 && n >= 120)
            {
                return 0.5;
            }
            else
            {
                return 0.0;
            }
        }
        public double RangeAge(double n)
        {
            if (n > 60)
            {
                return 1.0;
            }
            else if (n < 60 && n >= 41)
            {
                return 0.75; 
            }
            else if (n < 41 && n >= 19)
            {
                return 0.5;
            }
            else
            {
                return 0.0;
            }
        }
    }

    public class HeartDisease
    {
        public double age { get; set; }
        public double sex { get; set; }
        public double BP { get; set; }
        public double cholestrol { get; set; }
        public double heart_disease { get; set; }
    }
    public class BMI
    {
        public String Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Index { get; set; }

    }

}
