using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnayserUC1
{
    public abstract  class CensusAdapter
    {
        string[] censusData;
        protected string[] GetCensusData(string csvFilePath,string dataHeader)
        {
           // string[] censusData;
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File not Found", CensusAnalyserException.ExceptionType.FULE_NOT_FOUND);
            }
            if(Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalide file type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            if (censusData[0]!=dataHeader)
            {
                throw new CensusAnalyserException("Incorrecct header in data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}
