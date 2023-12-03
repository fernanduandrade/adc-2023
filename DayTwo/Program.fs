open Bag
open System.IO
let readFile = File.ReadAllLines "input.txt"

let resultPart1 =
    readFile
    |> Seq.map parseGame
    |> Seq.filter (fun game -> possibleGames game.Bags)
    |> Seq.map (fun x -> x.Id)
    |> Seq.sum
    
    
printfn "%A" resultPart1

let resultPart2 =
    readFile
    |> Seq.map parseGame
    |> Seq.map (fun x -> getGamePower x.Bags)
    |> Seq.sum
    
    
printfn "%A" resultPart2