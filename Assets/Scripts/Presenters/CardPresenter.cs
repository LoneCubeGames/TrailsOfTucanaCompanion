using CommonNames;
using Events;
using Interfaces;
using Models;
using UnityEngine;
using UnityEngine.UIElements;
using Views;

namespace Presenters
{
    public class CardPresenter : IPresenter
    {
        private readonly CardView _card;
        private readonly TerrainCardsModel _model;

        public CardPresenter(UIDocument uiDocument, string path, TerrainCardsModel model)
        {
            _card = new CardView();
            _model = model;
            _card.Init(uiDocument, path);
        }

        private void SetStyle(string style)
        {
            _card.Image.ClearClassList();
            _card.Image.AddToClassList(style);
            _card.Image.AddToClassList(CommonUssNames.Anim);
            _card.Image.RegisterCallback<TransitionEndEvent>(
                _ => _card.Image.RemoveFromClassList(CommonUssNames.Anim)
            );
        }

        private void Draw()
        {
            var index = Random.Range(0, _model.Items.Count);
            SetStyle(_model.Items[index]);
            _model.Items.RemoveAt(index);
        }

        private void Clear() => SetStyle(CommonUssNames.None);

        public void Subscribe()
        {
            EventManager.TerrainCardsChangedEvent.AddListener(Draw);
            EventManager.TerrainCardsClearedEvent.AddListener(Clear);
        }

        public void Unsubscribe()
        {
            EventManager.TerrainCardsChangedEvent.RemoveListener(Draw);
            EventManager.TerrainCardsClearedEvent.RemoveListener(Clear);
        }
    }
}
