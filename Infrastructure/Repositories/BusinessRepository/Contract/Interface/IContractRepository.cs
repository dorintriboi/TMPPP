﻿using Domain.Entities.Contract;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Contract.Interface;

public interface IContractRepository: IFullAuditGenericRepository<ContractEntity>;