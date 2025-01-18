using Cysharp.Threading.Tasks;
using DataManager.MasterData;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using GameFoundationBridge;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UserData.Model;
using Zenject;

public class GameScreenView : BaseView
{
    public LoadingUI loadingUI;
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
        // this.View.loadingUI.PlayIntro();
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
