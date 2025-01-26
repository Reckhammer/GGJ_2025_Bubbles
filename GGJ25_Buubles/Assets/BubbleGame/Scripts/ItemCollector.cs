using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private Collider m_Collider;
    public float colliderSize => (m_Collider.bounds.size.x);

    private void Awake()
    {
        m_Collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<StickObject>(out StickObject stickObj))
        {
            Debug.Log($"ItemCollector: {stickObj.name} stick object has been collided with");
            if (stickObj.size < colliderSize)
                stickObj.Stick();
        }
    }
}
