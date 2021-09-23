using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models.Foundations;
using Domain.Foundation;

namespace Application.Foundations
{
    public class FoundationService : IFoundationService
    {
        private readonly IFoundationCollection _foundationCollection;

        public FoundationService(IFoundationCollection foundationCollection)
        {
            _foundationCollection = foundationCollection;
        }
        public async Task<List<GetFoundationsModel>> GetFoundations(CancellationToken cancellationToken = default)
        {
            var results = await _foundationCollection.GetAll(cancellationToken);
            if (results == null || results.Count < 1)
            {
                return new List<GetFoundationsModel>();
            }

            var response = new List<GetFoundationsModel>();
            foreach (var result in results)
            {
                var model = new GetFoundationsModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    Events = result.Events,
                    Niche = result.Niche,
                    Location = result.Location
                };

                response.Add(model);
            }
            return response;
        }

        public async Task<GetFoundationsModel> GetFoundationById(string foundationId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(foundationId))
            {
                throw new Exception("Foundation Id is empty");
            }

            var result = await _foundationCollection.GetFoundationById(foundationId, cancellationToken);
            
            if (result == null)
            {
                return new GetFoundationsModel();
            }

            var response = new GetFoundationsModel()
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Events = result.Events,
                Niche = result.Niche,
                Location = result.Location
            };
            
            return response;
        }

        public async Task<GetFoundationsModel> CreateFoundation(AddFoundationModel model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new Exception("Foundation details are empty");
            }

            var foundation = new Foundation()
            {
                Title = model.Title,
                Description = model.Description,
                Events = model.Events,
                Niche = model.Niche,
                Location = model.Location
            };
            var result = await _foundationCollection.CreateFoundation(foundation, cancellationToken);
            var response = new GetFoundationsModel()
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Events = result.Events,
                Niche = result.Niche,
                Location = result.Location
            };
            return response;
        }

        public void UpdateFoundation(string foundationId, UpdateFoundationModel model)
        {
            if (string.IsNullOrWhiteSpace(foundationId))
            {
                throw new Exception("Foundation Id is empty");
            }
            if (model == null)
            {
                throw new Exception("Foundation Id is empty");
            }
            var currentFoundation = _foundationCollection.GetFoundationById(foundationId).Result;

            if (currentFoundation == null)
            {
                throw new Exception("Book does not exist");
            }
            
            currentFoundation.Title = model.Title;
            currentFoundation.Description = model.Description;
            currentFoundation.Events = model.Events;
            currentFoundation.Niche = model.Niche;
            currentFoundation.IsVerified = model.IsVerified;

            _foundationCollection.UpdateFoundation(foundationId, currentFoundation);
        }

        public void DeleteFoundationById(DeleteFoundationModel model)
        {
            if (model == null)
            {
                throw new Exception("Foundation Id is empty");
            }

            _foundationCollection.DeleteFoundationById(model.Id);
        }
    }
}