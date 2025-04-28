using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MR
{
public class TrajectoryLine : MonoBehaviour
{
    [SerializeField]
    public LineRenderer lineRenderer;

    [SerializeField, Min(3)]
    public int lineSegments = 60;

    [SerializeField, Min(1)]
    public float timeOfTheFlight = 5;


    public void ShowTrajectoryline(Vector3 startpoint, Vector3 startVelocity)
    {
      //The more points we add the smoother the line will be
      float timeStep = timeOfTheFlight / lineSegments;

      Vector3[] lineRendererPoints = CalculateTrajectoryline(startpoint, startVelocity, timeStep);

      lineRenderer.positionCount = lineSegments;
      lineRenderer.SetPositions(lineRendererPoints);
    }

    private Vector3[] CalculateTrajectoryline(Vector3 startpoint, Vector3 startVelocity, float timeStep)
    {
      Vector3[] lineRendererPoints = new Vector3[lineSegments];

      lineRendererPoints[0] = startpoint;

      for (int i = 1; i < lineSegments; i++)
      {
        float timeOffset = timeStep * i;
        Vector3 progressBeforeGravity = startVelocity * timeOffset;
        Vector3 gravityOffset = Vector3.up * -0.5f * Physics.gravity.y * timeOffset * timeOffset;
        Vector3 newPosition = startpoint + progressBeforeGravity - gravityOffset;
        lineRendererPoints[i] = newPosition;
      }

      return lineRendererPoints;
    }
  }
}
