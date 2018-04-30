using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OOP_2_3
{
    public class Global
    {
        public Animal value;
        public struct OrialObitania
        {
            public string Kontinent;
            public int Shirota;
            public int Dolgota;
            public string Raen;
            public int Ploshad;
        }
        public struct Kutator
        {
            public string Familia;
            public string Ima;
            public string Otchestvo;
            public string Strana;
        }
        public struct Animal
        {
            public string Nazvanie;
            public string Tip;
            public string Opisanie;
            public string Otrad;
            public int Vozrast;
            public string Klass;
            public bool IsRedBook;
            public OrialObitania orialObitania;
            public Kutator kutator;
            public string Data;
        }
        public OrialObitania GetOrialObitania(string Kontinent,
                int Shirota, int Dolgota, string Raen, int Ploshad)
        {
            OrialObitania ResorialObitania;
            ResorialObitania.Kontinent = Kontinent;
            ResorialObitania.Shirota = Shirota;
            ResorialObitania.Dolgota = Dolgota;
            ResorialObitania.Raen = Raen;
            ResorialObitania.Ploshad = Ploshad;
            return ResorialObitania;
        }
        public Kutator GetKutator(string Familia,
            string Ima, string Otchestvo, string Strana)
        {
            Kutator ResKutator;
            ResKutator.Familia = Familia;
            ResKutator.Ima = Ima;
            ResKutator.Otchestvo = Otchestvo;
            ResKutator.Strana = Strana;
            return ResKutator;
        }
        public void SetClassAnimal(string Nazvanie,
            string Tip, string Opisanie,
            string Otrad, int Vozrast,
            string Klass, bool IsRedBook,
            OrialObitania orialObitania,
            Kutator kutator,
            string Data)
        {
            value.Nazvanie = Nazvanie;
            value.Tip = Tip;
            value.Opisanie = Opisanie;
            value.Otrad = Otrad;
            value.Vozrast = Vozrast;
            value.Klass = Klass;
            value.IsRedBook = IsRedBook;
            value.orialObitania = orialObitania;
            value.kutator = kutator;
            value.Data = Data;
        }
        public string GetJSON()
        {
            return JsonConvert.SerializeObject(value);
        }
        public Animal GetClassAnimalWithJSON(string js)
        {
            value = JsonConvert.DeserializeObject<Animal>(js);
            return value;
        }

        public override string ToString()
        {
            return value.Nazvanie;
        }
    }
}
