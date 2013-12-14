using FluidInterace.Domain;
using FluidInterace.Specification;
using MbUnit.Framework;


namespace FluidInterace
{
    [TestFixture]
    public class PropertySpecificationBuilderTests
    {
        private PropertySpecificationBuilder<Album,string> sut;

        [SetUp]
        public void SetUp()
        {
            sut = new PropertySpecificationBuilder<Album, string>(x => x.Artist);
        }

        [Test]
        public void EqualToShouldReturnAPropertySpecification()
        {
            Assert.IsInstanceOfType(typeof(PropertySpecification<Album, string>), sut.EqualTo("someString"));
        }

        [Test]
        public void NotEqualToShouldReturnAPropertySpecification()
        {
            Assert.IsInstanceOfType(typeof(PropertySpecification<Album, string>), sut.NotEqualTo("someString"));
        }
    }
}