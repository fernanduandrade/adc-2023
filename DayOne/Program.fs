open System.IO
open System

let tryParseToInt (c: char) =
    match Int32.TryParse (c.ToString()) with
        | true, v -> Some v
        | _ -> None

let getNumberFromList (sequence: List<int>) =
    let firstNumber = sequence.Head
    let hasLastNumber = List.tryLast sequence
    let lastNumber =
        match hasLastNumber with
        | Some value -> value
        | _ -> firstNumber
    
    let concatValue = firstNumber.ToString() + lastNumber.ToString()
    Int32.Parse(concatValue)

let file = File.ReadLines "input.txt"
let stringToSeq (str: string) = Seq.choose tryParseToInt str

let getHeadAndTail (seq: seq<int>) =
    let seqList = Seq.toList seq
    let result = getNumberFromList seqList
    result

let resultFirstPart =
    file
    |> Seq.map stringToSeq
    |> Seq.map getHeadAndTail
    |> Seq.sum
    
printfn "%i" resultFirstPart

let replaceNumbersWithRepresentation (input: string) =
    let replacements =
        [
            ("one", "one1one");
            ("two", "two2two");
            ("three", "three3three");
            ("four", "four4four");
            ("five", "five5five");
            ("six", "six6six");
            ("seven", "seven7seven");
            ("eight", "eight8eight");
            ("nine", "nine9nine");
        ]

    replacements |> List.fold (fun (acc: string) (word, replacement) -> acc.Replace(word, replacement)) input


let resultSecondPart =
    file
    |> Seq.map (fun x-> replaceNumbersWithRepresentation x)
    |> Seq.map stringToSeq
    |> Seq.map getHeadAndTail
    |> Seq.sum
    
printfn "%i" resultSecondPart