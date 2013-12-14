namespace FluidInterace.Specification
{
    public class EqualToSpecification<T> : ISpecification<T>
    {
        private readonly object valueToEqual;

        public EqualToSpecification(object valueToEqual)
        {
            this.valueToEqual = valueToEqual;
        }

        public bool IsSatisfiedBy(T item)
        {
            return item.Equals(valueToEqual);
        }
    }
}