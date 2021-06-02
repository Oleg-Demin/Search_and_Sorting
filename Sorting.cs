using System;

namespace Test
{
    class Sorting
    {
        public static int[] BubbleSorting(int[] array)
        {
            int ln = array.Length;
            for (int i = 0; i < ln; i++)
            for (int j = 1; j < ln - i; j++)
                if (array[j - 1] > array[j])
                    (array[j - 1], array[j]) = (array[j], array[j - 1]);
            return array;
        }
        
        public static int[] SelectionSorting(int[] array)
        {
            int lastInd = array.Length - 1;
            for (int i = 0; i < lastInd; i++)
            {
                int maxInd = lastInd - i;
                for (int j = 0; j < lastInd - i; j++)
                    if (array[j] > array[maxInd])
                        maxInd = j;
                (array[lastInd - i], array[maxInd]) = (array[maxInd], array[lastInd - i]);
            }
            return array;
        }
        
        public static int[] InsertionSorting(int[] array)
        {
            int ln = array.Length;
            for (int i = 1; i < ln; i++)
            {
                int rem = array[i];
                for (int j = i - 1; j >= 0; j--)
                    if (array[j] > rem)
                    {
                        array[j + 1] = array[j];
                        if (j == 0)
                            array[j] = rem;
                    }
                    else
                    {
                        array[j + 1] = rem;
                        break;
                    }
            }
            return array;
        }
        
        public static int[] MergeSorting(int[] array)
        {
            int ln = array.Length;
            if (ln == 1)
                return array;
            else if (ln == 2)
            {
                if (array[0] > array[1])
                    Array.Reverse(array);
                return array;
            }
            else
            {
                int lnMsAr1 = ln / 2;
                int lnMsAr2 = ln - lnMsAr1;
                int[] msArray1 = new int[lnMsAr1];
                int[] msArray2 = new int[lnMsAr2];
                Array.Copy(array, 0, msArray1, 0, lnMsAr1);
                Array.Copy(array, lnMsAr1, msArray2, 0, lnMsAr2);
                Array.Clear(array, 0, ln);
                msArray1 = MergeSorting(msArray1);
                msArray2 = MergeSorting(msArray2);
                int i = 0;
                int j = 0;
                for (int k = 0; ; k++)
                {
                    if (i == lnMsAr1)
                    {
                        Array.Copy(msArray2, j, array, k, lnMsAr2 - j);
                        return array;
                    }
                    if (j == lnMsAr2)
                    {
                        Array.Copy(msArray1, i, array, k, lnMsAr1 - i);
                        return array;
                    }
                    if (msArray1[i] < msArray2[j])
                    {
                        array[k] = msArray1[i];
                        i++;
                    }
                    else
                    {
                        array[k] = msArray2[j];
                        j++;
                    }
                }
            }
        }
        
        public static int[] PyramidalSorting(int[] array)
        {
            int ln = array.Length;
            for (int i = ln / 2 - 1; i >= 0; i--)
            {
                int pr = i;
                int son1 = 2 * pr + 1;
                int son2 = 2 * pr + 2;
                while (son1 < ln)
                    if (son2 < ln)
                        if (array[pr] < Math.Max(array[son1], array[son2]))
                            if (array[son1] > array[son2])
                            {
                                (array[pr], array[son1]) = (array[son1], array[pr]);
                                pr = son1;
                                son1 = 2 * pr + 1;
                                son2 = 2 * pr + 2;
                            }
                            else
                            {
                                (array[pr], array[son2]) = (array[son2], array[pr]);
                                pr = son2;
                                son1 = 2 * pr + 1;
                                son2 = 2 * pr + 2;
                            }
                        else
                            break;
                    else
                    {
                        if (array[pr] < array[son1])
                            (array[pr], array[son1]) = (array[son1], array[pr]);
                        break;
                    }
            }
            for (int i = ln - 1; i >= 0; i--)
            {
                (array[0], array[i]) = (array[i], array[0]);
                int pr = 0;
                int son1 = 2 * pr + 1;
                int son2 = 2 * pr + 2;
                while (son1 < i)
                    if (son2 < i)
                        if (array[pr] < Math.Max(array[son1], array[son2]))
                            if (array[son1] > array[son2])
                            {
                                (array[pr], array[son1]) = (array[son1], array[pr]);
                                pr = son1;
                                son1 = 2 * pr + 1;
                                son2 = 2 * pr + 2;
                            }
                            else
                            {
                                (array[pr], array[son2]) = (array[son2], array[pr]);
                                pr = son2;
                                son1 = 2 * pr + 1;
                                son2 = 2 * pr + 2;
                            }
                        else
                            break;
                    else
                    {
                        if (array[pr] < array[son1])
                            (array[pr], array[son1]) = (array[son1], array[pr]);
                        break;
                    }
            }
            return array;
        }
    }
}