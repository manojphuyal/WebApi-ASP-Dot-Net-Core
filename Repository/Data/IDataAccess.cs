using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface IDataAccess
    {
        string GetConnectionString();
        int GetCommandTimeOut();
        DataSet ExecuteDataset(string sql);  //This is for more than one table
        //DataSet ExecuteDatasetAsync(string sql);  //This is for more than one table
        DataTable ExecuteDataTable(string sql); //This is for List of Data
        DataRow ExecuteDataRow(string sql); //This is for one data
        //DataRow ExecuteDataRowAsync(string sql); //This is for one data
        string FilterString(string strVal);
        string FilterXmlString(string strVal);
        string FilterXmlNodeString(string strVal);
        string FilterQuoteOnly(string strVal);
        string FilterQuote(string strVal);
        string ParseQuote(string val);
    }
}
