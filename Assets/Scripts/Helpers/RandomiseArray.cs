﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    public class RandomiseArray
    {
        private static System.Random random = new System.Random();
        private static void Shuffle<T>(T[] array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length - 1; ++i)
            {
                int r = random.Next(i, array.Length);
                (array[r], array[i]) = (array[i], array[r]);
            }
        }
    }
}
