using Contracts;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repositoryManager.CompanyRepository
                    .GetAllCompanies(trackChanges);

                return companies;
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Something went wrong in the" +
                    $" {nameof(GetAllCompanies)} service method {ex}");
                    throw;
            }
        }
    }
}
