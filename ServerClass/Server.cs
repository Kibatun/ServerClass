namespace ServerClass
{
    public class Server
    {
        private static readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        private static int count = 0;

        public static int GetCount()
        {
            rwLock.EnterReadLock();
            try
            {
                return count;
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            rwLock.EnterWriteLock();
            try
            {
                count += value;
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }
    }
}
