using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RateMedia.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Director { get; set; }
        public int Year { get; set; }

        public string? Url { get; set; }
        public string? Description { get; set; }
        public double ImdbRating { get; set; }

        public double AverageRating { get; set; }

        public int RatingCount { get; set; }
        public ICollection<Rating> Ratings { get; set; } = null!;
        public void recalculateAverage()
        {
            if (Ratings == null || RatingCount == 0)
            {
                AverageRating = 0.0;
                return;
            }

            double sum = 0;
            foreach (var r in Ratings) sum += r.Value;
            AverageRating = sum / RatingCount;
        }
    }
}