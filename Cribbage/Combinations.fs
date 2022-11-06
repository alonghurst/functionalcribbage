namespace Cribbage

open System
open Cards

module Combinations =

    let ArrayWithout cards index = 
        cards 
        |> Array.indexed
        |> Array.filter(fun (x, _) -> x <> index)
        |> Array.map(fun (_, y) -> y)

    let rec Generate (cards : Card[]) num = 
        match cards with
        | _ when cards.Length < num -> [||]
        | _ when cards.Length = num -> [| cards |]
        | _ -> cards
            |> Array.indexed
            |> Array.map(fun (x,_) -> ArrayWithout cards x)
            |> Array.map(fun a -> Generate a num)
            |> Array.reduce Array.append
