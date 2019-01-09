'use strict';

// so AJAX stands for Asynchronous JavaScript And XML
// "let's make requests and receive responses from
// XML-based services dynamically in the page."

// practical modern meaning:
// using the DOM API to send requests over the internet

// XMLHttpRequest is the traditional object used for this.

document.addEventListener("DOMContentLoaded", () => {
    let jokeHeader = document.getElementById("jokeHeader");
    let jokeBtn = document.getElementById("jokeBtn");
    let contentHeaders = new Headers()
    contentHeaders.append('Content-Type', 'application/json')

    jokeBtn.addEventListener("click", () => {
        // fetch API, modern way to do AJAX

        fetch("http://numbersapi.com/random/trivia?json")
            .then(response => 
                response.json())
            .then(obj => {
                jokeHeader.innerText = obj.text;
            })
            .catch(err => console.log(err));
    });


});

