namespace Cribbage

open System
open Cards

module Points =

    let Nobs cards turnup = 0
    let Nob card turnup = 0
    let Fifteens cards turnup = 2
    let Fifteen cards = 0
    let Pairs cards turnup = 3
    let Pair cards = 0
    let Straights cards turnup = 4
    let Straight cards = 0
    let Flushes cards turnup isBox = 5
    let Flush cards turnup isBox = 0

    
    let Calculate cards turnup isBox = 
        let total = Nobs cards turnup + 
            Fifteens cards turnup +
            Pairs cards turnup +
            Straights cards turnup + 
            Flushes cards turnup isBox
        total