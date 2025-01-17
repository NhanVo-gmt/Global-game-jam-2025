﻿namespace Level
{
    using Blueprints;
    using DataManager.MasterData;
    using DataManager.UserData;
    using UserData.Model;

    public class LevelManager : BaseDataManager<UserProfile>
    {
        private readonly PlayerBlueprint playerBlueprint;
        private readonly EnemyBlueprint enemyBlueprint;
        private readonly UpgradeBlueprint upgradeBlueprint;
        private readonly LevelBlueprint levelBlueprint;
        
        public LevelManager(MasterDataManager masterDataManager, PlayerBlueprint playerBlueprint, 
                            EnemyBlueprint enemyBlueprint, UpgradeBlueprint upgradeBlueprint, 
                            LevelBlueprint levelBlueprint) : base(masterDataManager)
        {
            this.playerBlueprint   = playerBlueprint;
            this.enemyBlueprint    = enemyBlueprint;
            this.upgradeBlueprint  = upgradeBlueprint;
            this.levelBlueprint    = levelBlueprint;
        }
        
        
    }
}