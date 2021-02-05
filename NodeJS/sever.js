var websocket = require('ws');

var webSocketSever = new websocket.Server({port:25500},()=>
{
    console.log("Sever has been started.");
} );

var wsList = [];

webSocketSever.on("connection", (ws, rq)=>
{
    console.log('client connected.');
    
    wsList.push(ws);

    ws.on("message",(data)=>
    {
        webSocketSever.clients.forEach(function each(client) 
        {
            if (client !== ws && client.readyState === websocket.OPEN) 
            {
                client.send(data,ws)
            }
        })

        //console.log("send from client : " + data);
        //BoardCast(data);
    });

    ws.on("close", ()=>
    {
        wsList = ArrayRemove(wsList, ws);
        console.log("client disconneted.");
    });
});



function ArrayRemove(arr, value)
{
    return arr.filter((element)=> 
    {
        return element != value;
    });
}

function BoardCast(data)
{
    for (var i = 0; i < wsList.length; i++) 
    {
        wsList[i].send(data);
    }
}