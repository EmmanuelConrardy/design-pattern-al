using System;
using System.Collections.Generic;
using Xunit;

namespace Adapter
{
    public class DataConverter
    {
        #region Without Design
        private ApiLegacyV1 _ApiLegacyV1 = new ApiLegacyV1();

        [Fact]
        public void Use_Adapter_Camel_To_Pascal_Design()
        {
            //Get data with old Api return message with "camelCase" format
            //It is used in a ot of projet ! We can't change it like this.
            var datas = _ApiLegacyV1.GetData();
            
            //We need to return the same data but with "PascalCase" format
            //So we convert datas
            var newData = new List<string>();
            foreach (var data in datas)
            {
                char[] a = data.ToCharArray();
                a[0] = char.ToUpper(a[0]);

                newData.Add(new string(a));
            }

            //update it ! Job done.
            datas = newData;

            //... code continue

            //Datas is now with PascalCase data but what about this code
            //he is defintly not in the good place in the middle of crappy legacy code
            //change can be hard and test difficult depend of code around
            //See with design to see how we can solve this and refactor this class

        }
    }
    public class ApiLegacyV1
    {
            public List<string> GetData() =>  new List<string>() { "cityOfStar", "toxiCity", "skyIsOver"};
    }
    #endregion

    #region With Design
    //Todo
    #endregion 
}
