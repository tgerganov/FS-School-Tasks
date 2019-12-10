module Draft_session_3

open System

// From lecture slides p. 8
let classA18 = "IT-PCL1-A18"
classA18.Length // 11
classA18.[7] // '-'

// From lecture slides p. 13
let square x = x * x // Abbreviated
let square1 = fun x -> x * x // Non-abbreviated
let sqSpec = square (square (2+5)) // 2401

// From lecture slides p. 14
// Adding a type manually. It is usually / mostly not needed because of the type inference in F#
let add (x : float) y = x + y // val add : x:float -> y:float -> float

// From lecture slides p. 17
let rec factorial t = 
    match t with
    | 0 | 1 -> 1
    | t when t < 0 -> failwith "Negative arguments are illegal!" 
    | _ -> t * factorial (t-1)

factorial 6 // 720
factorial 0 // 1
factorial 1 // 1
factorial -1 // System.Exception: Negative arguments are illegal!

// From lecture slides p. 5 (Tuples_Lists)
let tupledAdd (x, y) = x + y

let vadd (a, b) (c, d) = (a + c), (b + d) // val vadd : a:int * b:int -> c:int * d:int -> int * int
vadd (6, 5) (2, 2) // val it : int * int = (8, 7)

let vsub (a:float, b:float) (c:float, d:float) = (a - c), (b - d) // val vsub : a:float * b:float -> c:float * d:float -> float * float
vsub (6.0, 5.0) (2.0, 2.0) // val it : float * float = (4.0, 3.0)

let vlen (a:float, b:float) = a**2.0 + b**2.0 // val vlen : a:float * b:float -> float
vlen (4.0, 3.0) // val it : float = 25.0

// From lecture slides p. 10 (Tuples_Lists)
let listTodi = [0..2..10] // val listTodi : int list = [0; 2; 4; 6; 8; 10]
listTodi.Length // val it : int = 6
List.length listTodi // same result (naturally); two ways of finding the length
List.sum listTodi // val it : int = 30; Here with sum -> only one way...

// Exercises 03/3a
// 3.1 
// a
let vowelToUpper c = 
    match c with
    |'a' -> 'A'
    |'e' -> 'E' 
    |'i' -> 'I'
    |'o' -> 'O'
    |'u' -> 'U'
    |_ -> c

vowelToUpper 'a' // A
vowelToUpper 't' // t

// b
let rec vowelToUpperInAString s =
    match s with
    |"" -> ""
    |s -> (vowelToUpper s.[0]).ToString() + vowelToUpperInAString s.[1..s.Length-1]

vowelToUpperInAString "Svetoslav" // val it : string = "SvEtOslAv"

// Exercises 03/3b
// 3.2
// a
let rec pclLength ls = 
    match ls with
    |[] -> 0
    |h::t -> 1 + pclLength t 

pclLength ['a';'b';'c'] // val it : int = 3

// b
let rec pclSum ls = 
    match ls with
    |[] -> 0
    |h::t -> h + pclSum t

pclSum [1;2;3] // val it : int = 6

// 3.3
let rec takeSome n ls =
    match n with
    |0 -> []
    |_ -> List.head ls :: takeSome (n-1) ls.Tail 

takeSome 2 [1;2;3] // val it : int list = [1; 2]
