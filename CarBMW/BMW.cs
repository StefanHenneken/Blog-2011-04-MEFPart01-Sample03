using System;
using System.ComponentModel.Composition;
namespace CarBMW
{
    [Export(typeof(CarHost.ICarContract))]
    public class BMW : CarHost.ICarContract
    {
        private BMW()
        {
            Console.WriteLine("BMW constructor");
        }
        [ImportingConstructor]
        private BMW([Import("ConstructorParameter")]int parameter)
        {
            Console.WriteLine(String.Format("Parameter: {0}.", parameter));
        }
        public string StartEngine(string name)
        {
            return String.Format("{0} starts the BMW.", name);
        }
    }
}
