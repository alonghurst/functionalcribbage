namespace Cribbage

open Cards

module Nob =
    
    let IsNob card turnup =
        match card with
        | _ when card.Suit = turnup.Suit && card.Face = Jack -> true
        | _ -> false

    let Points b = 
        match b with
        | true -> 1
        | false -> 0

    let CountPoints cards turnup = 
        cards
        |> Array.map(fun c -> IsNob c turnup)
        |> Array.map Points
        |> Array.sum