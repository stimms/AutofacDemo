namespace AutofacDemo.Services
{
    public class NameResolver : INameResolver
    {
        public string GetName(string inputName)
        {
            return string.Format("{0} {0} bo bolly fee fi fo folly {0}", inputName);
        }
    }
}