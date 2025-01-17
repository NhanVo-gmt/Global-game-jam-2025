using Cysharp.Threading.Tasks;
using DataManager.MasterData;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using GameFoundationBridge;
using UnityEngine;
using UnityEngine.UI;
using UserData.Model;
using Zenject;

public class ShopScreenView : BaseView
{

}

[ScreenInfo(nameof(ShopScreenView))]
public class ShopScreenPresenter : BaseScreenPresenter<ShopScreenView>
{
    #region Inject
    
    private readonly GameSceneDirector gameSceneDirector;

    #endregion

    public ShopScreenPresenter(SignalBus signalBus, GameSceneDirector gameSceneDirector) : base(signalBus)
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
    

    public override void Dispose()
    {
        base.Dispose();
    }
}
