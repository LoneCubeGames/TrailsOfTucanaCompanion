using UnityEngine.UIElements;

namespace Views
{
    public class TerrainCardsView : VisualElement
    {
        public Button NextTerrainButton { get; private set; }
        public Button RestartButton { get; private set; }
        public Button NewGameButton { get; private set; }

        public void Init(UIDocument uiDocument, string path)
        {
            var root = uiDocument.rootVisualElement.Q<VisualElement>(path);
            NextTerrainButton = root.Q<Button>("next-terrain-button");
            RestartButton = root.Q<Button>("restart-button");
            NewGameButton = root.Q<Button>("new-game-button");
        }
    }
}
