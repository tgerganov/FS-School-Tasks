module Exam_09012019
// Todor Milev Gerganov, 246684

//Q 1
//Q 1a
let rec stringToCharList s =
    match s with
    |"" -> [] 
    |s -> s.[0]::stringToCharList s.[1 .. String.length s - 1]

//Testing:
//val stringToCharList : s:string -> char list
stringToCharList "Todor"
//val it : char list = ['T'; 'o'; 'd'; 'o'; 'r']
stringToCharList "Good luck!"
//val it : char list = ['G'; 'o'; 'o'; 'd'; ' '; 'l'; 'u'; 'c'; 'k'; '!']

//Q 1b
//Q 1c

//Q 2
//Q 2a
let rec replicate n s =
    match n with
    | 0 -> ""
    | n when n < 0 -> failwith "Negative numbers are not allowed!"
    | _ -> s + replicate (n-1) s

//val replicate : n:int -> s:string -> string
replicate 3 "fun" //val it : string = "funfunfun"
replicate 0 "fly" //val it : string = ""
replicate -1 "Example" //System.Exception: Negative numbers are not allowed!

//Q 2b
let incListBy1 ls = List.map(fun x -> x + 1) ls
//val incListBy1 : ls:int list -> int list
incListBy1 [0;1;2;4] //val it : int list = [1; 2; 3; 5]

//Q 2c

//Q 3
//Q 3a
type Meal = {
Name : string;
ServingTime : string;
ServingForm : string
}

//Q 3b
let firstDailyMeal = { Name = "Cereals"; ServingTime = "Breakfast"; ServingForm = "Cold" } 
let secondDailyMeal = { Name = "Pea Soup"; ServingTime = "Lunch"; ServingForm = "Warm" } 
let thirdDailyMeal = { Name = "Roast beef"; ServingTime = "Dinner"; ServingForm = "Warm" }

//Q 3c
firstDailyMeal.Name //val it : string = "Cereals"
secondDailyMeal.Name //val it : string = "Pea Soup"
thirdDailyMeal.Name //val it : string = "Roast beef"

//Q 4
//Q 4a
type Size = L | M | S

let sizeToString (s:Size) =
    match s with
    | L -> "Large"
    | M -> "Medium"
    | S -> "Small"

//val sizeToString : s:Size -> string
sizeToString L //val it : string = "Large"
sizeToString M //val it : string = "Medium"
sizeToString S //val it : string = "Small"

//Q 4b
//The initial function:
let getFlowerPotPrice size =
    let price =
        if size = "small" || size = "Small" then 10.0f
        elif size = "medium" || size = "Medium" then 20.0f
    printfn "The price is %.2f" price

//As we can see from the error: This expression was expected to have type 'unit' but here has type 'float32'
//This is due to the fact that our price function should print and when printing we have 'unit'

//I would rewrite the function like this:
let getFlowerPotPriceFix size =
    if size = "small" || size = "Small" then printfn "The price is %.2f" 10.0f
    elif size = "medium" || size = "Medium" then printfn "The price is %.2f" 20.0f

//val getFlowerPotPriceFix : size:string -> unit
getFlowerPotPriceFix "small" //The price is 10.00 val it : unit = ()
getFlowerPotPriceFix "Medium" //The price is 20.00 val it : unit = ()

//We could nicely rewrite the function also with pattern matching and (of course) using our custom Size type :-)

//Q 5
//Q 5a
type FluidQuantity =
    | Water of int
    | Milk of int
    | Tea of int
    | Coffee of int
    | Soda of int
with
    override qty.ToString() =
        match qty with
            | Water qty -> Printf.sprintf "%i cup(s)/glass(es) of Water" qty
            | Milk qty -> Printf.sprintf "%i can(s)/bottle(s) of Milk" qty
            | Tea qty -> Printf.sprintf "%i can(s)/bottle(s) of Tea" qty
            | Coffee qty -> Printf.sprintf "%i cup(s) of Coffee" qty
            | Soda qty -> Printf.sprintf "%i cup(s) of Soda" qty


let fluidIntakeAgent = MailboxProcessor.Start (fun inbox -> 
        let rec processMessage() = 
            async {
                let! msg = inbox.Receive()
                match msg with
                | FluidQuantity.Coffee msg when msg >= 10 -> printfn "%d in a day is a bit too much." msg  
                | FluidQuantity.Milk msg when msg >= 3 -> printfn "%d in a day is good for your teeth." msg
                | FluidQuantity.Soda msg when msg >= 4 -> printfn "%d in a day is bad for your stomach." msg  
                | FluidQuantity.Tea msg when msg < 3 -> printfn "%d in a day is not enough when you have cold." msg 
                | FluidQuantity.Water msg when msg < 7 -> printfn "%d in a day is less than recommended." msg  
                | _ -> failwith "Please give a valid type of drink."
                return! processMessage() 
                }
        processMessage ())

//val fluidIntakeAgent : MailboxProcessor<FluidQuantity>

//Q 5b
fluidIntakeAgent.Post (Coffee 10) //10 in a day is a bit too much.
fluidIntakeAgent.Post (Milk 5) //5 in a day is good for your teeth.
fluidIntakeAgent.Post (Soda 6) //6 in a day is bad for your stomach.
// I need a little fix here though :-(
