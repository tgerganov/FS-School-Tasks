module Draft_session_2

// From lecture slides, p. 20

/// A very simple constant integer
let i1 = 1
/// A second very simple constant integer
let i2 = 2
/// Add two integers
let i3 = i1 + i2
/// A function on integers
let f x = 2*x*x-5*x+3
/// The result of a simple computation
let result = f (i3 + 4)

// From lecture slides, p. 21
// Example for recursion with factorial
let rec factorial x =
    if x <= 1 then
        1
    else
        x * factorial (x - 1)

// Usage:
factorial 6 // 720

// Tuples
let pointA = (32, 42)
let dataB = (1, "fred", 3.1415)
let swap (a, b) = (b, a)
let pointB = swap pointA

// From lecture slides, p. 22
// Lists

/// The empty list
let listA = []
let listB = [1; 2; 3]
let oddNums = [1; 3; 5; 7; 9]
let evenNums = [2; 4; 6; 8; 10]
/// A list with 3 integers. Note that head::tail constructs a list.
let listC = 1 :: [2; 3]
let vowels = ['a'; 'e'; 'i'; 'o'; 'u']
let squaresOfOneToTen = [for x in 1..10 -> x*x]

// Exercises 01
// An element can be added to the end of the list by using e.g. @[13]. This is however not optimal solution.

// Exercises 02
// 2.1
(* If we have a loaded module (F# source file) in the project,
we can use it by adding "open[module]" in the Program file (like "using" in C#) *)
let a = 5
let b = let a = 10 in a + 5 // 15
let c = a + b // 20

// 2.2
let addNum1 a = a + 1
addNum1 5 // 6

let addNum10 b = b + 10
addNum10 5 // 15

let addNum20 c = c + addNum10 10
addNum20 5 // 25

// 2.3
let max2 a b = 
    if a > b then a else b

max 5 6 // 6

let evenOrOdd c = 
    if c%2 = 0 then printfn "Even number"
    else printfn "Odd number"

evenOrOdd 4 // Even number
evenOrOdd 7 // Odd number

let addXY a b = 
    printfn "%d, %d" a b
    a + b

addXY 3 2 // 3, 2 val it : int = 5

// 2.4
let rec addNumSpecial j k =
    if k <= 0 then j
    else addNumSpecial (addNum10 j) (k-1)     

addNumSpecial 3 5 // 53