namespace Tests

open Xunit
open Cribbage

module Calculate =

    let Test (cardString: string) isBox expectedPoints = 
        let cards = Cards.CardsFromString cardString
        let points = Points.Calculate cards[1..] cards[0] isBox
        Assert.Equal(expectedPoints, points)

    [<Fact>]
    let ``d9 hq s2 hk d3`` () = Test "d9 hq s2 hk d3" false 4

    [<Fact>]
    let ``c5 cj c10 cq ck`` () = Test "c5 cj c10 cq ck" false 18

    [<Fact>]
    let ``ca h2 d2 s10 h3 ca`` () = Test "ca h2 d2 s10 h3" false 14

    [<Fact>]
    let ``d3 s7 h8 dk s3 d3`` () = Test "d3 s7 h8 dk s3" false 4

    [<Fact>]
    let ``Turnup flush and nob = 6`` () =
        let cards = Cards.CardsFromString "hk hj h2 h6"
        let turnup = {Face = Ten; Suit = Hearts}
        let points = Points.Calculate cards turnup false
        Assert.Equal(6, points)