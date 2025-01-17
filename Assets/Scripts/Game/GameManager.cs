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
        }

        [SerializeField] private State currentState = State.None;

        #region Inject

        [Inject] private IScreenManager screenManager;

        #endregion

        public static Action<State> OnChangeGameState;
        
        private void Awake()
        {
            this.GetCurrentContainer().Inject(this);
        }


        private void ChangeState(State newState)
        {
            if (currentState == newState) return;
            
            currentState = newState;

            switch (currentState)
            {
            }
            
            OnChangeGameState?.Invoke(currentState);
        }
    }
}