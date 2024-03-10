﻿using Domain.Entities.Institution;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Institution.Interface;

public interface IInstitutionRepository : IFullAuditGenericRepository<InstitutionEntity>;