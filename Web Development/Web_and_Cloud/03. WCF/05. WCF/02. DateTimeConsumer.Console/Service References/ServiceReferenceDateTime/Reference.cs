﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DateTimeConsumer.Console.ServiceReferenceDateTime {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceDateTime.IServiceDateTime")]
    public interface IServiceDateTime {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDateTime/GetDayOfWeek", ReplyAction="http://tempuri.org/IServiceDateTime/GetDayOfWeekResponse")]
        string GetDayOfWeek(System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDateTime/GetDayOfWeek", ReplyAction="http://tempuri.org/IServiceDateTime/GetDayOfWeekResponse")]
        System.Threading.Tasks.Task<string> GetDayOfWeekAsync(System.DateTime date);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceDateTimeChannel : DateTimeConsumer.Console.ServiceReferenceDateTime.IServiceDateTime, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceDateTimeClient : System.ServiceModel.ClientBase<DateTimeConsumer.Console.ServiceReferenceDateTime.IServiceDateTime>, DateTimeConsumer.Console.ServiceReferenceDateTime.IServiceDateTime {
        
        public ServiceDateTimeClient() {
        }
        
        public ServiceDateTimeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceDateTimeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDateTimeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDateTimeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetDayOfWeek(System.DateTime date) {
            return base.Channel.GetDayOfWeek(date);
        }
        
        public System.Threading.Tasks.Task<string> GetDayOfWeekAsync(System.DateTime date) {
            return base.Channel.GetDayOfWeekAsync(date);
        }
    }
}
