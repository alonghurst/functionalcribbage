namespace Tests

open Xunit
open Helpers
open Cribbage

module Calculate =
    [<Fact>]
    let ``Temp`` () =
        let cards = Cards.CardsFromString "hk dq d7"
        let turnup = {Face = Ten; Suit = Spades}
        let points = Points.Calculate cards turnup false
        Assert.Equal(15, points)