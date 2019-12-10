module HandIn_1

// 1.1
let myInfoTuple = ("Todor Milev Gerganov", 246684) // val myInfoTuple : string * int = ("Todor Milev Gerganov", 246684)

let deTupleMyInfo (name:string, number:int) = // val deTupleMyInfo : name:string * number:int -> unit
    printfn "My name is: %s" name
    printfn "My student number is: %d" number

deTupleMyInfo myInfoTuple
(* My name is: Todor Milev Gerganov
   My student number is: 246684
   val it : unit = () *)

// Another way 1 (unofficial):
let deTupleMyInfo1 = printfn "%A" myInfoTuple
(* ("Todor Milev Gerganov", 246684)
   val deTupleMyInfo : unit = () *)

// Another way 2 (unofficial):
let deTupleMyInfo2 (a, b) = printfn "%A" (a, b)
deTupleMyInfo2 myInfoTuple
(* ("Todor Milev Gerganov", 246684)
   val it : unit = () *)

// 1.2
let vowelToUpper c = // val vowelToUpper : c:char -> char
    match c with
    |'a' -> 'A'
    |'e' -> 'E'
    |'i' -> 'I'
    |'o' -> 'O'
    |'u' -> 'U'
    |c -> c

vowelToUpper 'i' // val it : char = 'I'
vowelToUpper 't' // val it : char = 't'

// 1.3
let rec upperVowelStr str = // val upperVowelStr : str:string -> string
    match str with
    | "" -> ""
    | str -> (vowelToUpper (str.[0])).ToString() + upperVowelStr (str.[1 .. String.length str - 1]) 

upperVowelStr "Todor" // val it : string = "TOdOr"
upperVowelStr "Functional Programming" // val it : string = "FUnctIOnAl PrOgrAmmIng"

// 1.4
let rec pclAppend ls1 ls2 = 
    match ls1 with
    | [] -> ls2
    | h::t -> h::pclAppend t ls2 // val pclAppend : ls1:'a list -> ls2:'a list -> 'a list

pclAppend [1;2;3][4;5;6] // val it : int list = [1; 2; 3; 4; 5; 6]
pclAppend [4;7;10][12] // val it : int list = [4; 7; 10; 12]