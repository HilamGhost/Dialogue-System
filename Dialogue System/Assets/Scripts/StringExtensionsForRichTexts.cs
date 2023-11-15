using UnityEngine;

    public static class StringExtensionsForRichTexts
    {
        #region Change Text's Color
        
        /// <summary>
        /// You can use Supported colors which Unity's Supported Tags
        /// </summary>
       
        public static string AddColor(this string text,RichTextColors color)
        {
            string _wantedColorHead = "<color=" + ChosenColor(color) + "> ";
            string _wantedColorTail = "</color> ";

            string _textWithWantedColor = _wantedColorHead + text + _wantedColorTail;
            
            return _textWithWantedColor;
        }
       
        /// <summary>
        /// You can use Unity's colors
        /// </summary>
        /// 
        public static string AddColor(this string text,Color colorHex)
        {
            string _wantedColorHead = "<color=" + MakeRGBToHex(colorHex) + ">";
            string _wantedColorTail = "</color> ";

            string _textWithWantedColor = _wantedColorHead + text + _wantedColorTail;
            
            return _textWithWantedColor;
        }
        
        /// <summary>
        /// You can use your HEX CODE! (only hex code supports!)
        /// </summary>
        
        public static string AddColor(this string text,string _hex)
        {
            string _wantedColorHead = "<color=" + _hex + ">";
            string _wantedColorTail = "</color> ";

            string _textWithWantedColor = _wantedColorHead + text + _wantedColorTail;
            
            return _textWithWantedColor;
        }
        #endregion

        #region Change Text Size
        
        /// <summary>
        ///  You can change the font size.
        ///  Default Font Size is 12.5.
        /// </summary>
        /// <param name="_fontSize"> Lenght Of Font Size</param>
        /// <returns></returns>
        public static string ChangeFontSize(this string text, float _fontSize)
        {
            string _wantedSizeHead = "<size=" + _fontSize + "> ";
            string _wantedSizeTail = "</size> ";

            string _textWithWantedSize = _wantedSizeHead + text + _wantedSizeTail;
            
            return _textWithWantedSize;
        }

        #endregion
        
        #region  Change Text's Markup
        
        /// <summary>
        ///  Set's text to Bold
        /// </summary>
        public static string SetBold(this string text)
        {
            string _wantedBoldHead = "<b>";
            string _wantedBoldTail = "</b>";

            string _textWithWantedBold = _wantedBoldHead + text + _wantedBoldTail;
            
            return _textWithWantedBold;
        }
        
        /// <summary>
        ///  Set's text to Italic
        /// </summary>
        public static string SetItalic(this string text)
        {
            string _wantedItalicHead = "<i>";
            string _wantedItalicTail = "</i>";

            string _textWithWantedItalic = _wantedItalicHead + text + _wantedItalicTail;
            
            return _textWithWantedItalic;
        }
        
        /// <summary>
        ///  Set's text to Italic Bold
        /// </summary>
        public static string SetBoldItalic(this string text)
        {
            string _wantedItalicBoldHead = "<b><i>";
            string _wantedItalicBoldTail = "</i></b>";

            string _textWithWantedItalicBold = _wantedItalicBoldHead + text + _wantedItalicBoldTail;
            
            return _textWithWantedItalicBold;
        }
      

        #endregion

        #region Change Text's Caps
        /// <summary>
        ///  Set's text to UPPERCASE
        /// </summary>
        public static string SetUppercase(this string text)
        {
            string _wantedBoldHead = "<uppercase>";
            string _wantedBoldTail = "<uppercase>";

            string _textWithWantedBold = _wantedBoldHead + text + _wantedBoldTail;
            
            return _textWithWantedBold;
        }
        #endregion
       


        
        #region To Set Color
        
        static string MakeRGBToHex(Color c)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}",MakeFloatToByte(c.r), MakeFloatToByte(c.g), MakeFloatToByte(c.b));
        }
        
        static byte MakeFloatToByte(float f)
        {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }
        
        static string ChosenColor(RichTextColors color)
        {
            string _colorText = color.ToString().ToLower();
            return _colorText;
        }

        #endregion
        
        
    }
    public enum RichTextColors
    {
        Aqua,
        Black,	
        Blue,	
        Brown,
        Cyan,
        Darkblue,
        Fuchsia,
        Green,
        Grey,	
        Lightblue,
        Lime,
        Magenta,
        Maroon,
        Navy,
        Olive,
        Orange,
        Purple,
        Red,
        Silver,
        Teal,
        White,	
        Yellow

    }

