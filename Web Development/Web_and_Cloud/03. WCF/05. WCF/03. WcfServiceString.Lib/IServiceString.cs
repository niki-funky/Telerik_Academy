using System;
using System.Linq;
using System.ServiceModel;

namespace WcfServiceString.Lib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceString
    {
        [OperationContract]
        int NumberOfOccurences(string first, string second);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServiceString.Library.ContractType".
    
}
