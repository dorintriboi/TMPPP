﻿using Domain.Entities.Playlist;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Playlist.Interface;

public interface IPlaylistRepository: IFullAuditGenericRepository<PlaylistEntity>;