using UnityEngine.EventSystems;

namespace StarterProject.UIFramework
{
    public class PlaySoundOnPointerEnter : PlayerSoundOnEvent, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            PlaySound();
        }
    }
}
