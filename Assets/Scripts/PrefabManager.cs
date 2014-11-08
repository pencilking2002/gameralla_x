using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//use this to load everything into memory first
//so we don't have to use Resources.Load
//uses a dictionary to sort all the prefabs so you can get by string

public class PrefabManager : MonoBehaviour {

	private List<GameObject> scannedPrefabs;

	private static Dictionary<string, GameObject> prefabDict;

	private static string path = "Prefabs";

	//make those prefabs into the dictionary
	void Awake(){
		LoadAllPrefabs();
	}

	//use this to get a prefab
	public static GameObject GetPrefab(string prefabName){
		return prefabDict[prefabName];
	}



	static void LoadAllPrefabs(){
		GameObject[] prefabs = Resources.LoadAll<GameObject>(path);
		PrefabManager.prefabDict = new Dictionary<string, GameObject>();
		for(int i = 0; i < prefabs.Length; i++){
			prefabDict.Add (prefabs[i].name, prefabs[i]);
		}
	}


}
