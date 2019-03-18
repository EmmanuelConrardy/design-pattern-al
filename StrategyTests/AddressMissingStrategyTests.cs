using NUnit.Framework;
using Strategy;

namespace SomthingsElse
{
    [TestFixture]
    public class AddressMissingStrategyTests
    {
        [Test]
        public void Should_Return_True_When_Address_IsMissing()
        {
            //Arrange
            var address = CompleteAddress();
            address.Address = string.Empty;

            var infoMissing = new InfoMissing();

            //Act
            var result = infoMissing.IsMissingInfo(address, new SiteContext());

            //Assert
            Assert.IsTrue(result);
        }

        private static AddressViewModel CompleteAddress()
        {
            return new AddressViewModel
            {
                Address = "Address",
                Tel = "Tel",
                TaxNumber = "TaxNumber",
                ZipCode = "ZipCode",
                DocumentType = "DocumentType"
            };
        }

        [Test]
        public void Should_Return_True_When_ZipCode_IsMissing()
        {
            //Arrange
            var address = CompleteAddress();
            address.ZipCode = null;

            var infoMissing = new InfoMissing();

            //Act
            var result = infoMissing.IsMissingInfo(address, new SiteContext());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Should_Return_True_When_Tel_IsMissing()
        {
            //Arrange
            var address = CompleteAddress();
            address.Tel = null;

            var infoMissing = new InfoMissing();

            //Act
            var result = infoMissing.IsMissingInfo(address, new SiteContext());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Should_Return_True_When_TaxNumber_IsMissing_And_Site_Culture_Equal_ES()
        {
            //Arrange
            var address = CompleteAddress();
            address.TaxNumber = string.Empty;

            var site = new SiteContext();
            site.Culture = "ES";
            var infoMissingStrategy = new InfoMissingStrategy();
            var infoMissing = infoMissingStrategy.GetInfoMissingBy(site);

            //Act
            var result = infoMissing.IsMissingInfo(address, site);

            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(infoMissing.GetType().Equals(typeof(InfoMissingOfSpain)));
        }

        [Test]
        public void Should_Return_False_When_Tel_Is_Missing_And_Site_Culture_Equals_BE()
        {
            //Arrange
            var address = CompleteAddress();
            address.Tel = "";

            var infoMissing = new InfoMissing();
            var site = new SiteContext();
            site.Culture = "BE";

            //Act
            var result = infoMissing.IsMissingInfo(address, site);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Should_Return_True_When_DocumentType_IsMissing_And_Site_Culture_Equal_ES()
        {
            //Arrange
            var address = CompleteAddress();
            address.DocumentType = "";

            var site = new SiteContext();
            site.Culture = "ES";
            var infoMissingStrategy = new InfoMissingStrategy();
            var infoMissing = infoMissingStrategy.GetInfoMissingBy(site);

            //Act
            var result = infoMissing.IsMissingInfo(address, site);

            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(infoMissing.GetType().Equals(typeof(InfoMissingOfSpain)));

        }

        [TestCase("FR")]
        [TestCase("BE")]
        [Test]
        public void Should_Return_False_When_DocumentType_IsMissing_And_Site_Culture_Equal_(string culture)
        {
            //Arrange
            var address = CompleteAddress();
            address.DocumentType = "";

            var infoMissing = new InfoMissing();
            var site = new SiteContext();
            site.Culture = culture;

            //Act
            var result = infoMissing.IsMissingInfo(address, site);

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase("FR")]
        [TestCase("BE")]
        [Test]
        public void Should_Return_False_When_TaxNumber_IsMissing_And_Site_Culture_Equal_(string culture)
        {
            //Arrange
            var address = CompleteAddress();
            address.TaxNumber = "";

            var infoMissing = new InfoMissing();
            var site = new SiteContext();
            site.Culture = culture;

            //Act
            var result = infoMissing.IsMissingInfo(address, site);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void InfoMissingStrategy_Should_Return_InfoMissingOfSpain()
        {
            //Arrange
            var address = CompleteAddress();
            address.DocumentType = "";

            var infoMissingStrategy = new InfoMissingStrategy();
            var site = new SiteContext();
            site.Culture = "ES";
            var infoMissing = infoMissingStrategy.GetInfoMissingBy(site);

            //Act
            var result = infoMissing.IsMissingInfo(address, site);

            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(infoMissing.GetType().Equals(typeof(InfoMissingOfSpain)));
        }

        [Test]
        public void InfoMissingStrategy_Should_Return_InfoMissingOfBelgium_Tel_Is_Not_Mandatory()
        {
            //Arrange
            var address = CompleteAddress();
            address.Tel = "";

            var infoMissingStrategy = new InfoMissingStrategy();
            var site = new SiteContext();
            site.Culture = "BE";
            var infoMissing = infoMissingStrategy.GetInfoMissingBy(site);

            //Act
            var result = infoMissing.IsMissingInfo(address, site);

            //Assert
            Assert.IsFalse(result);
            Assert.IsTrue(infoMissing.GetType().Equals(typeof(InfoMissingOfBelgium)));
        }

        //TODO
        //Pass test to green
        //Complete the strategy of FR & BE using TDD
    }
}
