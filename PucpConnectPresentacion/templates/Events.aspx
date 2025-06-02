<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/SectionLayout.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="PucpConnectPresentacion.templates.Events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-2">
        <h2 class="fw-bold mb-4">Explorar Eventos</h2>

        <div class="row gy-4">
            <!-- Evento 1 -->
            <a href="EventProfile.aspx" class="col-md-6 text-decoration-none text-dark">
                <div class="event-card bg-white">
                    <img src="../Images/concierto.jpg" alt="Concierto" class="event-image" />
                    <div class="event-body">
                        <div class="event-top">
                            <div class="d-flex align-items-center gap-2">
                                <span class="btn btn-asistir">Asistir</span>
                            </div>
                            <span class="event-date">25 de mayo</span>
                        </div>
                        <div class="event-title">Concierto fin de parciales</div>
                        <div class="event-description">
                            Después de tanto estudio, ¡es momento de relajarse y celebrar!<br />
                            Ven a disfrutar buena música, amigos, y el merecido descanso que todos necesitamos.
                        </div>
                    </div>
                </div>
            </a>
            <!-- Evento 2 -->
            <div class="col-md-6">
                <div class="event-card bg-white">
                    <img src="../Images/baileton.jpg" alt="Baile" class="event-image" />
                    <div class="event-body">
                        <div class="event-top">
                            <div class="d-flex align-items-center gap-2">
                                <span class="btn btn-asistir">
                                    <i class="fa-solid fa-circle-check"></i> Asistiré 
                                </span>
                            </div>
                            <span class="event-date">15 de mayo</span>
                        </div>
                        <div class="event-title">Bailetón jueves cultural</div>
                        <div class="event-description">
                            ¡El ritmo se apodera del campus!<br />
                            Ven a mover el cuerpo, liberar el estrés y disfrutar de una tarde llena de música, baile y buena vibra.
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
