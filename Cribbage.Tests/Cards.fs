namespace Tests

open Xunit
open Helpers
open Cribbage

module ParseCard =
    [<Fact>]
    let ``King of Hearts`` () =
        let card = Cards.CardFromString "hk"
        AssertCard card Hearts King

    [<Fact>]
    let ``Ten of Diamonds`` () =
        let card = Cards.CardFromString "d10"
        AssertCard card Diamonds Ten