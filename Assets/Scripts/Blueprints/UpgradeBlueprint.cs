namespace Blueprints
{
    using DataManager.Blueprint.BlueprintReader;

    [BlueprintReader("Upgrade")]
    public class UpgradeBlueprint : GenericBlueprintReaderByRow<string, UpgradeRecord>
    {
        
    }
    
    [CsvHeaderKey("Id")]
    public class UpgradeRecord
    {
        public string Id;
    }
}