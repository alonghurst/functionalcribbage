namespace Cribbage

open System

module Program =

    let HandAndTurnups hand = 
        Cards.DeckOfCards
        |> Array.filter(fun c -> not (Array.contains c hand))
        |> Array.map(fun c -> (c, hand))

    let HandAndPoints (turnup, hand) =
        let score = Points.Calculate hand turnup false
        (turnup, hand, score)

    [<EntryPoint>]
    let main args =
    
        let deck = Cards.DeckOfCards

        printfn "Generating combinations"

        let hands = Combinations.Generate deck 4
        
        printfn "Counting points"

        let handsAndTurnup = 
            hands
            |> Array.map HandAndTurnups
            |> Array.reduce Array.append
            |> Array.map HandAndPoints
            |> Array.sortByDescending(fun (_, _, p) -> p)
            |> Array.take 3
            |> Array.map(fun (t, c, p) -> $"{p}: {(Cards.CardToString t)}, {(Cards.CardsToString c)}")

        printfn "%A" handsAndTurnup

        0
