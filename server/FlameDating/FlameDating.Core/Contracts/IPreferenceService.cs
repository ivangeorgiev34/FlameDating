using FlameDating.Infrastructure.Enums;

namespace FlameDating.Core.Contracts
{
    public interface IPreferenceService
    {
        Task<Guid> CreatePreferenceAsync(int maximumDistance, Gender PreferedGender);
    }
}
