namespace Tests

open Xunit
open Helpers
open Cribbage
open System.Collections.Generic

module Combinations =

    let AssertCombination (a: Card[]) (b : Card[]) =
        Assert.Equal(a.Length, b.Length)
        let aS = a |> Cards.Sort
        let bS = b |> Cards.Sort
        aS
            |> Array.indexed
            |> Array.map(fun (a, b) -> Assert.Equal(b, bS[a]))
        
    let AssertCombinations (combinations : Card[][]) (expected : string) =
        let expectedCombinations = expected.Split(',') |> Array.map Cards.CardsFromString
        Assert.Equal(expectedCombinations.Length, combinations.Length) 
        combinations
            |> Array.map(fun c -> expectedCombinations |> Array.find(fun e -> e = c))
            |> Array.map(fun x -> Assert.Equal(true, true))
            |> ignore
    
    let Test (cards: string) (expected: string) num =
        let parsedCards = Cards.CardsFromString cards
        let combinations = Combinations.Generate parsedCards num
        AssertCombinations combinations expected

    [<Fact>]
    let ``2: Simple Combination: a`` () =
        Test "hq hk" "hq hk" 2

    [<Fact>]
    let ``2: Simple Combination: b`` () =
        Test "hj hq hk" "hq hk, hj hq, hj hk" 2
    
    [<Fact>]
    let ``3: Simple Combination: a`` () =
        Test "hj hq hk" "hj hq hk" 3