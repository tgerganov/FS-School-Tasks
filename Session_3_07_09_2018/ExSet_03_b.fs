module ExSet_03_b

//Exercise 3.2 - Some List functions

//a
let rec pclLength ls = //val pclLength : ls:'a list -> int
    match ls with
    | [] -> 0
    | h::t -> 1 + pclLength t

pclLength ['x'; 'y'; 'z'] //val it : int = 3

//b
let rec pclSum ls = //val pclSum : ls:int list -> int
    match ls with
    | [] -> 0
    | h::t -> h + pclSum t

pclSum [2; 3; 5; 8] //val it : int = 18


//Exercise 3.3 - Lists

let rec takeSome n (ls : 'a list) = //val takeSome : n:int -> ls:'a list -> 'a list
    match n with
    | 0 -> []
    | _ -> ls.Head :: takeSome (n - 1) (ls.Tail)

takeSome 3 [1; 2; 3; 4; 5] //val it : int list = [1; 2; 3]
takeSome 2 ['a'; 'b'; 'c'; 'd'] //val it : char list = ['a'; 'b']

//Another way
let rec takeSom b l = //val takeSom : b:int -> l:'a list -> 'a list
    match b with
    | 0 -> []
    | _ -> List.head l :: takeSom (b - 1) (l.Tail)

takeSom 3 [10; 9; 8; 7; 6] //val it : int list = [10; 9; 8]
takeSom 3 ['t'; 'o'; 'd'; 'o'; 'r'] //val it : char list = ['t'; 'o'; 'd']