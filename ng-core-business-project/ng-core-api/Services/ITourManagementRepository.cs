using System.Collections.Generic;
using System.Threading.Tasks;
using ng_core_api.Entities;

namespace ng_core_api.Services
{
    public interface ITourManagementRepository {
        Task<IEnumerable<Band>> GetBands();
        Task<IEnumerable<Manager>> GetManagers();
        Task<IEnumerable<Tour>> GetTours();
        Task<Tour> GetTour(string tourId);
    }
}