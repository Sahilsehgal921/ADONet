using System;
using Test1ConnectedAdo;

namespace Test1ConnectedAdo
{
    public class BAL
    {
        DataAccess dal = new DataAccess();

        public void InsertAddress(Address address)
        {
            dal.InsertAddress(address);
        }

        public void EditAddress(int Address_id, Address address)
        {
            dal.EditAddress(Address_id, address);
        }
        public void DeleteAddress(int Address_id)
        {
             dal.DeleteAddress(Address_id);
        }
        public Address SearchAdress(string First_name)
        {
            return dal.SearchAdress(First_name);
        }
    }
}
