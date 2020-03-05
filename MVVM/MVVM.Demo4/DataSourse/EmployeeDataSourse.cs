using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeServiceReference;
using DataContract;

namespace MVVM.Demo4
{
    public class EmployeeDataSourse : IEmployeeDataSourse
    {
        public async Task<List<Employee>> GetAsync()
        {
            EmployeeServiceClient employeeServiceClient = new EmployeeServiceClient();
            {
                return await employeeServiceClient.GetAsync();
            }
        }

        public List<Employee> Get()
        {
            EmployeeServiceClient employeeServiceClient = new EmployeeServiceClient();
            {
                return employeeServiceClient.Get();
            }
        }
    }
}
