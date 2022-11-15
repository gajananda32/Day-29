using IndianStateCensusAnayserUC1.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnayserUC1
{
    public class CSVAdapterFactory
    {
        public Dictionary<string,CensusDTO> LoadCsvData(CensusAnalyser.Country country,string csvFilePath,string dataHeader)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdaptor().LoadCensusData(csvFilePath, dataHeader);
                //case (CensusAnalyser.Country.US):
                //    return new USCensusAdapter().LoadCensusData(csvFilePath, dataHeader);
                default :
                    throw new CensusAnalyserException("No such country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
