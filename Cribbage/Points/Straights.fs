namespace Cribbage

module Straights =
    
    let CountPointsFromCombinations combinations = 0

    let CountPoints cards = 
        let combinations = 
            Combinations.Generate cards 3
            |> Array.append (Combinations.Generate cards 4)
            |> Array.append (Combinations.Generate cards 5)

        CountPointsFromCombinations combinations 
