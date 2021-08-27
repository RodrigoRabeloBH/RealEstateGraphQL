using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealStateManage.API.Helpers;
using RealStateManager.Domain.Interfaces;

namespace RealStateManage.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyServices _services;
        private readonly ILogger<PropertiesController> _logger;

        public PropertiesController(IPropertyServices services, ILogger<PropertiesController> logger)
        {
            _services = services;
            _logger = logger;
        }

        [HttpGet("GetAllProperties")]
        [Cached(6000)]
        public async Task<IActionResult> GetAllProperties()
        {
            try
            {
                _logger.LogInformation("Buscando propiedades.");

                var properties = await _services.GetAll();

                if (properties.Any())
                {
                    return Ok(properties);
                }

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

        [Cached(6000)]
        [HttpGet("GetAllPropertiesWithPayments")]
        public async Task<IActionResult> GetAllPropertiesWithPayments()
        {
            try
            {
                _logger.LogInformation("Buscando propiedades.");

                var properties = await _services.GetAllPropertiesWithPayments();

                if (properties.Any())
                {
                    return Ok(properties);
                }

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }
    }
}