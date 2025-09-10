using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;


        public RepositoryManager(RepositoryContext repositoryContext,
                                 Lazy<ICompanyRepository> companyRepository,
                                 Lazy<IEmployeeRepository> employeeRepository)
        {
            _repositoryContext = repositoryContext;
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
        }


        public ICompanyRepository CompanyRepository => _companyRepository.Value;

        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;


        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
