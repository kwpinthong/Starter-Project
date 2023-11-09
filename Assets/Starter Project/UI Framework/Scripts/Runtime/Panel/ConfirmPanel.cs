using TMPro;
using UnityEngine;

namespace StarterProject.UIFramework
{
    public class ConfirmPanel : Panel
    {
        public string Message
        {
            get => messageText.text;
            set => messageText.text = value;
        }

        [SerializeField] private TMP_Text messageText;
    }
}
