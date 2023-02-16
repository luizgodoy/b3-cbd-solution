using B3.CDB.Main.Api.Options;
using Microsoft.Extensions.Options;
using System;

namespace B3.CDB.Main.Api.Supervisor
{
    public partial class DomainSupervisor : IDomainSupervisor
    {
        private CdbOptions _cdbOptions;
        private IrpfOptions _irpfOptions;

        public DomainSupervisor()
        {
            CheckOptions(_cdbOptions, _irpfOptions);
        }

        private void CheckOptions(CdbOptions cdbOptions, IrpfOptions irpfOptions)
        {
            if(cdbOptions == null)
            {
                _cdbOptions = new CdbOptions()
                {
                    Cdi = "0,9",
                    TaxaBancaria = "108"
                };
            }

            if(irpfOptions == null)
            {
                _irpfOptions = new IrpfOptions() { 
                    IrAte6Meses = "22,5",
                    IrAte12Meses = "20",
                    IrAte24Meses = "17,5",
                    IrAcima24Meses = "15"
                };
            }
        }
    }
}