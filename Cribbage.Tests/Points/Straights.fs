namespace Tests

open Xunit
open Cribbage

module Straights =
    
    let TestIsAdjacent (cardString : string) expected =
        let cards = Cards.CardsFromString cardString
        let adjacent = Straights.IsAdjacent cards[0] cards[1]
        Assert.Equal(expected, adjacent)

    [<Fact>]
    let ``Adjacent: A 2`` () = TestIsAdjacent "sa h2" true
      
    [<Fact>]
    let ``Adjacent: 3 4`` () = TestIsAdjacent "s3 h4" true
   
    [<Fact>]
    let ``Adjacent: 10 J`` () = TestIsAdjacent "sj h10" true
   
    [<Fact>]
    let ``Adjacent: Q K`` () = TestIsAdjacent "sq hk" true
    
    [<Fact>]
    let ``Adjacent: Q Q`` () = TestIsAdjacent "sq hq" false
   
    let TestIsStraight (cardString : string) expected =
        let cards = Cards.CardsFromString cardString
        let adjacent = Straights.IsStraight cards
        Assert.Equal(expected, adjacent)

    [<Fact>]
    let ``Is straight: A 2 3`` () = TestIsStraight "sa h2 c3" true
        
    [<Fact>]
    let ``Is straight: A 5 3`` () = TestIsStraight "sa h5 c3" false
    
    [<Fact>]
    let ``Is straight: 3 4 5`` () = TestIsStraight "s3 h4 c5" true

    [<Fact>]
    let ``Suit`` () = 
        let cards = Cards.SuitOfFaces Hearts
        let adjacent = Straights.IsStraight cards
        Assert.Equal(true, adjacent)

    let TestPoints (cardString : string) expected =
        let cards = Cards.CardsFromString cardString
        let points = Straights.CountPoints cards
        Assert.Equal(expected, points)

    [<Fact>]
    let ``Points: 3 4 5`` () = TestPoints "s3 h4 c5" 3
    
    [<Fact>]
    let ``Points: 2 3 4 5`` () = TestPoints "s3 h4 c5 c2" 4
    
    [<Fact>]
    let ``Points: 6 7 8 9 10`` () = TestPoints "s10 s9 h4 c6 c7 d8" 5

    [<Fact>]
    let ``Points: 3 4 4 5`` () = TestPoints "s3 h4 c5 d4" 6
        
    [<Fact>]
    let ``Points: 6 6 7 8 8`` () = TestPoints "s8 h8 s6 d6 c7" 12
        
    [<Fact>]
    let ``Points: 3 4 4 5 6`` () = TestPoints "s3 h4 c5 d4 h6" 8
        