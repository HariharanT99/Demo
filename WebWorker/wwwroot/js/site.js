// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//const jstz = require("./jstz");

// Write your JavaScript code.

const workBtn = document.getElementById('work-btn');

workBtn.addEventListener('click', () => {

    if (window.Worker) {
        console.log("Worker");

        const myWorker = new window.Worker("js/worker.js");
        myWorker.postMessage("do work");

        myWorker.onmessage = function (e) {
            document.getElementById('output').innerHTML = e.data;
        }
    }

    //document.getElementById('output').innerHTML = final;
});

const btn = document.getElementById('btn');
btn.addEventListener('click', () => {
    document.getElementById('random').innerHTML = "random";
});

onload = () => {
    var tzObj = jstz;
    var timeZoneCode = tzObj.timezone_name;
    console.log(timeZoneCode);

    const timezone = Intl.DateTimeFormat().resolvedOptions().timeZone;
    console.log(timezone);

    console.log(new Date().toTimeString().slice(9));
    console.log(Intl.DateTimeFormat().resolvedOptions().timeZone);
    console.log(new Date().getTimezoneOffset());
    console.log(new Date().getTimezoneOffset() / -60);
    console.log(window.location.href)
}