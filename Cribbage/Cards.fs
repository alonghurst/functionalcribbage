namespace Cribbage

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