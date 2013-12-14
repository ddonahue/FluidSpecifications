using System;

namespace FluidInterace.Specification
{
    public class PropertySpecificationBuilder<ItemToFilter, PropertyToFilterOn>
    {
        private readonly Func<ItemToFilter, PropertyToFilterOn> propertyAccessor;

        public PropertySpecificationBuilder(Func<ItemToFilter, PropertyToFilterOn> propertyAccessor)
        {
            this.propertyAccessor = propertyAccessor;
        }

        public ISpecification<ItemToFilter> EqualTo(object valueToEqual)
        {
            return new PropertySpecification<ItemToFilter, PropertyToFilterOn>(propertyAccessor, new EqualToSpecification<PropertyToFilterOn>(valueToEqual));
        }

        public ISpecification<ItemToFilter> NotEqualTo(object valueToEqual)
        {
            return new PropertySpecification<ItemToFilter, PropertyToFilterOn>(propertyAccessor, new NotEqualToSpecification<PropertyToFilterOn>(valueToEqual));
        }
    }
}