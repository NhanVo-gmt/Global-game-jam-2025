namespace Level
{
    using System.Collections.Generic;
    using Blueprints;
    using DataManager.MasterData;
    using DataManager.UserData;
    using UnityEngine;
    using UserData.Model;

    public class LevelManager : BaseDataManager<UserProfile>
    {
        private readonly PlayerBlueprint playerBlueprint;
        private readonly EnemyBlueprint  enemyBlueprint;
        private readonly LevelBlueprint  levelBlueprint;
        private readonly TypingBlueprint typingBlueprint;
        
        public LevelManager(MasterDataManager masterDataManager, PlayerBlueprint playerBlueprint, 
                            EnemyBlueprint enemyBlueprint, LevelBlueprint levelBlueprint,
                            TypingBlueprint typingBlueprint) : base(masterDataManager)
        {
            this.playerBlueprint = playerBlueprint;
            this.enemyBlueprint  = enemyBlueprint;
            this.levelBlueprint  = levelBlueprint;
            this.typingBlueprint = typingBlueprint;
        }

        public string GetRandomWord(TypingType id)
        {
            List<string> words = typingBlueprint[id].Words;
            return words[Random.Range(0, words.Count)].Trim();
        }
    }
}