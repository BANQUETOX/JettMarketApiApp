using AppLogic;
using DTO.Bills;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JettMarketApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        internal BillManager manager = new BillManager();

        [HttpPost]
        public IActionResult CreateBill(InputBill bill)
        {
            try
            {
                int billCreatedId = manager.CreateBill(bill);
                return Ok(billCreatedId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AssingProductToBill(int idBill, int idProduct, int productsAmount)
        {
            try
            {
                manager.AssingProductToBill(idBill, idProduct);
                return Ok("Product asigned to bill successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult RemoveProductFromBill(int idBill, int idProduct)
        {
            try
            {
                manager.RemoveProductFromBill(idBill, idProduct);
                return Ok("Product removed from bill successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PayBill(int billId)
        {
            try
            {
                manager.PayBill(billId);
                return Ok("Bill paid successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult UnpayBill(int billId)
        {
            try
            {
                manager.UnpayBill(billId);
                return Ok("Bill paid cancelled successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetAllBills()
        {
            try
            {
                var result = manager.GetAllBills();
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetUserBills(int idUser)
        {
            try
            {
                var result = manager.GetUserBills(idUser);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult UpdateBill(DbBill bill)
        {
            try
            {
                manager.UpdateBill(bill);
                return Ok("Bill updated successfully");
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult DeleteBill(int idBill)
        {
            try
            {
                manager.DeleteBill(idBill);
                return Ok("Bill deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        

    }

}
