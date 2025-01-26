using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    public static ScaleManager instance;
    public Transform levelTransform;
    public Transform collectItemTransform;

    public float minScale = 0.1f; // Minimum scale to prevent it from disappearing

    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public void ScaleDown(StickObject stickObj)
    {
        // Calculate the volume (assuming a box for simplicity)
        float volume = stickObj.origSize;

        // Determine the scale reduction factor (cube root of the volume for proportional scaling)
        float scaleReductionFactor = volume / 50f;
        Debug.Log($"SCALE REDUCTION FACTOR = {scaleReductionFactor}, VOLUME = {volume}, ITEM SIZE = {stickObj.origSize}");

        // Reduce the parent object's scale
        levelTransform.transform.localScale -= Vector3.one * volume;
        collectItemTransform.transform.localScale -= Vector3.one * volume;

        // Clamp the scale to prevent it from going below the minimum
        levelTransform.transform.localScale = Vector3.Max(levelTransform.transform.localScale, Vector3.one * minScale);
        collectItemTransform.transform.localScale = Vector3.Max(collectItemTransform.transform.localScale, Vector3.one * minScale);
    }
}
