module InClass_Slides

// From Slides
// 04 List Comprehensions, p. 6
let numbersNear x =
    [   
        yield x - 1
        yield x
        yield x + 1
    ]

numbersNear 3 // val it : int list = [2; 3; 4]

// 04 List Comprehensions, p. 7
let x =
    [ let negate x = -x
      for i in 1 .. 10 do
        if i % 2 = 0 then
            yield negate i
        else
            yield i ] // val x : int list = [1; -2; 3; -4; 5; -6; 7; -8; 9; -10]

// 04 List Comprehensions, p. 8
let multiplesOf x = [ for i in 1 .. 10 do yield x * i ] // val multiplesOf : x:int -> int list
let multiplesOf2 x = [ for i in 1 .. 10 -> x * i ] // Using "->" instead of "do yield", abbreviated version

// 04 List Comprehensions, p. 9
// Allowed usage of patterns with "for":
let pclSqrs n = [ for i in 1 .. n -> (i, i*i) ] // val pclSqrs : n:int -> (int * int) list
let pclSqrsAdd n = [ for (i,psq) in pclSqrs n -> i + psq ] // val pclSqrsAdd : n:int -> int list
pclSqrsAdd 4 // val it : int list = [2; 6; 12; 20]

// yield! (yield Bang) (puts a whole list (incl. sublists) of values into the output list)
let a = [for a in 1 .. 5 do
         match a with
            | 3 -> yield! ["p";"c";"l"]
            | _ -> yield a.ToString()
        ] // val a : string list = ["1"; "2"; "p"; "c"; "l"; "4"; "5"]

// 04 List Comprehensions, p. 10
// Allowed usage of patterns with "yield":
let listWithYield = 
    [ for i in 0 .. 10 .. 20 do
        yield [i .. 1 .. i+9]] 
(* val listWithYield : int list list =
  [[0; 1; 2; 3; 4; 5; 6; 7; 8; 9]; [10; 11; 12; 13; 14; 15; 16; 17; 18; 19];
   [20; 21; 22; 23; 24; 25; 26; 27; 28; 29]]
*)

let listWithYieldBang =
    [ for i in 0 .. 10 .. 20 do
        yield! [ i .. 1 .. i+9 ] ]
(* val listWithYieldBang : int list =
  [0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 15; 16; 17; 18; 19; 20;
   21; 22; 23; 24; 25; 26; 27; 28; 29]
*)

// 04b Error Handling, p. 2
let primesUnderMax n = // val primesUnderMax : n:int -> int list
    [ for i in 0 ..  n do
        if i % 2 > 0 then
         yield i ]

primesUnderMax 20 // val it : int list = [1; 3; 5; 7; 9; 11; 13; 15; 17; 19] -> That solution finds the odd numbers rather than the primes :-(

// Solution for finding primes from StackOverflow, implementing the Sieve of Eratosthenes
// This implementation won't work for very large lists but it illustrates the elegance of a functional solution.
let rec sieve = function
    | (p::xs) -> p :: sieve [ for x in xs do if x % p > 0 then yield x ]
    | []      -> []

let primes = sieve [2..20]  
printfn "%A" primes // val primes : int list = [2; 3; 5; 7; 11; 13; 17; 19]

// 04b Error Handling, p. 7
// Factorial with error handling:
let rec factorialFailWith n =
    match n with
    | 0 -> 1
    | _ -> if n > 0
            then n * factorialFailWith (n-1)
            else failwith "Non natural number argument to factorialFailWith"
      
factorialFailWith 6 // val it : int = 720
factorialFailWith -1 // System.Exception: Non natural number argument to factorialFailWith


// InClass Drafts
(* let a = [ for a in 1 .. 5 do
          match a with
              | 3 -> yield! ["p"; "c"; "l"]
              | _ -> yield a.ToString()
  ]

let rec pclFold f acc ls =
    match ls with
    | [] -> acc
    | (h::t) -> h + pclFold f acc t 


let rec factorialFailWith n = 
    match n with
        | 0 -> 1
        | _ -> if n > 0
                then n * factorialFailWith (n - 1)
                else failwith "Non natural..."

let result = factorialFailWith -2

let pclSumWithFold plist func acc = 
    pclFold plist func acc

let fSum a b = a + b *)