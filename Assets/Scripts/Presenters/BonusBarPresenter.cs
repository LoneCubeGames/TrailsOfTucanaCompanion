using System.Collections.Generic;
using System.Linq;
using CommonNames;
using Extensions;
using Interfaces;
using Models;
using UnityEngine;
using UnityEngine.UIElements;
using Views;

namespace Presenters
{
    public class BonusBarPresenter : IPresenter
    {
        private readonly BonusBarView _view;
        private readonly TerrainCardsModel _model;

        private List<VisualElement> _bonusBlueCards;
        private List<VisualElement> _bonusRedCards;
        private bool _isBonusBarShown;

        public BonusBarPresenter(UIDocument uiDocument, string path, TerrainCardsModel model)
        {
            _view = new BonusBarView();
            _model = model;
            _view.Init(uiDocument, path);
            _view.BonusBarContainer.Hide();

            InitializeBlueCards();
            InitializeRedCards();
        }

        private void OnBonusBarButtonClicked() =>
            _view.BonusBarContainer.Toggle(ref _isBonusBarShown);

        public void Subscribe()
        {
            _view.BonusBarButton.clicked += OnBonusBarButtonClicked;
            SubscribeToBlueCards();
            SubscribeToRedCards();
        }

        public void Unsubscribe()
        {
            _view.BonusBarButton.clicked -= OnBonusBarButtonClicked;
            UnsubscribeFromBlueCards();
            UnsubscribeFromRedCards();
        }

        private void InitializeBlueCards()
        {
            _bonusBlueCards = _view
                .BonusBarContainer.Query<VisualElement>(className: CommonUssNames.BonusBlue)
                .ToList();
        }

        private void InitializeRedCards()
        {
            _bonusRedCards = _view
                .BonusBarContainer.Query<VisualElement>(className: CommonUssNames.BonusRed)
                .ToList();

            var randomizedCards = _bonusRedCards
                .OrderBy(_ => Random.Range(0, int.MaxValue))
                .ToList();

            _view.BonusRedContainer.Clear();

            foreach (var card in randomizedCards)
                _view.BonusRedContainer.Add(card);
        }

        private void SubscribeToBlueCards()
        {
            if (_bonusBlueCards == null)
                return;

            foreach (var card in _bonusBlueCards)
                card.RegisterCallback<ClickEvent>(OnCardClicked);
        }

        private void SubscribeToRedCards()
        {
            if (_bonusRedCards == null)
                return;

            foreach (var card in _bonusRedCards)
                card.RegisterCallback<ClickEvent>(OnCardClicked);
        }

        private void UnsubscribeFromBlueCards()
        {
            if (_bonusBlueCards == null)
                return;

            foreach (var card in _bonusBlueCards)
                card.UnregisterCallback<ClickEvent>(OnCardClicked);
        }

        private void UnsubscribeFromRedCards()
        {
            if (_bonusRedCards == null)
                return;

            foreach (var card in _bonusRedCards)
                card.UnregisterCallback<ClickEvent>(OnCardClicked);
        }

        private void OnCardClicked(ClickEvent evt)
        {
            if (evt.currentTarget is not VisualElement card)
                return;

            if (card.ClassListContains(CommonUssNames.Selected))
                card.RemoveFromClassList(CommonUssNames.Selected);
            else
                card.AddToClassList(CommonUssNames.Selected);
        }
    }
}
