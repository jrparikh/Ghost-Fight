using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player1, player2;
    private float minSizeY = 6.5f;
    //public float minSizeY = 12.61f;
    //public float maxSizeY = 9f;
    public Camera camera;
    public static List<GameObject> players = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        foreach (GameObject player in players)
        {
            if(player.tag == "Player1")
            {
                player1 = player.transform;
            }
            else if(player.tag == "Player2")
            {
                player2 = player.transform;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        SetCameraPos();
        SetCameraSize();
        
    }

    void SetCameraPos()
    {
        Vector3 middle = (player1.position + player2.position) * 0.5f;
        camera.transform.position = new Vector3(
            middle.x,
            middle.y,
            camera.transform.position.z
        );
        //Debug.Log("x" + middle.x);
        //Debug.Log("y" + middle.y);
    }

    void SetCameraSize()
    {
        //horizontal size is based on actual screen ratio
        float minSizeX = minSizeY * Screen.width / Screen.height;
        //multiplying by 0.5, because the ortographicSize is actually half the height
        float width = Mathf.Abs(player1.position.x - player2.position.x) * 0.5f;
        float height = Mathf.Abs(player1.position.y - player2.position.y) * 0.5f;
        //computing the size
        float camSizeX = Mathf.Max(width, minSizeX);
        camera.orthographicSize = Mathf.Max(height, camSizeX * Screen.height / Screen.width, minSizeY);
    }
}
