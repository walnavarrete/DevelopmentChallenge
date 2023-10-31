using System;
using System.Collections.Generic;
using Castle.Windsor;
using DevelopmentChallenge.Data.Classes;
using FormasGeometricas.Data.Classes;
using FormasGeometricas.Globalization;
using NUnit.Framework;
using Castle.MicroKernel.Registration;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTestsRefactor
    {
        private WindsorContainer Container;

        [SetUp]
        public void SetUp()
        {
            Container = new WindsorContainer();
            Container.Register(Component.For(typeof(ILocalization)).ImplementedBy<Localization>());
        }

        [TearDown]
        public void TearDownw()
        {
            Container.Dispose();
        }

        [TestCase]
        public void TestResumenListaVacia()
        {
            IEnumerable<Forma> formas = new List<FormaGroup<Cuadrado>>();
            FormaGeometricaRefactor.Localization = Container.Resolve<ILocalization>();
            FormaGeometricaRefactor.Localization.SetCurrentCulture("es-AR");

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometricaRefactor.Imprimir(formas));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            IEnumerable<Forma> formas = new List<FormaGroup<Cuadrado>>();
            FormaGeometricaRefactor.Localization = Container.Resolve<ILocalization>();

            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometricaRefactor.Imprimir(formas));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            IEnumerable<Forma> formas = new List<FormaGroup<Cuadrado>>();
            FormaGeometricaRefactor.Localization = Container.Resolve<ILocalization>();
            FormaGeometricaRefactor.Localization.SetCurrentCulture("it-IT");

            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                FormaGeometricaRefactor.Imprimir(formas));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            FormaGeometricaRefactor.Localization = Container.Resolve<ILocalization>();
            FormaGeometricaRefactor.Localization.SetCurrentCulture("es-AR");

            IEnumerable<Forma> formas = new List<Cuadrado> { new Cuadrado(FormaGeometricaRefactor.Localization) { Lado = 5 } };

            var resumen = FormaGeometricaRefactor.Imprimir(formas);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 forma Perimetro 20 Area 25", resumen);
        }


        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            FormaGeometricaRefactor.Localization = Container.Resolve<ILocalization>();

            var FormaGroup = new FormaGroup<Forma>(FormaGeometricaRefactor.Localization);
            FormaGroup.Add(new Cuadrado(FormaGeometricaRefactor.Localization) { Lado = 5 });
            FormaGroup.Add(new Cuadrado(FormaGeometricaRefactor.Localization) { Lado = 1 });
            FormaGroup.Add(new Cuadrado(FormaGeometricaRefactor.Localization) { Lado = 3 });

            var resumen = FormaGeometricaRefactor.Imprimir(new List<FormaGroup<Forma>> { FormaGroup });

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            FormaGeometricaRefactor.Localization = Container.Resolve<ILocalization>();

            IEnumerable<Forma> formas = new List<Trapecio> { new Trapecio(FormaGeometricaRefactor.Localization) { Base1 = 5, Base2 = 6, Base3 = 4, Base4 = 3, Altura = 8 } };

            var resumen = FormaGeometricaRefactor.Imprimir(formas);

            Assert.AreEqual("<h1>Shapes report</h1>1 Trapezium | Area 44 | Perimeter 18 <br/>TOTAL:<br/>1 shape Perimeter 18 Area 44", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            FormaGeometricaRefactor.Localization = Container.Resolve<ILocalization>();

            IEnumerable<Forma> formas = new List<Rectangulo> { new Rectangulo(FormaGeometricaRefactor.Localization) { Base = 5, Altura = 8 } };

            var resumen = FormaGeometricaRefactor.Imprimir(formas);

            Assert.AreEqual("<h1>Shapes report</h1>1 Rectangle | Area 40 | Perimeter 26 <br/>TOTAL:<br/>1 shape Perimeter 26 Area 40", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioUnCuadrado()
        {
            FormaGeometricaRefactor.Localization = Container.Resolve<ILocalization>();

            IEnumerable<Forma> formas = new List<Forma>
            {
                new Trapecio(FormaGeometricaRefactor.Localization) { Base1 = 5, Base2 = 6, Base3 = 4, Base4 = 3, Altura = 8 },
                new Cuadrado(FormaGeometricaRefactor.Localization) { Lado = 5 }
            };

            var resumen = FormaGeometricaRefactor.Imprimir(formas);

            Assert.AreEqual("<h1>Shapes report</h1>1 Trapezium | Area 44 | Perimeter 18 <br/>1 Square | Area 25 | Perimeter 20 <br/>TOTAL:<br/>2 shapes Perimeter 38 Area 69", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            FormaGeometricaRefactor.Localization = Container.Resolve<ILocalization>();

            var FormaGroupCuadrado = new FormaGroup<Forma>(FormaGeometricaRefactor.Localization);
            FormaGroupCuadrado.Add(new Cuadrado(FormaGeometricaRefactor.Localization) { Lado = 5 });
            FormaGroupCuadrado.Add(new Cuadrado(FormaGeometricaRefactor.Localization) { Lado = 2 });

            var FormaGroupCirculo = new FormaGroup<Forma>(FormaGeometricaRefactor.Localization);
            FormaGroupCirculo.Add(new Circulo(FormaGeometricaRefactor.Localization) { Lado = 3 });
            FormaGroupCirculo.Add(new Circulo(FormaGeometricaRefactor.Localization) { Lado = 2.75m });

            var FormaGroupTrianguloEquilatero = new FormaGroup<Forma>(FormaGeometricaRefactor.Localization);
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(FormaGeometricaRefactor.Localization) { Lado = 4 });
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(FormaGeometricaRefactor.Localization) { Lado = 9 });
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(FormaGeometricaRefactor.Localization) { Lado = 4.2m });

            var resumen = FormaGeometricaRefactor.Imprimir(new List<FormaGroup<Forma>> { FormaGroupCuadrado, FormaGroupCirculo, FormaGroupTrianguloEquilatero });

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            FormaGeometricaRefactor.Localization = Container.Resolve<ILocalization>();
            FormaGeometricaRefactor.Localization.SetCurrentCulture("es-AR");

            var FormaGroupCuadrado = new FormaGroup<Forma>(FormaGeometricaRefactor.Localization);
            FormaGroupCuadrado.Add(new Cuadrado(FormaGeometricaRefactor.Localization) { Lado = 5 });
            FormaGroupCuadrado.Add(new Cuadrado(FormaGeometricaRefactor.Localization) { Lado = 2 });

            var FormaGroupCirculo = new FormaGroup<Forma>(FormaGeometricaRefactor.Localization);
            FormaGroupCirculo.Add(new Circulo(FormaGeometricaRefactor.Localization) { Lado = 3 });
            FormaGroupCirculo.Add(new Circulo(FormaGeometricaRefactor.Localization) { Lado = 2.75m });

            var FormaGroupTrianguloEquilatero = new FormaGroup<Forma>(FormaGeometricaRefactor.Localization);
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(FormaGeometricaRefactor.Localization) { Lado = 4 });
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(FormaGeometricaRefactor.Localization) { Lado = 9 });
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(FormaGeometricaRefactor.Localization) { Lado = 4.2m });

            var resumen = FormaGeometricaRefactor.Imprimir(new List<FormaGroup<Forma>> { FormaGroupCuadrado, FormaGroupCirculo, FormaGroupTrianguloEquilatero });

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
    }
}

