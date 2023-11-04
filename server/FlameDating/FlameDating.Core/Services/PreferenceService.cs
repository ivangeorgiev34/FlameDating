using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Common;
using FlameDating.Infrastructure.Enums;
using FlameDating.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlameDating.Core.Services
{
    public class PreferenceService : IPreferenceService
    {
        private readonly IRepository repo;

        public PreferenceService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<Guid> CreatePreferenceAsync(int maximumDistance, Gender PreferedGender)
        {
            var preference = new Preference()
            {
                Gender = PreferedGender,
                MaximumDistance = maximumDistance
            };

            await repo.AddAsync(preference);
            await repo.SaveChangesAsync();

            return preference.Id;
        }

        public async Task EditPreferenceByIdAsync(Guid id, int maximumDistance, Gender PreferedGender)
        {
            var preference = await GetPreferenceByIdAsync(id);

            if (preference == null)
            {
                throw new NullReferenceException("Preference does not exist");
            }

            preference.MaximumDistance = maximumDistance;
            preference.Gender = PreferedGender;

            await repo.SaveChangesAsync();
        }

        public async Task<Preference?> GetPreferenceByIdAsync(Guid id)
        {
            var preference = await repo.All<Preference>()
                .FirstOrDefaultAsync(p => p.Id == id);

            return preference;
        }

        public async Task<bool> PreferenceExistsByIdAsync(Guid id)
        {
            var preferenceExists = await repo.AllReadonly<Preference>()
                .AnyAsync(p => p.Id == id);

            return preferenceExists;
        }
    }
}
