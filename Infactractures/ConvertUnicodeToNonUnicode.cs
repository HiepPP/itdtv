using System.Globalization;

namespace ssc.consulting.switchboard.Infactractures
{
    public static class ConvertStringExtension
    {
        public static string ConvertUnicodeToNonUnicode(this string strConvert)
        {
            var stFormD = strConvert.Normalize(System.Text.NormalizationForm.FormD);
            var sb = new System.Text.StringBuilder();
            for (var i = 0; i <= stFormD.Length - 1; i++)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
                if (uc == UnicodeCategory.NonSpacingMark != false) continue;
                string str;
                switch (stFormD[i])
                {
                    case 'đ':
                        str = "d";
                        break;
                    case 'Đ':
                        str = "D";
                        break;
                    default:
                        if (stFormD[i] == '\r' | stFormD[i] == '\n')
                            str = "";
                        else
                            str = stFormD[i].ToString(CultureInfo.InvariantCulture);
                        break;
                }
                sb.Append(str);
            }
            return sb.ToString();
        }

        public static string ConvertToSeoName(this string strConvert)
        {
            return strConvert.ConvertUnicodeToNonUnicode().Trim().Replace(" ", "-");
        }
    }
}