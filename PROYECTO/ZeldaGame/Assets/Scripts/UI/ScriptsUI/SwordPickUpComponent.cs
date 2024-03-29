using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickUpComponent : MonoBehaviour
{
    public AttackComponent attack; 
    public UIManager _uiManager;
    public LinkInput _input;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LinkMovement player = collision.gameObject.GetComponent<LinkMovement>();
        if(player != null)
        {
            _uiManager.PonerEspada(true);
            attack._canAttack = true;
            _input.canAttack = true;
            Destroy(this.gameObject);
        }
    }
}
