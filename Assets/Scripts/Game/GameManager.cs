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
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            this.GetCurrentContainer().Inject(this);
        }

        public string GetRandomWord()
        {
            return levelManager.GetRandomWord(TypingType.Short);
        }
    }
}