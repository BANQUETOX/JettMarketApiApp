using Dapper;
using DataAccess.Dao;
using DTO.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class BillMapper
    {
        internal SqlDao sqlDao = SqlDao.GetInstance();

        public int CreateBill(InputBill bill)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@amount", bill.amount);
            parameters.Add("@idUser", bill.idUser);
            parameters.Add("@paid",bill.paid);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_CREATE_BILL";
            operation.parameters = parameters;
            var createdBillId = sqlDao.QueryProcedure<int>(operation);
            return createdBillId[0];
        }

        public List<DbBill> GetAllBills()
        {
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_BILLS";
            var result = sqlDao.QueryProcedure<DbBill>(operation);
            return result;
        }

        public List<DbBill> GetUserBills(int idUser)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idUser", idUser);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_BILL_USER";
            operation.parameters = parameters;
            var result = sqlDao.QueryProcedure<DbBill>(operation);
            return result;

        }

        public int UpdateBill(DbBill bill)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id",bill.id);
            parameters.Add("@amount", bill.amount);
            parameters.Add("@idUser", bill.idUser);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_UPDATE_BILL";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }
        public int DeleteBill(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id",id);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_DELETE_BILL";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public int AssingProductToBill(int idBill, int idProduct)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idBill",idBill);
            parameters.Add("@idProduct",idProduct);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_ASSING_PRODUCT_BILL";
            operation.parameters = parameters;
            var rowsAffected = sqlDao.ExecuteStoredProcedure(operation);    
            return rowsAffected;
        }

        public int RemoveProductToBill(int idBill, int idProduct)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idBill", idBill);
            parameters.Add("@idProduct", idProduct);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_REMOVE_PRODUCT_BILL";
            operation.parameters = parameters;
            var rowsAffected = sqlDao.ExecuteStoredProcedure(operation);
            return rowsAffected;
        }

        public int PayBill(int idBill)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idBill", idBill);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_PAY_BILL";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }

        public int UnpayBill(int idBill)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idBill", idBill);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_UNPAY_BILL";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }


    }
}
