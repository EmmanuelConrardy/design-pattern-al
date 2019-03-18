using System;

namespace Strategy
{
    public class InfoMissing
    {
        public virtual bool IsMissingInfo(AddressViewModel address, SiteContext siteContext)
        {
            {
                if (string.IsNullOrEmpty(address.Address) ||
                    string.IsNullOrEmpty(address.ZipCode) ||   )
                {   
                    return true;
                }

                var telMissing = IsTelMissing(address, siteContext);
                if (telMissing)
                    return true;

                return false;
            }
        }

        protected virtual bool IsTelMissing(AddressViewModel address, SiteContext siteContext)
        {
            if (string.IsNullOrEmpty(address.Tel))
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
