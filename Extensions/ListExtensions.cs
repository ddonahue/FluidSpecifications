using System.Collections.Generic;
using FluidInterace.Specification;

namespace FluidInterace.Extensions
{
    public static class ListExtensions
    {
        public static List<T> GetOnlyItems<T>(this List<T> itemsToFilter, ISpecification<T> specification)
        {
            var filteredList = new List<T>();
            foreach(T item in itemsToFilter)
            {
                if (specification.IsSatisfiedBy(item))
                {
                    filteredList.Add(item);
                }
            }

            return filteredList;
        }
    }
}