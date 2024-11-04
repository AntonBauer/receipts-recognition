namespace ReceiptsRecognition.Domain

module TesseractLanguage =
    type Language = private Language of string

    let english = Language "eng"

    let german = Language "deu"