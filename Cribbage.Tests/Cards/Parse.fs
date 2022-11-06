namespace Tests

open Xunit
open Helpers
open Cribbage

module CardFromString =
    [<Fact>]
    let ``King of Hearts`` () =
        let card = Cards.CardFromString "hk"
        AssertCard card Hearts King

    [<Fact>]
    let ``Ten of Diamonds`` () =
        let card = Cards.CardFromString "d10"
        AssertCard card Diamonds Ten

module CardsFromString =
    [<Fact>]
    let ``Ace of Spades, Two of Clubs, Seven of Diamonds`` () =
        let cards = Cards.CardsFromString "sa c2 d7"
        AssertCard (Some(cards[0])) Spades Ace
        AssertCard (Some(cards[1])) Clubs Two
        AssertCard (Some(cards[2])) Diamonds Seven