namespace CZBK.HeiMaOA.COMMON
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    /// <summary> 
    /// ��֤����
    /// </summary> 
    public class VerifyCode
    {
        #region �ֶ�
        private static readonly string[] FontItems =
            { 
                "Arial", 
                "Helvetica", 
                "Geneva", 
                "sans-serif", 
                "Verdana" 
            };
        private static readonly Brush[] BrushItems =
            { 
                Brushes.OliveDrab, 
                Brushes.ForestGreen, 
                Brushes.DarkCyan, 
                Brushes.LightSlateGray, 
                Brushes.RoyalBlue, 
                Brushes.SlateBlue, 
                Brushes.DarkViolet, 
                Brushes.MediumVioletRed, 
                Brushes.IndianRed, 
                Brushes.Firebrick, 
                Brushes.Chocolate, 
                Brushes.Peru, 
                Brushes.Goldenrod 
            };
        private static readonly string[] BrushName =
            { 
                "OliveDrab",
                "ForestGreen", 
                "DarkCyan", 
                "LightSlateGray", 
                "RoyalBlue", 
                "SlateBlue",
                "DarkViolet", 
                "MediumVioletRed", 
                "IndianRed", 
                "Firebrick", 
                "Chocolate", 
                "Peru", 
                "Goldenrod" 
            };
        private readonly Color _background;
        private readonly Pen _borderColor;
        private readonly Font _font;
        private readonly int _width;
        private readonly int _height;
        private readonly Random _random;
        private int _brushNameIndex;
        #endregion

        /// <summary>
        /// ��֤��
        /// </summary>
        public string Code { get; private set; }

        #region ���캯��

        /// <summary>
        /// ����һ����֤�����
        /// </summary>
        /// <param name="length">��֤�볤��</param>
        /// <param name="width">ͼƬ���</param>
        /// <param name="height">ͼƬ�߶�</param>
        /// <param name="fontSize">�����С</param>
        /// <param name="background">����ɫ</param>
        /// <param name="border">�߿���ɫ</param>
        public VerifyCode(byte length = 4, short width = 50, short height = 20, float fontSize = 12, Color background = default(Color), Pen border = default(Pen))
        {
            this._random = new Random();
            this._background = background;
            this._borderColor = border ?? Pens.White;
            this._font = this.GetFont(fontSize);
            this._width = width;
            this._height = height;
            this.Code = GetRandomCode(length);
        }
        #endregion

        #region ȡ��һ��ָ��λ��������� _static string GetRandomCode(int length)
        /// <summary> 
        /// ȡ��һ��ָ��λ��������� 
        /// </summary> 
        /// <returns></returns> 
        private static string GetRandomCode(int length)
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, length);
        }
        #endregion

        #region ���ȡһ������ _Font GetFont()
        /// <summary> 
        /// ���ȡһ������ 
        /// </summary> 
        /// <returns></returns> 
        private Font GetFont(float fontSize)
        {
            int fontIndex = this._random.Next(0, FontItems.Length);
            FontStyle fontStyle = GetFontStyle(this._random.Next(0, 2));
            return new Font(FontItems[fontIndex], fontSize, fontStyle);
        }
        #endregion

        #region ȡһ���������ʽ _static FontStyle GetFontStyle(int index)
        /// <summary> 
        /// ȡһ���������ʽ 
        /// </summary> 
        /// <param name="index"></param> 
        /// <returns></returns> 
        private static FontStyle GetFontStyle(int index)
        {
            switch (index)
            {
                case 0:
                    return FontStyle.Bold;
                case 1:
                    return FontStyle.Italic;
                default:
                    return FontStyle.Regular;
            }
        }
        #endregion

        #region ���ȡһ����ˢ _Brush GetBrush()
        /// <summary> 
        /// ���ȡһ����ˢ 
        /// </summary> 
        /// <returns></returns> 
        private Brush GetBrush()
        {
            int brushIndex = this._random.Next(0, BrushItems.Length);
            this._brushNameIndex = brushIndex;
            return BrushItems[brushIndex];
        }
        #endregion

        #region ����λͼ +Bitmap DrawBitmap()
        /// <summary> 
        /// ����λͼ��ע��Է���ֵʹ�ù������Դ�ͷ� 
        /// </summary> 
        public byte[] DrawBitmap()
        {
            using (var image = new Bitmap(this._width, this._height))
            {
                using (var g = Graphics.FromImage(image))
                {
                    this.PaintBackground(g);
                    this.PaintText(g);
                    this.PaintTextStain(image);
                    this.PaintBorder(g);
                    //����ͼƬ����
                    var stream = new MemoryStream();
                    image.Save(stream, ImageFormat.Gif);
                    //���ͼƬ��
                    return stream.ToArray();
                }
            }
        }
        /// <summary> 
        /// �滭������ɫ 
        /// </summary> 
        /// <param name="g"></param> 
        private void PaintBackground(Graphics g)
        {
            g.Clear(this._background);
        }
        /// <summary> 
        /// �滭�߿� 
        /// </summary> 
        /// <param name="g"></param> 
        private void PaintBorder(Graphics g)
        {
            g.DrawRectangle(this._borderColor, 0, 0, this._width - 1, this._height - 1);
        }
        /// <summary> 
        /// �滭���� 
        /// </summary> 
        /// <param name="g"></param> 
        private void PaintText(Graphics g)
        {
            g.DrawString(this.Code, this._font, this.GetBrush(), 3, 1);
        }
        /// <summary> 
        /// �滭����������͸�����
        /// </summary> 
        /// <param name="b"></param> 
        private void PaintTextStain(Bitmap b)
        {
            for (int n = 0; n < 50; n++)
            {
                int x = this._random.Next(this._width);
                int y = this._random.Next(this._height);
                b.SetPixel(x, y, Color.FromName(BrushName[this._brushNameIndex]));
            }
        }
        #endregion
    }
}