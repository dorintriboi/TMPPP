using Domain.Entities.Employee;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Employee;

public interface IEmployeeRepository : IFullAuditGenericRepository<EmployeeEntity>;