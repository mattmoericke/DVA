namespace DVA.Provider
{
    public class NewsProviderBase
    {
        public static INewsProvider GetNewsProvider ()
        {
            return new GNewsNewsProvider();
        }
    }
}
