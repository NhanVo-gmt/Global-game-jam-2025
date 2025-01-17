using Cysharp.Threading.Tasks;
using DataManager.MasterData;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using GameFoundationBridge;
using UnityEngine;
using UnityEngine.UI;
using UserData.Model;
using Zenject;

public class StartGameScreenView : BaseView
{

}

[ScreenInfo(nameof(StartGameScreenView))]
public class StartGameScreenPresenter : BaseScreenPresenter<StartGameScreenView>
{
    #region Inject
    
    private readonly GameSceneDirector gameSceneDirector;
    private readonly MasterDataManager masterDataManager;

    #endregion

    public StartGameScreenPresenter(SignalBus signalBus, GameSceneDirector gameSceneDirector, MasterDataManager masterDataManager) : base(signalBus)
    {
        this.gameSceneDirector = gameSceneDirector;
        this.masterDataManager = masterDataManager;
    }

    public override UniTask BindData()
    {
        this.masterDataManager.InitializeData().Forget();
        
        return UniTask.CompletedTask;
    }
    protected override void OnViewReady()
    {
        base.OnViewReady();
        this.OpenViewAsync().Forget();
    }
    

    public override void Dispose()
    {
        base.Dispose();
    }
}
