using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace StarterProject.UIFramework
{
    public class SettingOption : Selectable
    {
        public enum SettingType
        {
            Slider,
        }

        [SerializeField] private SettingType _type = SettingType.Slider;
        [SerializeField] private Slider _slider;
        [SerializeField] private float _sliderStep = 0.1f;

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
        }

        public override void OnMove(AxisEventData eventData)
        {
            if (_type == SettingType.Slider)
            {
                float min = _slider.minValue;
                float max = _slider.maxValue;
                float value = _slider.value;
                
                var direction = eventData.moveDir;

                if (direction == MoveDirection.Left)
                {
                    _slider.value = Mathf.Clamp(value - _sliderStep, min, max);
                }
                else if (direction == MoveDirection.Right)
                {
                    _slider.value = Mathf.Clamp(value + _sliderStep, min, max);
                }
                else
                {
                    base.OnMove(eventData);
                }
            }
        }
    }
}
