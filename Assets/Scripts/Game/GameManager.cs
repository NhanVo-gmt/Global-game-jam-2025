namespace Game
{
    using System;
    using Blueprints;
    using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
    using GameFoundation.Scripts.Utilities.Extension;
    using Level;
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
        [Inject] private LevelManager   levelManager;

        #endregion

        public static GameManager   Instance;
        public static Action<State> OnChangeGameState;

        public int              Point;
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
            
            Point = 0;
        }

        public string GetRandomWord(TypingType type)
        {
            return levelManager.GetRandomWord(type);
        }

        public void AddPoint(int addedPoint)
        {
            Point += addedPoint;
            
            OnAddedPoint?.Invoke(Point, addedPoint);
        }
    }
}