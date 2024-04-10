using Infrastructure.Data;
using Infrastructure.Repositories.AccountRepository.AccountGenericRepository;
using Infrastructure.Repositories.BusinessRepository.Employee;
using Infrastructure.Repositories.BusinessRepository.Employee.Interface;
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

public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
{
    public ApplicationUnitOfWork(ApplicationDbContext context, IEmployeeRepository employeeRepository,
        IEmployeeSalaryRepository employeeSalaryRepository, IEventRepository eventRepository,
        IInstitutionRepository institutionRepository, ISpectacleRepository spectacleRepository,
        ITeamMemberRepository teamMemberRepository, ITeamRepository teamRepository,
        IPlaylistRepository playlistRepository, IMusicRepository musicRepository) : base(context)
    {
        EmployeeRepository = employeeRepository;
        EmployeeSalaryRepository = employeeSalaryRepository;
        EventRepository = eventRepository;
        InstitutionRepository = institutionRepository;
        SpectacleRepository = spectacleRepository;
        TeamRepository = teamRepository;
        TeamMemberRepository = teamMemberRepository;
        PlaylistRepository = playlistRepository;
        MusicRepository = musicRepository;
    }

    public IEmployeeRepository EmployeeRepository { get; }

    public IEmployeeSalaryRepository EmployeeSalaryRepository { get; }

    public IEventRepository EventRepository { get; }

    public IInstitutionRepository InstitutionRepository { get; }

    public ISpectacleRepository SpectacleRepository { get; }

    public ITeamRepository TeamRepository { get; }

    public ITeamMemberRepository TeamMemberRepository { get; }
    public IPlaylistRepository PlaylistRepository { get; }
    public IMusicRepository MusicRepository { get; }

    public IAccountGenericRepository GetType<TType>(TType type)
    {
        throw new Exception();
    }
}