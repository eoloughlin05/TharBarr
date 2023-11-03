using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    //WIP - Refactoring this out from SpawnManager class - will complete in next release
    public class RandomiseArray
    {
        private static System.Random random = new System.Random();
        public static void Shuffle<T>(T[] array)
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
