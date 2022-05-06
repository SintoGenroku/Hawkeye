using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.Domain.Models
{
    public class FilmInfo
    {
        public int KinopoiskId { get; set; }
        public string? NameRu { get; set; }
        public string? NameEn { get; set; }
        public string? NameOriginal { get; set; }
        public string? PosterUrl { get; set; }
        public string? PosterUrlPreview { get; set; }
        public string? CoverUrl { get; set; }
        public string? logoUrl { get; set; }
        public int ReviewsCount { get; set; }
        public int RatingGoodReview { get; set; }
        public int RatingGoodReviewVoteCount { get; set; }
        public float RatingKinopoisk { get; set; }
        public int RatingKinopoiskVoteCount { get; set; }
        public float RatingImdb { get; set; }
        public int RatingImdbVoteCount { get; set; }
        public float RatingFilmCritics { get; set; }
        public int RatingFilmCriticsVoteCount { get; set; }
        public float RatingAwait { get; set; }
        public int RatingAwaitVoteCount { get; set; }
        public float RatingRfCritics { get; set; }
        public int RatingRfCriticsVoteCount { get; set; }
        public string? WebUrl { get; set; }
        public int Year { get; set; }
        public int FilmLenght { get; set; }
        public string? Slogan { get; set; }
        public string? Description { get; set; }
        public string? ShortDesription { get; set; }
        public string? EditorAnnotation { get; set; }
        public bool? IsTicketAvailable { get; set; }
        public string? ProductionStatus { get; set; }
        public string? Type { get; set; }
        public string? RatingMpaa { get; set; }
        public string? RatingAgeLimits { get; set; }
        public Dictionary<string, string>? Countries { get; set; }
        public Dictionary<string, string>? Genres { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public bool Serial { get; set; }
        public bool ShortFilm { get; set; }
        public bool Completed { get; set; }
        public bool HasIMax { get; set; }
        public bool Has3D { get; set; }
        public DateTime LastSync { get; set; }

    }
}
