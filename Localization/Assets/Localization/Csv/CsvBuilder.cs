using System.Collections.Generic;

public class CsvBuilder : CsvBase
{
    private char fieldSeparator = ',';

    public string BuildNewCsv(string[] headers)
    {
        return CreateHeader(headers);
    }

    public string BuildCsv(string[] headers, List<string[]> translations)
    {
        string csv = CreateHeader(headers);
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
    
    private string CreateHeader(string[] headers)
    {
        string csv = "";
        for (int i = 0; i < headers.Length; i++)
        {
            csv += surround + headers[i] + surround;
            if (i != headers.Length - 1)
                csv += fieldSeparator;
        }
        return csv;
    }
}
