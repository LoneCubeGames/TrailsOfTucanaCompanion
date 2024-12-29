using Events;
using Extensions;
using Interfaces;
using Models;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Views;

namespace Presenters
{
    public class TerrainCardsPresenter : IPresenter
    {
        private readonly TerrainCardsView _view;
        private readonly TerrainCardsModel _model;

        public TerrainCardsPresenter(UIDocument uiDocument, string path, TerrainCardsModel model)
        {
            _view = new TerrainCardsView();
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

        public void Subscribe()
        {
            _view.NextTerrainButton.clicked += OnNextTerrainButtonClicked;
            _view.NextRoundButton.clicked += OnNextRoundButtonClicked;
            _view.NewGameButton.clicked += OnNewGameButtonClicked;
            EventManager.TerrainCardsChangedEvent.AddListener(UpdateTerrainCardsCountsLabel);
            EventManager.TerrainCardsClearedEvent.AddListener(UpdateTerrainCardsCountsLabel);
        }

        public void Unsubscribe()
        {
            _view.NextTerrainButton.clicked -= OnNextTerrainButtonClicked;
            _view.NextRoundButton.clicked -= OnNextRoundButtonClicked;
            _view.NewGameButton.clicked -= OnNewGameButtonClicked;
            EventManager.TerrainCardsChangedEvent.RemoveListener(UpdateTerrainCardsCountsLabel);
            EventManager.TerrainCardsClearedEvent.RemoveListener(UpdateTerrainCardsCountsLabel);
        }
    }
}
