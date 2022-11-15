using IndianStateCensusAnayserUC1.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnayserUC1
{
    public class IndianCensusAdaptor:CensusAdapter 
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string ,CensusDTO> LoadCensusData(string csvFilePath,string dataHeader)
        {
            dataMap = new Dictionary<string, CensusDTO>() ;
            censusData = GetCensusData(csvFilePath, dataHeader);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File contain wrong Delemitter", CensusAnalyserException.ExceptionType.INCORRECT_DELMITER);
                }
                string[] colum = data.Split(",");
                if(csvFilePath.Contains("IndianStatecode.csv"))
                {
                    dataMap.Add(colum[1], new CensusDTO(new StateCodeDAO(colum[0], colum[1], colum[2], colum[3])));
                }
                if (csvFilePath.Contains("IndianStatecode.csv"))
                {
                    dataMap.Add(colum[0], new CensusDTO(new CensusDataDAD(colum[0], colum[1], colum[2], colum[3])));
                }              
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
        
    }
}
