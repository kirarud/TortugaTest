using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMover : MonoBehaviour
{
    [SerializeField] private int _moveSpeed = 10;
    [SerializeField] private Transform _whiteCircle;
    [SerializeField] private float r1;
    [SerializeField] private float r2;
    private Vector2 _targetPosition= new Vector2();

    
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            var currentMPos = Input.mousePosition;

            var circleTarget = Camera.main.ScreenToWorldPoint(currentMPos);
            _targetPosition = circleTarget;
        }
       
    }
    private void FixedUpdate()
    {
        var radius1 = transform.localScale.x/2;
        var radius2 = _whiteCircle.localScale.x/2;
        r1 = radius1;
        r2 = radius2;
        var movingVector = (_targetPosition - (Vector2)transform.position).normalized*Time.deltaTime*_moveSpeed;

        if((transform.position+(Vector3)movingVector).magnitude+radius1 <=radius2)
        {
            if((transform.position-(Vector3)_targetPosition).magnitude<((Vector3)movingVector).magnitude)
            {
                transform.position = _targetPosition;
                return;
            }
            transform.position =transform.position + (Vector3)movingVector;
        }
        
    }
}
