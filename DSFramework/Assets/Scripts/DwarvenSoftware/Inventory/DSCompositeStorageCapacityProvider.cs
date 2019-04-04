using System.Collections.Generic;
using System.Linq;

namespace DwarvenSoftware.Inventory
{
    public class DSCompositeStorageCapacityProvider : IStorageCapacityProvider
    {
        public int Capacity => _providers.Sum(provider => provider.Capacity);

        private readonly List<IStorageCapacityProvider> _providers;

        public DSCompositeStorageCapacityProvider(List<IStorageCapacityProvider> providers = null)
        {
            _providers = providers ?? new List<IStorageCapacityProvider>();
        }
        
        public DSCompositeStorageCapacityProvider(params IStorageCapacityProvider[] providers)
        {
            _providers = providers != null ? new List<IStorageCapacityProvider>(providers) : new List<IStorageCapacityProvider>();
        }
    }
}