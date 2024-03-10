using Infrastructure.Repositories.AccountRepository.AccountGenericRepository;
using Infrastructure.Repositories.BusinessRepository.Employee;
using Infrastructure.Repositories.BusinessRepository.Employee.Interface;
using Infrastructure.Repositories.BusinessRepository.EmployeeSalary;
using Infrastructure.Repositories.BusinessRepository.EmployeeSalary.Interface;
using Infrastructure.Repositories.BusinessRepository.Event;
using Infrastructure.Repositories.BusinessRepository.Event.Interface;
using Infrastructure.Repositories.BusinessRepository.Institution;
using Infrastructure.Repositories.BusinessRepository.Institution.Interface;
using Infrastructure.Repositories.BusinessRepository.Spectacle;
using Infrastructure.Repositories.BusinessRepository.Spectacle.Interface;
using Infrastructure.Repositories.BusinessRepository.Team;
using Infrastructure.Repositories.BusinessRepository.Team.Interface;
using Infrastructure.Repositories.BusinessRepository.TeamMember;
using Infrastructure.Repositories.BusinessRepository.TeamMember.Interface;

namespace Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;

public interface IApplicationUnitOfWork : IUnitOfWork
{
    IEmployeeRepository EmployeeRepository { get; }
    IEmployeeSalaryRepository EmployeeSalaryRepository { get; }
    IEventRepository EventRepository { get; }
    IInstitutionRepository InstitutionRepository { get; }
    ISpectacleRepository SpectacleRepository { get; }
    ITeamRepository TeamRepository { get; }
    ITeamMemberRepository TeamMemberRepository { get; }
    IAccountGenericRepository GetType<TType>(TType type);
}