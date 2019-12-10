module TestExam_08_01_2019

open System
open Draft_session_2

//Start time: 10:30

//Q 1
//Q 1a
(*
The first function (f) takes x and y as single arguments.
The second function (g) takes a tuple(!) as argument.
*)

//Q 1b
let rec stringToList s =
    match s with
    |"" -> [] 
    |s -> s.[0]::stringToList s.[1 .. String.length s - 1]

//Testing:
//val stringToList : s:string -> char list
stringToList "Todor"
//val it : char list = ['T'; 'o'; 'd'; 'o'; 'r']

//Q 2
//Q 2a
type Vector =
| TwoDim of int*int //or float/double 
| ThreeDim of int*int*int
| FourDim of int*int*int*int
| FiveDim of int*int*int*int*int

//Q 2b
let vecLen (a:float, b:float) = sqrt((pown a 2) + (pown b 2)) 
//val vecLen : a:float * b:float -> float
vecLen (6.0, 8.0)
//val it : float = 10.0 -> Also called the magnitude of a vector; We use the well-known Pythagoras' theorem

//Q 2c
let vecAdd (a, b) (c, d) = ((a + c), (b + d))
//val vecAdd : a:int * b:int -> c:int * d:int -> int * int
vecAdd (8,13) (26,7) //val it : int * int = (34, 20)

//Q 3
//Q 3a
let rec rerun s n =
    match n with
    | 0 -> ""
    | _ -> s + rerun s (n-1)
//val rerun : s:string -> n:int -> string
rerun "code" 3 //"codecodecode"
rerun "code" 0 //val it : string = ""
//The case with negative n is not included. We would use "failwith" to throw an exception because of a StackOverflow.

//Q 3b -> TODO!

//Q 4
//Q 4a
let f1 i j k = 
    seq {
         for x in [0 .. i] do
             for y in [0 .. j] do
                 if x+y < k then yield (x,y) 
    }

List.ofSeq (f1 2 2 3)
//val it : (int * int) list = [(0, 0); (0, 1); (0, 2); (1, 0); (1, 1); (2, 0)]

//Q 4b
let f2 f p sq = Seq.map(fun x -> f x) (Seq.filter(fun x -> p x) (sq)) 
//We apply the Map function from the Seq module over the filtered sequence with the Filter function from the Seq module
//val f2 : f:('a -> 'b) -> p:('a -> bool) -> sq:seq<'a> -> seq<'b>

//Q 5
//Q 5a
type expr = 
| Const of int 
| BinOpr of expr * string * expr

Const(10) //1
BinOpr(Const(10), "+", Const(20)) //2
BinOpr(Const(1), "+", (BinOpr(Const(2), "*", Const(3)))) //3

//Q 5b -> TODO!

//Q 5c -> TODO!
