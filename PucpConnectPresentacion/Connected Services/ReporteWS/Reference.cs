﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PucpConnectPresentacion.ReporteWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ws.pucpconnect.pe.edu.pucp/", ConfigurationName="ReporteWS.ReporteWS")]
    public interface ReporteWS {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el espacio de nombres de partes de mensaje () no coincide con el valor predeterminado (http://ws.pucpconnect.pe.edu.pucp/).
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.pucpconnect.pe.edu.pucp/ReporteWS/generarReportePorcentajeAlumnosPorCar" +
            "reraRequest", ReplyAction="http://ws.pucpconnect.pe.edu.pucp/ReporteWS/generarReportePorcentajeAlumnosPorCar" +
            "reraResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraResponse generarReportePorcentajeAlumnosPorCarrera(PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.pucpconnect.pe.edu.pucp/ReporteWS/generarReportePorcentajeAlumnosPorCar" +
            "reraRequest", ReplyAction="http://ws.pucpconnect.pe.edu.pucp/ReporteWS/generarReportePorcentajeAlumnosPorCar" +
            "reraResponse")]
        System.Threading.Tasks.Task<PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraResponse> generarReportePorcentajeAlumnosPorCarreraAsync(PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el espacio de nombres de partes de mensaje () no coincide con el valor predeterminado (http://ws.pucpconnect.pe.edu.pucp/).
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.pucpconnect.pe.edu.pucp/ReporteWS/generarReporteEventosConParticipantes" +
            "Request", ReplyAction="http://ws.pucpconnect.pe.edu.pucp/ReporteWS/generarReporteEventosConParticipantes" +
            "Response")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesResponse generarReporteEventosConParticipantes(PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.pucpconnect.pe.edu.pucp/ReporteWS/generarReporteEventosConParticipantes" +
            "Request", ReplyAction="http://ws.pucpconnect.pe.edu.pucp/ReporteWS/generarReporteEventosConParticipantes" +
            "Response")]
        System.Threading.Tasks.Task<PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesResponse> generarReporteEventosConParticipantesAsync(PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="generarReportePorcentajeAlumnosPorCarrera", WrapperNamespace="http://ws.pucpconnect.pe.edu.pucp/", IsWrapped=true)]
    public partial class generarReportePorcentajeAlumnosPorCarreraRequest {
        
        public generarReportePorcentajeAlumnosPorCarreraRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="generarReportePorcentajeAlumnosPorCarreraResponse", WrapperNamespace="http://ws.pucpconnect.pe.edu.pucp/", IsWrapped=true)]
    public partial class generarReportePorcentajeAlumnosPorCarreraResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public byte[] @return;
        
        public generarReportePorcentajeAlumnosPorCarreraResponse() {
        }
        
        public generarReportePorcentajeAlumnosPorCarreraResponse(byte[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="generarReporteEventosConParticipantes", WrapperNamespace="http://ws.pucpconnect.pe.edu.pucp/", IsWrapped=true)]
    public partial class generarReporteEventosConParticipantesRequest {
        
        public generarReporteEventosConParticipantesRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="generarReporteEventosConParticipantesResponse", WrapperNamespace="http://ws.pucpconnect.pe.edu.pucp/", IsWrapped=true)]
    public partial class generarReporteEventosConParticipantesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public byte[] @return;
        
        public generarReporteEventosConParticipantesResponse() {
        }
        
        public generarReporteEventosConParticipantesResponse(byte[] @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ReporteWSChannel : PucpConnectPresentacion.ReporteWS.ReporteWS, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReporteWSClient : System.ServiceModel.ClientBase<PucpConnectPresentacion.ReporteWS.ReporteWS>, PucpConnectPresentacion.ReporteWS.ReporteWS {
        
        public ReporteWSClient() {
        }
        
        public ReporteWSClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReporteWSClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReporteWSClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReporteWSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraResponse PucpConnectPresentacion.ReporteWS.ReporteWS.generarReportePorcentajeAlumnosPorCarrera(PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraRequest request) {
            return base.Channel.generarReportePorcentajeAlumnosPorCarrera(request);
        }
        
        public byte[] generarReportePorcentajeAlumnosPorCarrera() {
            PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraRequest inValue = new PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraRequest();
            PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraResponse retVal = ((PucpConnectPresentacion.ReporteWS.ReporteWS)(this)).generarReportePorcentajeAlumnosPorCarrera(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraResponse> PucpConnectPresentacion.ReporteWS.ReporteWS.generarReportePorcentajeAlumnosPorCarreraAsync(PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraRequest request) {
            return base.Channel.generarReportePorcentajeAlumnosPorCarreraAsync(request);
        }
        
        public System.Threading.Tasks.Task<PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraResponse> generarReportePorcentajeAlumnosPorCarreraAsync() {
            PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraRequest inValue = new PucpConnectPresentacion.ReporteWS.generarReportePorcentajeAlumnosPorCarreraRequest();
            return ((PucpConnectPresentacion.ReporteWS.ReporteWS)(this)).generarReportePorcentajeAlumnosPorCarreraAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesResponse PucpConnectPresentacion.ReporteWS.ReporteWS.generarReporteEventosConParticipantes(PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesRequest request) {
            return base.Channel.generarReporteEventosConParticipantes(request);
        }
        
        public byte[] generarReporteEventosConParticipantes() {
            PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesRequest inValue = new PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesRequest();
            PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesResponse retVal = ((PucpConnectPresentacion.ReporteWS.ReporteWS)(this)).generarReporteEventosConParticipantes(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesResponse> PucpConnectPresentacion.ReporteWS.ReporteWS.generarReporteEventosConParticipantesAsync(PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesRequest request) {
            return base.Channel.generarReporteEventosConParticipantesAsync(request);
        }
        
        public System.Threading.Tasks.Task<PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesResponse> generarReporteEventosConParticipantesAsync() {
            PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesRequest inValue = new PucpConnectPresentacion.ReporteWS.generarReporteEventosConParticipantesRequest();
            return ((PucpConnectPresentacion.ReporteWS.ReporteWS)(this)).generarReporteEventosConParticipantesAsync(inValue);
        }
    }
}
