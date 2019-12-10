module ExSet_01

5+3 //should be terminated by ;; if written in the F# Interactive console
//val it : int = 8

5-3 //Here evaluation by pressing Alt+Enter (the result is seen in the F# Interactive console)
//val it : int = 2

5/3
//val it : int = 1 (because both operands are of type int)

5/3.0
//ExSet_01.fs(12,3): error FS0001: The type 'float' does not match the type 'int'

5.0/3
//ExSet_01.fs(15,5): error FS0001: The type 'int' does not match the type 'float'
//Valid for +,-,/,*

5.0/3.0
//val it : float = 1.666666667 (because both operands are of type float)

pown 5.0 3
//val it : float = 125.0 (no issues here)

pown 5 3.0
(* ExSet_01.fs(25,8): error FS0001: This expression was expected to have type
'int' but here has type 'float' (there are however issues here) *)

pown 5 5 //the standard power function with two integers
//val it : int = 3125

5.0 ** 5.0
//val it : float = 3125.0 (that's interesting; using ** when having two floats)
//Be aware of whitespaces; they do matter in F# !!!

//-------------------------------------------------------------------------------------//

3 :: [4; 5; 2; 7]
//val it : int list = [3; 4; 5; 2; 7] (adding an element to a list; here in the beginning (as a head))
//Lists - the first element is the head and the rest are the tail

List.length [4; 5; 2; 7] //A standard function of the List module
//val it : int = 4

[4; 5; 2; 7] :: 3
(* ExSet_01.fs(45,17): error FS0001: This expression was expected to have type 'int list list'    
but here has type 'int' *)

[4; 5; 2; 7] @ [3]
//val it : int list = [4; 5; 2; 7; 3]
//A way to do it, however not very optimal - see the bookmark from StackOverflow for more details
