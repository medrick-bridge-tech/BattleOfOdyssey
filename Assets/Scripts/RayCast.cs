using UnityEngine;

public class RayCast
{
    private static Vector2 Rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }

    public static bool DetectPlayer(Vector3 watcher, Vector3 target,float viewRange, float viewFieldDegree, float viewFieldPiece)
    {
        var direction = target - watcher;
        var numberOfPieces = viewFieldDegree / viewFieldPiece;

        RaycastHit2D hit;

        for (float i = -(numberOfPieces / 2); i <= (numberOfPieces / 2); i += 1)
        {
            Debug.DrawRay(watcher, Rotate(direction, (i * viewFieldPiece) * Mathf.Deg2Rad));
            hit = Physics2D.Raycast(watcher, Rotate(direction, (i * viewFieldPiece) * Mathf.Deg2Rad), viewRange, LayerMask.GetMask("Player") | LayerMask.GetMask("Ambush"));
                
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    Debug.Log("Player detected");
                    return true; // Player detected, no need to continue    
                }
            }
        }

        // No player detected
        return false;
    }
}