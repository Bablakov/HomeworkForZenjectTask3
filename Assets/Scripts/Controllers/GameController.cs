using System.Collections.Generic;
using Scripts.Players;
using Scripts.Balls;
using UnityEngine;
using Scripts.Interfaces;
using Scripts.VictoryCondition;
using Scripts.Input;

namespace Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private List<Ball> _balls;
        [SerializeField] private StartPanel _startPanel;

        private IVictoryCondition _victoryDeterminant;

        private void Awake()
        {
            PlayerInitialize();

            /*_startPanel.Initialize(this);*/
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        public void StartGameWithDestroyAllBall()
        {
            _victoryDeterminant = new AllBurstVictory(_balls, _player);
            _player.Enable();
            Subscribe();
        }

        public void StartGameWithDestroyAllBallOneColor()
        {
            _victoryDeterminant = new OneColorVictory(_balls, _player);
            _player.Enable();
            Subscribe();
        }

        private void Subscribe()
        {
            /*_victoryDeterminant.WonGame += OnWonGame;
            _victoryDeterminant.LostGame += OnLostGame;*/
        }

        private void Unsubscribe()
        {
           /* _victoryDeterminant.WonGame -= OnWonGame;
            _victoryDeterminant.LostGame -= OnLostGame;*/
        }

        private void OnWonGame()
        {
            Debug.Log("Победа!!!");
            _player.Disable();
        }

        private void OnLostGame()
        {
            Debug.Log("Поражение (((");
            _player.Disable();
        }

        private void PlayerInitialize()
        {
            GameInput gameInput = new GameInput();
            _player.Initialize(gameInput);
            _player.Disable();
        }
    }
}