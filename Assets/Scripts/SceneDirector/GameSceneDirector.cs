namespace GameFoundationBridge
{
    using System;
    using Cysharp.Threading.Tasks;
    using GameFoundation.Scripts.AssetLibrary;
    using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Zenject;

    public static class SceneName
    {
        public const string Loading          = "0.LoadingScene";
        public const string StartScene       = "1.StartScene";
        public const string GameScene        = "2.GameScene";
        public const string GameOverScene    = "3.GameOverScene";
    }

    public class GameSceneDirector : SceneDirector
    {
        public GameSceneDirector(SignalBus signalBus, IGameAssets gameAssets) :
            base(signalBus, gameAssets)
        {
            CurrentSceneName = SceneName.Loading;
        }

        #region shortcut
        
        public UniTask LoadStartScene()
        {
            return this.LoadSingleSceneBySceneManagerAsync(SceneName.StartScene);
        }
        
        public UniTask LoadGameScene()
        {
            return this.LoadSingleSceneBySceneManagerAsync(SceneName.GameScene);
        }
        
        public async UniTask LoadLevelScene(string id, int index)
        {
            string levelName = $"Level{id}Stage{index}";
            await this.LoadMultipleSceneBySceneManagerAsync(SceneName.GameScene, SceneName.GameScene, levelName);
        }
        public UniTask LoadGameOverScene()
        {
            return this.LoadSingleSceneBySceneManagerAsync(SceneName.GameOverScene);
        }

        #endregion
    }
}