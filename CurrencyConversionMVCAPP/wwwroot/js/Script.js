let btn = document.getElementById('SRC');
let url = document.getElementById('url');

let btn1 = document.getElementById('DEST');
let url1 = document.getElementById('url1');


let changeresult = document.getElementById('changeresult');
let fetchbtn = document.getElementById('fetchbtn');

let Sourcename = document.getElementById('Sourcename');
let DestinationName = document.getElementById('DestinationName');

let prevop = document.getElementById('PrevOp');

let Amt = document.getElementById('amount');

console.log("ajax");

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

    const xhr = new XMLHttpRequest();
    xhr.open('GET', "/Currency/Result?Source=" + str + "&Destination=" + str1, true);
    xhr.onprogress = function () {
        console.log('progress');
    }
    xhr.onload = function () {
        let parsed = JSON.parse(this.responseText);
        console.log("-------------------------parsed----------------------------");
        console.log(parsed);
        let result = JSON.parse(parsed);

        Sourcename.innerHTML = str.toUpperCase();
        changeresult.innerHTML = result["Result"];
        DestinationName.innerHTML = str1.toUpperCase();
       
       
        let SourceVal = str.toUpperCase();
        let ResultVal = result["Result"];
        let DestVal = str1.toUpperCase();
        let Now = new Date();
        let obj = { SourceVal, DestVal, ResultVal, Now };
       
        console.log('---------------------------amont------------------------------------------------')
        console.log('-------------------op=---------------------');
        console.log(JSON.parse(localStorage.getItem(0)))
        if (localStorage.length < 5) {

            let c = localStorage.length;
            console.log(c);
            localStorage.setItem(c, JSON.stringify(obj));
           
        }
        else {
            localStorage.removeItem(0);
            for (let i = 1; i < 5 ; i++)
            {
                let op = localStorage.getItem(i);
                localStorage.removeItem(i);
                let n = i;
                localStorage.setItem(n - 1, op);
            }
            localStorage.setItem(4, JSON.stringify(obj));
          
        }
       
    }
    xhr.send();
}
/*setInterval(buttonclickhandle, 60000);*/