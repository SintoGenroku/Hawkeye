using Hawkeye.Domain.Models;

namespace Hawkeye.Domain.Services
{
    public interface IFilmService
    {
        Task<FilmInfo> GetFilm();
    }
}
