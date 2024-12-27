using System.Collections.Generic;
using CommonNames;

namespace Models
{
    public class TerrainCardsModel
    {
        public List<string> Items { get; } = new();

        public TerrainCardsModel() => CreateNewCards();

        public void CreateNewCards()
        {
            Items.Clear();
            Items.Add(CommonTerrainCardsNames.Desert);
            Items.Add(CommonTerrainCardsNames.Desert);
            Items.Add(CommonTerrainCardsNames.Desert);
            Items.Add(CommonTerrainCardsNames.Desert);
            Items.Add(CommonTerrainCardsNames.Desert);
            Items.Add(CommonTerrainCardsNames.Desert);
            Items.Add(CommonTerrainCardsNames.Desert);
            Items.Add(CommonTerrainCardsNames.Desert);
            Items.Add(CommonTerrainCardsNames.Forest);
            Items.Add(CommonTerrainCardsNames.Forest);
            Items.Add(CommonTerrainCardsNames.Forest);
            Items.Add(CommonTerrainCardsNames.Forest);
            Items.Add(CommonTerrainCardsNames.Forest);
            Items.Add(CommonTerrainCardsNames.Forest);
            Items.Add(CommonTerrainCardsNames.Forest);
            Items.Add(CommonTerrainCardsNames.Mountain);
            Items.Add(CommonTerrainCardsNames.Mountain);
            Items.Add(CommonTerrainCardsNames.Mountain);
            Items.Add(CommonTerrainCardsNames.Mountain);
            Items.Add(CommonTerrainCardsNames.Mountain);
            Items.Add(CommonTerrainCardsNames.Mountain);
            Items.Add(CommonTerrainCardsNames.Water);
            Items.Add(CommonTerrainCardsNames.Water);
            Items.Add(CommonTerrainCardsNames.Water);
            Items.Add(CommonTerrainCardsNames.Water);
            Items.Add(CommonTerrainCardsNames.Any);
            Items.Add(CommonTerrainCardsNames.Any);
        }
    }
}
