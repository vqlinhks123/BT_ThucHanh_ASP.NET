using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuQuangLinh_BT_Buoi10.DataObject;

namespace VuQuangLinh_BT_Buoi10.Interfaces
{
    public interface ICustomer
    {
        void Add(Customer customer);
        void Remove(int Identity);
        void ModifyCustomerInfo();
    }
}
