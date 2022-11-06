namespace Tests

open Xunit
open Cribbage

module Helpers =
    let AssertCard (card : Card option) (s : Suit) (f : Face) =
        match card with
        | None -> Assert.True(false, $"Card is {None}")
        | _ when card.Value.Suit = s -> Assert.Equal(f, card.Value.Face)
        | _ when card.Value.Face = f -> Assert.Equal(s, card.Value.Suit)
        | _ -> Assert.True(false, $"{card} is not {s} {f}")