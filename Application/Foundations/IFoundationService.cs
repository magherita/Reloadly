using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Models.Foundations;

namespace Application.Foundations
{
    public interface IFoundationService
    {
        
        Task<List<GetFoundationsModel>> GetFoundations(CancellationToken cancellationToken = default);

        Task<GetFoundationsModel> GetFoundationById(string foundationId, CancellationToken cancellationToken = default);

        Task<GetFoundationsModel> CreateFoundation(AddFoundationModel model, CancellationToken cancellationToken = default);

        void UpdateFoundation(string foundationId, UpdateFoundationModel model);

        void DeleteFoundationById(DeleteFoundationModel model);
    }
}