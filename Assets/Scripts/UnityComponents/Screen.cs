using UnityEngine;

namespace UnityComponents
{
    public class Screen : MonoBehaviour
    {
        public ScreenType Type;
        public virtual void Show(bool state)
        {
            this.gameObject.SetActive(state);
        }

        public virtual void UpdateState()
        {
            
        }
    }
}