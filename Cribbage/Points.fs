namespace Cribbage

open System
open Cards

module Points =
    
    let Nob card turnup =
        match card with
        | _ when card.Suit = turnup.Suit && card.Face = Jack -> 1
        | _ -> 0

    let Nobs cards turnup = 
        cards
        |> Array.map(fun c -> Nob c turnup)
        |> Array.sum

    let Fifteens cards turnup = 0
    let Fifteen cards = 0
    let Pairs cards turnup = 0
    let Pair cards = 0
    let Straights cards turnup = 0
    let Straight cards = 0

    let Flush (cards : Card[]) turnup isBox =
        let suit = cards[0].Suit
        let count = 
            cards 
            |> Array.filter(fun c -> c.Suit = suit) 
            |> Array.length

        match count with
        | 4 when turnup.Suit = suit -> 5
        | 4 when not isBox -> 4
        |_ -> 0

    let Flushes cards turnup isBox =
        match cards with
        | [||] -> 0
        | _ -> Flush cards turnup isBox

    
    let Calculate cards turnup isBox = 
        let total = Nobs cards turnup + 
            Fifteens cards turnup +
            Pairs cards turnup +
            Straights cards turnup + 
            Flushes cards turnup isBox
        total