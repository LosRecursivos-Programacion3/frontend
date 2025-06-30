<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="PucpConnectPresentacion.Reportes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes PDF</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnEventos" runat="server" Text="Ver Reporte de Eventos" OnClick="btnEventos_Click" />
        <asp:Button ID="btnCarreras" runat="server" Text="Ver Reporte de Carreras" OnClick="btnCarreras_Click" />
    </form>
</body>
</html>