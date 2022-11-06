namespace Tests

open Xunit
open Helpers
open Cribbage

module Deck =
    [<Fact>]
    let ``There are 52 cards`` () =
        let cards = Cards.DeckOfCards
        Assert.Equal(52, cards.Length)

    [<Fact>]
    let ``Each card appears only once`` () =
        let cards = Cards.DeckOfCards |> Array.distinct
        Assert.Equal(52, cards.Length)