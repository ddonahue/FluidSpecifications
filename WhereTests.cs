using FluidInterace.Domain;
using FluidInterace.FluidInterface;
using FluidInterace.Specification;
using MbUnit.Framework;

namespace FluidInterace
{
    [TestFixture]
    public class WhereTests
    {
        [Test]
        public void ShouldReturnPropertySpecificationFactoryWithCorrectlyInferredTypes()
        {
            Assert.IsInstanceOfType(typeof(PropertySpecificationBuilder<Album,string>),Where<Album>.Has(x => x.Title));
            Assert.IsInstanceOfType(typeof(PropertySpecificationBuilder<Album,int>),Where<Album>.Has(x => x.ReleaseYear));
        }
    }
}