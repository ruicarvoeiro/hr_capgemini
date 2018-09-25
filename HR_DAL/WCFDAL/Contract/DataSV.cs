using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFDAL.Contract
{
    [DataContract]
    public abstract class DataSV
    {
        [DataMember]
        public bool HasError { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public bool HasRows { get; set; }
    }
}