using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    private float endingPos = 6.75f;
    private float speedForBar = 5;
    private Vector3 startingPos;
    private bool keepMoving = true;
    private float time = 0;
    private int maxTime = 5;
    private new SpriteRenderer renderer;

    float RandomFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double number = (random.NextDouble() * (max - min) + min);
        return (float)number; 
    }

    // public omdat ik het in een ander script ga gebruiken
    public bool increaseSpeed = false;

    void Start()
    {
        startingPos = gameObject.transform.position;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!keepMoving)
        {
            time += Time.deltaTime;
            if (time > maxTime) 
            {
                keepMoving = true;
                time = 0;
            }
        }

        if (keepMoving)
        {
            renderer.color = Color.green;
            transform.Translate(Vector2.right * Time.deltaTime * speedForBar);
        }
        if (gameObject.transform.position.x > endingPos || (Input.GetKeyDown(KeyCode.Space)))
        {
            gameObject.transform.position = startingPos;
            keepMoving = false;
            renderer.color = Color.black;
        }
    }
}
