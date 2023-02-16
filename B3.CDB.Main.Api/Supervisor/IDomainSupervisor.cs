using B3.CDB.Main.Api.ViewModel;

namespace B3.CDB.Main.Api.Supervisor
{
    public interface IDomainSupervisor
    {
        CdbResultViewModel GetCdbResult(CdbViewModel cdb);
    }
}
