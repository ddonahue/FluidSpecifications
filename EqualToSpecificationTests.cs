using FluidInterace.Domain;
using FluidInterace.Specification;
using MbUnit.Framework;

namespace FluidInterace
{
    [TestFixture]
    public class EqualToSpecificationTests
    {
        private EqualToSpecification<string> sut;
        private Album testAlbum;

        [SetUp]
        public void SetUp()
        {
            testAlbum = new Album("Depeche Mode", "Violator", 1991, "New Wave");
        }
        
        [RowTest]
        [Row("Depeche Mode", true)]
        [Row("Behemoth", false)]
        public void ItWorks(string artist, bool result)
        {
            sut = new EqualToSpecification<string>(artist);
            Assert.AreEqual(sut.IsSatisfiedBy(testAlbum.Artist), result);
        }
    }
}