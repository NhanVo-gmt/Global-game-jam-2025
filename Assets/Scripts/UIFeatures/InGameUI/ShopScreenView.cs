using System;
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
    public Button skipBtn;
}

[ScreenInfo(nameof(ShopScreenView))]
public class ShopScreenPresenter : BaseScreenPresenter<ShopScreenView>
{
    public static Action OnSkip;

    public ShopScreenPresenter(SignalBus signalBus) : base(signalBus)
    {
        
    }

    public override UniTask BindData()
    {
        this.View.skipBtn.onClick.AddListener(() => OnSkip?.Invoke());
        
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
        
        this.View.skipBtn.onClick.RemoveAllListeners();
    }
}
