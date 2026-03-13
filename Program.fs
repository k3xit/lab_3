open System

let rec inputInt () = 
    printf "Введите целое число: "
    match System.Int32.TryParse(Console.ReadLine()) with
    | true, convertInt -> convertInt
    | _ -> 
        printfn "Ошибка, повторите ввод"
        inputInt ()

let rec seqRange () =
    printf "Начало: "
    let startOfSeq = inputInt ()
    printf "Конец: "
    let endOfSeq = inputInt ()
    if (endOfSeq <= startOfSeq) then 
        printfn "Ошибка: Конец меньше или равен началу"
        printfn "Повторите ввод"
        seqRange ()
    else 
        startOfSeq, endOfSeq
let absoluteInt X =
    if (X<0) then 
        -X
    else 
        X

let rec firstNum X =
    let Y = absoluteInt X
    if ((Y/10)=0) then 
        Y
    else 
        firstNum (Y/10)


let printSeq inputSeq = 
    for x in inputSeq do
        printf "%i " x

[<EntryPoint>]
let main args =
    printfn "Создание изначальной последовательности: "
    let startOfSeq, endOfSeq = seqRange()
    let aSeq = seq {startOfSeq .. endOfSeq}
    printf "Изначальная последовательность: " 
    printSeq aSeq
    let bSeq = aSeq |> Seq.map(firstNum)
    printf "\nИтоговая последовательность: "
    printSeq bSeq
    printfn "Конец работы."
    0