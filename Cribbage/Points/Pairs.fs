namespace Cribbage

module Pairs =
    
    let private GenerateCombinations cards = Combinations.Generate cards 2

    let IsPair a b = a.Face = b.Face

    let Get cards =
        GenerateCombinations cards
        |> Array.filter(fun a -> IsPair a[0] a[1])

    let CountPoints cards = 
        let pairs = Get cards 
        pairs.Length * 2
