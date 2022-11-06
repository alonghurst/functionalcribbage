namespace Cribbage

module Combinations =

    let ArrayWithout cards index = 
        cards 
        |> Array.indexed
        |> Array.filter(fun (x, _) -> x <> index)
        |> Array.map(fun (_, y) -> y)
        |> Cards.Sort

    let rec Generate (cards : Card[]) num = 
        match cards.Length with
        | l when l < num -> [||]
        | l when l = num -> [| cards |]
        | _ -> cards
            |> Array.indexed
            |> Array.map(fun (x,_) -> ArrayWithout cards x)
            |> Array.map(fun a -> Generate a num)
            |> Array.reduce Array.append
            |> Array.distinct
            