using System;

namespace Strategy
{
    public class InfoMissing
    {
        public virtual bool IsMissingInfo(AddressViewModel address, SiteContext siteContext)
        {
            {
                if (string.IsNullOrEmpty(address.Address) ||
                    string.IsNullOrEmpty(address.ZipCode) ||
                    IsTelMissing(address, siteContext) )
                {   
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
        }

        protected virtual bool IsTelMissing(AddressViewModel address, SiteContext siteContext)
        {
            if (string.IsNullOrEmpty(address.Tel) && siteContext.Culture != "BE")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class InfoMissingStrategy
    {
        public InfoMissing GetInfoMissingBy(SiteContext site)
        {

        }
    }

    public class InfoMissingOfSpain : InfoMissing
    {
        public override bool IsMissingInfo(AddressViewModel address, SiteContext siteContext)
        {

    }

    public class InfoMissingOfBelgium : InfoMissing
    {
        public override bool IsMissingInfo(AddressViewModel address, SiteContext siteContext)
        {
        }

        protected override bool IsTelMissing(AddressViewModel address, SiteContext siteContext)
        {
                return string.IsNullOrEmpty(address.Tel);
        }
    }
}
