using UnityEngine;

public class RopeController : MonoBehaviour
{
    public bool isCollision;
    public Animator Anim;
    
    public void Reset()
    {
        //speedAnim = 40f;
        Anim.speed = 1;
        isCollision = false;
    }

    public void SetCollisionTrue()
    {
        isCollision = true;
    }
    
    public void SetCollisionFalse()
    {
        isCollision = false;
    }
}
