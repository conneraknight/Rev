<<<<<<< HEAD
console.log('main.js')

// JavaScript is dynamically typed
//variables have no types, only values have types

// JavaScript is interpreted, not compiled
// JavaScript is run in the browser
//  or, server-side with things like Node.JS

var x;

//numbers
// for integers, floating-point, whatever
x = 5;
x = 5.5;
//we have all the stuff that IEEE floating points
// are supposed to ahve
=======
console.log('main.js');

// JavaScript is dynamically typed
// variables have no types, only values have types

// JavaScript is interpreted, not compiled
// JavaScript is run in the browser
//   or, server-side with things like Node.JS

var x;

// numbers
// for integers, floating-point, whatever
// 64-bit floating-point number
x = 5;
x = 5.5;
// we have all the stuff that IEEE floating points
// are supposed to have
>>>>>>> dc21a5b17d55361a28b4d9eb33a55590333f7e9a
x = Infinity;
x = -Infinity;
x = -0;
x = NaN; // "not a number" is number type
<<<<<<< HEAD
x = "123abc"/6

//string
//single or double quotes, same thing
x = "asdf"

//boolean
x = true;
x = false;

//null
//typeof lies and says it's object
//but this has been kept for back compatibility
x = null;

//object
// we don't use classes as templates for ojbects in JS
x = {}; //object with no properties
//works like "dynamic" in C#

x.asdf = true;
x.server = 'abc';
console.log("value of x not real: " + x.notreal);
console.log("type of x not real: " + typeof(x.notreal));

//we can access the properties of objects
// with indexing syntax or dot syntax
console.log(x['abcd']);

// there's syntax for arrays but they are just objects as well
x = [1,2,3]

//functions are first-class objects
// functions are really just "object" type
// but typeof does call them "function"
//functions have parameter names, but not parameter types
//or return type.
function my_function(a,b,c){
    if (a == 1) return a;
}
//if no return statement, it returns undefined

//unpassed parameters will be "undefined"
console.log(my_function(1,2,3));

x = my_function;
x.ser = 'xyz';

//undefined
x = undefined;



console.log("value of x: " + x);
console.log("type of x: " + typeof(x));

//we standardized JavaScript under the name
// "ECMAScript" or "ES" for short
// "what version of JavaScript are we using"
// ES5
    // this is the baseline for all modern javascript
    // because all browsers support it
    // prototypal inheritance
// ES6 aka ES2015
    // 99 % support this
    //classes + interface
// ES7 aka ES2016
// ES2017
=======
x = "12asad3" / 6;

// string
// single or double quotes, same thing
x = "asdf";

// boolean
x = true;
x = false;

// null
// typeof lies and says it's object
// but this has been kept for back compatibility
x = null;

// object
// works like "dynamic" in C#
// get or set any property without "declaring" it
// we don't use classes as templates for objects in JS
x = {};
x.asdf = true;
x.erver = 'abc';

// we can access the properties of objects
// with indexing syntax or dot syntax
console.log(x["asdf"]);

// there's syntax for arrays but they are just objects as well
x = [1, 2, 3];

// functions are first-class objects
// functions are really just "object" type
//   but typeof does call them "function"
// functions have parameter names, but not parameter types
//  or return type.
function my_function(a, b, c = 5) {

    // if (a == 1) return a;
    console.log(b);
    console.log(c);
}
// (if no return statement, it returned undefined)

// un-passed parameters will be "undefined"
x = my_function();

x = my_function;
x.ser = 'asdsc';

// undefined
// x = undefined;

console.log(x);
console.log("value of x: " + x);
console.log("type of x: " + typeof(x));

console.log("value of x.notreal: " + x.notreal);
console.log("type of x.notreal: " + typeof(x.notreal));

// we standardized JavaScript under the name
// "ECMAScript" or "ES" for short
// "what version of JavaScript are we using"
//  ES5
    // this is the baseline for all modern javascript
    // because all browsers support it
    // prototypal inheritance
//  ES6 aka ES2015
    // classes + interfaces
//  ES2016
//  ES2017
>>>>>>> dc21a5b17d55361a28b4d9eb33a55590333f7e9a

// symbol
// (added in ES5, for GUIDs, unique IDs for things)

<<<<<<< HEAD
// there are lots of other languages that people have come
// up with that extend JavaScript and compile down to
//JavaScript

//TypeScript, made by Microsoft
//      adds opt-in strict typing to JavaScript
// CoffeeScript

//sometimes people call this "transpilation"
=======
// there are lots of other languages that people have come up with that extend JavaScript and compile down to JavaScript

// TypeScript, made by Microsoft
//     adds opt-in strict typing to JavaScript
// CoffeeScript

// sometimes people call this "transpilation"
>>>>>>> dc21a5b17d55361a28b4d9eb33a55590333f7e9a
// often we say we transpile to JavaScript

// we also transpile ES6 to ES5
// any higher version we can transpile to a lower version
