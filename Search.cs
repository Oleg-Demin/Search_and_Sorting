namespace Test
{
    class Search
    {
        public static int LinearSearch(int[] array, int key)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == key)
                    return i;
            return -1;
        }

        public static int BinarySearch(int[] array, int key)
        {
            int fInd = 0;
            int lInd = array.Length - 1;
            int rt = -1;
            while (true)
            {
                int mInd = (fInd + lInd) / 2;
                if (array[mInd] == key)
                {
                    rt = mInd;
                    if (mInd - 1 >= fInd && array[fInd] <= key && array[mInd - 1] >= key)
                        lInd = mInd - 1;
                    else
                        return rt;
                }
                else if (mInd - 1 >= fInd && array[fInd] <= key && array[mInd - 1] >= key)
                    lInd = mInd - 1;
                else if (mInd + 1 <= lInd && array[mInd + 1] <= key && array[lInd] >= key)
                    fInd = mInd + 1;
                else
                    return rt;
            }
        }
    }
}