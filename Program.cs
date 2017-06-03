using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace CarHost
{
    class Program
    {
        [Import(typeof(ICarContract))]
        private Lazy<ICarContract> carPart { get; set; }

        [Export("ConstructorParameter")]
        private int Parameter { get; set; }
       
        static void Main(string[] args)
        {
            new Program().Run();
        }
        void Run()
        {          
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);

            this.Parameter = 10;
            container.ComposeParts(this);
            Console.WriteLine(carPart.Value.StartEngine("Sebastian"));
            container.Dispose();
        }
    }
}
