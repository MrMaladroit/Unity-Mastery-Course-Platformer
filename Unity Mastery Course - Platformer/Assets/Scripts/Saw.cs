using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private Transform sawBladeSprite;
    private float positionPercent;
    private int direction = 1;

    private void Update()
    {
        positionPercent += direction * Time.deltaTime;
        sawBladeSprite.position = Vector3.Lerp(startPosition.position, endPosition.position, positionPercent);

        if (positionPercent >= 1 && direction == 1)
            direction = -1;
        else if (positionPercent <= 0 && direction == -1)
            direction = 1;
    }
}