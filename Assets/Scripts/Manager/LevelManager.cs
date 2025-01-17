namespace Level
{
    using Blueprints;
    using DataManager.MasterData;
    using DataManager.UserData;
    using UserData.Model;

    public class LevelManager : BaseDataManager<UserProfile>
    {
        private readonly PlayerBlueprint playerBlueprint;
        private readonly EnemyBlueprint enemyBlueprint;
        private readonly LevelBlueprint levelBlueprint;
        
        public LevelManager(MasterDataManager masterDataManager, PlayerBlueprint playerBlueprint, 
                            EnemyBlueprint enemyBlueprint, LevelBlueprint levelBlueprint) : base(masterDataManager)
        {
            this.playerBlueprint   = playerBlueprint;
            this.enemyBlueprint    = enemyBlueprint;
            this.levelBlueprint    = levelBlueprint;
        }
        
        
    }
}