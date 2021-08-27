using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RealStateManager.Domain.Interfaces;
using RealStateManager.Domain.Models;

namespace RealStateManager.Application.Services
{
    public class PropertyServices : IPropertyServices
    {
        private readonly IPropertyRepository _rep;
        private readonly ILogger<PropertyServices> _logger;
        public PropertyServices(IPropertyRepository rep, ILogger<PropertyServices> logger)
        {
            _rep = rep;
            _logger = logger;
        }
        public async Task Create(Property property)
        {
            try
            {
                _logger.LogInformation("Iniciou o processo de criacao de propriedade.");

                await _rep.Create(property);

                _logger.LogInformation($"Propriedade: {property.Name} inserida as {DateTime.UtcNow}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public async Task<IEnumerable<Property>> GetAllPropertiesWithPayments()
        {
            IEnumerable<Property> properties = null;

            try
            {
                _logger.LogInformation($"Buscando todas as propriedades {DateTime.UtcNow}");

                properties = await _rep.GetAllPropertiesWithPayments();

                if (properties.Any())
                {
                    _logger.LogInformation($"Propriedades encontradas: {properties.Count()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return properties;
        }
        public async Task<IEnumerable<Property>> GetAll()
        {
            IEnumerable<Property> properties = null;

            try
            {
                _logger.LogInformation($"Buscando todas as propriedades {DateTime.UtcNow}");

                properties = await _rep.GetAll();

                _logger.LogInformation($"Propriedades encontradas: {properties.Count()}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return properties;
        }
        public async Task<Property> GetByIdWithPayments(int id)
        {
            Property property = null;

            try
            {
                _logger.LogInformation($"Buscando todas as propriedades {DateTime.UtcNow}");

                property = await _rep.GetByIdWithPayments(id);

                if (property != null)
                {
                    _logger.LogInformation($"Propriedade encontrada: {property.Name}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return property;
        }
        public async Task<Property> GetById(int id)
        {
            Property property = null;

            try
            {
                _logger.LogInformation($"Buscando todas as propriedades {DateTime.UtcNow}");

                property = await _rep.GetById(id);

                if (property != null)
                {
                    _logger.LogInformation($"Propriedade encontrada: {property.Name}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return property;
        }
        public async Task Remove(int id)
        {
            try
            {
                _logger.LogInformation("Iniciou o processo de remoção de propriedade.");

                await _rep.Delete(id);

                _logger.LogInformation($"Propriedade removida as {DateTime.UtcNow}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public async Task Update(Property property)
        {
            try
            {
                _logger.LogInformation("Iniciou o processo de atualização de propriedade.");

                await _rep.Update(property);

                _logger.LogInformation($"Propriedade: {property.Name} atualizada as {DateTime.UtcNow}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}