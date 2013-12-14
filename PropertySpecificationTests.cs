using FluidInterace.Domain;
using FluidInterace.Specification;
using MbUnit.Framework;
using Rhino.Mocks;

namespace FluidInterace
{
    [TestFixture]
    public class PropertySpecificationTests
    {
        private PropertySpecification<Album,string> sut;

        private ISpecification<string> specification;
        private Album testAlbum;

        [SetUp]
        public void SetUp()
        {
            specification = MockRepository.GenerateMock<ISpecification<string>>();

            testAlbum = new Album("Depeche Mode", "Violator", 1991, "New Wave");
            sut = new PropertySpecification<Album, string>(x => x.Artist, specification);
        }

        [RowTest]
        [Row("Depeche Mode", true)]
        [Row("Behemoth", false)]
        public void ItWorks(string artist, bool result)
        {
            specification.Expect(x => x.IsSatisfiedBy(artist)).Return(result);
            Assert.AreEqual(sut.IsSatisfiedBy(testAlbum), result);
        }
    }
}