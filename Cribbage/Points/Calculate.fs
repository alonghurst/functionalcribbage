namespace Cribbage

module Points =
        
    let Calculate cards turnup isBox = 
        let allCards = cards |> Array.append [| turnup |]

        let total = 
            Nob.CountPoints cards turnup + 
            Flush.CountPoints cards turnup isBox +
            Fifteens.CountPoints allCards +
            Straights.CountPoints allCards +
            Pairs.CountPoints allCards
        total