using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Foundation
{
    public interface IFoundationCollection
    {
        
        Task<List<Foundation>> GetAll(CancellationToken cancellationToken = default);
        Task<Foundation> GetFoundationById(string foundationId, CancellationToken cancellationToken = default);
        Task<Foundation> CreateFoundation(Foundation foundation, CancellationToken cancellationToken = default);
        void UpdateFoundation(string foundationId, Foundation foundation);
        void DeleteFoundationById(string foundationId);
    }
}