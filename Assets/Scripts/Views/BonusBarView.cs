using UnityEngine.UIElements;

namespace Views
{
    public class BonusBarView : VisualElement
    {
        public VisualElement BonusBarContainer { get; private set; }
        public VisualElement BonusRedContainer { get; private set; }
        public Button BonusBarButton { get; private set; }

        public void Init(UIDocument uiDocument, string path)
        {
            var root = uiDocument.rootVisualElement.Q<VisualElement>(path);
            BonusBarContainer = root.Q<VisualElement>("bonus-bar-container");
            BonusRedContainer = root.Q<VisualElement>("bonus-red-container");
            BonusBarButton = root.Q<Button>("bonus-bar-button");
        }
    }
}
