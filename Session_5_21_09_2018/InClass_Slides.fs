module InClass_Slides

// From Slides
// 05 Higher Order Functions 1, p. 7
let rec map f = function // val map : f:('a -> 'b) -> _arg1:'a list -> 'b list
    | [] -> []
    | hd::tl -> f hd :: map f tl

List.map List.rev [[1;2;3]; [4;5;6]] // val it : int list list = [[3; 2; 1]; [6; 5; 4]]

// 05 Higher Order Functions 1, p. 8
// Example: a function that adds one to each element in a list of integers
let rec incList ls = // val incList : ls:int list -> int list
    match ls with
    | [] -> []
    | hd::tl -> hd + 1 :: incList tl

incList [2;1;3;4] // val it : int list = [3; 2; 4; 5]

// Define incList through map:
let incList1 ls = let inc n = n + 1 in map inc ls // val incList1 : ls:int list -> int list
incList1 [1;2;3] // val it : int list = [2; 3; 4]

// Negate a list through map:
let negate x = -x
List.map negate [1 .. 10] // val it : int list = [-1; -2; -3; -4; -5; -6; -7; -8; -9; -10]

// 05 Higher Order Functions 1, p. 9
// Filter: removes all elements from a list that do not satisfy a given predicate
let rec filter predicate ls = // val filter : predicate:('a -> bool) -> ls:'a list -> 'a list
    match ls with
    | [] -> []
    | x::xs -> if predicate x then x :: filter predicate xs else filter predicate xs

// 05 Higher Order Functions 1, p. 10
// List.filter with guard ("when"); pattern when guard -> expr
let rec filter1 p l =
    match l with
    | [] -> []
    | hd::tl when p hd -> hd :: filter1 p tl
    | hd::tl -> filter1 p tl

// 05 Higher Order Functions 1, p. 11
// Fold
// (+)
let rec pclSum l = 
    match l with
    | [] -> 0
    | (l::ls) -> l + pclSum ls

// (*)
let rec product l =
    match l with
    | [] -> 1
    | x::xs -> x * product xs

// 05 Higher Order Functions 1, p. 12
// foldBack (fold from the right/backward)
// val foldBack : f:('a -> 'b -> 'b) -> l:'a list -> init:'b -> 'b
let rec foldBack f l init =
    match l with
    | [] -> init
    | x::xs -> f x (foldBack f xs init)

// Defining sum, product through foldBack: 
let sum xs = List.foldBack (+) xs 0
let product1 xs = List.foldBack (*) xs 1

// 05 Higher Order Functions 1, p. 13
// fold (from the left)
let rec fold f init l =
    match l with
    | [] -> init
    | x::xs -> fold f (f init x) xs

// 05 Higher Order Functions 1, p. 15
// Defining sum, product with fold (better):
let sum1 xs = List.fold (+) 0 xs
let product2 xs = List.fold (*) 1 xs

// 05 Lambda Currying Closures 2, p. 10,11 (Closures)
let mult i lst = List.map (fun x -> x * i) lst // val mult : i:int -> lst:int list -> int list
mult 10 [1; 3; 5; 7] // val it : int list = [10; 30; 50; 70]

let closureFun =
    let multi2 x y = x * y
    let triple = multi2 3 // partial application of multi2
    // triple is a closure that takes one arg
    printfn "%d" (triple 5) // 15