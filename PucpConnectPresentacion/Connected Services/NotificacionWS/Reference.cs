﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PucpConnectPresentacion.NotificacionWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ws.pucpconnect.pe.edu.pucp/", ConfigurationName="NotificacionWS.NotificacionWS")]
    public interface NotificacionWS {
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/cambiarEstadoRequest", ReplyAction="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/cambiarEstadoResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        PucpConnectPresentacion.NotificacionWS.cambiarEstadoResponse cambiarEstado(PucpConnectPresentacion.NotificacionWS.cambiarEstadoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/cambiarEstadoRequest", ReplyAction="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/cambiarEstadoResponse")]
        System.Threading.Tasks.Task<PucpConnectPresentacion.NotificacionWS.cambiarEstadoResponse> cambiarEstadoAsync(PucpConnectPresentacion.NotificacionWS.cambiarEstadoRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/marcarComoVistoRequest", ReplyAction="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/marcarComoVistoResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        PucpConnectPresentacion.NotificacionWS.marcarComoVistoResponse marcarComoVisto(PucpConnectPresentacion.NotificacionWS.marcarComoVistoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/marcarComoVistoRequest", ReplyAction="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/marcarComoVistoResponse")]
        System.Threading.Tasks.Task<PucpConnectPresentacion.NotificacionWS.marcarComoVistoResponse> marcarComoVistoAsync(PucpConnectPresentacion.NotificacionWS.marcarComoVistoRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/obtenerNotificacionesRequest", ReplyAction="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/obtenerNotificacionesResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesResponse obtenerNotificaciones(PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/obtenerNotificacionesRequest", ReplyAction="http://ws.pucpconnect.pe.edu.pucp/NotificacionWS/obtenerNotificacionesResponse")]
        System.Threading.Tasks.Task<PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesResponse> obtenerNotificacionesAsync(PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cambiarEstado", WrapperNamespace="http://ws.pucpconnect.pe.edu.pucp/", IsWrapped=true)]
    public partial class cambiarEstadoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.pucpconnect.pe.edu.pucp/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int idNotificacion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.pucpconnect.pe.edu.pucp/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool estado;
        
        public cambiarEstadoRequest() {
        }
        
        public cambiarEstadoRequest(int idNotificacion, bool estado) {
            this.idNotificacion = idNotificacion;
            this.estado = estado;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cambiarEstadoResponse", WrapperNamespace="http://ws.pucpconnect.pe.edu.pucp/", IsWrapped=true)]
    public partial class cambiarEstadoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.pucpconnect.pe.edu.pucp/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool @return;
        
        public cambiarEstadoResponse() {
        }
        
        public cambiarEstadoResponse(bool @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="marcarComoVisto", WrapperNamespace="http://ws.pucpconnect.pe.edu.pucp/", IsWrapped=true)]
    public partial class marcarComoVistoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.pucpconnect.pe.edu.pucp/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int idNotificacion;
        
        public marcarComoVistoRequest() {
        }
        
        public marcarComoVistoRequest(int idNotificacion) {
            this.idNotificacion = idNotificacion;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="marcarComoVistoResponse", WrapperNamespace="http://ws.pucpconnect.pe.edu.pucp/", IsWrapped=true)]
    public partial class marcarComoVistoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.pucpconnect.pe.edu.pucp/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool @return;
        
        public marcarComoVistoResponse() {
        }
        
        public marcarComoVistoResponse(bool @return) {
            this.@return = @return;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.pucpconnect.pe.edu.pucp/")]
    public partial class notificacion : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool estadoField;
        
        private timestamp fechaField;
        
        private int idNotificacionField;
        
        private string mensajeField;
        
        private string tipoField;
        
        private int usuarioIdField;
        
        private bool vistoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public bool estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
                this.RaisePropertyChanged("estado");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public timestamp fecha {
            get {
                return this.fechaField;
            }
            set {
                this.fechaField = value;
                this.RaisePropertyChanged("fecha");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public int idNotificacion {
            get {
                return this.idNotificacionField;
            }
            set {
                this.idNotificacionField = value;
                this.RaisePropertyChanged("idNotificacion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string mensaje {
            get {
                return this.mensajeField;
            }
            set {
                this.mensajeField = value;
                this.RaisePropertyChanged("mensaje");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string tipo {
            get {
                return this.tipoField;
            }
            set {
                this.tipoField = value;
                this.RaisePropertyChanged("tipo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public int usuarioId {
            get {
                return this.usuarioIdField;
            }
            set {
                this.usuarioIdField = value;
                this.RaisePropertyChanged("usuarioId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public bool visto {
            get {
                return this.vistoField;
            }
            set {
                this.vistoField = value;
                this.RaisePropertyChanged("visto");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.pucpconnect.pe.edu.pucp/")]
    public partial class timestamp : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int nanosField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int nanos {
            get {
                return this.nanosField;
            }
            set {
                this.nanosField = value;
                this.RaisePropertyChanged("nanos");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="obtenerNotificaciones", WrapperNamespace="http://ws.pucpconnect.pe.edu.pucp/", IsWrapped=true)]
    public partial class obtenerNotificacionesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.pucpconnect.pe.edu.pucp/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int idUsuario;
        
        public obtenerNotificacionesRequest() {
        }
        
        public obtenerNotificacionesRequest(int idUsuario) {
            this.idUsuario = idUsuario;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="obtenerNotificacionesResponse", WrapperNamespace="http://ws.pucpconnect.pe.edu.pucp/", IsWrapped=true)]
    public partial class obtenerNotificacionesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.pucpconnect.pe.edu.pucp/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PucpConnectPresentacion.NotificacionWS.notificacion[] @return;
        
        public obtenerNotificacionesResponse() {
        }
        
        public obtenerNotificacionesResponse(PucpConnectPresentacion.NotificacionWS.notificacion[] @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface NotificacionWSChannel : PucpConnectPresentacion.NotificacionWS.NotificacionWS, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NotificacionWSClient : System.ServiceModel.ClientBase<PucpConnectPresentacion.NotificacionWS.NotificacionWS>, PucpConnectPresentacion.NotificacionWS.NotificacionWS {
        
        public NotificacionWSClient() {
        }
        
        public NotificacionWSClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NotificacionWSClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NotificacionWSClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NotificacionWSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PucpConnectPresentacion.NotificacionWS.cambiarEstadoResponse PucpConnectPresentacion.NotificacionWS.NotificacionWS.cambiarEstado(PucpConnectPresentacion.NotificacionWS.cambiarEstadoRequest request) {
            return base.Channel.cambiarEstado(request);
        }
        
        public bool cambiarEstado(int idNotificacion, bool estado) {
            PucpConnectPresentacion.NotificacionWS.cambiarEstadoRequest inValue = new PucpConnectPresentacion.NotificacionWS.cambiarEstadoRequest();
            inValue.idNotificacion = idNotificacion;
            inValue.estado = estado;
            PucpConnectPresentacion.NotificacionWS.cambiarEstadoResponse retVal = ((PucpConnectPresentacion.NotificacionWS.NotificacionWS)(this)).cambiarEstado(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PucpConnectPresentacion.NotificacionWS.cambiarEstadoResponse> PucpConnectPresentacion.NotificacionWS.NotificacionWS.cambiarEstadoAsync(PucpConnectPresentacion.NotificacionWS.cambiarEstadoRequest request) {
            return base.Channel.cambiarEstadoAsync(request);
        }
        
        public System.Threading.Tasks.Task<PucpConnectPresentacion.NotificacionWS.cambiarEstadoResponse> cambiarEstadoAsync(int idNotificacion, bool estado) {
            PucpConnectPresentacion.NotificacionWS.cambiarEstadoRequest inValue = new PucpConnectPresentacion.NotificacionWS.cambiarEstadoRequest();
            inValue.idNotificacion = idNotificacion;
            inValue.estado = estado;
            return ((PucpConnectPresentacion.NotificacionWS.NotificacionWS)(this)).cambiarEstadoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PucpConnectPresentacion.NotificacionWS.marcarComoVistoResponse PucpConnectPresentacion.NotificacionWS.NotificacionWS.marcarComoVisto(PucpConnectPresentacion.NotificacionWS.marcarComoVistoRequest request) {
            return base.Channel.marcarComoVisto(request);
        }
        
        public bool marcarComoVisto(int idNotificacion) {
            PucpConnectPresentacion.NotificacionWS.marcarComoVistoRequest inValue = new PucpConnectPresentacion.NotificacionWS.marcarComoVistoRequest();
            inValue.idNotificacion = idNotificacion;
            PucpConnectPresentacion.NotificacionWS.marcarComoVistoResponse retVal = ((PucpConnectPresentacion.NotificacionWS.NotificacionWS)(this)).marcarComoVisto(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PucpConnectPresentacion.NotificacionWS.marcarComoVistoResponse> PucpConnectPresentacion.NotificacionWS.NotificacionWS.marcarComoVistoAsync(PucpConnectPresentacion.NotificacionWS.marcarComoVistoRequest request) {
            return base.Channel.marcarComoVistoAsync(request);
        }
        
        public System.Threading.Tasks.Task<PucpConnectPresentacion.NotificacionWS.marcarComoVistoResponse> marcarComoVistoAsync(int idNotificacion) {
            PucpConnectPresentacion.NotificacionWS.marcarComoVistoRequest inValue = new PucpConnectPresentacion.NotificacionWS.marcarComoVistoRequest();
            inValue.idNotificacion = idNotificacion;
            return ((PucpConnectPresentacion.NotificacionWS.NotificacionWS)(this)).marcarComoVistoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesResponse PucpConnectPresentacion.NotificacionWS.NotificacionWS.obtenerNotificaciones(PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesRequest request) {
            return base.Channel.obtenerNotificaciones(request);
        }
        
        public PucpConnectPresentacion.NotificacionWS.notificacion[] obtenerNotificaciones(int idUsuario) {
            PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesRequest inValue = new PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesRequest();
            inValue.idUsuario = idUsuario;
            PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesResponse retVal = ((PucpConnectPresentacion.NotificacionWS.NotificacionWS)(this)).obtenerNotificaciones(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesResponse> PucpConnectPresentacion.NotificacionWS.NotificacionWS.obtenerNotificacionesAsync(PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesRequest request) {
            return base.Channel.obtenerNotificacionesAsync(request);
        }
        
        public System.Threading.Tasks.Task<PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesResponse> obtenerNotificacionesAsync(int idUsuario) {
            PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesRequest inValue = new PucpConnectPresentacion.NotificacionWS.obtenerNotificacionesRequest();
            inValue.idUsuario = idUsuario;
            return ((PucpConnectPresentacion.NotificacionWS.NotificacionWS)(this)).obtenerNotificacionesAsync(inValue);
        }
    }
}
