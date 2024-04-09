using Domain.Entities.Spectacle;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.Spectacle.Interface;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Spectacle;

public class CacheSpectacleRepository(ApplicationDbContext context, SpectacleRepository repository) :
    FullAuditGenericRepository<SpectacleEntity>(context),
    ISpectacleRepository
{
    private Dictionary<string, SpectacleEntity> DictionaryEntity = new();
    public async Task<SpectacleEntity?> GetByIdAsync(string id)
    {
        if (DictionaryEntity.ContainsKey(id))
        {
            return DictionaryEntity[id];
        }

        var entity = await repository.GetByIdAsync(id);
        DictionaryEntity.Add(id, entity);

        return entity;
    }
}