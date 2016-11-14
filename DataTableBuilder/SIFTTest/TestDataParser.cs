using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Newtonsoft.Json.Linq;namespace SIFTTest
{
    public class TestDataParser
    {

        private JArray testObjectData;

        public TestDataParser(Object toData)
        {
            testObjectData = (JArray)toData;
        }

        public List<Dictionary<string, Object>> GetTestObjectsByType(string objectType)
        {
            var returnObjects = new List<Dictionary<string, Object>>();

            var testObjects = testObjectData
                              .Where(testobject => testobject["test_obj_type"].ToString().Equals(objectType));
                              
            foreach (var testobject in testObjects)
                returnObjects.Add(testobject.ToObject<Dictionary<string, Object>>());

            return returnObjects;
        }


        public Dictionary<string, Object> GetTestObject(string objectType, int index=0)
        {
            var returnObjects = GetTestObjectsByType(objectType);

            return returnObjects[index];
        }

        public string GetParamValue(Dictionary<string, Object> testData, string param)
        {
           JObject parameters =  (JObject)testData["Parameters"];           
           var value = parameters.ToObject<Dictionary<string,string>>();
           if(value.Keys.Contains(param))
               return value[param];

            return null;
        }
    }
}
