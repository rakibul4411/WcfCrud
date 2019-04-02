using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCrud
{
    [ServiceContract]
    public interface IService1
    {
        
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetPerson")]
        IEnumerable<Person> GetPerson();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetPerson/{id}")]
        Person GetPersonById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat =WebMessageFormat.Json, UriTemplate = "AddPerson")]
        void InsertPerson(Person per);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat =WebMessageFormat.Json, UriTemplate = "UpdatePerson")]
        void UpdatetPerson(Person per);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat =WebMessageFormat.Json, UriTemplate = "DeletePerson")]
        void DeletePerson(Person per);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Person
    {

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}
