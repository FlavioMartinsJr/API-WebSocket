
var menu = new Object();
const pesquisar = document.getElementById("pesquisar");
const textPesquisar = document.getElementById("textPesquisar");
const componetUser = document.getElementById("userBuscados");

var imgUserEnviado;
var nomeUserEnviado;
menu.ListaUser = function (){
    $.ajax({
        type: "GET",
        timeout: 50000,
        url: "/api/ListaUser",
        data: { text: textPesquisar.value },
        async: true,

        success: function (jsonRetornado) {
            componetUser.innerHTML = ''
            jsonRetornado.usuarioBuscado.result.forEach((item) => {
                if (item.id != usuarioLogado.getAttribute('key')) {

                    let divProfile = document.createElement("div");
                    divProfile.className = "profile-main";
                    divProfile.setAttribute('onclick', "ListaUserById(" + item.id + ");");

                    let img = document.createElement("img");
                    img.src = item.img;

                    let divProfileText = document.createElement("div");
                    divProfileText.className = "profile-text";

                    let h3 = document.createElement("h3");
                    h3.innerText = item.nome;

                    let p = document.createElement("p");
                    p.innerText = "Visto em " + item.dataAlteracao;

                    divProfileText.appendChild(h3);
                    divProfileText.appendChild(p);

                    let divProfileStatus = document.createElement("div");

                    if (item.ativo == true) {
                        divProfileStatus.className = "profile-status";
                    } else {
                        divProfileStatus.className = "profile-status inativo";
                    }
                    divProfile.appendChild(img);
                    divProfile.appendChild(divProfileText);
                    divProfile.appendChild(divProfileStatus);
                    componetUser.appendChild(divProfile);
                } else {
                    imgUserEnviado = item.img;
                    nomeUserEnviado = item.nome;
                }
            })
        }
    });
}

const headerChat = document.getElementById("header");
var usuarioRecebidoId;
var imgUserRecebido;
var nomeUserRecebido;

function ListaUserById(id) {
    $.ajax({
        type: "GET",
        timeout: 50000,
        url: "/api/ListaUserById",
        data: { id: id },
        async: true,

        success: function (jsonRetornado) {
            var item = jsonRetornado.usuarioBuscado.result;
            if (item.ativo == false) {
                return;
            }
            usuarioRecebidoId = item.id;
            headerChat.innerHTML = '';

            let divProfile = document.createElement("div");
            divProfile.className = "profile-main-sm";

            let img = document.createElement("img");
            imgUserRecebido = item.img;
            img.src = item.img;

            let divProfileText = document.createElement("div");
            divProfileText.className = "profile-text";

            let h3 = document.createElement("h3");
            nomeUserRecebido = item.nome;
            h3.innerText = nomeUserRecebido;

            let p = document.createElement("p");
            p.innerText = "Online";

            divProfileText.appendChild(h3);
            divProfileText.appendChild(p);
            divProfile.appendChild(img);
            divProfile.appendChild(divProfileText);

            let divTextCenter = document.createElement("div");
            divTextCenter.className = "text-center";
            let h2 = document.createElement("h2");
            h2.innerText = "Chat";
            divTextCenter.appendChild(h2);

            let divStatus = document.createElement("div");
            divStatus.className = "profile-status-sm";
            let h4 = document.createElement("h4");
            h4.innerText = item.dataAlteracao;
            divStatus.appendChild(h4);

            headerChat.appendChild(divProfile);
            headerChat.appendChild(divTextCenter);
            headerChat.appendChild(divStatus);

            criarChat();

            

        }
    });
}

const chatBody = document.getElementById("chat")
function criarChat() {
    $.ajax({
        type: "GET",
        timeout: 50000,
        url: "/api/ListaChatByUsersId",
        data: { userRecebidoId: usuarioRecebidoId, userEnviadoId: usuarioLogado.getAttribute('key') },
        async: true,

        success: function (jsonRetornado) {
            buttonsend.disabled = false;
            chatBody.innerHTML = ''
            jsonRetornado.chatBuscado.result.forEach((item) => {
                let nomeMensagem = nomeUserRecebido;
                let imgMensagem = imgUserRecebido;

                if (item.usuarioEnviadoId != usuarioRecebidoId) {
                    nomeMensagem = nomeUserEnviado;
                    imgMensagem = imgUserEnviado;
                }
                
                let divProfileMain = document.createElement("div");
                divProfileMain.className = "profile-main-chat";

                let imgChat = document.createElement("img");
                imgChat.src = imgMensagem;

                let divChatContent = document.createElement("div");
                divChatContent.className = "chat-content";

                let divProfileTextChat = document.createElement("div");
                divProfileTextChat.className = "profile-text-chat";

                let p1 = document.createElement("p");
                p1.innerText = nomeMensagem;

                let p2 = document.createElement("p");

                let h4 = document.createElement("h4");
                h4.innerText = item.mensagemEnviada;

                divProfileTextChat.appendChild(p1);
                divProfileTextChat.appendChild(p2);
                divChatContent.appendChild(divProfileTextChat);
                divChatContent.appendChild(h4);

                divProfileMain.appendChild(imgChat);
                divProfileMain.appendChild(divChatContent);
                chatBody.appendChild(divProfileMain);

            })
        }
    
    });

}

const buttonsend = document.getElementById("buttonSend");
const mensageSend = document.getElementById("mensageSend");
var enviar = new Object();
var numero = 0;
enviar.EnviarMensagem = function () {

    
    $.ajax({
        type: "POST",
        timeout: 50000,
        url: "/api/SendMenssage",
        data: { menssage: mensageSend.value, userRecebidoId: usuarioRecebidoId, userEnviadoId: usuarioLogado.getAttribute("key") },
        async: true,

        success: function (jsonRetornado) {
            var item = jsonRetornado.result.result;
            if (!socket || socket.readyState !== WebSocket.OPEN) {
                alert("socket not connected");
            }
            var data = item.mensagemEnviada;
            var message = {};
            message.Type = "chat";
            message.Sender = item.usuarioEnviadoId+"";
            message.Content = data;
            message.Receiver = item.usuarioRecebidoId+"";
            message.IsPrivate = false;
            socket.send(JSON.stringify(message));
            mensageSend.value = ''
            socket.onmessage = function (event) {
                menu.ListaUser();
                criarChat();
                numero = numero + 1;
                document.title = "Home - Chat (" + numero + ")"; 
                var receivedMessage = JSON.parse(event.data);
            };
            
                
        }
    });
    

}
buttonsend.onclick = function () {
    if (mensageSend.value == '') {
        return;
    }
    $(function () {
        enviar.EnviarMensagem();

    });
}
pesquisar.onclick = function () {
    $(function () {
        menu.ListaUser();

    });
}
$(function () {
    menu.ListaUser();

});
textPesquisar.onchange = function () {
    $(function () {
        menu.ListaUser();
    });
}

document.onclick = function () {
    numero = 0;
    document.title = "Home - Chat";
}