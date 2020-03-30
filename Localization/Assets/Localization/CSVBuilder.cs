using System.Collections.Generic;

public class CSVBuilder : CSVBase
{
    private char fieldSeparator = ',';
    
    public string BuildCsv(string[] headers, List<string[]> translations)
    {
        string csv = "";
        
        // Headers
        for (int i = 0; i < headers.Length; i++)
        {
            csv += surround + headers[i] + surround;
            if (i != headers.Length - 1)
                csv += fieldSeparator;
        }
        csv += lineSeparator;
        
        // Translations
        for (int i = 0; i < translations.Count; i++)
        {
            string[] translation = translations[i];
            for (int j = 0; j < translation.Length; j++)
            {
                csv += surround + translation[j] + surround;
                if (j != translation.Length - 1)
                    csv += fieldSeparator;
            }

            if (i != translations.Count - 1)
                csv += lineSeparator;
        }
        return csv;
    }
}
