using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace B3.CDB.Main.Test
{
    [TestClass]
    public class CdbSupervisorService
    {
        private readonly B3.CDB.Main.Api.Supervisor.DomainSupervisor _supervisor = new Api.Supervisor.DomainSupervisor();

        [TestMethod]
        public void GetCdb_ValorPrincipalPositivo_ReturnFalse()
        {
            B3.CDB.Main.Api.ViewModel.CdbViewModel cdb = new Api.ViewModel.CdbViewModel();
            
            // Arrange: Principal com valor negativo
            cdb.Principal = -1;
            cdb.Vencimento = 10;
            
            // act
            Assert.ThrowsException<System.ArgumentException>(() => _supervisor.GetCdbResult(cdb));

            // Arrange: Principal igual a zero
            cdb.Principal = 0;
            cdb.Vencimento = 10;
            
            // act
            Assert.ThrowsException<System.ArgumentException>(() => _supervisor.GetCdbResult(cdb));
        }

        [TestMethod]
        public void GetCdb_Vencimento_ReturnFalse()
        {
            B3.CDB.Main.Api.ViewModel.CdbViewModel cdb = new Api.ViewModel.CdbViewModel();

            // Principal com valor negativo
            cdb.Vencimento = 1;
            cdb.Principal = 100;

            // act
            Assert.ThrowsException<System.ArgumentException>(() => _supervisor.GetCdbResult(cdb));
        }

        [TestMethod]
        public void GetCdb_ValorPositivo_Should()
        {
            B3.CDB.Main.Api.ViewModel.CdbViewModel cdb = new Api.ViewModel.CdbViewModel();
            cdb.Principal = 1000;
            cdb.Vencimento = 25;

            Assert.AreEqual(_supervisor.GetCdbResult(cdb).ValorBruto, 1273,5734);
            Assert.AreEqual(_supervisor.GetCdbResult(cdb).ValorLiquido, 1232,5374);
        }
    }
}