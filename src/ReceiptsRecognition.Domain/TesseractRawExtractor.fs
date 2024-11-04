namespace ReceiptsRecognition.Domain

module TesseractRawExtractor =

    open System.IO

    open TextExtractor
    open Tesseract
    open TesseractLanguage

    type TesseractDataPath = TesseractDataPath of string

    type TesseractExtractorFactory = TesseractDataPath -> Language -> RawExtractor

    let private readBytes stream =
        use reader = new BinaryReader(stream)
        reader.ReadBytes((int)stream.Length);

    let create:TesseractExtractorFactory =
        fun tesseractDataPath language->
            fun stream ->
                use engine = new TesseractEngine(tesseractDataPath.ToString(), language.ToString(), EngineMode.Default)
                let bytes = readBytes stream
                use image = Pix.LoadFromMemory(bytes)
                use processed = engine.Process(image)
                processed.GetText()