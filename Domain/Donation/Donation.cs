using System;

namespace Domain.Donation
{
    public class Donation
    {
        public Guid Id { get; set; }
        public string Amount { get; set; }
        public Guid UserId { get; set; }
    }
}