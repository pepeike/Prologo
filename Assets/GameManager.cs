using System.Collections;
using TMPro;
using UnityEngine;

public enum PlayerIndex {
    Player1,
    Player2
}

public class Player {
    public int points;
    public PlayerIndex index;
    public float playerDialSpeed = 1f;

    public void IncreaseSpeed(float increment)
    {
        playerDialSpeed += increment;
    }

}

public class GameManager : MonoBehaviour
{

    private float yPosition;
    [SerializeField] private float xDiff = 5f;
    private float xSpawnPosition;

    public GameObject dialArea;
    public GameObject hitAreaPrefab;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;

    Player player1 = new Player { points = 0, index = PlayerIndex.Player1 };
    Player player2 = new Player { points = 0, index = PlayerIndex.Player2 };
    public Player currentPlayer;
    public float speedIncrement;

    private void Awake() {
        yPosition = dialArea.transform.position.y;
    }

    void SelectNewPosition() {
        xSpawnPosition = Random.Range(-xDiff, xDiff);
    }

    GameObject inst;
    public void SpawnHitArea() {
        if (inst != null) {
            Destroy(inst);
        }
        SelectNewPosition();
        Vector3 spawnPosition = new Vector3(xSpawnPosition, yPosition, 0f);
        inst = Instantiate(hitAreaPrefab, spawnPosition, Quaternion.identity);
    }

    public void AddPoint(PlayerIndex playerIndex) {
        if (playerIndex == PlayerIndex.Player1) {
            player2.IncreaseSpeed(speedIncrement);
            player1.points++;
            PassTurn(playerIndex);
            score1.text = player1.points.ToString();
            //Debug.Log("Player 1 Points: " + player1.points);
        } else if (playerIndex == PlayerIndex.Player2) {
            player1.IncreaseSpeed(speedIncrement);
            player2.points++;
            PassTurn(playerIndex);
            score2.text = player2.points.ToString();
            //Debug.Log("Player 2 Points: " + player2.points);
        }
    }

    public void PassTurn(PlayerIndex playerIndex) {
        if (playerIndex == PlayerIndex.Player1) {
            currentPlayer = player2;
            SpawnHitArea();
            
        } else if (playerIndex == PlayerIndex.Player2) {
            SpawnHitArea();
            currentPlayer = player1;
            
        }
        Debug.Log(currentPlayer.playerDialSpeed);
    }

    public void ComputeHitRoutine(bool isHit, PlayerIndex playerIndex) {
        if (isHit) {
            AddPoint(playerIndex);
        } else {
            PassTurn(playerIndex);
        }
    }


    private void Start() {
        currentPlayer = player1; // Player 1 come�a
        SpawnHitArea();
        
    }

}
