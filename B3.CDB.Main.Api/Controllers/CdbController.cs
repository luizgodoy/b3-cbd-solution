using B3.CDB.Main.Api.Supervisor;
using B3.CDB.Main.Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace B3.CDB.Main.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CdbController : Controller
    {
        private readonly ILogger<CdbController> _logger;
        private readonly IDomainSupervisor _domainSupervisor;
        public CdbController(ILogger<CdbController> logger, IDomainSupervisor domainSupervisor)
        {
            _logger = logger;
            _domainSupervisor = domainSupervisor;
        }

        [HttpGet]
        public CdbResultViewModel GetCdb([FromQuery] CdbViewModel cdb)
        {
            try
            {
                return _domainSupervisor.GetCdbResult(cdb);
            } 
            catch(ArgumentNullException ex)
            {
                _logger.LogError(ex.Message);
                return new CdbResultViewModel() { Status = ex.ParamName };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new CdbResultViewModel() { Status = ex.Message };
            }            
        }
    }
}