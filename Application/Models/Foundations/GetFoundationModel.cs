using System;
using Domain.Foundation;
using Domain.Location;

namespace Application.Models.Foundations
{
    public class GetFoundationsModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Events { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsVerified { get; set; }
        public Niche  Niche { get; set; }
        public Location Location { get; set; }
    }
}