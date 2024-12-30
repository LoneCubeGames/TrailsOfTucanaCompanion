using Events;
using Extensions;
using Interfaces;
using Models;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Views;

namespace Presenters
{
    public class TerrainCardsPresenter : IPresenter
    {
        private readonly TerrainCardsView _view;
        private readonly TerrainCardsModel _model;
        private readonly InputSystemActions _inputSystemActions;

        public TerrainCardsPresenter(UIDocument uiDocument, string path, TerrainCardsModel model)
        {
            _view = new TerrainCardsView();
            _inputSystemActions = new InputSystemActions();
            _model = model;
            _view.Init(uiDocument, path);
            _view.NextRoundButton.Hide();
            _view.NewGameButton.Hide();

            UpdateTerrainCardsCountsLabel();
        }

        private void UpdateTerrainCardsCountsLabel() =>
            _view.NextTerrainButton.text = (_model.Items.Count / 2).ToString();

        private void OnNextRoundButtonClicked()
        {
            _model.CreateNewCards();
            _view.NextRoundButton.Hide();
            _view.NewGameButton.Hide();
            _view.NextTerrainButton.Show();

            EventManager.TerrainCardsClearedEvent.Invoke();
        }

        private void OnNewGameButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnNextTerrainButtonClicked()
        {
            switch (_model.Items.Count)
            {
                case 1:
                    return;
                case 3:
                    _view.NextRoundButton.Show();
                    _view.NewGameButton.Show();
                    _view.NextTerrainButton.Hide();
                    break;
            }

            EventManager.TerrainCardsChangedEvent.Invoke();
        }

        private void OnNextTerrainKeyboardClicked(InputAction.CallbackContext _) =>
            OnNextTerrainButtonClicked();

        private void OnNextRoundKeyboardClicked(InputAction.CallbackContext _) =>
            OnNextRoundButtonClicked();

        private void OnNewGameKeyboardClicked(InputAction.CallbackContext _) =>
            OnNewGameButtonClicked();

        public void Subscribe()
        {
            _view.NextTerrainButton.clicked += OnNextTerrainButtonClicked;
            _view.NextRoundButton.clicked += OnNextRoundButtonClicked;
            _view.NewGameButton.clicked += OnNewGameButtonClicked;
            EventManager.TerrainCardsChangedEvent.AddListener(UpdateTerrainCardsCountsLabel);
            EventManager.TerrainCardsClearedEvent.AddListener(UpdateTerrainCardsCountsLabel);

            _inputSystemActions.Enable();
            _inputSystemActions.UI.Next.performed += OnNextTerrainKeyboardClicked;
            _inputSystemActions.UI.NextRound.performed += OnNextRoundKeyboardClicked;
            _inputSystemActions.UI.NewGame.performed += OnNewGameKeyboardClicked;
        }

        public void Unsubscribe()
        {
            _view.NextTerrainButton.clicked -= OnNextTerrainButtonClicked;
            _view.NextRoundButton.clicked -= OnNextRoundButtonClicked;
            _view.NewGameButton.clicked -= OnNewGameButtonClicked;
            EventManager.TerrainCardsChangedEvent.RemoveListener(UpdateTerrainCardsCountsLabel);
            EventManager.TerrainCardsClearedEvent.RemoveListener(UpdateTerrainCardsCountsLabel);

            _inputSystemActions.Disable();
            _inputSystemActions.UI.Next.performed -= OnNextTerrainKeyboardClicked;
            _inputSystemActions.UI.NextRound.performed -= OnNextRoundKeyboardClicked;
            _inputSystemActions.UI.NewGame.performed -= OnNewGameKeyboardClicked;
        }
    }
}
