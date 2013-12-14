using System.Collections.Generic;
using FluidInterace.Domain;
using FluidInterace.Extensions;
using FluidInterace.Specification;
using MbUnit.Framework;
using Rhino.Mocks;

namespace FluidInterace
{
    [TestFixture]
    public class ListExtensionsTests
    {
        private Album greenDayDookie;
        private Album greenDayKerplunk;
        private Album petShopBoysActually;
        private Album theCarsDoorToDoor;
        private List<Album> allAlbums;

        private List<Album> resultList;
        private ISpecification<Album> specification;

        [SetUp]
        public void SetUp()
        {
            specification = MockRepository.GenerateMock<ISpecification<Album>>();

            greenDayDookie = new Album("Green Day", "Dookie", 1994, "Pop Punk");
            greenDayKerplunk = new Album("Green Day", "Kerplunk", 1992, "Pop Punk");
            petShopBoysActually = new Album("Pet Shop Boys", "Actually", 1987, "New Wave");
            theCarsDoorToDoor = new Album("The Cars", "Door To Door", 1987, "Rock");
            
            allAlbums = new List<Album> { greenDayDookie, greenDayKerplunk, petShopBoysActually, theCarsDoorToDoor };

            specification.Expect(x => x.IsSatisfiedBy(greenDayDookie)).Return(true);
            specification.Expect(x => x.IsSatisfiedBy(greenDayKerplunk)).Return(true);
            specification.Expect(x => x.IsSatisfiedBy(petShopBoysActually)).Return(false);
            specification.Expect(x => x.IsSatisfiedBy(theCarsDoorToDoor)).Return(false);

            resultList = ListExtensions.GetOnlyItems(allAlbums, specification);
        }

        [Test]
        public void ShouldReturnFilteredListWithOnlyItemsThatSatisfySpecification()
        {
            Assert.AreEqual(2, resultList.Count);   
            Assert.IsTrue(resultList.Contains(greenDayDookie));
            Assert.IsTrue(resultList.Contains(greenDayKerplunk));
        }
    }
}