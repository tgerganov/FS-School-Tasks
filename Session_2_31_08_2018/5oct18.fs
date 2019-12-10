module _5oct18

//Simple example
let rec sumList lst = 
    match lst with
    | [] -> 0
    | hd::tl -> hd + sumList(tl)

let list = [1..100000]
let list2 = [1..1000000]

sumList list //val it : int = 705082704
sumList list2 //Process is terminated due to StackOverflowException.

//-------------------------------------------------

let sumListTR lst = //tail recursive 
    let rec sumListHelper(lst, total) = 
        match lst with
        | [] -> total
        | hd::tl -> 
            let newtotal = hd + total //to be more interesting/efficient/elegant; could be done also directly
            sumListHelper(tl, newtotal)
    sumListHelper(lst, 0)

sumListTR list2 //val it : int = 1784293664; no StackOverflowException when tail recursion is used

//-------------------------------------------------

let seqOfNumbers = seq { 1 .. 5 } //val seqOfNumbers : seq<int>
seqOfNumbers |> Seq.iter (printfn "%d")
(*
1
2
3
4
5
val it : unit = () *)

//-------------------------------------------------

// Print a list of integers in reverse using a continuation, slides 7, p. 14
// val printListRev : list:int list -> unit
let printListRev list =
    let rec printListRevTR list cont =
        match list with
        // For an empty list, execute the continuation
        | [] -> cont()
        // For other lists, add printing the current node as part of the continuation.
        | hd::tl -> printListRevTR tl (fun () -> printf "%d " hd
                                                 cont())
    printListRevTR list (fun () -> printfn "Done!")

printListRev [1;2;3] // 3 2 1 Done!
printListRev [] // Done!

// Example for a sequence
let mySeq = seq { for i in 1 .. 10 do yield i} // val mySeq : seq<int>
mySeq // val it : seq<int> = seq [1; 2; 3; 4; ...]








