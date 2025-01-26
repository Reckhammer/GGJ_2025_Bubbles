using UnityEngine;

public class StickObject : MonoBehaviour
{
    public Collider m_Collider;
    public Rigidbody m_Rigidbody;
    public float size => (m_Collider.bounds.size.x + m_Collider.bounds.size.y + m_Collider.bounds.size.z) / 3;

    private void Awake()
    {
        m_Collider = GetComponent<Collider>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void Stick()
    {
        Debug.Log($"{this.name} has been stuck!", this);
        ContainmentManager.instance.AddStickObject(this);
    }
}
