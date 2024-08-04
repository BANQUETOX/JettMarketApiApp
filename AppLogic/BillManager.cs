using Azure.Core;
using DataAccess.Mappers;
using DTO.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class BillManager
    {

        internal BillMapper mapper = new BillMapper();

        public int CreateBill(InputBill bill) {
            return mapper.CreateBill(bill);
        }

        public List<DbBill> GetAllBills()
        {
            return mapper.GetAllBills();
        }

        public List<DbBill> GetUserBills(int idUser)
        {
            return mapper.GetUserBills(idUser);
        }

        public void UpdateBill(DbBill bill)
        {
            mapper.UpdateBill(bill);
        }
        public void DeleteBill(int id)
        {
            mapper.DeleteBill(id);
        }

        public void AssingProductToBill(int idBill, int idProduct)
        {
            mapper.AssingProductToBill(idBill, idProduct);
        }

        public void RemoveProductFromBill(int idBill, int idProduct)
        {
            mapper.RemoveProductToBill(idBill, idProduct);
        }

        public void PayBill(int idBill) { mapper.PayBill(idBill); }
        public void UnpayBill (int idBill) { mapper.UnpayBill(idBill); }
    }
}
