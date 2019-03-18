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
            if (site.Culture == "ES")
            {
                return new InfoMissingOfSpain();
            }
            else if (site.Culture == "BE")
            {
                return new InfoMissingOfBelgium();
            }
            else
            {
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
