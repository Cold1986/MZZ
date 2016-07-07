 var xmlHttp;
function createxmlhttprequest() {
    try {
        xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
    } catch (_e) {  
        try {
            xmlHttp = new ActivrXobject("Microsoft.XMLHTTP");
        } catch (_E) { }
    }
    if (!xmlHttp && typeof XMLHttpRequest != 'undefined') {
        try {
            xmlHttp = new XMLHttpRequest();
        }
        catch (e) {
            xmlHttp = false;
        }
    }
}

function move(id, data, direction, total) {
    
    createxmlhttprequest();
    var url = "move.aspx?id=" +id + "&data=" + data + "&direction=" + direction + "&total=" + total + "&date=" + new Date();
   
    xmlHttp.open("GET", url, true);
   
    xmlHttp.onreadystatechange = updatepage;
    xmlHttp.send(null);
   
    function updatepage() {

        if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
           
            var response = xmlHttp.responseText;
           
            window.location.reload();


        }
        else {
          
        }
    }
}