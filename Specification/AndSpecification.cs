namespace FluidInterace.Specification
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> leftSpecification;
        private readonly ISpecification<T> rightSpecification;

        public AndSpecification(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
        {
            this.leftSpecification = leftSpecification;
            this.rightSpecification = rightSpecification;
        }

        public bool IsSatisfiedBy(T item)
        {
            return leftSpecification.IsSatisfiedBy(item) && rightSpecification.IsSatisfiedBy(item);
        }
    }
}