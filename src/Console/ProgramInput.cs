using Console.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace Console
{
    public interface IProgramInput
    {
        void Run();
    }

    public class ProgramInput : IProgramInput
    {
        private IEnumerable<Strategies.IProgramInput> _selection;

        public ProgramInput(IEnumerable<Strategies.IProgramInput> selections)
        {
            _selection = selections;
        }

        public void Run()
        {
            var input = string.Empty;

            while (input != "0")
            {
                System.Console.WriteLine("1) Show Categories");
                System.Console.WriteLine("2) Show Featured Products");
                System.Console.WriteLine("3) Show Products in Category");
                System.Console.WriteLine("0) Exit");

                System.Console.Write("Enter an option: ");

                input = System.Console.ReadKey().KeyChar.ToString().ToUpper();

                System.Console.Clear();

                switch (input)
                {                   
                    case "1":
                        _selection.OfType<ShowCategories>().First().Execute().Wait();
                        break;
                    case "2":
                        _selection.OfType<ShowFeaturedProducts>().First().Execute().Wait();
                        break;
                    case "3":
                        _selection.OfType<ShowCategories>().First().Execute().Wait();
                        _selection.OfType<ShowProductsInCategory>().First().Execute().Wait();
                        break;
                }

                System.Console.WriteLine();
            }
        }

        private void ExecuteStrategy<T>()
            where T : Strategies.IProgramInput
        {
            _selection.OfType<T>().First().Execute();
        }
    }
}
