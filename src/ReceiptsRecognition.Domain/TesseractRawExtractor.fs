namespace ReceiptsRecognition.Domain

module TesseractRawExtractor =

    open TextExtractor
    open Tesseract

    type TesseractDataPath = TesseractDataPath of string
    type Language = Language of string

    type TesseractExtractorFactory = TesseractDataPath -> Language -> RawExtractor

    let create:TesseractExtractorFactory =
        fun tesseractDataPath language->
            fun stream ->
                let engine = new TesseractEngine(tesseractDataPath.ToString(), language.ToString(), EngineMode.Default)
                let bytes = [| 0uy |]
                let image = Pix.LoadFromMemory(bytes)
                let processed = engine.Process(image)
                let text = processed.GetText()

                processed.Dispose()
                image.Dispose();
                engine.Dispose()

                text

    // let extract tesseractDataPath language filePath =
    //     let engine = new TesseractEngine(tesseractDataPath, language, EngineMode.Default)
    //     let image = Pix.LoadFromFile(filePath)
    //     let processed = engine.Process(image)
    //     let text = processed.GetText()

    //     processed.Dispose()
    //     image.Dispose();
    //     engine.Dispose()

    //     text