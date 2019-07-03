using System.Collections.Generic;
using System.Threading.Tasks;
using MVVM.Demo3.EmployeeServiceReference;
using DataContract;

namespace MVVM.Demo3
{
    public class EmployeeDataSourse : IEmployeeDataSourse
    {
        public async Task<List<Employee>> GetAsync()
        {
            using (EmployeeServiceClient employeeServiceClient = new EmployeeServiceClient())
            {
                return await employeeServiceClient.GetAsync();
            }
        }

        public List<Employee> Get()
        {
            using (EmployeeServiceClient employeeServiceClient = new EmployeeServiceClient())
            {
                return employeeServiceClient.Get();
            }
        }
    }
}
