using UnityEngine.UIElements;

namespace Views
{
    public class StatisticBarView : VisualElement
    {
        public VisualElement StatisticBarContainer { get; private set; }
        public Button StatisticBarButton { get; private set; }
        public Label DesertLabel { get; private set; }
        public Label ForestLabel { get; private set; }
        public Label MountainLabel { get; private set; }
        public Label WaterLabel { get; private set; }
        public Label AnyLabel { get; private set; }

        public void Init(UIDocument uiDocument, string path)
        {
            var root = uiDocument.rootVisualElement.Q<VisualElement>(path);
            StatisticBarContainer = root.Q<VisualElement>("statistic-bar-container");
            StatisticBarButton = root.Q<Button>("statistic-bar-button");
            DesertLabel = root.Q<Label>("desert-label");
            ForestLabel = root.Q<Label>("forest-label");
            MountainLabel = root.Q<Label>("mountain-label");
            WaterLabel = root.Q<Label>("water-label");
            AnyLabel = root.Q<Label>("any-label");
        }
    }
}
