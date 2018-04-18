using eLearning.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DataAccess
{
   public class DAStock :DABase
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "DAStock";

        string QRY_ADD_STOCK = @"INSERT INTO STOCK(NAME,STOCK_TYPE,QUANTITY,CREATED_ON)
                                VALUES('{0}',{1},{2},GETDATE())";

        string QRY_CHECK_STOCK_EXIST = @"SELECT COUNT(*) FROM STOCK WHERE NAME ='{0}'";


        public bool CheckStockExist(string Stockname)
        {
            string query = string.Format(QRY_CHECK_STOCK_EXIST, Stockname);
            int count = (int)ExecuteScalar(query);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void AddStock(DataTable dt)
        {
            try
            {
                string query = string.Format(QRY_ADD_STOCK, dt.Rows[0]["NAME"].ToString(),
                                                           dt.Rows[0]["STOCK_TYPE"].ToString(),
                                                           dt.Rows[0]["QUANTITY"].ToString());
                ExecuteNonQuery(query);
            }
            catch(Exception ex)
            {
                logger.Error(MODULE_NAME, "AddStock", ex);
            }
        }


    }
}
