using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            this.movement.enabled = false;
            // Make sure that there is at least 1 object of this type, will throw error otherwise
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
