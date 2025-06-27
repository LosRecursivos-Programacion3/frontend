<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Create.Master" AutoEventWireup="true" CodeBehind="SelectInterest.aspx.cs" Inherits="PucpConnectPresentacion.templates.SelectInterest" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
    Selecciona tus intereses
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h4 class="text-center fw-bold mb-4">¿Qué te interesa? ¿Qué te inspira?</h4>
    <p class="text-center">Por favor, elige hasta 5 hobbies</p>

    <div class="d-flex flex-wrap justify-content-center">
        <asp:Repeater ID="rptIntereses" runat="server">
            <ItemTemplate>
                <input 
                    type="checkbox" 
                    class="btn-check" 
                    name="interes"
                    id='<%# "chk" + Eval("id") %>' 
                    value='<%# Eval("id") %>'
                    <%# ((List<int>)ViewState["InteresesAlumno"] != null && ((List<int>)ViewState["InteresesAlumno"]).Contains((int)Eval("id")) ? "checked" : "") %> />

                <label 
                    class="btn btn-outline-primary m-1" 
                    for='<%# "chk" + Eval("id") %>'>
                    <%# Eval("nombre") %>
                </label>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <asp:HiddenField ID="hdnSeleccionados" runat="server" />

    <div class="text-center mt-4">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary px-4" OnClick="btnGuardar_Click" />
    </div>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            const checkboxes = document.querySelectorAll("input[type=checkbox][name=interes]");
            const hiddenField = document.getElementById("<%= hdnSeleccionados.ClientID %>");
            let seleccionados = [];

            // Inicializar seleccionados
            checkboxes.forEach(cb => {
                if (cb.checked) {
                    seleccionados.push(cb.value);
                }
            });
            hiddenField.value = seleccionados.join(",");

            // Escuchar cambios
            checkboxes.forEach(cb => {
                cb.addEventListener("change", () => {
                    const id = cb.value;

                    if (cb.checked) {
                        if (!seleccionados.includes(id)) {
                            if (seleccionados.length >= 5) {
                                cb.checked = false;
                                alert("Solo puedes seleccionar hasta 5 intereses.");
                                return;
                            }
                            seleccionados.push(id);
                        }
                    } else {
                        seleccionados = seleccionados.filter(x => x !== id);
                    }
                    console.log(seleccionados);
                    hiddenField.value = seleccionados.join(",");
                });
            });
        });
    </script>
</asp:Content>
