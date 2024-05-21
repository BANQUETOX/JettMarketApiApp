using DataAccess.Mappers;
using DTO.Rols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class RolManager
    {
        internal RolMapper mapper = new RolMapper();

        public List<DbRol> GetAllRols()
        {
          return mapper.GetAllRols();
        }

        public DbRol GetRolById(int id) { 
            return mapper.GetRolById(id);
        }
        public void AsingAdminRol(int idUser)
        {
            mapper.AsingAdminRol(idUser);
        }
        public void RemoveAdminRol(int idUser)
        {
            mapper.RemoveAdminRol(idUser);
        }
        public void AsingCustomerRol(int idUser)
        {
            mapper.AsingCustomerRol(idUser);
        }
        public void RemoveCustomerRol(int idUser)
        {
            mapper.RemoveCustomerRol(idUser);
        }
    }
}
