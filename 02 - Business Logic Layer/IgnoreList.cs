using DbProject;
using System.Xml.Serialization;
// this class is for 
public class IgnoreList
{
    public static XmlAttributeOverrides GetOverrides()
    {
        XmlAttributeOverrides overrides = new XmlAttributeOverrides();
        XmlAttributes attrs = new XmlAttributes();
        attrs.XmlIgnore = true;

        // Ignore the Expression and Position properties of the ExpressionsVsPosition class
        overrides.Add(typeof(ExpressionsVsPosition), "Expression", attrs);
        overrides.Add(typeof(ExpressionsVsPosition), "Position", attrs);

        // Ignore the WordsVsGroups property of the Group class
        overrides.Add(typeof(Group), "WordsVsGroups", attrs);

        // Ignore the ExpressionsVsPositions property of the LinguisticExpression class
        overrides.Add(typeof(LinguisticExpression), "ExpressionsVsPositions", attrs);

        // Ignore the Song and WordsVsGroups properties of the Word class
        overrides.Add(typeof(Word), "Song", attrs);
        overrides.Add(typeof(Word), "WordsVsGroups", attrs);

        // Ignore the Positions and Words properties of the Song class
        overrides.Add(typeof(Song), "Positions", attrs);
        overrides.Add(typeof(Song), "Words", attrs);

        // Ignore the Group and Word properties of the WordsVsGroup class
        overrides.Add(typeof(WordsVsGroup), "Group", attrs);
        overrides.Add(typeof(WordsVsGroup), "Word", attrs);

        // Ignore the Song and ExpressionsVsPositions properties of the Position class
        overrides.Add(typeof(Position), "Song", attrs);
        overrides.Add(typeof(Position), "ExpressionsVsPositions", attrs);

        return overrides;
    }
}