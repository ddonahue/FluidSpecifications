namespace FluidInterace.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
    }
}