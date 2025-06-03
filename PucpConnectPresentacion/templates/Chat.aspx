<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Chat.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="PucpConnectPresentacion.templates.Chat" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Panel Izquierdo -->
    <div class="sidebar">
        <div class="chat-header">
            <i class="bi bi-arrow-left"></i> &nbsp; <span>Chats</span>
        </div>

        <div class="chat-preview">
            <img src="..\Images\profile-5.jpg" class="rounded-circle" alt="Foto" />
            <div class="chat-info">
                <div><strong>David Allasi</strong></div>
                <div class="text-muted small">Hey, rony</div>
            </div>
            <div class="chat-time">23:25 PM</div>
        </div>

        <div class="icon-bar">
            <i class="bi bi-chat-dots-fill"></i>
            <i class="bi bi-people-fill"></i>
        </div>
    </div>

    <!-- Panel Derecho -->
    <div class="chat-main">
        <div class="chat-topbar">
            <div>
                <strong>David Allasi</strong> <span class="text-success small">Online</span>
            </div>
            <i class="bi bi-person-circle fs-4"></i>
        </div>

        <div class="messages">
            <div class="message">
                Hey rony <span class="time">23:25 PM</span>
            </div>
        </div>

        <div class="chat-input">
            <input type="text" class="form-control" placeholder="Que pasa david 😊" />
            <button class="btn btn-primary" type="button">
                <i class="bi bi-send-fill"></i>
            </button>
        </div>
    </div>
</asp:Content>
