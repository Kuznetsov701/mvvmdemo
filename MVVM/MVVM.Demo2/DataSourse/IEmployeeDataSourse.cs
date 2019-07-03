using DataContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVVM.Demo2
{
    public interface IEmployeeDataSourse
    {
        List<Employee> Get();
        Task<List<Employee>> GetAsync();
    }
}
