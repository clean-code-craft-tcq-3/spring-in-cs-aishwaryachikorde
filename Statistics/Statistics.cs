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
        public float average { get; set; }

        /// <summary>
        /// Minimum value
        /// </summary>
        public float min { get; set; }

        /// <summary>
        /// Maximum value
        /// </summary>
        public float max { get; set; }
        #endregion

        public Stats CalculateStatistics(List<float> numbers)
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
        public float GetAverage(List<float> input)
        {
            float average = input.Average();
            Console.WriteLine("The average of the input numbers is -" + average);

            return average;
        }

        public float GetMinValue(List<float> input)
        {
            float min = input.Min();
            Console.WriteLine("The minimum value among the input values is -" + min);

            return min;
        }

        public float GetMaxValue(List<float> input)
        {
            float max = input.Max();
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
        public float maxThreshold;
        private IAlerter[] alerter;

        public StatsAlerter(float maxThreshold, IAlerter[] alerters)
        {
            this.maxThreshold = maxThreshold;
            this.alerter = alerters;
        }

        //Checking the alerting implementation
        public void checkAndAlert(List<float> thresholdValue)
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
