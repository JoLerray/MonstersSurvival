using UnityEngine;

[RequireComponent(typeof(Camera))]

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector4 MapSize;
    
    private Camera _camera;

    private void Start() {
        
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        var x = Mathf.Clamp(_player.transform.position.x, MapSize.x +_camera.orthographicSize * 2,MapSize.y - _camera.orthographicSize * 2);
        var y = Mathf.Clamp(_player.transform.position.y, MapSize.z +_camera.orthographicSize,MapSize.w -_camera.orthographicSize);
       
        transform.position = new Vector3(x , y , transform.position.z);
       
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(MapSize.x ,MapSize.z), new Vector2(MapSize.y ,MapSize.w));
    }
}
