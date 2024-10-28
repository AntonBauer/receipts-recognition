namespace ReceiptsRecognition.Domain

open Tesseract

module Say =
    let hello tesseractDataPath language filePath =
        let engine = new TesseractEngine(tesseractDataPath, language, EngineMode.Default)
        let image = Pix.LoadFromFile(filePath)
        let processed = engine.Process(image)
        let text = processed.GetText()

        processed.Dispose()
        image.Dispose();
        engine.Dispose()

        text
