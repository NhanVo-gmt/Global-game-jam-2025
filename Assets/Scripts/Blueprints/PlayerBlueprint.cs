namespace Blueprints
{
    using DataManager.Blueprint.BlueprintReader;

    [BlueprintReader("Player")]
    public class PlayerBlueprint : GenericBlueprintReaderByRow<string, PlayerRecord>
    {
        
    }

    [CsvHeaderKey("Id")]
    public class PlayerRecord
    {
        public string Id;
    }
}