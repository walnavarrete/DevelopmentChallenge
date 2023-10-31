using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace FormasGeometricas.Globalization
{
    public class Localization : ILocalization
    {
        private string Culture { get; set; } = "en-US";
        private Dictionary<string, string> Translations { get; set; }

        public Localization()
        {
            Translations = new Dictionary<string, string>();
            LoadLocalizationLabels();
        }

        public string LocalizeString(string key)
        {
            if (this.Translations.ContainsKey(key))
                return this.Translations[key];

            return key;
        }

        public void SetCurrentCulture(string culture)
        {
            this.Culture = culture;
            LoadLocalizationLabels();
        }

        private void LoadLocalizationLabels()
        {

            switch (this.Culture)
            {
             
                case "en-US":
                Translations = new Dictionary<string, string>
                {
                    { "listaVaciaFormas", "<h1>Empty list of shapes!</h1>" },
                    { "reporteFormas", "<h1>Shapes report</h1>" },
                    { "total", "TOTAL:<br/>" },
                    { "forma", "shape" },
                    { "formas", "shapes" },
                    { "perimetro", "Perimeter" },
                    { "area", "Area" },
                    { "cuadrado", "Square" },
                    { "cuadrados", "Squares" },
                    { "circulo", "Circle" },
                    { "circulos", "Circles" },
                    { "triangulo", "Triangle" },
                    { "triangulos", "Triangles" },
                    { "trapecio", "Trapezium" },
                    { "trapecios", "Trapeziums" },
                    { "rectangulo", "Rectangle" },
                    { "rectangulos", "Rectangles" },
                };
                        break;

                case "es-AR":

                Translations = new Dictionary<string, string>
                {
                    { "listaVaciaFormas", "<h1>Lista vacía de formas!</h1>" },
                    { "reporteFormas", "<h1>Reporte de Formas</h1>" },
                    { "total", "TOTAL:<br/>" },
                    { "forma", "forma" },
                    { "formas", "formas" },
                    { "perimetro", "Perimetro" },
                    { "area", "Area" },
                    { "cuadrado", "Cuadrado" },
                    { "cuadrados", "Cuadrados" },
                    { "circulo", "Círculo" },
                    { "circulos", "Círculos" },
                    { "triangulo", "Triángulo" },
                    { "triangulos", "Triángulos" },
                    { "trapecio", "Trapecio" },
                    { "trapecios", "Trapecios" },
                    { "rectangulo", "Rectangulo" },
                    { "rectangulos", "Rectangulos" },
                };
                        break;
   
                case "it-IT":
                Translations = new Dictionary<string, string>
                {
                    { "listaVaciaFormas", "<h1>Elenco vuoto di forme!</h1>" },
                    { "reporteFormas", "<h1>Rapporto sui moduli</h1>" },
                    { "total", "TOTALE:<br/>" },
                    { "forma", "forma" },
                    { "formas", "forme" },
                    { "perimetro", "Perimetro" },
                    { "area", "La zona" },
                    { "cuadrado", "Piazza" },
                    { "cuadrados", "Piazze" },
                    { "circulo", "Cerchio" },
                    { "circulos", "Cerchi" },
                    { "triangulo", "Triangolo" },
                    { "triangulos", "Triangoli" },
                    { "trapecio", "Trapezio" },
                    { "trapecios", "Trapezio" },
                    { "rectangulo", "Rettangolo" },
                    { "rectangulos", "Rettangoli" },
                };
                        break;
                    default:
                        break;
            }

            
        }
    }
}
