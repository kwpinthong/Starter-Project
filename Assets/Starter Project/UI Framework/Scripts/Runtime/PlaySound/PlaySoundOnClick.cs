using UnityEngine.EventSystems;

namespace StarterProject.UIFramework
{
    public class PlaySoundOnClick : PlayerSoundOnEvent, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            PlaySound();
        }
    }
}
