using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private Transform sawBladeSprite;
    [SerializeField] private float speed;

    private float positionPercent;
    private int direction = 1;

    private void Update()
    {
        float distance = Vector2.Distance(startPosition.position, endPosition.position);
        float speedForDistance = speed / distance;
        positionPercent += direction * Time.deltaTime * speedForDistance;
        sawBladeSprite.position = Vector3.Lerp(startPosition.position, endPosition.position, positionPercent);

        if (positionPercent >= 1 && direction == 1)
            direction = -1;
        else if (positionPercent <= 0 && direction == -1)
            direction = 1;
    }
}