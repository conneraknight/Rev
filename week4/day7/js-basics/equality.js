<<<<<<< HEAD

function compare(a,b) {
    console.log("a: "+ a + ", " + b);
    // "double equals" and "triple equals"
    // double equals coerces the type of the values
    // to try to "compare value without caring about type"
    console.log("a == b: "+ (a == b));
    console.log("a === b: "+ (a === b));
=======
function compare(a, b) {
    console.log("a: " + a + ", b: " + b);
    // "double equals" and "triple equals"
    // double equals coerces the type of the values
    // to try to "compare value without caring about type"
    console.log("a == b: " + (a == b));
    console.log("a === b: " + (a === b));
>>>>>>> dc21a5b17d55361a28b4d9eb33a55590333f7e9a
    console.log();
}

compare(5, "5");
compare({}, "");
<<<<<<< HEAD

=======
>>>>>>> dc21a5b17d55361a28b4d9eb33a55590333f7e9a
compare(null, "");
compare(null, undefined);

// always use triple equals aka. "strict equality"
<<<<<<< HEAD
// not "loose equality"
=======
// not "loose equality"
>>>>>>> dc21a5b17d55361a28b4d9eb33a55590333f7e9a
