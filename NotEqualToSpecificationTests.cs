using FluidInterace.Domain;
using FluidInterace.Specification;
using MbUnit.Framework;


namespace FluidInterace
{
    [TestFixture]
    public class NotEqualToSpecificationTests
    {
        private NotEqualToSpecification<string> sut;
        private Album testAlbum;

        [SetUp]
        public void SetUp()
        {
            testAlbum = new Album("Depeche Mode", "Violator", 1991, "New Wave");
        }

        [RowTest]
        [Row("Depeche Mode", false)]
        [Row("Behemoth", true)]
        public void ItWorks(string artist, bool result)
        {
            sut = new NotEqualToSpecification<string>(artist);
            Assert.AreEqual(sut.IsSatisfiedBy(testAlbum.Artist), result);
        }
    }
}