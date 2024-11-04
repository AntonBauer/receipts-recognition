open ReceiptsRecognition.Domain.TesseractRawExtractor
open System.IO
open System

let private loadImage path =
    File.OpenRead(path)

try
    printfn "Extracting data since 2024"

    let language = "deu"
    let dataPath = @""
    let imagePath = @""
    let imageData = loadImage imagePath

    let extractor = create dataPath language
    let data = extractor imageData

    printfn "%s" data
    Console.ReadLine() |> ignore

with
| _ -> Console.ReadLine() |> ignore