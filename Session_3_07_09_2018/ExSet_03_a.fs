module ExSet_03_a

//Exercise 3.1 - Pattern matching and recursion

//a
let vowelToUpper c = 
    match c with
    | 'a' -> 'A'
    | 'e' -> 'E'
    | 'i' -> 'I'
    | 'o' -> 'O'
    | 'u' -> 'U'
    | c -> c

vowelToUpper 'a' //val it : char = 'A'
vowelToUpper 't' //val it : char = 't'

//b
let rec vowelToUpperInStr s = //val vowelToUpperInStr : s:string -> string
    match s with
    | "" -> ""
    | s -> (vowelToUpper s.[0]).ToString() + vowelToUpperInStr s.[1 .. (String.length s) - 1]

vowelToUpperInStr "Functional Programming" //val it : string = "FUnctIOnAl PrOgrAmmIng"
vowelToUpperInStr "Todor" //val it : string = "TOdOr"
