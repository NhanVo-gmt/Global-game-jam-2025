using Cysharp.Threading.Tasks;
using DataManager.MasterData;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using GameFoundationBridge;
using UnityEngine;
using UnityEngine.UI;
using UserData.Model;
using Zenject;

public class GameScreenView : BaseView
{

}

[ScreenInfo(nameof(GameScreenView))]
public class GameScreenPresenter : BaseScreenPresenter<GameScreenView>
{
    #region Inject
    
    private readonly GameSceneDirector gameSceneDirector;

    #endregion

    public GameScreenPresenter(SignalBus signalBus, GameSceneDirector gameSceneDirector) : base(signalBus)
    {
        this.gameSceneDirector = gameSceneDirector;
    }

    public override UniTask BindData()
    {
        
        return UniTask.CompletedTask;
    }
    
    protected override void OnViewReady()
    {
        base.OnViewReady();
        this.OpenViewAsync().Forget();
    }
    
    public void LoadGameOverScene()
    {
        this.gameSceneDirector.LoadGameOverScene().Forget();
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
