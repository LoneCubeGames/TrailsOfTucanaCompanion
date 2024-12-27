using CommonNames;
using UnityEngine.UIElements;

namespace Extensions
{
    public static class VisualElementExtension
    {
        public static void Show(this VisualElement visualElement)
        {
            visualElement.RemoveFromClassList(CommonUssNames.Hide);
        }

        public static void Hide(this VisualElement visualElement)
        {
            visualElement.AddToClassList(CommonUssNames.Hide);
        }

        public static void Toggle(this VisualElement visualElement, ref bool state)
        {
            if (!state)
            {
                visualElement.Show();
                state = true;
            }
            else
            {
                visualElement.Hide();
                state = false;
            }
        }
    }
}
