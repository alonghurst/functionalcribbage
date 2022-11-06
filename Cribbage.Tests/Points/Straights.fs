namespace Tests

open Xunit
open Cribbage

module Straights =
    
    let TestIsAdjacent (cardString : string) expected =
        let cards = Cards.CardsFromString cardString
        let adjacent = Straights.IsAdjacent cards[0] cards[1]
        Assert.Equal(expected, adjacent)

    [<Fact>]
    let ``A 2`` () = TestIsAdjacent "sa h2" true
      
    [<Fact>]
    let ``3 4`` () = TestIsAdjacent "s3 h4" true
   
    [<Fact>]
    let ``10 J`` () = TestIsAdjacent "sj h10" true
   
    [<Fact>]
    let ``Q K`` () = TestIsAdjacent "sq hk" true
    
    [<Fact>]
    let ``Q Q`` () = TestIsAdjacent "sq hq" false
   
    let TestAreAllAdjacent (cardString : string) expected =
        let cards = Cards.CardsFromString cardString
        let adjacent = Straights.AreAllAdjacent cards
        Assert.Equal(expected, adjacent)

    [<Fact>]
    let ``A 2 3`` () = TestAreAllAdjacent "sa h2 c3" true
        
    [<Fact>]
    let ``A 5 3`` () = TestAreAllAdjacent "sa h5 c3" false
    
    [<Fact>]
    let ``3 4 5`` () = TestAreAllAdjacent "s3 h4 c5" true

    [<Fact>]
    let ``Suit`` () = 
        let cards = Cards.SuitOfFaces Hearts
        let adjacent = Straights.AreAllAdjacent cards
        Assert.Equal(true, adjacent)