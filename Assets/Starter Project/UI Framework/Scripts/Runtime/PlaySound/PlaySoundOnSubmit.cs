using UnityEngine.EventSystems;

namespace StarterProject.UIFramework
{
    public class PlaySoundOnSubmit : PlayerSoundOnEvent, ISubmitHandler
    {
        public void OnSubmit(BaseEventData eventData)
        {
            PlaySound();
        }
    }
}
