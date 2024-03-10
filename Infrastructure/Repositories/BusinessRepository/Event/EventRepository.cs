using Domain.Entities.Event;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Event;

public class EventRepository(ApplicationDbContext context) : FullAuditGenericRepository<EventEntity>(context),
    IEventRepository;