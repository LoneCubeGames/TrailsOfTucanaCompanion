using CommonNames;
using Extensions;
using Interfaces;
using Models;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Views;

namespace Presenters
{
    public class VillageBarPresenter : IPresenter
    {
        private readonly VillageBarView _view;
        private readonly TerrainCardsModel _model;
        private readonly InputSystemActions _inputSystemActions;
        private bool _isVillageBarShown;

        public VillageBarPresenter(UIDocument uiDocument, string path, TerrainCardsModel model)
        {
            _view = new VillageBarView();
            _inputSystemActions = new InputSystemActions();
            _model = model;
            _view.Init(uiDocument, path);
            _view.VillageBarContainer.Hide();

            SetRandomVillageUssClass();
        }

        private void OnVillageBarButtonClicked() =>
            _view.VillageBarContainer.Toggle(ref _isVillageBarShown);

        private void OnVillageBarKeyboardClicked(InputAction.CallbackContext _) =>
            OnVillageBarButtonClicked();

        private void SetRandomVillageUssClass()
        {
            var random = Random.Range(0, 13);
            var villageUssClassName = CommonUssNames.Village + "_" + random;

            _view.VillageBarImage.ClearClassList();
            _view.VillageBarImage.AddToClassList(villageUssClassName);
        }

        public void Subscribe()
        {
            _view.VillageBarButton.clicked += OnVillageBarButtonClicked;

            _inputSystemActions.Enable();
            _inputSystemActions.UI.Map.performed += OnVillageBarKeyboardClicked;
        }

        public void Unsubscribe()
        {
            _view.VillageBarButton.clicked -= OnVillageBarButtonClicked;

            _inputSystemActions.Disable();
            _inputSystemActions.UI.Map.performed -= OnVillageBarKeyboardClicked;
        }
    }
}
