// Models/Rating.cs
// <<entity>> – po UML VOPC diagramu
// Atributi: id : int, value : int, createdAt : Date, userId : String, movieId : int
// Operacije: newRating(movieId, userId, value) : Rating

using System;
using System.ComponentModel.DataAnnotations;

namespace RateMedia.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Range(1, 10, ErrorMessage = "Ocena mora biti med 1 in 10.")]
        public int Value { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public int MovieId { get; set; }

        public Movie? Movie { get; set; }
        public User? User { get; set; }
        public static Rating newRating(int movieId, string userId, int value)
        {
            return new Rating
            {
                MovieId = movieId,
                UserId = userId,
                Value = value,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}