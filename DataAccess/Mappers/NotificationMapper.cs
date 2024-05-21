using Dapper;
using DataAccess.Dao;
using DTO.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class NotificationMapper
    {
        internal SqlDao sqlDao = SqlDao.GetInstance();

        public List<DbNotification> GetAll()
        {
            SqlOperation operation =  new SqlOperation();
            operation.procedureName = "SP_GET_NOTIFICATIONS";
            var result = sqlDao.QueryProcedure<DbNotification>(operation);
            return result;
        }

        public List<DbNotification> GetUserNotifications(int userId) {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId",userId);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_GET_NOTIFICATIONS_USER";
            operation.parameters = parameters;
            var result = sqlDao.QueryProcedure<DbNotification>(operation);
            return result;

        }

        public int CreateNotification(NotificationInput notification)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userToId", notification.userToId);
            parameters.Add("@message",notification.message);
            SqlOperation operation = new SqlOperation();
            operation.procedureName = "SP_CREATE_NOTIFICATION";
            operation.parameters = parameters;
            var affectedRows = sqlDao.ExecuteStoredProcedure(operation);
            return affectedRows;
        }
    }
}
