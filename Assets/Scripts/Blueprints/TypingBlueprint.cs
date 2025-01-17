namespace Blueprints
{
    using System.Collections.Generic;
    using DataManager.Blueprint.BlueprintReader;

    [BlueprintReader("Typing")]
    public class TypingBlueprint : GenericBlueprintReaderByRow<TypingType, TypingRecord>
    {
        
    }

    [CsvHeaderKey("Id")]
    public class TypingRecord
    {
        public TypingType   Id;
        public List<string> Words;
    }

    public enum TypingType
    {
        Short,
        Medium,
        Long
    }
}