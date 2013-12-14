using System;
using FluidInterace.Specification;

namespace FluidInterace.FluidInterface
{
    public static class Where<ItemToFilter>
    {
        public static PropertySpecificationBuilder<ItemToFilter, PropertyToFilterOn> Has<PropertyToFilterOn>(Func<ItemToFilter, PropertyToFilterOn> propertyAccessor)
        {
            return new PropertySpecificationBuilder<ItemToFilter, PropertyToFilterOn>(propertyAccessor);
        }
    }
}