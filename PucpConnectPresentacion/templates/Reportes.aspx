<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="PucpConnectPresentacion.Reportes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes - PUCP Connect</title>
    <style>
        body {
            font-family: 'Segoe UI', Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f5f5f5;
        }
        .blue-header {
            background-color: #0056b3;
            color: white;
            padding: 15px 20px;
            display: flex;
            align-items: center;
            box-shadow: 0 2px 5px rgba(0,0,0,0.2);
        }
        .back-button {
            color: white;
            text-decoration: none;
            font-size: 16px;
            font-weight: bold;
            margin-right: 20px;
            display: flex;
            align-items: center;
            background: none;
            border: none;
            cursor: pointer;
            padding: 0;
        }
        .back-button:hover {
            color: #e6f0ff;
            text-decoration: none;
        }
        .container {
            max-width: 1000px;
            margin: 30px auto;
            background: white;
            border-radius: 8px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
            overflow: hidden;
        }
        .content {
            padding: 30px;
        }
        h1 {
            color: #2c3e50;
            margin-bottom: 30px;
            text-align: center;
        }
        .btn-download {
            background-color: #007bff;
            color: white;
            padding: 12px 25px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            transition: all 0.3s;
            display: block;
            margin: 15px auto;
            width: 280px;
            text-align: center;
            font-weight: 500;
        }
        .btn-download:hover {
            background-color: #0056b3;
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        }
        .error-message {
            color: #dc3545;
            text-align: center;
            margin-top: 20px;
            padding: 10px;
            background-color: #f8d7da;
            border: 1px solid #f5c6cb;
            border-radius: 4px;
            display: none;
        }
        .description {
            text-align: center;
            color: #6c757d;
            margin-bottom: 30px;
        }
        .report-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
            gap: 20px;
            margin-top: 20px;
        }
        .blue-footer {
            background-color: #0056b3;
            padding: 15px;
            text-align: center;
            color: white;
            margin-top: 30px;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Barra azul superior con botón Volver -->
        <div class="blue-header">
            <asp:LinkButton ID="btnVolver" runat="server" CssClass="back-button" OnClick="btnIrAlMain_Click">
                ← Volver al Inicio
            </asp:LinkButton>
            <h1 style="margin: 0; flex-grow: 1;">Reportes Estadísticos</h1>
        </div>

        <div class="container">
            <div class="content">
                <div class="report-section">
                    <div class="section-title">Reportes de Usuarios y Eventos</div>
                    <p class="description">Descargue informes detallados en formato PDF</p>
                    
                    <div class="report-grid">
                        <asp:Button ID="btnDescargarUsuarios" CssClass="btn-download" runat="server" 
                            Text="📊 Reporte de Usuarios" OnClick="btnDescargarUsuarios_Click" />
                        
                        <asp:Button ID="btnDescargarEventos" CssClass="btn-download" runat="server" 
                            Text="📅 Reporte de Eventos" OnClick="btnDescargarEventos_Click" />
                        
                        <asp:Button ID="btnDescargarCarreras" CssClass="btn-download" runat="server" 
                            Text="🎓 Alumnos por Carrera" OnClick="btnDescargarCarreras_Click" />
                    </div>
                </div>

                <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
            </div>

            <div class="blue-footer">
                PUCP Connect - Sistema de Gestión Universitaria © <%= DateTime.Now.Year %>
            </div>
        </div>
    </form>
</body>
</html>
