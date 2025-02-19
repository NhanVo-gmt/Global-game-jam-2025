namespace DIContexts
{
    using DataManager.MasterData;
    using GameFoundation.Scripts;
    using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
    using GameFoundation.Scripts.Utilities;
    using GameFoundationBridge;
    using Level;
    using Setting;
    using UnityEngine.EventSystems;
    using Zenject;
    using Initialiser = Initialiser;

    public class GameProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Common systems and services
            GameFoundationInstaller.Install(this.Container);

            //Rebind SceneDirector
            this.Container.Bind<GameSceneDirector>().AsSingle().NonLazy();
            this.Container.Rebind<SceneDirector>().FromResolveGetter<GameSceneDirector>(data => data).AsCached();

            //Local User data
            this.Container.Bind<MasterDataManager>().AsSingle();
            
            //Audio
            this.Container.Bind<MasterAudio>().FromComponentInNewPrefabResource("GameAudio").AsCached().NonLazy();
            this.Container.BindInterfacesTo<AudioManager>().AsCached().NonLazy();
            
            //Data
            this.Container.Bind<LevelManager>().AsCached().NonLazy();
            
            //Loading
            // this.Container.Bind<LoadingUI>().FromComponentInNewPrefabResource("LoadingCanvas").AsCached().NonLazy();
            
            //Common Event System
            this.Container.Bind<EventSystem>().FromComponentInNewPrefabResource(nameof(EventSystem)).AsSingle().NonLazy();
            
            this.Container.Bind<SettingManager>().AsSingle();
            
            this.Container.Bind<Initialiser>().FromComponentInHierarchy().AsSingle();
        }
    }
}