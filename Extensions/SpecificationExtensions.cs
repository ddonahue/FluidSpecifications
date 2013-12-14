using FluidInterace.Specification;

namespace FluidInterace.Extensions
{
    public static class SpecificationExtensions
    {
        public static ISpecification<T> And<T>(this ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
        {
            return new AndSpecification<T>(leftSpecification, rightSpecification);
        }

        public static ISpecification<T> Or<T>(this ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
        {
            return new OrSpecification<T>(leftSpecification, rightSpecification);
        }
    }
}