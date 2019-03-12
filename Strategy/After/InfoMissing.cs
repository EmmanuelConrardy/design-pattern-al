using System;

namespace Strategy
{
    public class InfoMissing
    {
        public virtual bool IsMissingInfo(AddressViewModel address, SiteContext siteContext)
        {
            if (string.IsNullOrEmpty(address.Address))
                return true;

            if (string.IsNullOrEmpty(address.ZipCode))
                return true;

            var telMissing = IsTelMissing(address, siteContext);
            if (telMissing)
                return true;

            return false;
        }

        protected virtual bool IsTelMissing(AddressViewModel address, SiteContext siteContext)
        {
            return string.IsNullOrEmpty(address.Tel) && siteContext.Culture != "BE";
        }
    }

    public class InfoMissingStrategy
    {
        public InfoMissing GetInfoMissingBy(SiteContext site)
        {
            switch (site.Culture)
            {
                case "ES":
                    return new InfoMissingOfSpain();
                case "BE":
                    return new InfoMissingOfBelgium();
                default:
                    return new InfoMissing();
            }
        }
    }

    public class InfoMissingOfSpain : InfoMissing
    {
        public override bool IsMissingInfo(AddressViewModel address, SiteContext siteContext)
        {
            if (string.IsNullOrEmpty(address.DocumentType))
                return true;

            if (string.IsNullOrEmpty(address.TaxNumber))
                return true;

            return base.IsMissingInfo(address, siteContext);
        }
    }

    public class InfoMissingOfBelgium : InfoMissing
    {
        public override bool IsMissingInfo(AddressViewModel address, SiteContext siteContext)
        {
            return base.IsMissingInfo(address, siteContext);
        }

        protected override bool IsTelMissing(AddressViewModel address, SiteContext siteContext)
        {
            return false;
        }
    }
}
