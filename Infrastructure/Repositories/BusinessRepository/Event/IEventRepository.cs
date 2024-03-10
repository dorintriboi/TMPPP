using Domain.Entities.Event;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Event;

public interface IEventRepository : IFullAuditGenericRepository<EventEntity>;