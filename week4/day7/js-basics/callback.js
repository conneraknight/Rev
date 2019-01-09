'use strict';

function addNumber(a,b, callback)
{
    let result= a+b;

    return callback(result);
}

addNumber(3,4, console.log); // prints 7

//becomes useful because it is easy because of first class functions
//helpful because in javascript deal with events a lot, and doing
//other things when events fire
/////////////////
//callbacks are importatn because we
// do a lot of istening to/waiting for events
// in JS, and also asynchronous stuff

// often use arrow functions
addNumber(3,4,result => console.log("calculation done"));


function newCounter() {
    let inc = 0;
    
    return function (){
        return ++inc;
    }
}

let counter = newCounter();
//normally at this point, "inc" would dissapear from the stack
// because it has passed out of scope

console.log(counter());//prints 1
console.log(counter());//prints 2
console.log(counter());//prints 3

let counter2 = newCounter();

console.log(counter2());//prints 1
console.log(counter2());//prints 2
console.log(counter2());//prints 3

// in JavaScript, variables that are referenced by functions
// that are still in scope, themselves remain in scope

// in JavaScript, functions "close over" any variables they
//reference

// this behavior is called "closure"
// sometimes we call the functions themselves "closures"

// before ES6, we wanted "namespaces", we wnated to
//encapsulate private details and expose only
//needed functionality
//closure allows us to do this

// IIFE (immediately-invoked function expression)
let library = (function(){
    let privateData = 0;
    return {
        libraryMethod() {
            return privateData;
        }
    };
})();

//privateData is invisible to the outside
library.libraryMethod
