using System.Collections;
using UnityEngine;

public class PlayerFigure : MonoBehaviour
{
    public int startIndex;
    public int currentPositionIndex;
    public float moveDuration = 1f;

    private void Start()
    {

            transform.position = GameManager.instance.boardPositions[currentPositionIndex].position;
     
    }

    public void Move(int steps)
    {
        int targetPositionIndex = currentPositionIndex + steps;
        targetPositionIndex = Mathf.Clamp(targetPositionIndex, 0, GameManager.instance.boardPositions.Length - 1);

        StartCoroutine(SmoothMoveToPosition(targetPositionIndex));
    }

    private IEnumerator SmoothMoveToPosition(int targetPositionIndex)
    {
        while (currentPositionIndex != targetPositionIndex)
        {
            int nextPositionIndex = currentPositionIndex + (targetPositionIndex > currentPositionIndex ? 1 : -1);
            Vector3 startPosition = GameManager.instance.boardPositions[currentPositionIndex].position;
            Vector3 endPosition = GameManager.instance.boardPositions[nextPositionIndex].position;

            float elapsedTime = 0;

            while (elapsedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = endPosition;
            currentPositionIndex = nextPositionIndex;
        }
    }
}