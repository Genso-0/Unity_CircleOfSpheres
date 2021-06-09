using UnityEngine;

public class CircleOfSpheres : MonoBehaviour
{ 
    public float pointSize = .1f;
    public int totalPoints;
    public const float twoPi = 6.28319f;
    void OnDrawGizmos()
    { 
        var segmentWidth = GetSegmentWidth(totalPoints);
        var radius = GetRadius(totalPoints, pointSize);
        Gizmos.DrawSphere(transform.position, 1);
        float angle = 0;
        for (int i = 0; i < totalPoints; i++)
        { 
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);
            angle += segmentWidth;
            var pos = new Vector3(x, 0, y) + transform.position;

            Gizmos.DrawSphere(pos, pointSize); 
        }
    } 
    private float GetRadius(int totalPoints, float nodeSize)
    {
        //From the formula LengthOfCircle = radius * theta; -> radius = lengthOfCircle / theta -> radius = (totalPoints * pointSize)/360degrees 
        return (totalPoints * (nodeSize * 2)) / twoPi; 
    } 
    private float GetSegmentWidth(int count)
    {
        return twoPi / count;
    }
}
