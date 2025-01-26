using UnityEngine;

public class ContainmentManager : MonoBehaviour
{
    public static ContainmentManager instance;
    public Transform containmentArea;
    public Collider containerCollider;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        this.transform.localScale = ScaleManager.instance.levelTransform.localScale;   
    }

    private void OnDestroy()
    {
        instance = null;
    }


    public void AddStickObject(StickObject newItem)
    {
        // Prevent the object from flying around
        newItem.m_Collider.enabled = false;
        Destroy(newItem.m_Rigidbody);
        newItem.m_Rigidbody = null;

        // Set item inside the bubble
        newItem.transform.parent = containmentArea;
        newItem.transform.localScale = Vector3.one;
        Vector3 randomPointInside = Random.insideUnitSphere * (containerCollider.bounds.extents.magnitude - 0.5f);
        newItem.transform.localPosition = randomPointInside;
    }
}
