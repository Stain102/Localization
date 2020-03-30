using System;
using System.Text.RegularExpressions;

public class CSVReader : CSVBase
{
    private string[] fieldSeperator = {"\",\""};
    private Regex csvParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

    public string[] SplitText(string value)
    {
        return value.Split(lineSeparator);
    }

    public string[] SplitHeader(string value)
    {
        return value.Split(fieldSeperator, StringSplitOptions.None);
    }

    public string[] SplitLine(string value)
    {
        return csvParser.Split(value);
    }

    public string TrimValue(string value)
    {
        value = value.TrimStart(' ', surround);
        value = value.TrimEnd(surround);
        return value;
    }
}
