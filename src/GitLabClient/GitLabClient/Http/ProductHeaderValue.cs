namespace Foxkit
{
    public class ProductHeaderValue : IProductHeaderValue
    {
        private readonly System.Net.Http.Headers.ProductHeaderValue productHeaderValue;

        public ProductHeaderValue(string name)
            : this(new System.Net.Http.Headers.ProductHeaderValue(name))
        {
        }

        public ProductHeaderValue(string name, string version)
            : this(new System.Net.Http.Headers.ProductHeaderValue(name, version))
        {
        }

        public ProductHeaderValue(System.Net.Http.Headers.ProductHeaderValue productHeaderValue)
        {
            this.productHeaderValue = productHeaderValue;
        }

        public string Name => productHeaderValue.Name;

        public string Version => productHeaderValue.Version;
    }
}
