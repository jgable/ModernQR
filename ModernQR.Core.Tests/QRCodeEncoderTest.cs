using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ModernQR.Imaging;
using System.Drawing;
using ModernQR.Data;

namespace ModernQR.Tests
{
    
    
    /// <summary>
    ///This is a test class for QRCodeEncoderTest and is intended
    ///to contain all QRCodeEncoderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class QRCodeEncoderTest
    {
        // QRData Matrix from valid qr tag generated from old QRCodeLib.
        private static bool[][] helloWorldQRData = new bool[][] 
            {
                new bool[] { true, true, true, true, true, true, true, false, false, true, true, true, false, false, true, true, false, false, false, false, false, true, true, false, true, false, true, true, true, true, true, true, true, },
                new bool[] { true, false, false, false, false, false, true, false, false, true, true, false, false, false, false, true, true, false, true, false, true, true, false, false, false, false, true, false, false, false, false, false, true, },
                new bool[] { true, false, true, true, true, false, true, false, true, false, false, true, false, false, true, true, false, false, false, false, false, true, true, false, true, false, true, false, true, true, true, false, true, },
                new bool[] { true, false, true, true, true, false, true, false, true, true, false, false, false, false, false, true, false, false, true, false, false, true, false, false, true, false, true, false, true, true, true, false, true, },
                new bool[] { true, false, true, true, true, false, true, false, true, false, false, true, true, true, true, true, true, true, false, false, true, false, true, false, false, false, true, false, true, true, true, false, true, },
                new bool[] { true, false, false, false, false, false, true, false, true, true, true, false, false, true, true, false, false, true, false, true, false, false, true, true, true, false, true, false, false, false, false, false, true, },
                new bool[] { true, true, true, true, true, true, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, true, true, true, true, true, true, },
                new bool[] { false, false, false, false, false, false, false, false, true, false, true, true, true, true, false, false, true, true, true, true, true, false, false, true, false, false, false, false, false, false, false, false, false, },
                new bool[] { true, false, true, true, true, true, true, false, false, true, true, false, true, false, true, false, false, false, false, true, false, true, true, true, true, false, true, true, true, true, true, false, false, },
                new bool[] { false, false, true, true, false, false, false, true, true, true, true, true, true, true, false, true, true, true, true, false, true, false, false, false, false, false, true, false, false, true, true, true, false, },
                new bool[] { false, false, false, true, false, false, true, false, true, false, true, false, true, true, true, false, false, true, false, true, false, false, true, true, true, false, false, false, true, true, true, false, false, },
                new bool[] { true, false, false, true, false, true, false, true, true, false, true, true, true, true, false, false, true, true, true, true, true, false, false, true, false, true, false, false, false, true, true, true, false, },
                new bool[] { true, true, false, false, false, true, true, true, false, true, false, true, false, false, true, false, true, false, false, true, true, true, true, true, false, false, false, true, false, false, false, false, false, },
                new bool[] { true, false, false, false, true, true, false, false, true, false, false, false, true, true, false, true, false, false, true, false, false, true, false, false, true, true, false, false, true, true, false, false, true, },
                new bool[] { false, true, false, true, true, false, true, true, true, false, true, true, false, false, true, true, true, false, true, false, true, true, false, false, false, true, true, true, true, false, false, true, false, },
                new bool[] { false, false, true, true, false, false, false, true, true, true, true, true, false, false, false, true, false, false, false, false, false, true, true, false, true, true, true, false, true, true, false, false, false, },
                new bool[] { true, false, false, false, true, true, true, false, false, true, false, true, true, true, false, true, true, false, true, false, true, true, false, false, true, true, false, false, false, false, true, false, true, },
                new bool[] { true, false, true, true, false, true, false, false, true, true, false, false, true, false, false, true, false, false, false, false, false, true, true, false, true, true, true, false, false, true, false, false, false, },
                new bool[] { true, true, true, false, true, true, true, false, true, false, true, false, true, true, true, true, true, false, true, false, true, true, false, false, true, true, true, true, false, false, true, true, true, },
                new bool[] { false, true, true, false, false, true, false, true, false, false, true, true, true, false, true, true, false, false, false, false, false, true, true, false, false, false, true, true, false, true, true, false, true, },
                new bool[] { false, false, false, false, true, false, true, false, true, false, true, true, false, false, false, true, false, false, true, false, false, true, false, false, true, true, true, false, false, false, false, true, true, },
                new bool[] { false, false, true, true, true, true, false, true, false, true, false, false, false, false, false, true, true, true, false, false, true, false, true, false, false, false, false, true, false, false, true, false, false, },
                new bool[] { false, true, false, false, true, true, true, false, false, false, false, true, false, true, true, false, false, true, false, true, false, false, true, true, true, false, false, false, false, true, true, true, false, },
                new bool[] { false, true, false, true, true, false, false, true, false, false, true, true, true, true, false, false, true, true, true, true, true, false, false, true, false, false, true, true, false, false, true, true, true, },
                new bool[] { false, true, false, true, true, true, true, true, true, true, false, false, true, false, true, false, false, false, false, true, false, true, true, true, true, true, true, true, true, true, true, false, true, },
                new bool[] { false, false, false, false, false, false, false, false, true, false, true, true, false, true, true, true, true, true, true, false, true, false, false, false, true, false, false, false, true, true, false, true, false, },
                new bool[] { true, true, true, true, true, true, true, false, false, false, true, false, false, false, true, false, false, true, false, true, false, false, true, true, true, false, true, false, true, false, true, false, false, },
                new bool[] { true, false, false, false, false, false, true, false, true, false, false, true, false, true, true, false, true, true, true, true, true, false, false, true, true, false, false, false, true, true, true, true, false, },
                new bool[] { true, false, true, true, true, false, true, false, true, true, false, true, false, false, true, false, true, false, false, true, true, true, true, false, true, true, true, true, true, false, false, false, false, },
                new bool[] { true, false, true, true, true, false, true, false, true, true, false, false, false, false, true, true, false, false, true, false, false, true, false, false, true, true, false, true, true, true, false, false, false, },
                new bool[] { true, false, true, true, true, false, true, false, true, true, true, true, true, false, false, true, true, false, true, false, true, true, false, true, false, false, true, true, false, false, false, false, false, },
                new bool[] { true, false, false, false, false, false, true, false, false, true, false, false, true, false, false, true, false, false, false, false, false, true, true, true, true, false, false, false, true, true, false, false, false, },
                new bool[] { true, true, true, true, true, true, true, false, true, false, true, true, true, true, true, true, true, false, true, false, true, true, false, false, true, true, false, false, true, false, true, true, false, },

            };

        /// <summary>
        ///A test for EncodeData
        ///</summary>
        [TestMethod()]
        public void EncodeDataTest()
        {
            QRCodeEncoder target = new QRCodeEncoder();
            target.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            target.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            target.QRCodeVersion = 4;

            string content = "Hello World"; 
            bool[][] expected = helloWorldQRData; 
            bool[][] actual;

            actual = target.EncodeData(content);

            Assert.AreEqual<int>(expected.Length, actual.Length, "Lengths equal");

            string msgForm = "Value Same: [{0},{1}]";
            for (int row = 0; row < actual.Length; row++)
            {
                for (int col = 0; col < actual.Length; col++)
                {
                    // Note the comparison col, row are switched because my exported data is backwards
                    Assert.AreEqual(expected[row][col], actual[col][row], string.Format(msgForm, col, row));
                }
            }
        }

        [TestMethod]
        public void EncodeImageTest()
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            encoder.QRCodeVersion = 4;

            string content = "Hello World";

            var cellWidth = 6;
            var img = new QRImage(encoder).EncodeImage(content, cellWidth);
            
            Assert.IsNotNull(img, "Image is not null");

            var halfCellWidth = cellWidth / 2;
            var cells = encoder.EncodeData(content);
            for (int i = 0; i < cells.Length; i++)
            {
                for (int j = 0; j < cells.Length; j++)
                {
                    // Add offset for middle of cell.
                    var x = (i * cellWidth) + halfCellWidth;
                    var y = (j * cellWidth) + halfCellWidth;
                    var pixColor = img.GetPixel(x, y);
                    var expected = cells[i][j] ? Color.Black : Color.White;

                    Assert.AreEqual(expected.R, pixColor.R);
                    Assert.AreEqual(expected.G, pixColor.G);
                    Assert.AreEqual(expected.B, pixColor.B);                    
                }
            }

            img.Save("HelloWorld" + new Random().Next(100, 999) + "_QR.bmp");
        }

        [TestMethod]
        public void DecodeImageTest()
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            encoder.QRCodeVersion = 4;

            string content = "Hello World";

            var cellWidth = 6;
            var img = new QRImage(encoder).EncodeImage(content, cellWidth);

            Assert.IsNotNull(img, "Image is not null");

            QRCodeDecoder decoder = new QRCodeDecoder();

            QRCodeBitmapImage bitmapImg = new QRCodeBitmapImage(img);
            var result = decoder.decode(bitmapImg);

            Assert.AreEqual(content, result);
        }
    }
}
