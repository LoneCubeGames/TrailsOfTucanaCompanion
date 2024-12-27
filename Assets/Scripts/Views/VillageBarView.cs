using UnityEngine.UIElements;

namespace Views
{
    public class VillageBarView : VisualElement
    {
        public VisualElement VillageBarContainer { get; private set; }
        public VisualElement VillageBarImage { get; private set; }
        public Button VillageBarButton { get; private set; }

        public void Init(UIDocument uiDocument, string path)
        {
            var root = uiDocument.rootVisualElement.Q<VisualElement>(path);
            VillageBarContainer = root.Q<VisualElement>("village-bar-container");
            VillageBarImage = root.Q<VisualElement>("village-bar-image");
            VillageBarButton = root.Q<Button>("village-bar-button");
        }
    }
}
