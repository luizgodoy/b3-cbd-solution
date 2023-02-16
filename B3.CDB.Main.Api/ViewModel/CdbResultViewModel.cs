using Microsoft.AspNetCore.Mvc;

namespace B3.CDB.Main.Api.ViewModel
{
    public class CdbResultViewModel
    {
        public double ValorBruto { get; set; }

        public double ValorLiquido { get; set; }

        public string Status { get; set; }
    }
}