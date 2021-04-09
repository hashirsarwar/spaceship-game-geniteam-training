using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 1;
    private float maxY = -5;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < maxY)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ShipModel")
        {
            Game.GameOver();
            Destroy(gameObject);
        }
    }
}
