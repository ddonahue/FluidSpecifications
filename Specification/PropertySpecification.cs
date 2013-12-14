using System;

namespace FluidInterace.Specification
{
    public class PropertySpecification<ItemToFilter, PropertyToFilterOn> : ISpecification<ItemToFilter>
    {
        private readonly Func<ItemToFilter, PropertyToFilterOn> propertyAccessor;
        private readonly ISpecification<PropertyToFilterOn> specification;

        public PropertySpecification(Func<ItemToFilter, PropertyToFilterOn> propertyAccessor, ISpecification<PropertyToFilterOn> specification)
        {
            this.propertyAccessor = propertyAccessor;
            this.specification = specification;
        }

        public bool IsSatisfiedBy(ItemToFilter item)
        {
            return specification.IsSatisfiedBy(propertyAccessor(item));
        }
    }
}