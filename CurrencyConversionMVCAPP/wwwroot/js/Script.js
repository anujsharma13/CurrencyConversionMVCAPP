let btn = document.getElementById('SRC');
let url = document.getElementById('url');

let btn1 = document.getElementById('DEST');
let url1 = document.getElementById('url1');


let changeresult = document.getElementById('changeresult');
let fetchbtn = document.getElementById('fetchbtn');

let Sourcename = document.getElementById('Sourcename');
let DestinationName = document.getElementById('DestinationName');


let Amt = document.getElementById('amount');

let prevAmt = document.getElementById('prevamt');
let prevsrc = document.getElementById('prevsrc');
let prevdest = document.getElementById('prevdest');

let prevresult = document.getElementById('prevresult');

let prevAmtlabel = document.getElementById('prevamtlabel');
let prevsrclabel = document.getElementById('prevsrclabel');
let prevdestlabel = document.getElementById('prevdestlabel');
let output = document.getElementById('output');
let Recenttransaction = document.getElementById('Recenttransaction');
let To = document.getElementById('To');
let Recentdiv = document.getElementById('Recentdiv');
let outputlabel = document.getElementById('outputlabel');
let Outputdiv = document.getElementById('Outputdiv');
let Difference = document.getElementById('Difference');
let Differencelabel = document.getElementById('Differencelabel');

let onrate = document.getElementById('onrate');
let onratelabel = document.getElementById('onratelabel');
console.log("ajax");
let Resultdata=0;
let AmtData = 0;
function addRowHandlers() {
    var table = document.getElementById("tab");
    var rows = table.getElementsByTagName("tr");
    var srcdata, destdata;
    for (i = 0; i < rows.length; i++) {
        var currentRow = table.rows[i];
        var createClickHandler = function (row) {
            return function () {
                var cell1 = row.getElementsByTagName("td")[0];
                var cell2 = row.getElementsByTagName("td")[1];
                var cell3 = row.getElementsByTagName("td")[2];
                var cell4 = row.getElementsByTagName("td")[3];
              
                 srcdata = cell1.innerHTML;
                destdata = cell2.innerHTML;
                Amtdata = cell3.innerHTML;
                Resultdata = cell4.innerHTML;
               
                
                console.log("id:" + srcdata + destdata + Amtdata + Resultdata);

                //prev data
                Recenttransaction.innerHTML = "Recent Transaction";
                prevAmt.innerHTML = "Amount : "+Amtdata;
                prevsrc.innerHTML = "From : "+srcdata.toUpperCase();
                prevdest.innerHTML = "To : "+destdata.toUpperCase();
                prevresult.innerHTML = "Value : " + Resultdata;
               
                //prev history label
                prevAmtlabel.innerHTML = "Prev Amount"
                prevsrclabel.innerHTML = "Prev Source"
                prevdestlabel.innerHTML = "Prev Destination"

                //styling
                prevAmt.style.border = "2px solid black";
               
            };
        };
        currentRow.onclick = createClickHandler(currentRow);
       

    }
  
}
btn.addEventListener('click', buttonclickhandler)
function buttonclickhandler() {
    console.log("clicked");

    let str = btn.value.substring(4, 6).toLowerCase();
    let image = "https://flagcdn.com/48x36/str.png";  
    url.setAttribute("src", image.substring(0, 26) + str + image.substring(29, 33));
    console.log(image.substring(0, 26) + str + image.substring(29, 33));
}

btn1.addEventListener('click', buttonclickhandlerDest)
function buttonclickhandlerDest() {
  
    console.log("clicked");

    let str = btn1.value.substring(4, 6).toLowerCase();
    let image = "https://flagcdn.com/48x36/str.png";

    url1.setAttribute("src", image.substring(0, 26) + str + image.substring(29, 33));
    console.log(image.substring(0, 26) + str + image.substring(29, 33));
}

fetchbtn.addEventListener('click', buttonclickhandle)
function buttonclickhandle() {
    console.log("clicked");
    let str = btn.value.substring(0, 3).toLowerCase();
    let str1 = btn1.value.substring(0, 3).toLowerCase();
    let amount = Amt.value;
  
    //tab.deleteRow(1);
    const xhr = new XMLHttpRequest();
    xhr.open('GET', "/Currency/Result?Source=" + str + "&Destination=" + str1 + "&Amount=" + amount, true);
    xhr.onprogress = function () {
        console.log('progress');
    }
    xhr.onload = function () {
        let parsed = JSON.parse(this.responseText);
        //console.log("-------------------------parsed----------------------------");
        //console.log(parsed);
        let result = JSON.parse(parsed);
        outputlabel.innerHTML="Converted Value"
        output.innerHTML = result['Result'];
        onratelabel.innerHTML = "At Rate";
        onrate.innerHTML = result['oneResult'];
       // Recenttransaction.innerHTML = "Recent Transaction";
        //Recentdiv.style.border = "outset";
        //Outputdiv.style.border = "outset"
       
        //Sourcename.innerHTML = str.toUpperCase();
        //changeresult.innerHTML = result["Result"];
        //DestinationName.innerHTML = str1.toUpperCase();
        let table = document.querySelector('table');
        
        var rowCount = 0;
        var rows = table.getElementsByTagName("tr");
        for (var i = 0; i < rows.length; i++) {
            if (rows[i].getElementsByTagName("td").length > 0) {
                rowCount++;
            }
        }
        if (rowCount >= 5) {
            table.deleteRow(1);
            var newrow = table.insertRow(5);
            var cell1 = newrow.insertCell(0);
            var cell2 = newrow.insertCell(1);
            var cell3 = newrow.insertCell(2);
            var cell4 = newrow.insertCell(3);
            cell1.innerHTML = str.toUpperCase();
            cell2.innerHTML = str1.toUpperCase();
            cell3.innerHTML = result['Amount'];
            cell4.innerHTML = result['Result'];
            //if (prevAmt.innerHTML.length > 0) {
            //    Differencelabel.innerHTML = "Current-Recent";
            //    Difference.innerHTML = (output.innerHTML - Resultdata);
            //}
            //let current = new Date();
            //let cDate = current.getFullYear() + '-' + (current.getMonth() + 1) + '-' + current.getDate();
            //let cTime = current.getHours() + ":" + current.getMinutes() + ":" + current.getSeconds();
            //let dateTime = cDate + ' ' + cTime;
            //cell5.innerHTML = dateTime;
        }
        else {
            var newrow = table.insertRow(rowCount+1);

            var cell1 = newrow.insertCell(0);
            var cell2 = newrow.insertCell(1);
            var cell3 = newrow.insertCell(2);
            var cell4 = newrow.insertCell(3);
            cell1.innerHTML = str.toUpperCase();
            cell2.innerHTML = str1.toUpperCase();
            cell3.innerHTML = result['Amount'];
            cell4.innerHTML = result['Result'];
            
            //if (prevAmt.innerHTML.length > 0) {
            //    Differencelabel.innerHTML = "Current-Recent";
            //    Difference.innerHTML = (output.innerHTML - Resultdata);
            //}
        //    let current = new Date();
        //    let cDate = current.getFullYear() + '-' + (current.getMonth() + 1) + '-' + current.getDate();
        //    let cTime = current.getHours() + ":" + current.getMinutes() + ":" + current.getSeconds();
        //    let dateTime = cDate + ' ' + cTime;
        //    cell5.innerHTML = dateTime;
        }
        if (rowCount > 0) {
            console.log("---------"+rowCount+"--------------");
            if (rowCount >= 5) {
                var number1 = table.rows[rowCount-1].cells.item(0).innerHTML;
                var number2 = table.rows[rowCount-1].cells.item(1).innerHTML;
                var number3 = table.rows[rowCount-1].cells.item(2).innerHTML;
                var number4 = table.rows[rowCount-1].cells.item(3).innerHTML;

                console.log(number1);
                console.log(number2);
                console.log(number3);
                console.log(number4);
                Recenttransaction.innerHTML = "Recent Transaction";
                prevAmt.innerHTML = "Amount : " + number3;
                prevsrc.innerHTML = "From : " + number1;

                prevdest.innerHTML = "To : " + number2;
                prevresult.innerHTML = "Value : " + number4;
            }
            else {
                var number1 = table.rows[rowCount].cells.item(0).innerHTML;
                var number2 = table.rows[rowCount].cells.item(1).innerHTML;
                var number3 = table.rows[rowCount].cells.item(2).innerHTML;
                var number4 = table.rows[rowCount].cells.item(3).innerHTML;

                console.log(number1);
                console.log(number2);
                console.log(number3);
                console.log(number4);
                Recenttransaction.innerHTML = "Recent Transaction";
                prevAmt.innerHTML = "Amount : " + number3;
                prevsrc.innerHTML = "From : " + number1;

                prevdest.innerHTML = "To : " + number2;
                prevresult.innerHTML = "Value : " + number4;
            }
        }
        ////let SourceVal = str.toUpperCase();
        //let ResultVal = result["Result"];
        //let DestVal = str1.toUpperCase();
        //let Now = new Date();
       /* let obj = { SourceVal, DestVal, ResultVal, Now };*/
        
        //console.log('---------------------------amont------------------------------------------------')
        //console.log(amount);
        //console.log('-------------------op=---------------------');
        //console.log(JSON.parse(localStorage.getItem(0)));
        //let output = JSON.parse(localStorage.getItem(0));
        //console.log('----------------------------0---------------------------------------');
        //console.log(output.SourceVal);
        //if (localStorage.length < 5) {

        //    let c = localStorage.length;
        //    console.log(c);
        //    localStorage.setItem(c, JSON.stringify(obj));
           
        //}
        //else {
        //    localStorage.removeItem(0);
        //    for (let i = 1; i < 5 ; i++)
        //    {
        //        let op = localStorage.getItem(i);
        //        localStorage.removeItem(i);
        //        let n = i;
        //        localStorage.setItem(n - 1, op);
        //    }
        //    localStorage.setItem(4, JSON.stringify(obj));
          
        //}
       
    }
    xhr.send();
}
/*setInterval(buttonclickhandle, 60000);*/
document.getElementById('amount').onchange = function () {
    let changedvalue = parseFloat(Amt.value);
   // Amt.value = changedvalue.toFixed(2);

};