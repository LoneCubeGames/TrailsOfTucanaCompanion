using UnityEngine.UIElements;

namespace Views
{
    public class CardView : VisualElement
    {
        public VisualElement Card { get; private set; }
        public VisualElement Image { get; private set; }

        public void Init(UIDocument uiDocument, string path)
        {
            var root = uiDocument.rootVisualElement.Q<VisualElement>(path);
            Card = root.Q<VisualElement>("card");
            Image = root.Q<VisualElement>("image");
        }
    }
}
