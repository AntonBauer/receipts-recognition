open ReceiptsRecognition.Domain
open ReceiptsRecognition.Domain.TesseractRawExtractor
open System.IO

let private loadImage path =
    File.OpenRead(path)

printfn "Extracting data since 2024"

let language = TesseractLanguage.english
let dataPath = TesseractDataPath "./tessdata"
let imagePath = @"C:\Users\AntonBauer\Downloads\test_recipe.jpg"
let imageData = loadImage imagePath

let extractor = create dataPath language
let data = extractor imageData

printfn "%s" data