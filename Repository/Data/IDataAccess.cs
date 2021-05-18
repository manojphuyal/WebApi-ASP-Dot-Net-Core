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
        DataSet ExecuteDataset(string sql);  
        DataTable ExecuteDataTable(string sql); 
        DataRow ExecuteDataRow(string sql);
        string FilterString(string strVal);
        string FilterXmlString(string strVal);
        string FilterXmlNodeString(string strVal);
        string FilterQuoteOnly(string strVal);
        string FilterQuote(string strVal);
        string ParseQuote(string val);
    }
}
