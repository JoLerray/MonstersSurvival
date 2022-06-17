using UnityEngine;

[RequireComponent(typeof(Camera))]

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    [SerializeField] private Vector4 _mapSize;
    
    public Vector4 MapSize {get{ return _mapSize;}}

    private Camera _camera;

    private void Start() {
        
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        var x = Mathf.Clamp(_player.transform.position.x, _mapSize.x +_camera.orthographicSize * 2,_mapSize.y - _camera.orthographicSize * 2);
        var y = Mathf.Clamp(_player.transform.position.y, _mapSize.z +_camera.orthographicSize,_mapSize.w -_camera.orthographicSize);
       
        transform.position = new Vector3(x , y , transform.position.z);
       
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(_mapSize.x ,_mapSize.z), new Vector2(_mapSize.y ,_mapSize.w));
    }
}
