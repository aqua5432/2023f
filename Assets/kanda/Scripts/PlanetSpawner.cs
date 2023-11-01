using UnityEngine;
using System.Collections.Generic; // 追加

public class PlanetSpawner : MonoBehaviour
{
    public List<GameObject> planetPrefabs;
    public float spawnInterval = 5f; // 惑星の生成間隔
    private float timer = 0f;
    private GameObject playerObject; // プレイヤーオブジェクトの参照

    void Start(){
        // プレイヤーオブジェクトのタグを使用して検索
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject == null){
            Debug.LogError("Player object not found.");
        }for(int i = 0;i < 4;i++){
            SpawnPlanet();
        }
    }

    void Update(){
        timer += Time.deltaTime;
        if (timer >= spawnInterval && playerObject != null){
            SpawnPlanet();
            timer = 0f;
        }
    }

    void SpawnPlanet(){
        int randomIndex = Random.Range(0, planetPrefabs.Count);
        GameObject selectedPlanetPrefab = planetPrefabs[randomIndex];

        Transform playerTransform = playerObject.transform;
        // ここでプレイヤーのTransformを使用する
        float playerZPosition = playerTransform.position.z; // プレイヤーまたはカメラのZ座標位置
        float spawnDistance = Random.Range(100f,200f); // 生成する距離（適宜調整）
        float value = 0;
        while(value > -5f && value < 5f){
            value = Random.Range(-15f, 15f);
        }

        Vector3 randomPosition = new Vector3(
            value, // X軸は適切な範囲でランダム
            Random.Range(-9f, 9f), // Y軸は適切な範囲でランダム
            playerZPosition + spawnDistance // Z軸はプレイヤーの位置に生成距離を加える
        );

        GameObject newPlanet = Instantiate(selectedPlanetPrefab, randomPosition, Quaternion.identity);
        newPlanet.AddComponent<Planet>(); // Planetスクリプトをアタッチ
    }
}
