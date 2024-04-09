﻿using Domain.Entities.PlaylistMusic;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.PlaylistMusic.Interface;

public interface IPlaylistMusicRepository: IFullAuditGenericRepository<PlaylistMusicEntity>;