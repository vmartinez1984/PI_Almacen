let conversationInterval;
let userOnlineInterval;
let usersOnlineInterval;
var lastChatId = 1;
var isBussy = false;

$('document').ready(function () {
    getListUsers();
    repeatSetUserOnLineEveryXTime();
});

function repeatEveryXSeconds() {
    console.log("inicio")
    conversationInterval = setInterval(isLastChatId, 2000);
}

function repeatGetUserOnLineEveryXTime() {
    usersOnlineInterval = setInterval(getUsersOnline, 5000)
}

function repeatSetUserOnLineEveryXTime() {
    userOnlineInterval = setInterval(setUserOnline, 2000)
}

function getListUsers() {
    var url;

    url = "/api/users";
    fetch(url).then(
        response => {
            if (response.ok) {
                return response.json();
            } else {
                throw response;
            }
        }
    ).then(response => {
        //console.log(response);
        fillListUsers(response);
        repeatGetUserOnLineEveryXTime();
    });
}

function fillListUsers(response) {
    let divList;

    divList = document.getElementById("divListUusers");
    response.forEach(element => {
        var div;
        var divStatus;
        var divRow;

        divRow = document.createElement("div");
        div = document.createElement("div");
        divStatus = document.createElement("div");

        divRow.className = "row"
        div.innerHTML = element.name;
        div.className = "col-md-5"
        divStatus.className = "col-md-7"
        divStatus.innerHTML = "<p class='text-success' id='user_" + element.id + "'><span id='spanOnLine_" + element.id + "'></span> <button class='btn btn-success btn-sm' onclick='onclick_chatear(" + userIdSource + "," + element.id + "," + '"' + element.name + '"' + ");'>Chatear</button> </p>"
        divRow.appendChild(div)
        divRow.appendChild(divStatus)
        setInputHidden(divRow, element.id);
        divList.append(divRow);
        //console.log(element)
    });
}

function setInputHidden(divRow, userId) {
    var inputHidden;

    inputHidden = document.createElement("input");
    inputHidden.type = "hidden";
    inputHidden.value = userId;
    inputHidden.name = "lastChatId_" + userId
    divRow.appendChild(inputHidden);
}

function onclick_chatear(userIdSource, userIdDestiny, userNameDestiny) {
    $("#profile-tab").tab('show');
    document.getElementById('userIdSource').value = userIdSource;
    document.getElementById('userIdDestiny').value = userIdDestiny;
    document.getElementById('userNameDestiny').innerHTML = userNameDestiny;
    document.getElementById('message').focus();
    getConversation();
    repeatEveryXSeconds();
}

function onclick_sendMessage() {
    var myHeaders = new Headers();
    myHeaders.append("accept", "*/*");
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify({
        "userIdSource": document.getElementById("userIdSource").value,
        "message": document.getElementById("message").value,
        "userIdDestiny": document.getElementById("userIdDestiny").value
    });

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };

    fetch("/Api/Chat", requestOptions)
        .then(response => {
            if (response.ok)
                return response.json();
            else
                throw response;
        })
        .then(result => {
            //console.log(result);
            document.getElementById("message").value = '';
            getConversation();
        })
        .catch((error) => { console.log(error) });
}

function getConversation() {
    var userIdSource;
    var userIdDestiny;
    var url;

    userIdSource = document.getElementById("userIdSource").value
    userIdDestiny = document.getElementById("userIdDestiny").value
    url = "/Api/Chat/" + userIdSource + "/" + userIdDestiny

    fetch(url)
        .then(response => {
            if (response.ok)
                return response.json();
            else
                throw response;
        })
        .then(result => {
            isBussy = true
            //console.log(result);
            var conversation

            conversation = document.getElementById("divConversation");
            conversation.innerHTML = '';
            result.forEach(item => {
                var p
                var blockquote;

                p = document.createElement("p");
                if (item.userIdSource == userIdSource)
                    p.className = "text-left"
                else
                    p.className = "text-right"
                p.innerHTML = item.message + "<footer class='blockquote-footer'>" + item.userNameSource + "</footer>";
                blockquote = document.createElement("blockquote")
                //blockquote.className = "blockquote"
                blockquote.append(p)
                conversation.append(blockquote)
                setLastChatId(item.id)
            });
            isBussy = false
        })
        .catch(error => { console.log(error); isBussy = false; });
}

function setLastChatId(lastId) {
    if (lastChatId <= lastId)
        lastChatId = lastId
}

function isLastChatId() {
    //debugger;
    var url

    url = "/Api/Chat/" + lastChatId + "/IsLast"
    if (isBussy == false) {
        isBussy = true
        fetch(url)
            .then(response => {
                if (response.ok)
                    return response.json();
                else
                    throw response;
            })
            .then(result => {
                //debugger;
                console.log(result);
                if (result.isLast) {
                    //tenemos el ultimo chatId
                } else {
                    console.log("Obteniendo conversación")
                    getConversation();
                }
                isBussy = false
            })
            .catch(error => {
                isBussy = false
                console.log(error)
            });
    }
}

function onkeyup_detectEnter(event) {
    var keycode = event.keyCode;
    //console.log(keycode)
    if (keycode == '13') {
        onclick_sendMessage();
    }
}

function getUsersOnline() {
    var url;

    url = "/api/users/online";
    fetch(url)
        .then(
            response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw response;
                }
            }
        )
        .then(response => {
            //console.log(response);
            response.forEach(item => {
                var span;

                span = document.getElementById("spanOnLine_" + item.userId)
                if (item.online == true) {
                    span.className = "text-success";
                    span.innerHTML = "online"
                } else {
                    span.className = "text-danger";
                    span.innerHTML = "offline"
                }
            });
        })
        .catch((error) => { console.log(error); });
}

function setUserOnline() {
    var url;
    var myHeaders = new Headers();
    myHeaders.append("accept", "*/*");
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify({
        "userId": userIdSource,
    });

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };

    url = "/api/users/online";
    fetch(url, requestOptions)
        .then(
            response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw response;
                }
            }
        )
        .then(response => {
            //console.log(response);            
        })
        .catch((error) => { console.log(error); });
}