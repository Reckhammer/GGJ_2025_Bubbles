using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    public static ScaleManager instance;
    public ItemCollector playerCollector;
    public Transform levelTransform;
    public Transform collectItemTransform;
    public float scaleFactor = 0.1f;
    public float minScale = 0.01f; // Minimum scale to prevent it from disappearing

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
        // Get the player's size (using its collider)
        float playerVolume = playerCollector.colliderSize;

        // Get the picked object's size
        float objectVolume = stickObj.size;

        Debug.Log($"Object Volume = {objectVolume}");

        if (playerVolume > 0 && objectVolume > 0)
        {
            // Calculate the scaling factor based on the size ratio
            float sizeRatio = objectVolume / playerVolume;

            // Shrink the world (parent object) based on the ratio
            Vector3 newScale = levelTransform.localScale * (1f - sizeRatio * scaleFactor);

            // Clamp to avoid scaling too small
            newScale = Vector3.Max(newScale, Vector3.one * minScale);

            // Apply the new scale
            levelTransform.localScale = newScale;
            collectItemTransform.localScale = newScale;

            Debug.Log($"World scaled to: {newScale} based on object size ratio: {sizeRatio}, objectVolume = {objectVolume}, playerVolume = {playerVolume}");
        }

        //// Calculate the volume (assuming a box for simplicity)
        //float volume = stickObj.origSize * levelTransform.localScale.x;

        //// Determine the scale reduction factor (cube root of the volume for proportional scaling)
        //float scaleReductionFactor = Mathf.Pow(volume, 1/3);
        //Debug.Log($"SCALE REDUCTION FACTOR = {scaleReductionFactor}, VOLUME = {volume}, ITEM SIZE = {stickObj.origSize}");

        //// Reduce the parent object's scale
        //Debug.Log($"Reducing scale by {Vector3.one * scaleReductionFactor}");
        //levelTransform.transform.localScale *= scaleFactor;
        //collectItemTransform.transform.localScale *= scaleFactor;

        //// Clamp the scale to prevent it from going below the minimum
        //levelTransform.transform.localScale = Vector3.Max(levelTransform.transform.localScale, Vector3.one * minScale);
        //collectItemTransform.transform.localScale = Vector3.Max(collectItemTransform.transform.localScale, Vector3.one * minScale);
    }
}
