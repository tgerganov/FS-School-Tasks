module ExSet_02

//Exercise 2.1 - F# files

//Selecting these and evaluating with Alt+Enter
let x = 23
let myName = "Todor"
let y = 4 + 2
(* gives the following result:
val x : int = 23
val myName : string = "Todor"
val y : int = 6 *)

let a = 5
let b = let a = 10 in a + 5
let c = a + b 
(* val a : int = 5
   val b : int = 15
   val c : int = 20 *)

//Exercise 2.2 - Function Declaration I

let addNum1 a = a + 1 //val addNum1 : a:int -> int
addNum1 5 //val it : int = 6 

let addNum10 a = a + 10 //val addNum10 : a:int -> int
addNum10 5 //val it : int = 15

let addNum20 a = a + addNum10 10 //val addNum20 : a:int -> int
addNum20 5 //val it : int = 25

//Exercise 2.3 - Function Declaration II

let max2 a b = if a > b then a else b //val max2 : a:'a -> b:'a -> 'a when 'a : comparison

max2 1 2 //val it : int = 2
max2 2 1 //val it : int = 2
//TODO: Try with a ternary operator and pattern matching

let evenOrOdd a = if a % 2 = 0 then printfn "even number" else printfn "odd number" //val evenOrOdd : a:int -> unit
evenOrOdd 5 //odd number; val it : unit = ()
evenOrOdd 10 //even number; val it : unit = ()

let addXY a b = printfn "First int: %i, Second int: %i, Sum: %i" a b (a + b) //val addXY : a:int -> b:int -> unit
addXY 2 3 //First int: 2, Second int: 3, Sum: 5; val it : unit = ()

//----------An example for printing----------//
printfn "A string: %s. An int: %i. A float: %f. A bool: %b" "hello" 42 3.14 true
//-------------------------------------------//

//(Exercise 2.4 Optional)

let rec addNum_jk j k = //val addNum_jk : j:int -> k:int -> int
    if k = 0 then j 
    else addNum_jk (addNum10 j) (k-1)

addNum_jk 3 5 //val it : int = 53


