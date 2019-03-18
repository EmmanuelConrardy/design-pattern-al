using System;

namespace Strategy
{
    public class InfoMissing
    {
        public virtual bool IsMissingInfo(AddressViewModel address, SiteContext siteContext)
        {
            throw new NotImplementedException();   
        }
    }

    public class InfoMissingStrategy
    {
        public InfoMissing GetInfoMissingBy(SiteContext site)
        {
            throw new NotImplementedException();
        }
    }

    public class InfoMissingOfSpain : InfoMissing
    {
        
    }

    public class InfoMissingOfBelgium : InfoMissing
    {
        
    }
}
