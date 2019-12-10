module ExSet_05a

// 5.1
// val countNumOfVowels : str:string -> int * int * int * int * int
let countNumOfVowels (str : string) =
    let charList = List.ofSeq str
    let accFunc (As, Es, Is, Os, Us) letter =
        match letter with
        |'a' -> (As + 1, Es, Is, Os, Us)
        |'e' -> (As, Es + 1, Is, Os, Us)
        |'i' -> (As, Es, Is + 1, Os, Us)
        |'o' -> (As, Es, Is, Os + 1, Us)
        |'u' -> (As, Es, Is, Os, Us + 1)
        |_ -> (As, Es, Is, Os, Us)
    List.fold accFunc (0, 0, 0, 0, 0) charList

countNumOfVowels "Higher-order functions can take and return functions of any order"
// val it : int * int * int * int * int = (4, 5, 3, 5, 3)

// 5.2
// val primesUpTo : n:int -> int list
let primesUpTo n = 
    let isPrime num =
        let rec check i =
            i > num/2 || (num % i <> 0 && check (i + 1))
        check 2
    List.filter isPrime [2 .. n]

primesUpTo 10 // val it : int list = [2; 3; 5; 7]

// 5.3
// val pclFib : n:int -> int
let rec pclFib n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | n -> pclFib(n-1) + pclFib(n-2)

pclFib 3 // val it : int = 2

// 5.4
// a
let doubleNum x = x * 2
let sqrNum x = x * x

// b
let pclQuad x = doubleNum (doubleNum x)

// c
let pclFourth x = sqrNum (sqrNum x)

// Tests:
doubleNum 2 // 4
sqrNum 3 // 9

pclQuad 2 // 8
pclFourth 3 // 81