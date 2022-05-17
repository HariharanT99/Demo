onmessage = function (e) {
    console.log('worker called')
    var d =new Date();
    let final = 0;
    for (let i = 0; i < 100000; i++) {
        final = d.getTime();
    }

    postMessage(final);
}