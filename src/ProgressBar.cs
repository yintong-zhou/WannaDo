﻿using System;
using static System.Console;

namespace WannaDo
{
    public class ProgressBar
    {
        public void ShowPercentProgress(string message, int currElementIndex, int totalElementCount)
        {
            if (currElementIndex < 0 || currElementIndex >= totalElementCount)
            {
                throw new InvalidOperationException("currElement out of range");
            }

            int percent = (100 * (currElementIndex + 1)) / totalElementCount;
            Write("\r{0}{1}% complete", message, percent);
            
            if (currElementIndex == totalElementCount - 1)
            {
                WriteLine(Environment.NewLine);
            }
        }
    }
}
