using Domain.Entities.EmployeeSalary;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.Employee;
using Infrastructure.Repositories.BusinessRepository.EmployeeSalary.Interface;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.EmployeeSalary;

public class EmployeeSalaryRepository
    (ApplicationDbContext context) : FullAuditGenericRepository<EmployeeSalaryEntity>(context),
        IEmployeeSalaryRepository;