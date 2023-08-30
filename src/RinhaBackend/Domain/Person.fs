module Domain

open System


type Person = { Id:Guid; Name:string; Nickname:string; BirthDay:DateTime; Stack:String[] }

let validPerson person =
  let validName p = not (String.IsNullOrWhiteSpace p.Name) && p.Name.Length <= 100
  let validNickName p = not (String.IsNullOrWhiteSpace p.Nickname) && p.Nickname.Length <= 32
  let validStack p =  match p.Stack with 
                      | null -> true
                      | item -> Array.forall (fun element -> not (String.IsNullOrWhiteSpace element)) item
  let valid p = validName p && validNickName p && validStack p
  valid person


let ValidPerson = {Id = Guid.NewGuid(); 
                  Name = "Nome teste"; 
                  Nickname = "apelido teste"; 
                  BirthDay = DateTime.Now;
                  Stack = [| "F#"; "Elixir"; "Clojure" |] }

let InvalidPerson = {Id = Guid.NewGuid(); 
                  Name = ""; 
                  Nickname = "apelido teste"; 
                  BirthDay = DateTime.Now;
                  Stack = [| "F#"; "Elixir"; "Clojure" |] }

let InvalidPersonWithStackEmpty = {Id = Guid.NewGuid(); 
                  Name = "Nome teste"; 
                  Nickname = "apelido teste"; 
                  BirthDay = DateTime.Now;
                  Stack = [| "F#"; ""; "Clojure" |] }

let ValidPersonWithStackNull = {Id = Guid.NewGuid(); 
                  Name = "Nome teste"; 
                  Nickname = "apelido teste"; 
                  BirthDay = DateTime.Now;
                  Stack = null }

printfn "ValidPerson test is valid %b" (validPerson ValidPerson)
printfn "InvalidPerson test is valid %b" (validPerson InvalidPerson)
printfn "InvalidPersonWithStackEmpty test is valid %b" (validPerson InvalidPersonWithStackEmpty)
printfn "ValidPersonWithStackNull test is valid %b" (validPerson ValidPersonWithStackNull)