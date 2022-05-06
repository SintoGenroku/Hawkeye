﻿using Hawkeye.OmdbAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.OmdbAPI.Services
{
    public interface IFilmDataSourceService
    {
        Task<FilmDataSource> GetFilmData(int id);
    }
}
