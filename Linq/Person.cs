using System;

namespace Linq
{
    public enum BMIIndex 
    {
        Underweight,
        Normal,
        Overweight,
        Heavy,
        HighRisk
    }

    public class Person
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMI => Weight / (Height * Height);
        public String State { get; set; }

        public BMIIndex Classification() 
        {
            if (BMI < 18.5)
            {
                return BMIIndex.Underweight;
            }
            else if (BMI > 18.5 && BMI < 25.0)
            {
                return BMIIndex.Normal;
            }
            else if (BMI > 25.0 && BMI < 29.9)
            {
                return BMIIndex.Overweight;
            }
            else if (BMI > 29.9 && BMI < 40.0)
            {
                return BMIIndex.Heavy;
            }
            else {
                return BMIIndex.HighRisk;
            }
        }
    }
}
