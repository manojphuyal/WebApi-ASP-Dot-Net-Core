using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _configuration;

        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration["DataAccess:ConnectionString"];
        }

        public int GetCommandTimeOut()
        {
            int cto = 0;
            try
            {
                int.TryParse(_configuration["DataAccess:CommandTimeOut"], out cto);
                if (cto == 0)
                    cto = 30;
            }
            catch (Exception)
            {
                cto = 30;
            }
            return cto;
        }

        public DataSet ExecuteDataset(string sql)
        {
            var ds = new DataSet();
            using (var con = new SqlConnection(GetConnectionString()))
            {
                var cmd = new SqlCommand(sql, con);
                cmd.CommandTimeout = GetCommandTimeOut();
                SqlDataAdapter da;
                try
                {
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    da.Dispose();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    da = null;
                    cmd.Dispose();
                }
                return ds;
            }
        }

        public async Task<DataSet> ExecuteDatasetAsync(string sql)
        {
            var ds = new DataSet();
            using (var con = new SqlConnection(GetConnectionString()))
            {
                var cmd = new SqlCommand(sql, con);
                cmd.CommandTimeout = GetCommandTimeOut();
                SqlDataAdapter da;
                try
                {
                    da = new SqlDataAdapter(cmd);
                    await Task.Run(() => { da.Fill(ds); });
                    da.Dispose();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    da = null;
                    cmd.Dispose();
                }
                return ds;
            }
        }
        public DataTable ExecuteDataTable(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                return ds.Tables[0];
            }
        }

        public DataRow ExecuteDataRow(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                return ds.Tables[0].Rows[0];
            }
        }
        public async Task<DataRow> ExecuteDataRowAsync(string sql)
        {
            using (var ds =await ExecuteDatasetAsync(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                return ds.Tables[0].Rows[0];
            }
        }

        public string FilterString(string strVal)
        {
            var str = FilterQuote(strVal);

            if (str.ToLower() != "null")
                str = "'" + str + "'";

            return str;
        }

        public string FilterXmlString(string strVal)
        {
            return "'" + strVal + "'";
        }

        public string FilterXmlNodeString(string strVal)
        {
            var str = FilterQuote(strVal);

            if (str.ToLower() == "null")
            {
                str = "";
            }

            return str;
        }

        public string FilterQuoteOnly(string strVal)
        {
            if (string.IsNullOrEmpty(strVal))
            {
                strVal = "''";
            }
            else
            {
                strVal = string.Format("'{0}'", strVal);
            }

            return strVal;
        }

        public string FilterQuote(string strVal)
        {
            if (string.IsNullOrEmpty(strVal))
            {
                strVal = "";
            }
            var str = strVal.Trim();

            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace(";", "");
                //str = str.Replace(",", "");
                str = str.Replace("--", "");
                str = str.Replace("'", "");

                str = str.Replace("/*", "");
                str = str.Replace("*/", "");

                str = Regex.Replace(str, " select ", string.Empty, RegexOptions.IgnoreCase);
                str = Regex.Replace(str, " insert ", string.Empty, RegexOptions.IgnoreCase);
                str = Regex.Replace(str, " update ", string.Empty, RegexOptions.IgnoreCase);
                str = Regex.Replace(str, " delete ", string.Empty, RegexOptions.IgnoreCase);
                str = Regex.Replace(str, " drop ", string.Empty, RegexOptions.IgnoreCase);
                str = Regex.Replace(str, " truncate ", string.Empty, RegexOptions.IgnoreCase);
                str = Regex.Replace(str, " create ", string.Empty, RegexOptions.IgnoreCase);
                str = Regex.Replace(str, " begin ", string.Empty, RegexOptions.IgnoreCase);
                str = Regex.Replace(str, " end ", string.Empty, RegexOptions.IgnoreCase);
                str = Regex.Replace(str, " char ", string.Empty, RegexOptions.IgnoreCase);
                str = Regex.Replace(str, " exec ", string.Empty, RegexOptions.IgnoreCase);
                str = Regex.Replace(str, " xp_cmd ", string.Empty, RegexOptions.IgnoreCase);

                str = Regex.Replace(str, @"<.*?>", string.Empty);

            }
            else
            {
                str = "null";
            }
            return str;
        }

        public string ParseQuote(string val)
        {
            return "\"" + val + "\"";
        }

        DataSet IDataAccess.ExecuteDataset(string sql)
        {
            var ds = new DataSet();
            using (var con = new SqlConnection(GetConnectionString()))
            {
                var cmd = new SqlCommand(sql, con);
                cmd.CommandTimeout = GetCommandTimeOut();
                SqlDataAdapter da;
                try
                {
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    da.Dispose();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    da = null;
                    cmd.Dispose();
                }
                return ds;
            }
        }


        DataTable IDataAccess.ExecuteDataTable(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                return ds.Tables[0];
            }
        }

        DataRow IDataAccess.ExecuteDataRow(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                return ds.Tables[0].Rows[0];
            }
        }
    }
}
