using B3.CDB.Main.Api.ViewModel;
using System;

namespace B3.CDB.Main.Api.Supervisor
{
    public partial class DomainSupervisor
    {
        public CdbResultViewModel GetCdbResult(CdbViewModel cdb)
        {
            if (cdb == null)
                throw new System.ArgumentNullException("Os dados de entrada não foram informados");

            if (cdb.Principal <= 0)
                throw new System.ArgumentException("O valor do principal deve ser maior que zero");

            if (cdb.Vencimento <= 1)
                throw new System.ArgumentException("O vencimento deverá ser maior que 1 mês");

            return Calculate(cdb.Principal, cdb.Vencimento);
        }

        /// <summary>
        /// Juros compostos pagando um percentual sobre o CDI
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="vencimento"></param>
        /// <returns></returns>
        private CdbResultViewModel Calculate(double valorInicial, int vencimento)
        {
            double valorFinal = valorInicial * Math.Pow(1 + (Convert.ToDouble(_cdbOptions.Cdi)/100) * (Convert.ToDouble(_cdbOptions.TaxaBancaria)/100), vencimento);
            double rendimentos = valorFinal - valorInicial;
            double rendimentoLiquido = CalculateIr(rendimentos, vencimento);

            return new CdbResultViewModel()
            {
                ValorBruto = Math.Round(valorFinal,4),
                ValorLiquido = Math.Round(valorInicial + rendimentoLiquido,4),
            };
        }

        /// <summary>
        /// Calcular o valor do IR sobre o rendimento, não pode afetar o pricipal
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="vencimento"></param>
        /// <returns></returns>
        private double CalculateIr(double valor, int vencimento)
        {
            double resultado = 0;

            if (vencimento <= 6)
                resultado = valor - (valor * (Convert.ToDouble(_irpfOptions.IrAte6Meses) / 100));
            else if (vencimento <= 12)
                resultado = valor - (valor * (Convert.ToDouble(_irpfOptions.IrAte12Meses) / 100));
            else if (vencimento <= 24)
                resultado = valor - (valor * (Convert.ToDouble(_irpfOptions.IrAte24Meses) / 100));
            else if (vencimento > 24)
                resultado = valor - (valor * (Convert.ToDouble(_irpfOptions.IrAcima24Meses) / 100));

            return resultado;
        }
    }
}
