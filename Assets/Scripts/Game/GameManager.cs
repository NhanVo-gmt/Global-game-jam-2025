namespace Game
{
    using System;
    using Blueprints;
    using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
    using GameFoundation.Scripts.Utilities.Extension;
    using Level;
    using UnityEngine;
    using Zenject;
    using UnityEngine.UI;

    public class GameManager : MonoBehaviour
    {
        public enum State
        {
            None,
            Paused,

        }

        [SerializeField] private State currentState = State.None;

        #region Inject

        [Inject] private IScreenManager screenManager;
        [Inject] private LevelManager   levelManager;

        #endregion

        public static GameManager   Instance;
        public static Action<State> OnChangeGameState;

        public Canvas pauseUI;
        public static int              Point;
        public Action<int, int> OnAddedPoint;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            this.GetCurrentContainer().Inject(this);
            this.currentState = State.None;
            
            Point = 0;
        }

        public string GetRandomWord(TypingType type)
        {
            return levelManager.GetRandomWord(type);
        }

        public void ChangeGameState(State state)
        {
            currentState = state;
            OnChangeGameState?.Invoke(currentState);
        }

        public State GetCurrentState()
        {
            return currentState;
        }
        public void UnpauseGame()
        {
            ChangeGameState(State.None);
            Time.timeScale = 1;
            pauseUI.gameObject.SetActive(false);
        }
        public void PauseGame()
        {
            ChangeGameState(State.Paused);
			Time.timeScale = 0;
            pauseUI.gameObject.SetActive(true);
        }

        public void AddPoint(int addedPoint)
        {
            Point += addedPoint;
            
            OnAddedPoint?.Invoke(Point, addedPoint);
        }
    }
}