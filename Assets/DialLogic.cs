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
            FindFirstObjectByType<GameManager>().ComputeHitRoutine(true, FindFirstObjectByType<GameManager>().currentPlayer.index);
        } else {
            Debug.Log("Missed!");
            FindFirstObjectByType<GameManager>().ComputeHitRoutine(false, FindFirstObjectByType<GameManager>().currentPlayer.index);
        }
    }

    void MoveDial() {
        dialSpeed = FindFirstObjectByType<GameManager>().currentPlayer.playerDialSpeed + 6;
        float dialFSpeed = 100 - (100/(1 + Mathf.Pow(System.MathF.E, (dialSpeed - 120)/50)));
        if (movingRight) {
            transform.Translate(Vector3.right * dialFSpeed * Time.deltaTime);
            if (dialPoint.transform.position.x >= dialAreaWidth) {
                movingRight = false;
            }
        } else {
            transform.Translate(Vector3.left * dialFSpeed * Time.deltaTime);
            if (dialPoint.transform.position.x <= -dialAreaWidth) {
                movingRight = true;
            }
        }
        Debug.Log(dialFSpeed);
    }

    void Update() {
        MoveDial();
        if (Input.GetKeyDown(KeyCode.Space)) {
            DetectHitArea();
        }
    }

}
