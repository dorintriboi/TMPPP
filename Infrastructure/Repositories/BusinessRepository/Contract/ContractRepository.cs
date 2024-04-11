using Domain.Entities.Contract;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.Contract.Interface;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Contract;

public class ContractRepository(ApplicationDbContext context) : FullAuditGenericRepository<ContractEntity>(context),
    IContractRepository;