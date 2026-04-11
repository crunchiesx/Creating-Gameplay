using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InfiniteBounds : MonoBehaviour
{
    private Rigidbody2D objectRb;
    private Collider2D objectCollider;
    private Camera mainCamera;

    private void Awake()
    {
        objectRb = GetComponent<Rigidbody2D>();
        objectCollider = GetComponent<Collider2D>();
        if (objectCollider == null)
        {
            objectCollider = GetComponentInChildren<Collider2D>();
        }

        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        float sizeBuffer = objectCollider.bounds.extents.magnitude * 0.75f;

        Vector3 topRightCorner = mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        Vector3 bottomLeftCorner = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));

        bool moveObject = false;
        Vector3 newPosition = objectRb.position;

        if (objectRb.position.x > topRightCorner.x + sizeBuffer)
        {
            newPosition.x = bottomLeftCorner.x - sizeBuffer;
            moveObject = true;
        }
        else if (objectRb.position.x < bottomLeftCorner.x - sizeBuffer)
        {
            newPosition.x = topRightCorner.x + sizeBuffer;
            moveObject = true;
        }

        if (objectRb.position.y > topRightCorner.y + sizeBuffer)
        {
            newPosition.y = bottomLeftCorner.y - sizeBuffer;
            moveObject = true;
        }
        else if (objectRb.position.y < bottomLeftCorner.y - sizeBuffer)
        {
            newPosition.y = topRightCorner.y + sizeBuffer;
            moveObject = true;
        }

        if (moveObject)
        {
            objectRb.position = newPosition;
        }
    }

    private void OnDisable()
    {
        objectRb = null;
        mainCamera = null;
    }
}
