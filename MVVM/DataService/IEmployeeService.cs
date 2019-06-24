using DataContract;
using System.Collections.Generic;
using System.ServiceModel;

namespace DataService
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        List<Employee> Get();
    }
}
