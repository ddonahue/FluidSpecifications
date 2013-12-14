namespace FluidInterace.Specification
{
    public class NotEqualToSpecification<T> : ISpecification<T>
    {
        private readonly object valueToEqual;

        public NotEqualToSpecification(object valueToEqual)
        {
            this.valueToEqual = valueToEqual;
        }

        public bool IsSatisfiedBy(T item)
        {
            return !item.Equals(valueToEqual);
        }
    }
}