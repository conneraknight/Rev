'use strict';

// so AJAX stands for Asynchronous JavaScript And XML
// "let's make requests and receive responses from
// XML-based services dynamically in the page."

// practical modern meaning:
// using the DOM API to send requests over the internet

// XMLHttpRequest is the traditional object used for this.



document.addEventListener("DOMContentLoaded", () => {
    let input = document.getElementById("jsonInput");
    let button = document.getElementById("inputBtn")

    button.addEventListener("click", () => {
        try{
            let proc = JSON.parse(input.value);
            console.log(proc)
        }
        catch(err){
            console.log(err)
            console.log("did not input valid json")
        }
    });
});

    


