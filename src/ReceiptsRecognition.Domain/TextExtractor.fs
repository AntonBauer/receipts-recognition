namespace ReceiptsRecognition.Domain


module TextExtractor =
    open System.IO

    /// <summary> Extracts text from an image </summary>
    type RawExtractor = Stream -> string

    /// <summary> Format extracted text into structured data</summary>
    type Formatter = string -> string

    /// <summary> Validates format </summary>
    type Validator = string -> Result<string, string>

    /// <summary> Parses validated data </summary>
    type Parser<'T> = string -> Result<'T, string>

    /// <summary> High level extractor definition </summary>
    type Extractor<'T> = Stream -> Result<'T, string>

    type ExtractorFactory<'T> = RawExtractor -> Formatter -> Validator -> Parser<'T> -> Extractor<'T>

    let createExtractor: ExtractorFactory<'T> =
        fun rawExtractor formatter validator parser ->
            fun stream -> rawExtractor stream |> formatter |> validator |> Result.bind parser
