using Cysharp.Threading.Tasks;
using DataManager.MasterData;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using GameFoundationBridge;
using UnityEngine;
using UnityEngine.UI;
using UserData.Model;
using Zenject;
using Game;
using TMPro;


public class GameOverScreenView : BaseView
{
    public Button startBtn;
    public Button quitBtn;

    [SerializeField] public TextMeshProUGUI pointText;


    private void Awake()
    {

        setPointText(GameManager.Point);
    }

    private void setPointText(int point)
    {
        pointText.text = ("POINT: " + point.ToString());
    }
}

[ScreenInfo(nameof(StartGameScreenView))]
public class GameOverScreenPresenter : BaseScreenPresenter<StartGameScreenView>
{
    #region Inject
    
    private readonly GameSceneDirector gameSceneDirector;
    private readonly MasterDataManager masterDataManager;

    #endregion

    public GameOverScreenPresenter(SignalBus signalBus, GameSceneDirector gameSceneDirector, MasterDataManager masterDataManager) : base(signalBus)
    {
        this.gameSceneDirector = gameSceneDirector;
        this.masterDataManager = masterDataManager;
    }

    public override UniTask BindData()
    {
        this.masterDataManager.InitializeData().Forget();
        
        this.View.startBtn.onClick.AddListener(() => this.gameSceneDirector.LoadGameScene());
        this.View.quitBtn.onClick.AddListener(() => Application.Quit());
        
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
        
        this.View.startBtn.onClick.RemoveAllListeners();
        this.View.quitBtn.onClick.RemoveAllListeners();
    }
}
