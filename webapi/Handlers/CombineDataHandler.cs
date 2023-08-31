/*This handler combined multiple data from oracle and mongoDB
 * 1. import for vas for today (one number)
 * 2. startWip for vas for today (one number)
 * 3. done for vas for today (one number)
 
 */

using webapi.DataAccess;

public class CombineDataHandler
{
    private readonly DataAccess _dataAccess;
    private readonly ExcelDataReader _excelDataReader;
    private readonly MongoDataAccess _mongoDataAccess;

    public CombineDataHandler(DataAccess dataAccess, ExcelDataReader excelDataReader, MongoDataAccess mongoDataAccess)
    {
        _dataAccess = dataAccess;
        _excelDataReader = excelDataReader;
        _mongoDataAccess = mongoDataAccess;
    }

    public CombineDataModel GetCombinedData()
    {
        var import = _dataAccess.VasImport().Sum(item => item.QTY);
        var startWip = _excelDataReader.GetFilteredNumber();
        var done = _dataAccess.GetBarVas().Sum(item => item.QTY);
        var latestEndWipValue = _mongoDataAccess.GetLastSavedEndWip();

        return new CombineDataModel
        {
            Import = import,
            StartWip = startWip,
            Done = done,
            EndWipLatest = latestEndWipValue 
        };
    }
}
