using Infrastructure.Data;
using Infrastructure.Repositories.AccountRepository.AccountGenericRepository;
using Infrastructure.Repositories.BusinessRepository.CompanyEvent.Interface;
using Infrastructure.Repositories.BusinessRepository.CompanyEventType.Interface;
using Infrastructure.Repositories.BusinessRepository.Contract.Interface;
using Infrastructure.Repositories.BusinessRepository.Employee;
using Infrastructure.Repositories.BusinessRepository.Employee.Interface;
using Infrastructure.Repositories.BusinessRepository.EmployeeCompanyEventType.Interface;
using Infrastructure.Repositories.BusinessRepository.EmployeeSalary;
using Infrastructure.Repositories.BusinessRepository.EmployeeSalary.Interface;
using Infrastructure.Repositories.BusinessRepository.Event;
using Infrastructure.Repositories.BusinessRepository.Event.Interface;
using Infrastructure.Repositories.BusinessRepository.Institution;
using Infrastructure.Repositories.BusinessRepository.Institution.Interface;
using Infrastructure.Repositories.BusinessRepository.Music.Interface;
using Infrastructure.Repositories.BusinessRepository.Playlist.Interface;
using Infrastructure.Repositories.BusinessRepository.Spectacle;
using Infrastructure.Repositories.BusinessRepository.Spectacle.Interface;
using Infrastructure.Repositories.BusinessRepository.Team;
using Infrastructure.Repositories.BusinessRepository.Team.Interface;
using Infrastructure.Repositories.BusinessRepository.TeamMember;
using Infrastructure.Repositories.BusinessRepository.TeamMember.Interface;

namespace Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;

public class ApplicationUnitOfWork(ApplicationDbContext context, IEmployeeRepository employeeRepository,
        IEmployeeSalaryRepository employeeSalaryRepository, IEventRepository eventRepository,
        IInstitutionRepository institutionRepository, ISpectacleRepository spectacleRepository,
        ITeamMemberRepository teamMemberRepository, ITeamRepository teamRepository,
        IPlaylistRepository playlistRepository, IMusicRepository musicRepository,
        IContractRepository contractRepository, ICompanyEventRepository companyEventRepository,
        ICompanyEventTypeRepository companyEventTypeRepository,
        IEmployeeCompanyEventTypeRepository employeeCompanyEventTypeRepository)
    : UnitOfWork(context), IApplicationUnitOfWork
{
    public IEmployeeRepository EmployeeRepository { get; } = employeeRepository;

    public IEmployeeSalaryRepository EmployeeSalaryRepository { get; } = employeeSalaryRepository;

    public IEventRepository EventRepository { get; } = eventRepository;

    public IInstitutionRepository InstitutionRepository { get; } = institutionRepository;

    public ISpectacleRepository SpectacleRepository { get; } = spectacleRepository;

    public ITeamRepository TeamRepository { get; } = teamRepository;

    public ITeamMemberRepository TeamMemberRepository { get; } = teamMemberRepository;
    public IPlaylistRepository PlaylistRepository { get; } = playlistRepository;
    public IMusicRepository MusicRepository { get; } = musicRepository;
    public IContractRepository ContractRepository { get; } = contractRepository;

    public ICompanyEventRepository CompanyEventRepository { get; } = companyEventRepository;
    public ICompanyEventTypeRepository CompanyEventTypeRepository { get; } = companyEventTypeRepository;
    public IEmployeeCompanyEventTypeRepository EmployeeCompanyEventTypeRepository { get; } = employeeCompanyEventTypeRepository;

    public IAccountGenericRepository GetType<TType>(TType type)
    {
        throw new Exception();
    }
}