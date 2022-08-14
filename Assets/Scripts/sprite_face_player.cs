using UnityEngine;

public class sprite_face_player : MonoBehaviour
{
    private Transform player;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        transform.LookAt(player);
    }
}
