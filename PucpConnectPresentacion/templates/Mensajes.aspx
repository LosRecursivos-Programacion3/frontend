<%@ Page Title="Mensajes" Language="C#"
    MasterPageFile="~/Masters/SectionLayout.master"
    AutoEventWireup="true" CodeBehind="Mensajes.aspx.cs"
    Inherits="PucpConnectPresentacion.templates.Mensajes" %>

<asp:Content ID="PageStyles" ContentPlaceHolderID="head" runat="server">
  <style>
    /* Envuelve todo y desplaza el chat hacia la derecha */
    .mensajes-page {
      margin-left: 220px;  /* Ajusta al ancho de tu sidebar global */
      box-sizing: border-box;
      height: calc(100vh - 56px); /* Resta la altura del navbar */
      overflow-y: auto;          /* Scroll interno si hace falta */
    }

    /* Panel de conversaciones */
    .chat-list {
      width: 200px;            /* Ancho fijo para tu lista de chats */
      border-right: 1px solid #dee2e6;
      overflow-y: auto;
    }

    /* Contenedor principal de chat */
    .chat-container { display:flex; height:100%; }
    .chat-main     { flex:1; display:flex; flex-direction:column; }
    .messages      { flex:1; padding:1rem; overflow-y:auto; background:#f8f9fa; }
    .chat-input    { display:flex; gap:.5rem; padding:.5rem; border-top:1px solid #dee2e6; background:#fff; }
    .message       { margin:.5rem 0; max-width:70%; padding:.5rem; border-radius:.3rem; background:#e9ecef; }
    .message.me    { margin-left:auto; background:#0d6efd; color:#fff; }
  </style>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="mensajes-page">
    <div class="chat-container">
      <div class="chat-list list-group" id="conversaciones"></div>
      <div class="chat-main">
        <div class="messages" id="messagesContainer"></div>
        <div class="chat-input">
          <input type="text" id="chatInput" class="form-control" placeholder="Escribe un mensaje…" />
          <button id="sendBtn" type="button" class="btn btn-primary d-flex align-items-center">
            <i class="bi bi-send-fill me-2"></i>
            <span>Enviar</span>
          </button>
        </div>
      </div>
    </div>
  </div>

<script type="text/javascript">
    ; (function () {
        const EMISOR_ID = <%= ((PucpConnectPresentacion.PUCPConnectWS.alumno)Session["usuarioActual"]).idAlumno %>;
        let RECEPTOR_ID = null;

        // Función que recarga el historial del chat activo
        function cargarHistorial() {
            const cont = document.getElementById("messagesContainer");
            cont.innerHTML = "";
            if (RECEPTOR_ID === null) return;
            PageMethods.CargarHistorial(EMISOR_ID, RECEPTOR_ID, function (msgs) {
                console.log(msgs);
                msgs.forEach(m => {
                    const d = document.createElement("div");
                    d.className = "message " + (m.EmisorId === EMISOR_ID ? "me" : "");
                    d.innerHTML = `
                      <span>${m.Contenido}</span>
                      <small class="d-block text-muted">${m.Timestamp}</small>
                    `;
                    cont.appendChild(d);
                });
                cont.scrollTop = cont.scrollHeight;
            });
        }

        // 1) Listar amigos SIN parametro, toma user de sesión en el server
        PageMethods.listarAmigos(function (amigos) {
            const lista = document.getElementById("conversaciones");
            lista.innerHTML = "";
            amigos.forEach(a => {
                const item = document.createElement("a");
                item.href = "#";
                item.className = "list-group-item list-group-item-action";
                item.dataset.receptorId = a.idAlumno;
                item.textContent = a.nombre;
                item.addEventListener("click", e => {
                    e.preventDefault();
                    // Selección visual
                    lista.querySelectorAll("a").forEach(x => x.classList.remove("active"));
                    item.classList.add("active");
                    // Actualizo receptor y cargo historial
                    RECEPTOR_ID = +item.dataset.receptorId;
                    cargarHistorial();
                });
                lista.appendChild(item);
            });
            // auto‐selecciona el primero
            const first = lista.querySelector("a");
            if (first) first.click();
        });

        // 2) WebSocket
        const host = "localhost:8080";  
        const proto = location.protocol === 'https:' ? 'wss:' : 'wss:';
        const ws = new WebSocket(`ws://${host}/PucpConnectWS/ws/chat?userId=${EMISOR_ID}`);
        ws.onopen = () => console.log("WebSocket conectado");
        ws.onerror = e => console.error("WS Error", e);
        ws.onclose = () => console.log("WebSocket cerrado");
        ws.onmessage = e => {
            const m = JSON.parse(e.data);
            // sólo muestro si pertenece a esta conversación
            if ((m.emisorId === EMISOR_ID && m.receptorId === RECEPTOR_ID) ||
                (m.emisorId === RECEPTOR_ID && m.receptorId === EMISOR_ID)) {
                const cont = document.getElementById("messagesContainer");
                const d = document.createElement("div");
                d.className = "message " + (m.emisorId === EMISOR_ID ? "me" : "");
                d.innerHTML = `
        <span>${m.contenido}</span>
        <small class="d-block text-muted">${m.timestamp}</small>
      `;
                cont.appendChild(d);
                cont.scrollTop = cont.scrollHeight;
            }
        };
        // 0) Previene cualquier submit accidental del <form>
        document.querySelector("form").addEventListener("submit", e => {
            e.preventDefault();
        });
        // 3) Envío de mensaje
        function send() {
            const txt = document.getElementById("chatInput").value.trim();
            if (!txt || RECEPTOR_ID === null) return;
            ws.send(JSON.stringify({
                emisorId: EMISOR_ID,
                receptorId: RECEPTOR_ID,
                contenido: txt
            }));
            document.getElementById("chatInput").value = "";
        }
        document.getElementById("sendBtn").onclick = send;
        document.getElementById("chatInput").onkeyup = e => { if (e.key === "Enter") send(); };
        // 2) Envío al click
        const sendBtn = document.getElementById("sendBtn");
        sendBtn.addEventListener("click", e => {
            e.preventDefault();
            send();
        });

        // 3) Envío al presionar Enter, sin submit
        const chatInput = document.getElementById("chatInput");
        chatInput.addEventListener("keydown", e => {
            if (e.key === "Enter") {
                e.preventDefault();
                send();
            }
        });
    })();

</script>

</asp:Content>
