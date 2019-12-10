module HandIn_2_3

//1.
type Department = 
| Software 
| Civil 
| Architectural
| GlobalBusiness
| Nursing

//2.
type PTraits = {
Programming : int;
Innovative : int;
Social : int;
Devoted : int;
Kind : int
}

//Custom type EPoint
type EPoint = { FIVE : int; TEN: int } 

//3.
type NonGroupedStudent = {
Name : string;
Age : int;
EPoint : EPoint;
PTraits : PTraits
}

//4.
type RealStudent = {
Name : string;
Age : int;
EPoint : EPoint;
Department : Department
}


let ngStudent1 = { Name = "Bob"; Age = 22; EPoint = { FIVE = 1; TEN = 1 }; PTraits = { Programming = 2; Innovative = 5; Social = 10; Devoted = 10; Kind = 4} } 

let ngStudent2 = { Name = "Alice"; Age = 20; EPoint = { FIVE = 3; TEN = 3 }; PTraits = { Programming = 4; Innovative = 8; Social = 1; Devoted = 1; Kind = 6} } 

let ngStudent3 = { Name = "Peter"; Age = 23; EPoint = { FIVE = 5; TEN = 4 }; PTraits = { Programming = 7; Innovative = 1; Social = 5; Devoted = 9; Kind = 3} } 

let ngStudent4 = { Name = "Kim"; Age = 25; EPoint = { FIVE = 6; TEN = 1 }; PTraits = { Programming = 8; Innovative = 4; Social = 6; Devoted = 7; Kind = 10} } 

let ngStudent5 = { Name = "Ole"; Age = 20; EPoint = { FIVE = 5; TEN = 5 }; PTraits = { Programming = 1; Innovative = 2; Social = 8; Devoted = 4; Kind = 9} }

let ngStudent6 = { Name = "Dummy"; Age = 19; EPoint = { FIVE = 1; TEN = 1 }; PTraits = { Programming = 1; Innovative = 1; Social = 1; Devoted = 1; Kind = 1} } 


let grouping (st : NonGroupedStudent) = //val grouping : st:NonGroupedStudent -> Department
    match st with
    | st when st.PTraits.Programming >= 7 && st.PTraits.Devoted > 7 -> Software
    | st when st.PTraits.Innovative >= 6 -> Architectural
    | st when st.PTraits.Social >= 8 || st.PTraits.Innovative >= 5 -> Civil
    | st when st.PTraits.Devoted >= 5 || st.PTraits.Innovative >= 6 -> GlobalBusiness
    | st when st.PTraits.Kind >= 7 && st.PTraits.Social >=9 -> Nursing
    | {Name = _; Age = _; EPoint = _; PTraits = _} -> failwith "The student is free to choose"


let registerStudent (st : NonGroupedStudent) = //val registerStudent : st:NonGroupedStudent -> RealStudent option
    let rs = { Name = st.Name; Age = st.Age; EPoint = st.EPoint; Department = grouping(st) }
    match st with
    | st when st.EPoint.FIVE >= 4 || (st.EPoint.FIVE >=2 && st.EPoint.TEN >= 1) || st.EPoint.TEN >= 2 -> Some(rs)
    | {Name = _; Age = _; EPoint = _; PTraits = _} -> None


//6.
type StudyMeritMessage = 
| WaiveEPoint of int
| GrantLeave of string


let grantMeritAgent = MailboxProcessor.Start (fun inbox -> //val grantMeritAgent : MailboxProcessor<StudyMeritMessage>
        let rec processMessage() = 
            async {
                let! msg = inbox.Receive()
                match msg with
                | StudyMeritMessage.GrantLeave msg when msg.Contains("fun") || msg.Contains("holiday") -> printfn "Leave not granted. Keep calm and write F#"
                | StudyMeritMessage.GrantLeave msg when msg.Contains("internship") -> printfn "Leave granted. Good luck with your internship"
                | StudyMeritMessage.GrantLeave msg when msg.Contains("health") -> printfn "Leave granted. Get better soon" 
                | StudyMeritMessage.WaiveEPoint msg when msg >= 20 -> printfn "%.1f points have been waived" ((float)msg * 0.5)
                | _ -> printfn "The reason for your leave is not valid or your ECTS points are below the minimum"
                return! processMessage() 
                }
        processMessage ())


//Testing results:
grantMeritAgent.Post (GrantLeave ("Just want to have a little fun")) //Leave not granted. Keep calm and write F#
grantMeritAgent.Post (GrantLeave ("I would love to go on holiday")) //Leave not granted. Keep calm and write F#

grantMeritAgent.Post (GrantLeave ("Just want to have another internship")) //Leave granted. Good luck with your internship

grantMeritAgent.Post (GrantLeave ("I have some health problems")) //Leave granted. Get better soon

grantMeritAgent.Post (GrantLeave ("I am sick and tired from school")) //The reason for your leave is not valid or your ECTS points are below the minimum

grantMeritAgent.Post (WaiveEPoint(25)) //12.5 points have been waived

grantMeritAgent.Post (WaiveEPoint(15)) //The reason for your leave is not valid or your ECTS points are below the minimum


registerStudent (ngStudent1) //val it : RealStudent option = None

registerStudent (ngStudent2) (* val it : RealStudent option = Some {Name = "Alice";
                                    Age = 20;
                                    EPoint = {FIVE = 3;
                                              TEN = 3;};
                                    Department = Architectural;} *)

registerStudent(ngStudent3) (* val it : RealStudent option = Some {Name = "Peter";
                                    Age = 23;
                                    EPoint = {FIVE = 5;
                                              TEN = 4;};
                                    Department = Software;} *)

grouping (ngStudent1) //val it : Department = Civil
grouping (ngStudent2) //val it : Department = Architectural
grouping (ngStudent3) //val it : Department = Software
grouping (ngStudent4) //val it : Department = GlobalBusiness
grouping (ngStudent5) //val it : Department = Civil

grouping (ngStudent6) //System.Exception: The student is free to choose
