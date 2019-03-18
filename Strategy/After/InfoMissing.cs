using System;

namespace Strategy
{
    public class InfoMissing
    {
        public virtual Boolean IsMissingInfo(AddressViewModel address, SiteContext siteContext)
        {
            if (address.Address.Equals("") || address.ZipCode == null ||
                address.Tel == null)
            {
                return (true);
            }
            return (false);
        }
    }

    public class InfoMissingStrategy
    {
        public InfoMissing GetInfoMissingBy(SiteContext siteContext)
        {
            if(siteContext.Culture == "ES")
            {
                return (new InfoMissingOfSpain());
            }else if(siteContext.Culture == "BE")
            {
                return (new InfoMissingOfBelgium());
            }
            return (new InfoMissing());
        }
    }

    public class InfoMissingOfSpain : InfoMissing
    {
        public override bool IsMissingInfo(AddressViewModel address, SiteContext siteContext)
        {
            if (address.TaxNumber.Equals("") || address.DocumentType == "")
            {
                return (true);
            }
            return (false);
        }
    }

    public class InfoMissingOfBelgium : InfoMissing
    {
        public override bool IsMissingInfo(AddressViewModel address, SiteContext siteContext)
        {
            if (address.Tel == "")
            {
                return (false);
            }
            return (false);
        }
    }
}
