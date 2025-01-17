using System;
using Cysharp.Threading.Tasks;
using DataManager.MasterData;
using Game;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using GameFoundation.Scripts.Utilities.LogService;
using GameFoundationBridge;
using UnityEngine;
using UnityEngine.UI;
using UserData.Model;
using Zenject;

public class ShopPopupModel
{
    public GameManager   gameManager;
    public PlayerManager playerManager;
}

public class ShopPopupView : BaseView
{
    public Button skipBtn;
}

[PopupInfo(nameof(ShopPopupView), false, false )]
public class ShopPopupPresenter : BasePopupPresenter<ShopPopupView, ShopPopupModel>
{
    public static Action OnSkip;

    public ShopPopupPresenter(SignalBus signalBus, ILogService logService) : base(signalBus, logService)
    {
        
    }
    
    public override UniTask BindData(ShopPopupModel popupModel)
    {
        this.View.skipBtn.onClick.AddListener(Skip);
        
        return UniTask.CompletedTask;
    }

    private void Skip()
    {
        this.View.skipBtn.onClick.RemoveAllListeners();
        
        CloseView();

        OnSkip?.Invoke();
    }

    protected override void OnViewReady()
    {
        base.OnViewReady();
        this.OpenViewAsync().Forget();
    }
    

    public override void Dispose()
    {
        base.Dispose();
        
        this.View.skipBtn.onClick.RemoveAllListeners();
    }
    
}
