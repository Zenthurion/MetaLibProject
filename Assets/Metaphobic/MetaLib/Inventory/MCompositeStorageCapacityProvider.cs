using System.Collections.Generic;
using System.Linq;

namespace MetaLib.Inventory
{
    public class MCompositeStorageCapacityProvider : IStorageCapacityProvider
    {
        public int Capacity => _providers.Sum(provider => provider.Capacity);

        private readonly List<IStorageCapacityProvider> _providers;

        public MCompositeStorageCapacityProvider(List<IStorageCapacityProvider> providers = null)
        {
            _providers = providers ?? new List<IStorageCapacityProvider>();
        }
        
        public MCompositeStorageCapacityProvider(params IStorageCapacityProvider[] providers)
        {
            _providers = providers != null ? new List<IStorageCapacityProvider>(providers) : new List<IStorageCapacityProvider>();
        }
    }
}