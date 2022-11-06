namespace Cribbage

open System

type Suit = Hearts | Clubs | Diamonds | Spades

type Face = Ace | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King

type Card = {
    Suit : Suit;
    Face : Face
}

module Cards =
    let SuitFromString (s : string) =
        match s.Trim().ToLower() with 
        | "h" | "heart" | "hearts"-> Some Hearts
        | "c" | "club" | "clubs" -> Some Clubs
        | "d" | "diamond" | "diamonds" -> Some Diamonds
        | "s" | "spade" | "spades"-> Some Spades
        | _ -> None

    let FaceFromString (s : string) =
        match s.Trim().ToLower() with 
        | "1" | "ace" | "a" -> Some Ace
        | "2" | "two" -> Some Two
        | "3" | "three" -> Some Three
        | "4" | "four" -> Some Four
        | "5" | "five" -> Some Five
        | "6" | "six" -> Some Six
        | "7" | "seven" -> Some Seven
        | "8" | "eight" -> Some Eight
        | "9" | "nine" -> Some Nine
        | "10" | "ten" -> Some Ten
        | "11" | "jack" | "j" -> Some Jack
        | "12" | "queen" | "q" -> Some Queen
        | "13" | "king" | "k" -> Some King
        | _ -> None

    let CardFromString (s: string) =
        let suit = SuitFromString (s[0].ToString())
        let face = FaceFromString s[1..]
        match (suit, face) with
        | (None, _) -> None
        | (_, None) -> None
        | (_, _) -> Some {Suit = suit.Value; Face = face.Value}

    let CardsFromString (s: string) =
        s.Split([| " "; ","; ";" |], StringSplitOptions.RemoveEmptyEntries) 
        |> Array.map CardFromString 
        |> Array.filter (fun c -> c.IsSome)
        |> Array.map (fun c -> c.Value)

    let FaceValue face = 
        match face with
        | Ace -> 1
        | Two -> 2
        | Three -> 3
        | Four -> 4
        | Five -> 5
        | Six -> 6
        | Seven -> 7
        | Eight -> 8
        | Nine -> 9
        | Ten | Jack | Queen | King -> 10

    let TotalFaceValue cards  =
        cards |> Array.map(fun c -> c.Face) |> Array.map FaceValue |> Seq.sum
