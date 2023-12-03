module Bag

open System

type Bag = {
                 Red: int
                 Green: int
                 Blue: int }

type Game = { Id: int; Bags: list<Bag> }


let parseBag (bagStr: string) =
    let bagItems = bagStr.Split([|' '; ','|], StringSplitOptions.RemoveEmptyEntries)
    printfn "%A" bagItems
    let getColorValue color =
        match bagItems |> Array.tryFindIndex (fun s -> s = color) with
        | Some(index) -> int bagItems.[index - 1]
        | _ -> 0
        
    { Blue = getColorValue "blue"; Green = getColorValue "green"; Red = getColorValue "red" }
    
    
let getGamePower (bags: list<Bag>) =
    let mutable rMax = 0
    let mutable gMax = 0
    let mutable bMax = 0
    
    bags
    |> List.iter (fun x ->
        rMax <- Math.Max(rMax, x.Red)
        gMax <- Math.Max(gMax, x.Green)
        bMax <- Math.Max(bMax, x.Blue)
        )
    let power = rMax * gMax * bMax
    power
    
let parseGame (line: string) =
    let gameInfo = line.Split([|':'|], StringSplitOptions.RemoveEmptyEntries)
    let gameId = Int32.Parse(gameInfo[0].Trim().Split(" ")[1])
                           
    let bagsInfo = gameInfo.[1].Split([|';'|], StringSplitOptions.RemoveEmptyEntries)
    let bags = bagsInfo |> Array.map parseBag |> Array.toList
    let game = { Id = gameId; Bags = bags }
    game
    

let possibleGames (bags: list<Bag>) =
    let isPossible (bag: Bag) =
        match bag with
        | { Blue = blue; Green = green; Red = red } when blue <= 14 && green <= 13 && red <= 12 -> true
        | _ -> false

    bags
    |> List.forall isPossible