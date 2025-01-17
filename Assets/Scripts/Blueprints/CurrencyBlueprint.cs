namespace Blueprints
{
    using DataManager.Blueprint.BlueprintReader;

    [BlueprintReader("Currency")]
    public class CurrencyBlueprint : GenericBlueprintReaderByRow<string, CurrencyRecord>
    {
        
    }
    
    [CsvHeaderKey("Id")]
    public class CurrencyRecord
    {
        public string Id;
    }
}