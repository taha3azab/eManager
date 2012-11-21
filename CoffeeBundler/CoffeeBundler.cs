using System.IO;
using System.Text;
using System.Web;
using System.Web.Optimization;
using CoffeeSharp;

namespace CoffeeBundler
{
    public class CoffeeBundler : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response) {
            var coffeeScriptEngine = new CoffeeScriptEngine();
            var compiledCoffeeScript = new StringBuilder();
            foreach (var file in response.Files) {
                using (var reader = new StreamReader(file.FullName)) {
                    compiledCoffeeScript.Append(coffeeScriptEngine.Compile(reader.ReadToEnd()));
                    reader.Close();
                }
            }
            response.Content = compiledCoffeeScript.ToString();
            response.ContentType = "text/javascript";
            response.Cacheability = HttpCacheability.Public;
        }
    }
}