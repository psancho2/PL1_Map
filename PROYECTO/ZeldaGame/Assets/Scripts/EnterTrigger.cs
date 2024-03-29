using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : MonoBehaviour
{
    [SerializeField] private bool espada;
    [SerializeField] private bool tienda;
    [SerializeField] private bool secreto;

    static public Vector3 lastPosition;
    static public Vector3 cameraPosition;
    private void OnTriggerStay2D(Collider2D other)
    {
        LinkMovement link = other.gameObject.GetComponent<LinkMovement>();
        Rigidbody2D rblink = LinkMovement.Link.GetComponent<Rigidbody2D>();
        if (link != null && rblink.velocity.normalized.y == 1)
        {
            GameManager.Game.ActivateRoom(espada, tienda, secreto);
            cameraPosition = Camera.main.transform.position;
            lastPosition = LinkMovement.Link.transform.position;
            GameManager.Game.EnterRoom();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
