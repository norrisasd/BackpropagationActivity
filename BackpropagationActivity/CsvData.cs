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
        public List<HeartDisease> getRecords()
        {
            using (var reader = new StreamReader("C:\\Users\\norrisasd\\source\\repos\\BackpropagationActivity\\BackpropagationActivity\\heart_v2.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                List<HeartDisease> records = csv.GetRecords<HeartDisease>().ToList();


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
    }

    public class HeartDisease
    {
        public int age { get; set; }
        public String sex { get; set; }
        public int BP { get; set; }
        public int cholestrol { get; set; }
        public int heart_disease { get; set; }
    }

}
