using FluidInterace.Extensions;
using FluidInterace.Specification;
using MbUnit.Framework;
using Rhino.Mocks;

namespace FluidInterace
{
    [TestFixture]
    public class SpecificationExtensionTests
    {
        private ISpecification<string> leftSpecification;
        private ISpecification<string> rightSpecification;

        [SetUp]
        public void SetUp()
        {
            leftSpecification = MockRepository.GenerateMock<ISpecification<string>>();
            rightSpecification = MockRepository.GenerateMock<ISpecification<string>>();
        }


        [Test]
        public void AndExtensionShouldReturnAPopulatedAndSpecification()
        {
            ISpecification<string> result = SpecificationExtensions.And(leftSpecification, rightSpecification);
            Assert.IsInstanceOfType(typeof(AndSpecification<string>), result);
        }

        [Test]
        public void OrExtensionShouldReturnAPopulatedOrSpecification()
        {
            ISpecification<string> result = SpecificationExtensions.Or(leftSpecification, rightSpecification);
            Assert.IsInstanceOfType(typeof(OrSpecification<string>), result);
        }
    }
}