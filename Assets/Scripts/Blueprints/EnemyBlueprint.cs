namespace Blueprints
{
    using DataManager.Blueprint.BlueprintReader;

    [BlueprintReader("Enemy")]
    public class EnemyBlueprint : GenericBlueprintReaderByRow<string, EnemyRecord>
    {
        
    }

    [CsvHeaderKey("Id")]
    public class EnemyRecord
    {
        public string Id;
    }
}