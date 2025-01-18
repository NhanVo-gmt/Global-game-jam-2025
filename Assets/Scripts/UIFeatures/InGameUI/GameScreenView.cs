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
using Game;

public class GameScreenView : BaseView
{
    public LoadingUI loadingUI;
    public Button continueButton;
    public Button exitButton;
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
        this.View.continueButton.onClick.AddListener(() => GameManager.Instance.UnpauseGame());
        this.View.exitButton.onClick.AddListener(() => 
        {   GameManager.Instance.UnpauseGame();
            this.gameSceneDirector.LoadGameOverScene();
        });
        
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
