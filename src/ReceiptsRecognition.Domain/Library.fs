namespace ReceiptsRecognition.Domain

open Tesseract

module Say =
    let hello filePath =
        let engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default)
        let image = Pix.LoadFromFile(filePath)
        let text = engine.Process(image)

        image.Dispose();
        engine.Dispose()

        text
