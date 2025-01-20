using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    
    private Rigidbody2D playerRigidbody;
    public Vector2 moveVector = Vector2.zero;

    [SerializeField]
    private float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Awake()
    {       
        Actions.MoveEvent += UpdateMoveVector;
    }  

    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void UpdateMoveVector(Vector2 InputVector)
    {
        moveVector = InputVector;
    }
 
    void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    void HandlePlayerMovement()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + moveVector * moveSpeed * Time.fixedDeltaTime);
    }

    void OnDisable()
    {
        Actions.MoveEvent -= UpdateMoveVector;
    }
}
