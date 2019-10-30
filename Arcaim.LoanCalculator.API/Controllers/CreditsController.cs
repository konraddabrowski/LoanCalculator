using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcaim.LoanCalculator.Infrastructure.CreditFlows;
using Arcaim.LoanCalculator.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arcaim.LoanCalculator.API.Controllers
{
    [Route("api/[controller]")]
    public class CreditsController : Controller
    {
        private ICreditService _service;

        public CreditsController(ICreditService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetEqualInstallmentResult")]
        public async Task<IActionResult> GetEqualInstallmentResult(decimal amount, decimal annual, int months)
        {
            try
            {
                await _service.SetCreditAsync(amount, annual, months);
                await _service.SetCreditFlowAsync(new EqualInstallment());
                return Ok(await _service.GetFinancialResultAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Cannot create holiday request.");
            }
            
        }
    }
}