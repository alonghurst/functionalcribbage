namespace Cribbage

module Fifteens =
    
    let private GenerateCombinations cards = 
        Combinations.Generate cards 2
        |> Array.append (Combinations.Generate cards 3)
        |> Array.append (Combinations.Generate cards 4)
        |> Array.append (Combinations.Generate cards 5)

    let IsFifteen cards =
        match Cards.TotalFaceValue cards with
        | 15 -> true
        | _ -> false

    let Get cards =
        GenerateCombinations cards
        |> Array.filter IsFifteen

    let CountPoints cards = 
        let fifteens = Get cards 
        fifteens.Length * 2

