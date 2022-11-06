namespace Cribbage

module Straights =
    
    let private GenerateCombinations cards = 
        Combinations.Generate cards 3
        |> Array.append (Combinations.Generate cards 4)
        |> Array.append (Combinations.Generate cards 5)

    let IsStraight cards = false

    let Get cards =
        GenerateCombinations cards
        |> Array.filter IsStraight

    let CountPoints cards = 
        let straights = Get cards 
        straights
        |> Array.map(fun a -> a.Length)
        |> Array.sum

