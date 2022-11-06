namespace Tests

open Xunit
open Helpers
open Cribbage
open System.Collections.Generic

module Nobs =
    [<Fact>]
    let ``Base case`` () =
        let card = {Face = Jack; Suit = Spades}
        let turnup = {Face = Ten; Suit = Spades}
        let points = Points.Nob card turnup
        Assert.Equal(1, points)
    
    [<Fact>]
    let ``In a whole deck of cards there is only 1 point for a nob`` () =
        let cards = Cards.DeckOfCards
        let turnup = {Face = Ten; Suit = Spades}
        let points = Points.Nobs cards turnup
        Assert.Equal(1, points)

    [<Fact>]
    let ``A nob is only awarded for a jack`` () =
        let cards = new List<Card>(Cards.SuitOfFaces Hearts)
        cards.Remove({Suit = Hearts; Face = Jack}) |> ignore

        let turnup = {Face = Six; Suit = Hearts}
        let points = Points.Nobs (cards.ToArray()) turnup
        Assert.Equal(0, points)

    [<Fact>]
    let ``A nob is only awarded for a jack of correct suit`` () =
        let cards = Cards.CardsFromString "dj cj sj"
        let turnup = {Face = Six; Suit = Hearts}
        let points = Points.Nobs cards turnup
        Assert.Equal(0, points)