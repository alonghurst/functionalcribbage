namespace Cribbage

module Straights =
    
    let private GenerateCombinations cards = 
        Combinations.Generate cards 3
        |> Array.append (Combinations.Generate cards 4)
        |> Array.append (Combinations.Generate cards 5)

    let IsAdjacent cardA cardB = 
        let (a, b) = 
            match cardA with 
            | _ when cardA.Face < cardB.Face -> (cardA.Face, cardB.Face)
            | _ -> (cardB.Face, cardA.Face)
        match a with
            | Ace when b = Two -> true
            | Two when b = Three -> true
            | Three when b = Four -> true
            | Four when b = Five -> true
            | Five when b = Six -> true
            | Six when b = Seven -> true
            | Seven when b = Eight -> true
            | Eight when b = Nine -> true
            | Nine when b = Ten -> true
            | Ten when b = Jack -> true
            | Jack when b = Queen -> true
            | Queen when b = King -> true
            | _ -> false

    let rec IsStraight cards =
        let sortedCards = cards |> Cards.SortByFace 
        match sortedCards with
        | _ when sortedCards.Length <= 1 -> true
        | _ when IsAdjacent sortedCards[0] sortedCards[1] -> IsStraight sortedCards[1..]
        | _ -> false

    let IsSubsetOfAny (cards : Set<Card>) (straights : Set<Card>[])= 
        let supersets = 
            straights
            |> Array.filter(fun s -> Set.isProperSuperset s cards)
        match supersets.Length with
        | 0 -> false
        | _ -> true

    let Get cards =
        let straights = 
            GenerateCombinations cards
            |> Array.filter IsStraight
            |> Array.map Set.ofSeq
        straights
        |> Array.filter(fun s -> not (IsSubsetOfAny s straights))

    let CountPoints cards = 
        let straights = Get cards 
        straights
        |> Array.map(fun a -> a.Count)
        |> Array.sum

