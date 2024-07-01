const usuarioLogado = document.getElementById("usuarioLogado");
const webSocketProtocol = location.protocol == "https:" ? "wss:" : "ws:";
const connectionUrl = webSocketProtocol + "//" + location.host + "/ws?username=";

var socket;
function socketConnect() {
    
    socket = new WebSocket(connectionUrl + usuarioLogado.getAttribute('key'));
   
    socket.onopen = function (event) {

        console.log("socket opened", event);
        
    };
    socket.onclose = function (event) {
        console.log("socket close", event);
    };
    socket.onmessage = function (event) {
        menu.ListaUser();
        criarChat();
        var receivedMessage = JSON.parse(event.data);
    };
};
socketConnect();


