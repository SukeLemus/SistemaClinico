﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaClinico.SistemaClinicaSoapWS {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SistemaClinicaSoapWS.ClinicaWebServiceSoap")]
    public interface ClinicaWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/lista_sintomas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet lista_sintomas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/lista_sintomas", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> lista_sintomasAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/actualizar_sintomas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int actualizar_sintomas(int id_sintoma, string nombre, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/actualizar_sintomas", ReplyAction="*")]
        System.Threading.Tasks.Task<int> actualizar_sintomasAsync(int id_sintoma, string nombre, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/lista_enfermedades", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet lista_enfermedades();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/lista_enfermedades", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> lista_enfermedadesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/lista_enfermedades_sintomas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet lista_enfermedades_sintomas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/lista_enfermedades_sintomas", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> lista_enfermedades_sintomasAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertar_enfermedad", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int insertar_enfermedad(string nombre, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertar_enfermedad", ReplyAction="*")]
        System.Threading.Tasks.Task<int> insertar_enfermedadAsync(string nombre, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertar_enfermedad_sintomas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int insertar_enfermedad_sintomas(int id_enfermedad, int id_sintoma);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertar_enfermedad_sintomas", ReplyAction="*")]
        System.Threading.Tasks.Task<int> insertar_enfermedad_sintomasAsync(int id_enfermedad, int id_sintoma);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/actualizar_enfermedad", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int actualizar_enfermedad(int id_enfermedad, string nombre, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/actualizar_enfermedad", ReplyAction="*")]
        System.Threading.Tasks.Task<int> actualizar_enfermedadAsync(int id_enfermedad, string nombre, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/actualizar_enfermedad_sintomas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int actualizar_enfermedad_sintomas(int id_enfermedad, int id_sintoma);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/actualizar_enfermedad_sintomas", ReplyAction="*")]
        System.Threading.Tasks.Task<int> actualizar_enfermedad_sintomasAsync(int id_enfermedad, int id_sintoma);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertar_sintomas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int insertar_sintomas(string nombre, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertar_sintomas", ReplyAction="*")]
        System.Threading.Tasks.Task<int> insertar_sintomasAsync(string nombre, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/eliminar_sintomas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int eliminar_sintomas(int idsintoma);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/eliminar_sintomas", ReplyAction="*")]
        System.Threading.Tasks.Task<int> eliminar_sintomasAsync(int idsintoma);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Login2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Login2(string usuario, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Login2", ReplyAction="*")]
        System.Threading.Tasks.Task<string> Login2Async(string usuario, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Login3", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Login3(string usuario, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Login3", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> Login3Async(string usuario, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TodoslosPacientes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TodoslosPacientes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TodoslosPacientes", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TodoslosPacientesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ClinicaWebServiceSoapChannel : SistemaClinico.SistemaClinicaSoapWS.ClinicaWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClinicaWebServiceSoapClient : System.ServiceModel.ClientBase<SistemaClinico.SistemaClinicaSoapWS.ClinicaWebServiceSoap>, SistemaClinico.SistemaClinicaSoapWS.ClinicaWebServiceSoap {
        
        public ClinicaWebServiceSoapClient() {
        }
        
        public ClinicaWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClinicaWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClinicaWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClinicaWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
        
        public System.Data.DataSet lista_sintomas() {
            return base.Channel.lista_sintomas();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> lista_sintomasAsync() {
            return base.Channel.lista_sintomasAsync();
        }
        
        public int actualizar_sintomas(int id_sintoma, string nombre, string descripcion) {
            return base.Channel.actualizar_sintomas(id_sintoma, nombre, descripcion);
        }
        
        public System.Threading.Tasks.Task<int> actualizar_sintomasAsync(int id_sintoma, string nombre, string descripcion) {
            return base.Channel.actualizar_sintomasAsync(id_sintoma, nombre, descripcion);
        }
        
        public System.Data.DataSet lista_enfermedades() {
            return base.Channel.lista_enfermedades();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> lista_enfermedadesAsync() {
            return base.Channel.lista_enfermedadesAsync();
        }
        
        public System.Data.DataSet lista_enfermedades_sintomas() {
            return base.Channel.lista_enfermedades_sintomas();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> lista_enfermedades_sintomasAsync() {
            return base.Channel.lista_enfermedades_sintomasAsync();
        }
        
        public int insertar_enfermedad(string nombre, string descripcion) {
            return base.Channel.insertar_enfermedad(nombre, descripcion);
        }
        
        public System.Threading.Tasks.Task<int> insertar_enfermedadAsync(string nombre, string descripcion) {
            return base.Channel.insertar_enfermedadAsync(nombre, descripcion);
        }
        
        public int insertar_enfermedad_sintomas(int id_enfermedad, int id_sintoma) {
            return base.Channel.insertar_enfermedad_sintomas(id_enfermedad, id_sintoma);
        }
        
        public System.Threading.Tasks.Task<int> insertar_enfermedad_sintomasAsync(int id_enfermedad, int id_sintoma) {
            return base.Channel.insertar_enfermedad_sintomasAsync(id_enfermedad, id_sintoma);
        }
        
        public int actualizar_enfermedad(int id_enfermedad, string nombre, string descripcion) {
            return base.Channel.actualizar_enfermedad(id_enfermedad, nombre, descripcion);
        }
        
        public System.Threading.Tasks.Task<int> actualizar_enfermedadAsync(int id_enfermedad, string nombre, string descripcion) {
            return base.Channel.actualizar_enfermedadAsync(id_enfermedad, nombre, descripcion);
        }
        
        public int actualizar_enfermedad_sintomas(int id_enfermedad, int id_sintoma) {
            return base.Channel.actualizar_enfermedad_sintomas(id_enfermedad, id_sintoma);
        }
        
        public System.Threading.Tasks.Task<int> actualizar_enfermedad_sintomasAsync(int id_enfermedad, int id_sintoma) {
            return base.Channel.actualizar_enfermedad_sintomasAsync(id_enfermedad, id_sintoma);
        }
        
        public int insertar_sintomas(string nombre, string descripcion) {
            return base.Channel.insertar_sintomas(nombre, descripcion);
        }
        
        public System.Threading.Tasks.Task<int> insertar_sintomasAsync(string nombre, string descripcion) {
            return base.Channel.insertar_sintomasAsync(nombre, descripcion);
        }
        
        public int eliminar_sintomas(int idsintoma) {
            return base.Channel.eliminar_sintomas(idsintoma);
        }
        
        public System.Threading.Tasks.Task<int> eliminar_sintomasAsync(int idsintoma) {
            return base.Channel.eliminar_sintomasAsync(idsintoma);
        }
        
        public string Login2(string usuario, string clave) {
            return base.Channel.Login2(usuario, clave);
        }
        
        public System.Threading.Tasks.Task<string> Login2Async(string usuario, string clave) {
            return base.Channel.Login2Async(usuario, clave);
        }
        
        public System.Data.DataSet Login3(string usuario, string clave) {
            return base.Channel.Login3(usuario, clave);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> Login3Async(string usuario, string clave) {
            return base.Channel.Login3Async(usuario, clave);
        }
        
        public System.Data.DataSet TodoslosPacientes() {
            return base.Channel.TodoslosPacientes();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TodoslosPacientesAsync() {
            return base.Channel.TodoslosPacientesAsync();
        }
    }
}
