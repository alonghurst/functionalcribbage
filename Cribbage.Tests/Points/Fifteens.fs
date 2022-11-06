namespace Tests

open Xunit
open Cribbage

module Fifteens =

    let Test (cardString : string) expected =
        let cards = Cards.CardsFromString cardString
        let points = Fifteens.CountPoints cards
        Assert.Equal(expected, points)

    [<Fact>]
    let ``Q 5`` () = Test "hq h5" 2

    [<Fact>]
    let ``Q J 5`` () = Test "hq hj h5" 4

    [<Fact>]
    let ``Q J 5 5`` () = Test "hq hj h5 d5" 8

    [<Fact>]
    let ``14`` () = Test "hq h4" 0

    [<Fact>]
    let ``16`` () = Test "hq h6" 0