using UnityEngine;

public class MoveUIElements : MonoBehaviour
{
    public RectTransform angelImage;  // Reference to the Angel image's RectTransform
    public RectTransform witchImage;  // Reference to the Witch image's RectTransform
    public RectTransform heartImage;  // Reference to the Heart image's RectTransform

    private float speed = 2f;  // Speed at which the images move vertically
    private float amplitude = 30f;  // The maximum amount the images move up and down
    private float angelStartY;  // Initial Y position for the Angel image
    private float witchStartY;  // Initial Y position for the Witch image
    private float heartStartX;  // Initial Y position for the Heart image

    void Start()
    {
        // Store the initial Y positions for each image (keeping X fixed)
        angelStartY = angelImage.anchoredPosition.y;
        witchStartY = witchImage.anchoredPosition.y;
        heartStartX = heartImage.anchoredPosition.x;
    }

    void Update()
    {
        // Calculate the new vertical (y-axis) position using Mathf.Sin for up and down motion
        float angelNewY = angelStartY + Mathf.Sin(Time.time * speed) * amplitude;
        float witchNewY = witchStartY + Mathf.Sin(Time.time * speed) * amplitude;
        float heartNewX = heartStartX + Mathf.Sin(Time.time * speed) * 10f;

        // Update the positions with their respective new Y values while keeping their X position constant
        Vector2 angelPosition = angelImage.anchoredPosition;
        Vector2 witchPosition = witchImage.anchoredPosition;
        Vector2 heartPosition = heartImage.anchoredPosition;

        angelPosition.y = -angelNewY;
        witchPosition.y = witchNewY + 10f;
        heartPosition.x = heartNewX;

        // Apply the new position
        angelImage.anchoredPosition = angelPosition;
        witchImage.anchoredPosition = witchPosition;
        heartImage.anchoredPosition = heartPosition;
    }
}
