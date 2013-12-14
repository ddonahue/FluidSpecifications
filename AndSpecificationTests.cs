using FluidInterace.Specification;
using MbUnit.Framework;
using Rhino.Mocks;

namespace FluidInterace
{
    [TestFixture]
    public class AndSpecificationTests
    {
        private AndSpecification<string> sut;
        private ISpecification<string> leftSpecification;
        private ISpecification<string> rightSpecification;

        [SetUp]
        public void SetUp()
        {
            leftSpecification = MockRepository.GenerateMock<ISpecification<string>>();
            rightSpecification = MockRepository.GenerateMock<ISpecification<string>>();

            sut = new AndSpecification<string>(leftSpecification, rightSpecification);
        }

        [RowTest]
        [Row(true, true, true)]
        [Row(true, false, false)]
        [Row(false, true, false)]
        [Row(false, false, false)]
        public void ShouldReturnCorrectResults(bool leftResult, bool rightResult, bool andResult)
        {
            leftSpecification.Expect(x => x.IsSatisfiedBy(Arg<string>.Is.Anything)).Return(leftResult);
            rightSpecification.Expect(x => x.IsSatisfiedBy(Arg<string>.Is.Anything)).Return(rightResult);

            Assert.AreEqual(sut.IsSatisfiedBy(Arg<string>.Is.Anything), andResult);
        }
    }
}