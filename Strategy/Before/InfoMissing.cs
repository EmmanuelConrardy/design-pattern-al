using System;

namespace Strategy.Before
{
    public class InfoMissing
    {
        public bool IsMissingInfo(AddressViewModel address, SiteContext siteContext)
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

    public class InfoMissingOfSpain
    {

    }

    public class InfoMissingOfBelgium
    {

    }
}
