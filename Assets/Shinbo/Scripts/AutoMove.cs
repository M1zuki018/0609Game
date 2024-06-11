using UnityEngine;
public class AutoMove : MonoBehaviour
{

    GameObject _leftEdgeObj;
    GameObject _rightEdgeObj;
    GameObject _upEdgeObj;
    GameObject _downEdgeObj;

    Transform _leftEdge;
    Transform _rightEdge;
    Transform _upEdge;
    Transform _downEdge;

    [SerializeField] float _moveSpeed = 1.0f;
    private int _xDirection = 1;
    private int _yDirection = 1;
    

    private void Start()
    {
        _leftEdgeObj = GameObject.Find("Left");
        _rightEdgeObj = GameObject.Find("Right");
        _upEdgeObj = GameObject.Find("Up");
        _downEdgeObj = GameObject.Find("Down");

        _leftEdge = _leftEdgeObj.GetComponent<Transform>();
        _rightEdge = _rightEdgeObj.GetComponent<Transform>();
        _upEdge = _upEdgeObj.GetComponent<Transform>();
        _downEdge = _downEdgeObj.GetComponent<Transform>();

        Debug.Log(_leftEdge.transform.position);
    }

    void FixedUpdate()
    {
        
        if (transform.position.x > _rightEdge.position.x)
        {
            _xDirection = -1;
        }
        else if (transform.position.x <= _leftEdge.position.x)
        {
            _xDirection = 1;
        }

        if (transform.position.y > _downEdge.position.y)
        {
            _yDirection = -1;
        }
        else if (transform.position.y <= _upEdge.position.y)
        {
            _yDirection = 1;
        }
        
        
        transform.position = new Vector3(transform.position.x + _moveSpeed * Time.fixedDeltaTime * _xDirection, 
            transform.position.y + _moveSpeed * Time.fixedDeltaTime * _yDirection, 0);
    }
}