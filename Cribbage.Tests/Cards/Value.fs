namespace Tests

open Xunit
open Helpers
open Cribbage

module TotalFaceValue =
    [<Fact>]
    let ``K + Q + 7 = 27`` () =
        let cards = Cards.CardsFromString "hk dq d7"
        let value = Cards.TotalFaceValue cards
        Assert.Equal(27, value)

    [<Fact>]
    let ``A + 2 + 3 = 6`` () =
        let cards = Cards.CardsFromString "ha d2 d3"
        let value = Cards.TotalFaceValue cards
        Assert.Equal(6, value)

    [<Fact>]
    let ``6 + 6 + 6 + 6 = 24`` () =
        let cards = Cards.CardsFromString "h6 d6 s6 c6"
        let value = Cards.TotalFaceValue cards
        Assert.Equal(24, value)