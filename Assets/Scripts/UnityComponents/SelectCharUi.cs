using TMPro;
using UnityEngine;

namespace UnityComponents
{
    public class SelectCharUi : Screen
    {
        private const string textPay = "0.99 $";
        private const string textPlay = "PLAY";
        
        public TextMeshProUGUI TextBtnSlot1;
        public TextMeshProUGUI TextBtnSlot2;

        public override void UpdateState()
        {
            int buySlot1 = PlayerPrefs.GetInt("buySlot1");
            if (buySlot1 > 0)
            {
                TextBtnSlot1.text = textPlay;
            }
            else
            {
                TextBtnSlot1.text = textPay;
            }
            
            int buySlot2 = PlayerPrefs.GetInt("buySlot2");
            if (buySlot2 > 0)
            {
                TextBtnSlot2.text = textPlay;
            }
            else
            {
                TextBtnSlot2.text = textPay;
            }
        }
    }
}