module ExSet_04a

// 4.1 -> List.fold
// a 
let rec pclFold f acc ls =
    match ls with
    | [] -> acc
    | h::t -> h + pclFold f acc t 

pclFold (+) 0 [1;2;3]

// b
let pclSumWithFold ls = pclFold (+) 0 ls
pclSumWithFold [1;2;3]

// 4.2 -> List.foldBack
// a
let rec pclFoldBack f acc ls =
    match ls with
    | [] -> acc
    | h::t -> pclFoldBack f acc t + h

pclFoldBack (+) 0 [1;2;3] // TO BE CONTINUED !!!