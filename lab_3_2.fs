open System

let rec inputInt () = 
    match System.Int32.TryParse(Console.ReadLine()) with
    | true, convertInt -> convertInt
    | _ -> 
        printfn "Ошибка, повторите ввод\n>"
        inputInt ()

let seqInput seqLen =
    seq {
        for i in 1 .. seqLen do
            printf "%i. Введите целое число: " i
            match System.Int32.TryParse(Console.ReadLine()) with
            | true, convertInt -> yield convertInt
            | _ -> 
                printfn "Ошибка, повторите ввод"
    }

[<EntryPoint>]
let main args =
    printfn "Создание изначальной последовательности"
    printf "Введите количество элементов последовательности: "
    let seqLen = inputInt ()
    let aSeq = seqInput seqLen
    printf "\nЧисло для поиска: "
    let a = inputInt ()
    let b = aSeq |> Seq.fold(fun acc elem -> 
                            if elem=a then
                                acc+1
                            else
                                acc
                        ) 0 
    printfn "Количество совпадений: %i" b
    0
