using System.Collections.Generic;
using Interfaces;
using Models;
using Presenters;
using UnityEngine;
using UnityEngine.UIElements;

public class Bootstrap : MonoBehaviour
{
    private List<IPresenter> _presenters;

    private void Awake()
    {
        var model = new TerrainCardsModel();
        var document = GetComponent<UIDocument>();

        _presenters = new List<IPresenter>
        {
            new CardPresenter(document, "card-view-1", model),
            new CardPresenter(document, "card-view-2", model),
            new VillageBarPresenter(document, "village-bar-view", model),
            new StatisticBarPresenter(document, "statistic-bar-view", model),
            new BonusBarPresenter(document, "bonus-bar-view", model),
            new TerrainCardsPresenter(document, "terrain-cards-view", model),
        };
    }

    private void OnEnable()
    {
        foreach (var presenter in _presenters)
            presenter.Subscribe();
    }

    private void OnDisable()
    {
        foreach (var presenter in _presenters)
            presenter.Unsubscribe();
    }
}
