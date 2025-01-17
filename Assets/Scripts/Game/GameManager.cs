namespace Game
{
    using System;
    using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
    using GameFoundation.Scripts.Utilities.Extension;
    using UnityEngine;
    using Zenject;

    public class GameManager : MonoBehaviour
    {
        public enum State
        {
            None,
            Shop,
            Play,
        }

        [SerializeField] private State currentState = State.None;

        #region Inject

        [Inject] private IScreenManager screenManager;

        #endregion

        public static Action<State> OnChangeGameState;
        
        private void Awake()
        {
            this.GetCurrentContainer().Inject(this);
            ChangeState(State.Shop);
            
            RegisterEvents();
        }

        private void OnDestroy()
        {
            DeregisterEvents();
        }

        void RegisterEvents()
        {
            ShopPopupPresenter.OnSkip += Shop_OnSkip;
        }
        
        void DeregisterEvents()
        {
            ShopPopupPresenter.OnSkip -= Shop_OnSkip;
        }
        
        private void Shop_OnSkip()
        {
            ChangeState(State.Play);
        }

        private void ChangeState(State newState)
        {
            if (currentState == newState) return;
            
            currentState = newState;

            switch (currentState)
            {
                case State.Shop:
                    screenManager.OpenScreen<ShopPopupPresenter, ShopPopupModel>(new());
                    break;
                case State.Play:
                    // todo startgame
                    break;
            }
            
            OnChangeGameState?.Invoke(currentState);
        }
    }
}