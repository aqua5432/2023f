using UnityEngine;
public class Planet : MonoBehaviour
{
    private Camera mainCamera;
    private float destroyZPosition = -20f; // カメラのZ座標より小さい場合に破棄

    void Start(){
        mainCamera = Camera.main;
    }

    void Update(){
        // カメラのZ座標を取得
        float cameraZPosition = mainCamera.transform.position.z;
        // 惑星のZ座標がカメラより小さい場合に破棄
        if (transform.position.z < cameraZPosition + destroyZPosition){
            Destroy(gameObject);
        }
    }
}
