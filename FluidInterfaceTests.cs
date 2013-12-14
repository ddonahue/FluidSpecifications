using System.Collections.Generic;
using FluidInterace.Domain;
using FluidInterace.Extensions;
using FluidInterace.FluidInterface;
using MbUnit.Framework;


namespace FluidInterace
{
    [TestFixture]
    public class FluidInterfaceTests
    {
        private Album greenDayDookie;
        private Album greenDayKerplunk;
        private Album petShopBoysActually;
        private Album theCarsDoorToDoor;
        private Album morbidAngelCovenant;
        private Album earthCrisisDestroyTheMachines;
        private List<Album> allAlbums;

        private List<Album> resultList;

        [SetUp]
        public void SetUp()
        {
            greenDayDookie = new Album("Green Day", "Dookie", 1994, "Pop Punk");
            greenDayKerplunk = new Album("Green Day", "Kerplunk", 1992, "Pop Punk");
            petShopBoysActually = new Album("Pet Shop Boys", "Actually", 1987, "New Wave");
            theCarsDoorToDoor = new Album("The Cars", "Door To Door", 1987, "Rock");
            morbidAngelCovenant = new Album("Morbid Angel", "Covenant", 1993, "Metal");
            earthCrisisDestroyTheMachines = new Album("Earth Crisis", "Destroy The Machines", 1995, "Hardcore");

            allAlbums = new List<Album> { greenDayDookie, greenDayKerplunk, petShopBoysActually, theCarsDoorToDoor, morbidAngelCovenant, earthCrisisDestroyTheMachines};
        }

        [Test]
        public void ShouldOnlyReturnGreenDayAlbums()
        {
            resultList = allAlbums.GetOnlyItems(Where<Album>.Has(x => x.Artist).EqualTo("Green Day"));

            Assert.AreEqual(2, resultList.Count);
            Assert.IsTrue(resultList.Contains(greenDayDookie));
            Assert.IsTrue(resultList.Contains(greenDayKerplunk));
        }

        [Test]
        public void ShouldOnlyReturnGreenDayDookie()
        {
            resultList = allAlbums.GetOnlyItems(Where<Album>.Has(x => x.Artist).EqualTo("Green Day").And(Where<Album>.Has(x => x.ReleaseYear).EqualTo(1994)));

            Assert.AreEqual(1, resultList.Count);
            Assert.IsTrue(resultList.Contains(greenDayDookie));
        }

        [Test]
        public void ShouldOnlyReturnNonGreenDayAlbums()
        {
            resultList = allAlbums.GetOnlyItems(Where<Album>.Has(x => x.Genre).NotEqualTo("Pop Punk"));

            Assert.AreEqual(4, resultList.Count);
            Assert.IsTrue(resultList.Contains(petShopBoysActually));
            Assert.IsTrue(resultList.Contains(theCarsDoorToDoor));
            Assert.IsTrue(resultList.Contains(morbidAngelCovenant));
            Assert.IsTrue(resultList.Contains(earthCrisisDestroyTheMachines));
        }

        [Test]
        public void ShouldOnlyReturnAlbumsFrom1987And1993()
        {
            resultList = allAlbums.GetOnlyItems(Where<Album>.Has(x => x.ReleaseYear).EqualTo(1987).Or(Where<Album>.Has(x => x.ReleaseYear).EqualTo(1993)));

            Assert.AreEqual(3, resultList.Count);
            Assert.IsTrue(resultList.Contains(petShopBoysActually));
            Assert.IsTrue(resultList.Contains(theCarsDoorToDoor));
            Assert.IsTrue(resultList.Contains(morbidAngelCovenant));
        }
    }
}
