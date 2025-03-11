using Bookify.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Review
{
    public sealed class Review:Entity
    {
        private Review(Guid id,
                        Guid apartmentId,
                        Guid bookingId,
                        Guid userId,
                        int rating,
                        string comment,
                        DateTime createdOnUtc) : base(id)
        {
            ApartmentId = apartmentId;
            BookingId = bookingId;
            UserId = userId;
            Rating = rating;
            Comment = comment;
            CreatedOnUtc = createdOnUtc;
        }
        public Guid ApartmentId { get; private set; }
        public Guid BookingId { get; private set; }
        public Guid UserId { get; private set; }
        public int Rating { get; private set; }
        public string Comment { get; private set; }
        public DateTime CreatedOnUtc { get; private set; }
    }
}
