'use strict';


console.log("here")
// so AJAX stands for Asynchronous JavaScript And XML
// "let's make requests and receive responses from
// XML-based services dynamically in teh page."

//practical modern meaning:
// using the DOM API to send requests over the internet

// XMLHttpRequest is the traditional object used for this.

/*
function ajaxGet{
    URL,
    success,
    failure = res => console.log(res)){
        let xhr = new XMLHttpRequest();

        xhr.addEventListener("readystatechange", () =>{
            console.log(`ready-state is now: ${xhr.readyState}`);
            if(xhr.readyState === 4){
                // we've recieved the response
                // get the response body text
                let responseJSON = xhr.response;
                console.log(responseJSON);
                //if status code is success
                if(xhr.status >= 200 && xhr.status < 300)
                {
                    //success
                    // (DOM API provides JSON deserialize with
                    // JSON.parse()
                    // and JSON serialize with
                    // JSON.serialize())
                    let responseObj = JSON.parse(responseJSON);
                    console.log(responseObj);
                    let joke = responseObj.value.joke;
                    //jokeHeader.innerText = joke;
                }
            }
            xhr.open("GET", "https://api.icndb.com/jokes/random");
            xhr.send();

            console.log("request about to be sent.")
        });
    }
}
*/
debugger
document.addEventListener("DOMContentLoaded", () => {
    let jokeHeader = document.getElementById("jokeHeader");
    let jokeBtn = document.getElementById("jokeBtn");
    let jokeFetchBtn = document.getElementById("jokeFetchBtn");


    jokeBtn.addEventListener("click", () => {
        debugger
        let xhr = new XMLHttpRequest();

        xhr.addEventListener("readystatechange", () =>{
            debugger
            console.log(`ready-state is now: ${xhr.readyState}`);
            if(xhr.readyState === 4){
                // we've recieved the response
                // get the response body text
                let responseJSON = xhr.response;
                console.log(responseJSON);
                //if status code is success
                if(xhr.status >= 200 && xhr.status < 300)
                {
                    //success
                    // (DOM API provides JSON deserialize with
                    // JSON.parse()
                    // and JSON serialize with
                    // JSON.serialize())
                    let responseObj = JSON.parse(responseJSON);
                    console.log(responseObj);
                    let joke = responseObj.value.joke;
                    //jokeHeader.innerText = joke;
                }
            }
            
        });
        xhr.open("GET", "http://api.icndb.com/jokes/random");
            xhr.send();

            console.log("request about to be sent.")
        });
    jokeFetchBtn.addEventListener("click", () => {
        // fetch API, modern way to do AJAX
        fetch("http://api.icndb.com/jokes/random")
        .then(response => response.json())
        .then(obj => {
            // Response object we get back has a method to
            // deserialize the body as JSON
            //debugger //breakpoint
            jokeHeader.innerText = obj.value.joke;
        })
        .catch(err => console.log(err));

        // we can chain promises like this -
        // the .json() method returns a proise
        // to get the whole response body and
        // deserialize it

        // catch will catch any error from along the
        // chain
        // or, we can handle an error from one of them
        //using 2nd function argument to .then.
    })

    

});

//basically everything is on the window object, since it's the global object

// task 1: make a webpage that allows you to
// type JSON in a <textare> element, and then
// click a button to print it out to the console
// as a JS object. handle any errors gracefully
// with try/catch

//task 2: make a webpage that somehow makes
//requests to a different API from teh Chuck Norris
// Joke API, and somehow show the results on the page.