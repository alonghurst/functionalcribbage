namespace Tests

open Xunit
open Cribbage

module Pairs =

    let Test (cardString : string) expected =
        let cards = Cards.CardsFromString cardString
        let c = Combinations.Generate cards 2
        let points = Pairs.CountPoints cards
        Assert.Equal(expected, points)

    [<Fact>]
    let ``No`` () = Test "hq h5" 0

    [<Fact>]
    let ``Q Q`` () = Test "hq dq" 2

    [<Fact>]
    let ``2 2 2`` () = Test "h2 d2 s2" 6
    
    [<Fact>]
    let ``a a a a`` () = Test "ha da sa ca" 12