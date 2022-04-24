namespace CatalogoProdutosMVC.Helpers
{
    public class ConvertDateTimeToTimestamp
    {
        private static double DateTimeToTimestamp(DateTime value)
        {
            TimeSpan epoch = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            //return the total seconds (which is a UNIX timestamp)
            return (double)epoch.TotalSeconds;
        }
    }
}
