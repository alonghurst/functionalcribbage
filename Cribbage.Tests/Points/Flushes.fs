namespace Tests

open Xunit
open Helpers
open Cribbage
open System.Collections.Generic

module Flushes =
    [<Fact>]
    let ``No cards = 0`` () =
        let cards = [||]
        let turnup = {Face = Ten; Suit = Spades}
        let points = Points.Flushes cards turnup false
        Assert.Equal(0, points)

    [<Fact>]
    let ``4 cards of same suit = 4`` () =
        let cards = Cards.CardsFromString "c2 c3 c4 c5"
        let turnup = {Face = Ten; Suit = Spades}
        let points = Points.Flushes cards turnup false
        Assert.Equal(4, points)
    
    [<Fact>]
    let ``4 cards of same suit and turnup = 5`` () =
        let cards = Cards.CardsFromString "d2 d3 d4 d5"
        let turnup = {Face = Ten; Suit = Diamonds}
        let points = Points.Flushes cards turnup false
        Assert.Equal(5, points)

    [<Fact>]
    let ``3 cards of same suit = 0`` () =
        let cards = Cards.CardsFromString "s2 h3 s4 s5"
        let turnup = {Face = Ten; Suit = Hearts}
        let points = Points.Flushes cards turnup false
        Assert.Equal(0, points)

    [<Fact>]
    let ``3 cards of same suit and turnup = 0`` () =
        let cards = Cards.CardsFromString "h2 h3 d4 h5"
        let turnup = {Face = Ten; Suit = Hearts}
        let points = Points.Flushes cards turnup false
        Assert.Equal(0, points)

    [<Fact>]
    let ``In box 4 cards of same suit = 0`` () =
        let cards = Cards.CardsFromString "c2 c3 c4 c5"
        let turnup = {Face = Ten; Suit = Spades}
        let points = Points.Flushes cards turnup true
        Assert.Equal(0, points)
    
    [<Fact>]
    let ``In box 4 cards of same suit and turnup = 5`` () =
        let cards = Cards.CardsFromString "d2 d3 d4 d5"
        let turnup = {Face = Ten; Suit = Diamonds}
        let points = Points.Flushes cards turnup true
        Assert.Equal(5, points)

    [<Fact>]
    let ``In box 3 cards of same suit = 0`` () =
        let cards = Cards.CardsFromString "s2 h3 s4 s5"
        let turnup = {Face = Ten; Suit = Hearts}
        let points = Points.Flushes cards turnup true
        Assert.Equal(0, points)

    [<Fact>]
    let ``In box 3 cards of same suit and turnup = 0`` () =
        let cards = Cards.CardsFromString "h2 h3 d4 h5"
        let turnup = {Face = Ten; Suit = Hearts}
        let points = Points.Flushes cards turnup true
        Assert.Equal(0, points)