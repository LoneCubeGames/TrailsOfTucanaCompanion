using System.Linq;
using CommonNames;
using Events;
using Extensions;
using Interfaces;
using Models;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Views;

namespace Presenters
{
    public class StatisticBarPresenter : IPresenter
    {
        private readonly StatisticBarView _view;
        private readonly TerrainCardsModel _model;
        private readonly InputSystemActions _inputSystemActions;
        private bool _isStatisticBarShown;

        public StatisticBarPresenter(UIDocument uiDocument, string path, TerrainCardsModel model)
        {
            _view = new StatisticBarView();
            _inputSystemActions = new InputSystemActions();
            _model = model;
            _view.Init(uiDocument, path);
            _view.StatisticBarContainer.Hide();

            UpdateStatisticBarLabels();
        }

        private void UpdateStatisticBarLabels()
        {
            var deserts = _model
                .Items.Where(n => n.Contains(CommonTerrainCardsNames.Desert))
                .ToList()
                .Count;
            var forests = _model
                .Items.Where(n => n.Contains(CommonTerrainCardsNames.Forest))
                .ToList()
                .Count;
            var mountains = _model
                .Items.Where(n => n.Contains(CommonTerrainCardsNames.Mountain))
                .ToList()
                .Count;
            var waters = _model
                .Items.Where(n => n.Contains(CommonTerrainCardsNames.Water))
                .ToList()
                .Count;
            var any = _model
                .Items.Where(n => n.ToLower().Contains(CommonTerrainCardsNames.Any))
                .ToList()
                .Count;

            ShowDesert(deserts);
            ShowForest(forests);
            ShowMountain(mountains);
            ShowWater(waters);
            ShowAny(any);
        }

        private void ShowDesert(int value) => _view.DesertLabel.text = value.ToString();

        private void ShowForest(int value) => _view.ForestLabel.text = value.ToString();

        private void ShowMountain(int value) => _view.MountainLabel.text = value.ToString();

        private void ShowWater(int value) => _view.WaterLabel.text = value.ToString();

        private void ShowAny(int value) => _view.AnyLabel.text = value.ToString();

        private void OnStatisticBarButtonClicked() =>
            _view.StatisticBarContainer.Toggle(ref _isStatisticBarShown);

        private void OnStatisticBarKeyboardClicked(InputAction.CallbackContext _) =>
            OnStatisticBarButtonClicked();

        public void Subscribe()
        {
            _view.StatisticBarButton.clicked += OnStatisticBarButtonClicked;
            EventManager.TerrainCardsChangedEvent.AddListener(UpdateStatisticBarLabels);
            EventManager.TerrainCardsClearedEvent.AddListener(UpdateStatisticBarLabels);

            _inputSystemActions.Enable();
            _inputSystemActions.UI.Terrain.performed += OnStatisticBarKeyboardClicked;
        }

        public void Unsubscribe()
        {
            _view.StatisticBarButton.clicked -= OnStatisticBarButtonClicked;
            EventManager.TerrainCardsChangedEvent.RemoveListener(UpdateStatisticBarLabels);
            EventManager.TerrainCardsClearedEvent.RemoveListener(UpdateStatisticBarLabels);

            _inputSystemActions.Disable();
            _inputSystemActions.UI.Terrain.performed -= OnStatisticBarKeyboardClicked;
        }
    }
}
