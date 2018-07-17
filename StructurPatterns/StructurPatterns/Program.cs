using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1-decorator,2-adapter,3-composite");
            int number = 1;
            while (number != 0)
            {
                Console.WriteLine("enter pattern number");
                number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        Console.WriteLine("enter pizza number");
                        Console.WriteLine("1-итальянская пицца с томатами,2- итальянская пиццы с сыром,3-итальянская пиццы с томатами и сыром");
                        int number1 = 1;
                        if (number1 != 0)
                        {
                            number1 = Convert.ToInt32(Console.ReadLine());
                            switch (number1)
                            {
                                case 1:
                                    Console.WriteLine("итальянская пицца с томатами");
                                    Pizza pizza1 = new ItalianPizza();
                                    pizza1 = new TomatoPizza(pizza1);
                                    Console.WriteLine("Название: {0}", pizza1.Name);
                                    Console.WriteLine("Цена: {0}", pizza1.GetCost());
                                    break;
                                case 2:
                                    Console.WriteLine(" итальянская пиццы с сыром");
                                    Pizza pizza2 = new ItalianPizza();
                                    pizza2 = new CheesePizza(pizza2);
                                    Console.WriteLine("Название: {0}", pizza2.Name);
                                    Console.WriteLine("Цена: {0}", pizza2.GetCost());
                                    break;
                                case 3:
                                    Console.WriteLine("итальянская пиццы с томатами и сыром");
                                    Pizza pizza3 = new ItalianPizza();
                                    pizza3 = new TomatoPizza(pizza3);
                                    pizza3 = new CheesePizza(pizza3);
                                    Console.WriteLine("Название: {0}", pizza3.Name);
                                    Console.WriteLine("Цена: {0}", pizza3.GetCost());
                                    break;
                                default:
                                    Console.WriteLine("error");
                                    break;
                            }
                        }

                        break;

                    case 2:
                        // путешественник
                        Driver driver = new Driver();
                        // машина
                        Auto auto = new Auto();
                        // отправляемся в путешествие
                        driver.Travel(auto);
                        // встретились пески, надо использовать верблюда
                        Camel camel = new Camel();
                        // используем адаптер
                        ITransport camelTransport = new CamelToTransportAdapter(camel);
                        // продолжаем путь по пескам пустыни
                        driver.Travel(camelTransport);
                        break;
                    case 3:
                        Component fileSystem = new Directory("Файловая система");
                        // определяем новый диск
                        Component diskC = new Directory("Диск С");
                        // новые файлы
                        Component pngFile = new File("12345.png");
                        Component docxFile = new File("Document.docx");
                        // добавляем файлы на диск С
                        diskC.Add(pngFile);
                        diskC.Add(docxFile);
                        // добавляем диск С в файловую систему
                        fileSystem.Add(diskC);
                        // выводим все данные
                        fileSystem.Print();
                        Console.WriteLine();
                        // удаляем с диска С файл
                        diskC.Remove(pngFile);
                        // создаем новую папку
                        Component docsFolder = new Directory("Мои Документы");
                        // добавляем в нее файлы
                        Component txtFile = new File("readme.txt");
                        Component csFile = new File("Program.cs");
                        docsFolder.Add(txtFile);
                        docsFolder.Add(csFile);
                        diskC.Add(docsFolder);

                        fileSystem.Print();

                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                number = 1;
            }


        }
        /// <summary>
        /// decorator
        /// </summary>
        abstract class Pizza
        {
            public Pizza(string n)
            {
                this.Name = n;
            }
            public string Name { get; protected set; }
            public abstract int GetCost();
        }

        class ItalianPizza : Pizza
        {
            public ItalianPizza() : base("Итальянская пицца")
            { }
            public override int GetCost()
            {
                return 10;
            }
        }

        abstract class PizzaDecorator : Pizza
        {
            protected Pizza pizza;
            public PizzaDecorator(string n, Pizza pizza) : base(n)
            {
                this.pizza = pizza;
            }
        }

        class TomatoPizza : PizzaDecorator
        {
            public TomatoPizza(Pizza p)
                : base(p.Name + ", с томатами", p)
            { }

            public override int GetCost()
            {
                return pizza.GetCost() + 3;
            }
        }

        class CheesePizza : PizzaDecorator
        {
            public CheesePizza(Pizza p)
                : base(p.Name + ", с сыром", p)
            { }

            public override int GetCost()
            {
                return pizza.GetCost() + 5;
            }
        }

        ////adapter
        interface ITransport
        {
            void Drive();
        }
        // класс машины
        class Auto : ITransport
        {
            public void Drive()
            {
                Console.WriteLine("Машина едет по дороге");
            }
        }
        class Driver
        {
            public void Travel(ITransport transport)
            {
                transport.Drive();
            }
        }
        // интерфейс животного
        interface IAnimal
        {
            void Move();
        }
        // класс верблюда
        class Camel : IAnimal
        {
            public void Move()
            {
                Console.WriteLine("Верблюд идет по пескам пустыни");
            }
        }
        // Адаптер от Camel к ITransport
        class CamelToTransportAdapter : ITransport
        {
            Camel camel;
            public CamelToTransportAdapter(Camel c)
            {
                camel = c;
            }

            public void Drive()
            {
                camel.Move();
            }
        }


        ////composite
        abstract class Component
        {
            protected string name;

            public Component(string name)
            {
                this.name = name;
            }

            public virtual void Add(Component component) { }

            public virtual void Remove(Component component) { }

            public virtual void Print()
            {
                Console.WriteLine(name);
            }
        }
        class Directory : Component
        {
            private List<Component> components = new List<Component>();

            public Directory(string name)
                : base(name)
            {
            }

            public override void Add(Component component)
            {
                components.Add(component);
            }

            public override void Remove(Component component)
            {
                components.Remove(component);
            }

            public override void Print()
            {
                Console.WriteLine("Узел " + name);
                Console.WriteLine("Подузлы:");
                for (int i = 0; i < components.Count; i++)
                {
                    components[i].Print();
                }
            }
        }

        class File : Component
        {
            public File(string name)
                    : base(name)
            { }
        }
    }
}
