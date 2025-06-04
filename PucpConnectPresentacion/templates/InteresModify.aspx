<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ProfileSettings.Master" AutoEventWireup="true" CodeBehind="InteresModify.aspx.cs" Inherits="PucpConnectPresentacion.templates.InteresModify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="interests-container">
        <h1 class="title">¿Qué te interesa? ¿Qué te inspira?</h1>
        
        
        <div class="selection-info">
            <p><strong>Por favor, elige 5 hobbies</strong></p>
        </div>
        
        <div class="interests-grid">
            <!-- Primera fila -->
            <asp:CheckBox ID="chkArte" runat="server" CssClass="interest-checkbox" Text="Arte" />
            <asp:CheckBox ID="chkViajar" runat="server" CssClass="interest-checkbox" Text="Viajar" />
            <asp:CheckBox ID="chkMusica" runat="server" CssClass="interest-checkbox" Text="Música" />
            <asp:CheckBox ID="chkDeportes" runat="server" CssClass="interest-checkbox" Text="Deportes" />
            <asp:CheckBox ID="chkDiseno" runat="server" CssClass="interest-checkbox" Text="Diseño" />
            <asp:CheckBox ID="chkNaturaleza" runat="server" CssClass="interest-checkbox" Text="Naturaleza" />
            
            <!-- Segunda fila -->
            <asp:CheckBox ID="chkFotografia" runat="server" CssClass="interest-checkbox" Text="Fotografía" />
            <asp:CheckBox ID="chkLectura" runat="server" CssClass="interest-checkbox" Text="Lectura" />
            <asp:CheckBox ID="chkEscritura" runat="server" CssClass="interest-checkbox" Text="Escritura" />
            <asp:CheckBox ID="chkGastronomia" runat="server" CssClass="interest-checkbox" Text="Gastronomía" />
            <asp:CheckBox ID="chkTeatro" runat="server" CssClass="interest-checkbox" Text="Teatro" />
            <asp:CheckBox ID="chkYoga" runat="server" CssClass="interest-checkbox" Text="Yoga" />
            
            <!-- Tercera fila -->
            <asp:CheckBox ID="chkShopping" runat="server" CssClass="interest-checkbox" Text="Shopping" />
            <asp:CheckBox ID="chkArquitectura" runat="server" CssClass="interest-checkbox" Text="Arquitectura" />
            <asp:CheckBox ID="chkFestivales" runat="server" CssClass="interest-checkbox" Text="Festivales" />
            <asp:CheckBox ID="chkDibujo" runat="server" CssClass="interest-checkbox" Text="Dibujo" />
            <asp:CheckBox ID="chkAgricultura" runat="server" CssClass="interest-checkbox" Text="Agricultura" />
            <asp:CheckBox ID="chkIdiomas" runat="server" CssClass="interest-checkbox" Text="Idiomas" />
            
            <!-- Cuarta fila -->
            <asp:CheckBox ID="chkMuseo" runat="server" CssClass="interest-checkbox" Text="Museo" />
            <asp:CheckBox ID="chkCreacionContenido" runat="server" CssClass="interest-checkbox" Text="Creación de contenido" />
            <asp:CheckBox ID="chkActuacion" runat="server" CssClass="interest-checkbox" Text="Actuación" />
        </div>
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="save-button" />
    </div>
</asp:Content>
