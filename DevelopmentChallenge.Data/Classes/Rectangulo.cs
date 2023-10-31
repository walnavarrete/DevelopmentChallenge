using FormasGeometricas.Globalization;

namespace FormasGeometricas.Data.Classes
{
    public class Rectangulo : Forma
    {
        #region Properties
        public decimal Base { get; set; }
        public decimal Altura { get; set; }
        #endregion

        private readonly ILocalization Localization;

        public Rectangulo() { }

        public Rectangulo(ILocalization localization)
        {
            this.Localization = localization;
        }

        public override decimal CalcularArea()
        {
            return Base * Altura;
        }

        public override decimal CalcularPerimetro()
        {
            return (Base * 2 + Altura * 2);
        }

        public override string TraducirForma()
        {
            return Localization.LocalizeString("rectangulo");
        }

        public override string TraducirFormaPlural()
        {
            return Localization.LocalizeString("rectangulos");
        }

        public override string ObtenerLinea()
        {
            return $"1 {TraducirForma()} | {Localization.LocalizeString("area")} {CalcularArea():#.##} | {Localization.LocalizeString("perimetro")} {CalcularPerimetro():#.##} <br/>";
        }

        public override int GetListCount()
        {
            return 1;
        }

        public override void Add(Forma forma)
        {
            throw new System.NotImplementedException("Operation not permitted since this is a leaf node");
        }

        public override void Remove(Forma forma)
        {
            throw new System.NotImplementedException("Operation not permitted since this is a leaf node");
        }
    }
}
