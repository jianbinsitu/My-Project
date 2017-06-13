using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;
    public int damage;
    GameUI UI;

    void Awake()
    {
        speed = 10.0f;
        isReady = false;
    }

    void Start()
    {
        UI = GameObject.Find("GameManagerUI").GetComponent<GameUI>();
        UI.getdmg = damage;
        if (_direction.x == 0 && _direction.y == 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }

    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;

            if (position.x >= 20 || position.x <= -20)
            {
                Destroy(gameObject);
            }
        }
    }
}
