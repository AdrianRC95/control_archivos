/*******************************************************************************
 * Copyright (c) 2015 IBM Corp.
 *
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * and Eclipse Distribution License v1.0 which accompany this distribution.
 *
 * The Eclipse Public License is available at
 *    http://www.eclipse.org/legal/epl-v10.html
 * and the Eclipse Distribution License is available at
 *   http://www.eclipse.org/org/documents/edl-v10.php.
 *
 * Contributors:
 *    James Sutton - Initial Contribution
 *******************************************************************************/

/*
Eclipse Paho MQTT-JS Utility
This utility can be used to test the Eclipse Paho MQTT Javascript client.
*/

// Create a client instance
client = null;
connected = false;
userId = '78wekjfjp98yñldr63u234';


// Things to do as soon as the page loads
//document.getElementById("clientIdInput").value = 'js-utility-' + makeid();

// called when the client connects
function onConnect(context) {
  // Once a connection has been made, make a subscription and send a message.
  console.log("Client Connected");
  var statusSpan = document.getElementById("btnConexion");
    statusSpan.classList.remove('btn-danger');
    statusSpan.classList.add('btn-success');
    statusSpan.innerHTML = "Online...";
    //statusSpan.innerHTML = "Connected to: " + context.invocationContext.host + ':' + context.invocationContext.port + context.invocationContext.path + ' as ' + context.invocationContext.clientId;
  connected = true;
subscribe('demoHomeAutUTP');
  //setFormEnabledState(true);


}

function onFail(context) {
  console.log("Failed to connect");
  var statusSpan = document.getElementById("btnConexion");
    //statusSpan.innerHTML = 'Connection - Disconnected.';
    statusSpan.classList.remove('btn-success');
    statusSpan.classList.add('btn-danger');
    statusSpan.innerHTML = "Offline...";
  connected = false;
  //setFormEnabledState(false);
}

// called when the client loses its connection
function onConnectionLost(responseObject) {
  if (responseObject.errorCode !== 0) {
    console.log("Connection Lost: " + responseObject.errorMessage);
  }
    var statusSpan = document.getElementById("btnConexion");
    //statusSpan.innerHTML = 'Connection - Disconnected.';
    statusSpan.classList.remove('btn-success');
    statusSpan.classList.add('btn-danger');
    statusSpan.innerHTML = "Offline...";
  connected = false;
}

// called when a message arrives
function onMessageArrived(message) {
    console.log('Message Recieved: Topic: ', message.destinationName, '. Payload: ', message.payloadString, '. QoS: ', message.qos);
    //console.log(message);
    var mensaje = message.payloadString;
    var datos = mensaje.split('/');
    
    if(datos.length>2){
        var event = $('#'+datos[0]);
        var srt = datos[0].toLowerCase();
        if(srt.includes('foco')){
            var icon = event.children('i');
            if(datos[1] == 1) {
                icon.toggleClass('low');
                event.addClass('uno');
                event.removeClass('cero');
            }
            else if(datos[1] == 0) {
                icon.addClass('low');
                event.addClass('cero');
                event.removeClass('uno');              
            }
        }
        else if(srt.includes('puerta')) {
            var img = event.children('img');
            if(datos[1] == 1) {
                img.eq(0).removeClass('hidden');
                img.eq(1).addClass('hidden');
                event.addClass('uno');
                event.removeClass('cero');
            }
            else if(datos[1]==0) {
                img.eq(0).addClass('hidden');
                img.eq(1).removeClass('hidden');
                event.addClass('cero');
                event.removeClass('uno');
            }
        }
    }
    
  //var messageTime = new Date().toISOString();
  /* Insert into History Table
  var table = document.getElementById("incomingMessageTable").getElementsByTagName('tbody')[0];
  var row = table.insertRow(0);
  row.insertCell(0).innerHTML = message.destinationName;
  row.insertCell(1).innerHTML = safe_tags_regex(message.payloadString);
  row.insertCell(2).innerHTML = messageTime;
  row.insertCell(3).innerHTML = message.qos;


  if(!document.getElementById(message.destinationName)){
      var lastMessageTable = document.getElementById("lastMessageTable").getElementsByTagName('tbody')[0];
      var newlastMessageRow = lastMessageTable.insertRow(0);
      newlastMessageRow.id = message.destinationName;
      newlastMessageRow.insertCell(0).innerHTML = message.destinationName;
      newlastMessageRow.insertCell(1).innerHTML = safe_tags_regex(message.payloadString);
      newlastMessageRow.insertCell(2).innerHTML = messageTime;
      newlastMessageRow.insertCell(3).innerHTML = message.qos;

  } else {
      // Update Last Message Table
      var lastMessageRow = document.getElementById(message.destinationName);
      lastMessageRow.id = message.destinationName;
      lastMessageRow.cells[0].innerHTML = message.destinationName;
      lastMessageRow.cells[1].innerHTML = safe_tags_regex(message.payloadString);
      lastMessageRow.cells[2].innerHTML = messageTime;
      lastMessageRow.cells[3].innerHTML = message.qos;
  }*/

}

function connectionToggle(idUsuario){

    userId = idUsuario;
  if(connected){
    disconnect();
  } else {
    connect();
  }
}


function connect(){
    /*var hostname = document.getElementById("hostInput").value;
    var port = document.getElementById("portInput").value;
    var clientId = document.getElementById("clientIdInput").value;

    var path = document.getElementById("pathInput").value;
    var user = document.getElementById("userInput").value;
    var pass = document.getElementById("passInput").value;
    var keepAlive = Number(document.getElementById("keepAliveInput").value);
    var timeout = Number(document.getElementById("timeoutInput").value);
    var tls = document.getElementById("tlsInput").checked;
    var cleanSession = document.getElementById("cleanSessionInput").checked;
    var lastWillTopic = document.getElementById("lwtInput").value;
    var lastWillQos = Number(document.getElementById("lwQosInput").value);
    var lastWillRetain = document.getElementById("lwRetainInput").checked;
    var lastWillMessage = document.getElementById("lwMInput").value;*/
    
    var hostname = 'iot.eclipse.org';
    var port = 443;
    var clientId = userId;

    var path = '/ws';
    var user = '';
    var pass = '';
    var keepAlive = 60;
    var timeout = 5;
    var tls = true;
    var cleanSession = true;
    var lastWillTopic = '';
    var lastWillQos = 0;
    var lastWillRetain = false;
    var lastWillMessage = '';


    if(path.length > 0){
      client = new Paho.MQTT.Client(hostname, Number(port), path, clientId);
    } else {
      client = new Paho.MQTT.Client(hostname, Number(port), clientId);
    }
    console.info('Connecting to Server: Hostname: ', hostname, '. Port: ', port, '. Path: ', client.path, '. Client ID: ', clientId);

    // set callback handlers
    client.onConnectionLost = onConnectionLost;
    client.onMessageArrived = onMessageArrived;


    var options = {
      invocationContext: {host : hostname, port: port, path: client.path, clientId: clientId},
      timeout: timeout,
      keepAliveInterval:keepAlive,
      cleanSession: cleanSession,
      useSSL: tls,
      onSuccess: onConnect,
      onFailure: onFail
    };



    if(user.length > 0){
      options.userName = user;
    }

    if(pass.length > 0){
      options.password = pass;
    }

    if(lastWillTopic.length > 0){
      var lastWillMessage = new Paho.MQTT.Message(lastWillMessage);
      lastWillMessage.destinationName = lastWillTopic;
      lastWillMessage.qos = lastWillQos;
      lastWillMessage.retained = lastWillRetain;
      options.willMessage = lastWillMessage;
    }

    // connect the client
    client.connect(options);
    //var statusSpan = document.getElementById("connectionStatus");
    //statusSpan.innerHTML = 'Connecting...';
}

function disconnect(){
    console.info('Disconnecting from Server');
    client.disconnect();
    var statusSpan = document.getElementById("btnConexion");
    //statusSpan.innerHTML = 'Connection - Disconnected.';
    statusSpan.classList.remove('btn-success');
    statusSpan.classList.add('btn-danger');
    statusSpan.innerHTML = "Offline...";
    connected = false;
    //setFormEnabledState(false);

}

// Sets various form controls to either enabled or disabled
function setFormEnabledState(enabled){

    // Connection Panel Elements
    if(enabled){
      document.getElementById("clientConnectButton").innerHTML = "Disconnect";
    } else {
      document.getElementById("clientConnectButton").innerHTML = "Connect";
    }
    document.getElementById("hostInput").disabled = enabled;
    document.getElementById("portInput").disabled = enabled;
    document.getElementById("clientIdInput").disabled = enabled;
    document.getElementById("pathInput").disabled = enabled;
    document.getElementById("userInput").disabled = enabled;
    document.getElementById("passInput").disabled = enabled;
    document.getElementById("keepAliveInput").disabled = enabled;
    document.getElementById("timeoutInput").disabled = enabled;
    document.getElementById("tlsInput").disabled = enabled;
    document.getElementById("cleanSessionInput").disabled = enabled;
    document.getElementById("lwtInput").disabled = enabled;
    document.getElementById("lwQosInput").disabled = enabled;
    document.getElementById("lwRetainInput").disabled = enabled;
    document.getElementById("lwMInput").disabled = enabled;

    // Publish Panel Elements
    document.getElementById("publishTopicInput").disabled = !enabled;
    document.getElementById("publishQosInput").disabled = !enabled;
    document.getElementById("publishMessageInput").disabled = !enabled;
    document.getElementById("publishButton").disabled = !enabled;
    document.getElementById("publishRetainInput").disabled = !enabled;

    // Subscription Panel Elements
    document.getElementById("subscribeTopicInput").disabled = !enabled;
    document.getElementById("subscribeQosInput").disabled = !enabled;
    document.getElementById("subscribeButton").disabled = !enabled;
    document.getElementById("unsubscribeButton").disabled = !enabled;

}

function publish(event){
    //var topic = document.getElementById("publishTopicInput").value;
    //var qos = document.getElementById("publishQosInput").value;
    //var message = document.getElementById("publishMessageInput").value;
    //var retain = document.getElementById("publishRetainInput").checked
    var message = event.id;
    if(connected) {
        if(event.classList.contains('cero')) {
            message += '/1/';
        }
        else {
            message += '/0/';
        }
        console.info('Publishing Message: Topic: demoHomeAutUTP. QoS: 0. Message: ', message);
        message = new Paho.MQTT.Message(message);
        message.destinationName = 'demoHomeAutUTP';
        message.qos = 0;
        message.retained = false;
        client.send(message);
    }
}


function subscribe(topicSub){
    //var topic = document.getElementById("subscribeTopicInput").value;
    //var qos = document.getElementById("subscribeQosInput").value;
    var topic = topicSub;
    var qos = '0'
    console.info('Subscribing to: Topic: ', topic, '. QoS: ', qos);
    client.subscribe(topic, {qos: Number(qos)});
}

function unsubscribe(){
    var topic = document.getElementById("subscribeTopicInput").value;
    console.info('Unsubscribing from ', topic);
    client.unsubscribe(topic, {
         onSuccess: unsubscribeSuccess,
         onFailure: unsubscribeFailure,
         invocationContext: {topic : topic}
     });
}


function unsubscribeSuccess(context){
    console.info('Successfully unsubscribed from ', context.invocationContext.topic);
}

function unsubscribeFailure(context){
    console.info('Failed to  unsubscribe from ', context.invocationContext.topic);
}

function clearHistory(){
    var table = document.getElementById("incomingMessageTable");
    //or use :  var table = document.all.tableid;
    for(var i = table.rows.length - 1; i > 0; i--)
    {
        table.deleteRow(i);
    }

}


// Just in case someone sends html
function safe_tags_regex(str) {
   return str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
}

function makeid()
{
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    for( var i=0; i < 5; i++ )
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;
}


function on_off(event)
{
    var icon = $(event).children('i');
    icon.toggleClass('low');
}
function open_close(event)
{
    var img = $(event).children('img');
    img.toggleClass('hidden');
} 
