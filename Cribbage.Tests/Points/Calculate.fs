namespace Tests

open Xunit
open Helpers
open Cribbage

module Calculate =
    [<Fact>]
    let ``Turnup flush and nob = 6`` () =
        let cards = Cards.CardsFromString "hk hj h2 h6"
        let turnup = {Face = Ten; Suit = Hearts}
        let points = Points.Calculate cards turnup false
        Assert.Equal(6, points)