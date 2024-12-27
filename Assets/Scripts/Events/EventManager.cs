using UnityEngine.Events;

namespace Events
{
    public static class EventManager
    {
        public static readonly UnityEvent TerrainCardsChangedEvent = new();
        public static readonly UnityEvent TerrainCardsClearedEvent = new();
    }
}
