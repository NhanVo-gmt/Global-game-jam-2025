namespace Game
{
    using System;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        private enum State
        {
            Shop,
            Play,
        }

        [SerializeField] private State currentState = State.Shop;
        
        private void Awake()
        {
            currentState = State.Shop;
            
            RegisterEvents();
        }

        private void OnDestroy()
        {
            DeregisterEvents();
        }

        void RegisterEvents()
        {
            ShopScreenPresenter.OnSkip += Shop_OnSkip;
        }
        
        void DeregisterEvents()
        {
            ShopScreenPresenter.OnSkip -= Shop_OnSkip;
        }
        
        private void Shop_OnSkip()
        {
            ChangeState(State.Play);
        }

        private void ChangeState(State newState)
        {
            currentState = newState;
        }
    }
}