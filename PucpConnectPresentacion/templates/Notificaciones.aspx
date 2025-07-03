<%@ Page  
    Title="Notificaciones"  
    Language="C#"  
    MasterPageFile="~/Masters/MainLayout.Master"  
    AutoEventWireup="true"  
    CodeBehind="Notificaciones.aspx.cs"  
    Inherits="PucpConnectPresentacion.templates.Notificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Mis Notificaciones
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h5 class="mb-4 fw-semibold">Notificaciones</h5>
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

    <asp:Repeater ID="rptNotifs" runat="server">
      <HeaderTemplate>
        <ul class="list-group">
      </HeaderTemplate>
      <ItemTemplate>
        <li class="list-group-item d-flex justify-content-between align-items-center 
                   <%# (bool)Eval("visto") ? "" : "list-group-item-info" %>">
          <div>
            <strong><%# Eval("tipo") %></strong>  
            &ndash; <%# Eval("mensaje") %><br/>
            <small class="text-muted"><%# Eval("fecha", "{0:dd/MM/yyyy HH:mm}") %></small>
          </div>
          <asp:LinkButton 
            ID="lnkMarcar" 
            runat="server" 
            CssClass="btn btn-sm btn-outline-secondary"
            CommandArgument='<%# Eval("idNotificacion") %>'  
            OnCommand="lnkMarcar_Command">
            <%# (bool)Eval("visto") ? "Reabrir" : "Marcar leído" %>
          </asp:LinkButton>
        </li>
      </ItemTemplate>
      <FooterTemplate>
        </ul>
      </FooterTemplate>
    </asp:Repeater>

</asp:Content>
