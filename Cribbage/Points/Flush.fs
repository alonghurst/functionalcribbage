namespace Cribbage

open System
open Cards

module Flush =
    
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

    let CountPoints cards turnup isBox =
        match cards with
        | [||] -> 0
        | _ -> Flush cards turnup isBox