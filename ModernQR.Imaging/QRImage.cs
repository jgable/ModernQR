using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ModernQR.Imaging
{
    public class QRImage
    {
        virtual public QRCodeEncoder Encoder { get; set; }

        virtual public Color QRCodeBackgroundColor { get; set; }
        virtual public Color QRCodeForegroundColor { get; set; }        

        public QRImage()
        {
            this.Encoder = new QRCodeEncoder();

            this.QRCodeBackgroundColor = Color.White;
            this.QRCodeForegroundColor = Color.Black;
        }

        /// <summary>
        /// Encode the content using the encoding scheme given
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public virtual Bitmap EncodeImage(String content, int cellWidth = 5)
        {
            var encoding = QRCodeUtility.IsUniCode(content) ? Encoding.Unicode : Encoding.ASCII;
            
            return EncodeImage(content, encoding, cellWidth);
        }

        /// <summary>
        /// Encode the content using the encoding scheme given
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public virtual Bitmap EncodeImage(String content, Encoding encoding, int cellWidth)
        {
            bool[][] matrix = Encoder.CalculateQRCode(encoding.GetBytes(content));

            Bitmap image = new Bitmap((matrix.Length * cellWidth) + 1, (matrix.Length * cellWidth) + 1);
            Graphics g = Graphics.FromImage(image);
            SolidBrush brush = new SolidBrush(QRCodeBackgroundColor);
            brush.Color = QRCodeForegroundColor;

            g.FillRectangle(brush, new Rectangle(0, 0, image.Width, image.Height));            
            
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (matrix[j][i])
                    {
                        g.FillRectangle(brush, j * cellWidth, i * cellWidth, cellWidth, cellWidth);
                    }
                }
            }

            return image;
        }
    }
}
