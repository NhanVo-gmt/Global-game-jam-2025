using UnityEngine;

public class AutoDestroyObject : MonoBehaviour
{
    public float lastTime = 2f;
    
    protected virtual void OnEnable()
    {
        Destroy(gameObject, lastTime);
    }
}