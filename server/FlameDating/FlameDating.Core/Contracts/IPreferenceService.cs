using FlameDating.Infrastructure.Enums;
using FlameDating.Infrastructure.Models;

namespace FlameDating.Core.Contracts
{
    public interface IPreferenceService
    {
        Task<Guid> CreatePreferenceAsync(int maximumDistance, Gender PreferedGender);

        Task<Preference?> GetPreferenceByIdAsync(Guid id);

        Task<bool> PreferenceExistsByIdAsync(Guid id);

        Task EditPreferenceByIdAsync(Guid id, int maximumDistance, Gender PreferedGender);
    }
}
