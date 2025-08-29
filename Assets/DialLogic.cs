using UnityEngine;

public class DialLogic : MonoBehaviour
{

    public GameObject dialPoint;
    public GameObject hitArea;
    

    public float dialSpeed = 1f;
    private float dialAreaWidth = 5f;
    private bool movingRight = true;

    void DetectHitArea() {
        RaycastHit2D hit = Physics2D.Raycast(dialPoint.transform.position, Vector2.zero);
        Debug.Log(hit);
        if (hit.collider != null && hit.collider.CompareTag("HitArea")) {
            Debug.Log("Hit Area Detected!");
            Destroy(hit.transform.gameObject);
            FindFirstObjectByType<GameManager>().SpawnHitArea();
        }
    }

    void MoveDial() {
        if (movingRight) {
            transform.Translate(Vector3.right * dialSpeed * Time.deltaTime);
            if (dialPoint.transform.position.x >= dialAreaWidth) {
                movingRight = false;
            }
        } else {
            transform.Translate(Vector3.left * dialSpeed * Time.deltaTime);
            if (dialPoint.transform.position.x <= -dialAreaWidth) {
                movingRight = true;
            }
        }
    }

    void Update() {
        MoveDial();
        if (Input.GetKeyDown(KeyCode.Space)) {
            DetectHitArea();
        }
    }

}
