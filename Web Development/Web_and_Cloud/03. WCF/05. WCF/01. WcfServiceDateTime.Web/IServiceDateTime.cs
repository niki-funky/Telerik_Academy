using System;
using System.Linq;
using System.ServiceModel;

namespace WcfServiceDateTime.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceDateTime
    {

        [OperationContract]
        string GetDayOfWeek(DateTime date);
    }


    //// Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class Date
    //{
    //    [DataMember]
    //    DateTime Date { get; set; }
    //}
}
