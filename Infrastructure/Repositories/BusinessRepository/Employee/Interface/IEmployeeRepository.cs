using Domain.Entities.Employee;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Employee.Interface;

public interface IEmployeeRepository : IFullAuditGenericRepository<EmployeeEntity>;