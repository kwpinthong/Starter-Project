using UnityEngine.EventSystems;

namespace StarterProject.UIFramework
{
    public class PlaySoundOnSelect : PlayerSoundOnEvent, ISelectHandler
    {
        public void OnSelect(BaseEventData eventData)
        {
            PlaySound();
        }
    }
}
