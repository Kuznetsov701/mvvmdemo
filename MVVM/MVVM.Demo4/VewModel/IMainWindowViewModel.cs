using DataContract;
using System.Collections.Generic;

namespace MVVM.Demo4
{
    public interface IMainWindowViewModel
    {
        IEmployeeDataSourse EmployeeDataSourse { get; }
        string Filter { get; }
        List<Employee> FilteredSourse { get; set; }
        List<Employee> ItemsSourse{ get; set; }
    }
}
