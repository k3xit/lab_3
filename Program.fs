open System
open System.IO

let printSeq inputSeq = 
    for x in inputSeq do
        printfn "\t%s" x

let fullFile dir =
    Directory.EnumerateFiles(dir, "*.txt")
let fullDir dir =
    Directory.EnumerateDirectories(dir)
let rec searchDir () =
    printf "Введите путь каталога: "
    let dir = string(Console.ReadLine())
    match dir with
    | "" -> 
        printfn "Выход"
    | _ ->
        match Directory.Exists(dir) with 
        | true -> 
            let aDir = fullDir dir
            for bDir in aDir do 
                searchFile bDir
        | false -> 
            printfn "Нет такой директории"
            searchDir ()

and searchFile dir =
    let fSeq = fullFile dir
    match fSeq |> Seq.isEmpty with 
    | true -> 
        printfn "Директория: %s" dir
        printfn "Нет текстовых файлов"
    | false ->
        printfn "Директория: %s" dir
        printfn "Пути к текстовым файлам: "
        printSeq fSeq

[<EntryPoint>]
let main args =
    searchDir ()
    0