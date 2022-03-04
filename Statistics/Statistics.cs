namespace Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

     public class StatsComputer
    {
        #region Properties
        /// <summary>
        /// Average
        /// </summary>
        public double average { get; set; }

        /// <summary>
        /// Minimum value
        /// </summary>
        public double min { get; set; }

        /// <summary>
        /// Maximum value
        /// </summary>
        public double max { get; set; }
        #endregion

        public Stats CalculateStatistics(List<double> numbers)
        {
            Stats myNumber = new Stats();
            average = myNumber.GetAverage(numbers);
            min = myNumber.GetMinValue(numbers);
            max = myNumber.GetMaxValue(numbers);

            return myNumber;
        }
     }

     public class Stats
    {
        public double GetAverage(List<double> input)
        {
            double average = input.Average();
            Console.WriteLine("The average of the input numbers is -" + average);

            return average;
        }

        public double GetMinValue(List<double> input)
        {
            double min = input.Min();
            Console.WriteLine("The minimum value among the input values is -" + min);

            return min;
        }

        public double GetMaxValue(List<double> input)
        {
            double max = input.Max();
            Console.WriteLine("The maximum value among the input values is -" + max);

            return max;
        }
    }

    //Interface implementation
    public interface IAlerter
    {
        void raiseAlert();
    }

    //Email Alert method
    public class EmailAlert : IAlerter
    {
		/// <summary>
        /// Email Sent
        /// </summary>
        public bool emailSent;

        public EmailAlert()
        {
            emailSent = false;
        }

        public void raiseAlert()
        {
            emailSent = true;
        }
    }

    //LEDAlert class
    public class LEDAlert : IAlerter
    {
		/// <summary>
        /// ledGlows
        /// </summary>
        public bool ledGlows;

        public LEDAlert()
        {
            ledGlows = false;
        }

        public void raiseAlert()
        {
            ledGlows = true;
        }
}

    //StatsAleter class
    public class StatsAlerter
    {
        public double maxThreshold;
        private IAlerter[] alerter;

        public StatsAlerter(double maxThreshold, IAlerter[] alerters)
        {
            this.maxThreshold = maxThreshold;
            this.alerter = alerters;
        }

        //Checking the alerting implementation
        public void checkAndAlert(List<double> thresholdValue)
        {
            for (var i = 0; i <= thresholdValue.Count; ++i)
            {
                switch (thresholdValue[i] > maxThreshold)
                {
                    case true:
                    {
                        foreach (IAlerter alert in alerter)
                        {
                            alert.raiseAlert();
                        }

                        break;
                    }
                }
            }
        }
    }
}
    

