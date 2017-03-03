using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerdSpawner : MonoBehaviour {

	/// <summary>
	/// This is a reference to the prefab in the project which will be spawned.
	/// </summary>
    public GameObject NerdPrefab;
    // Use this for initialization
    public Transform SpawnLocation;

    public void Spawn()
	{
		// Spawn nerd, at this transform position (so you would want to replace that with somethign, at a zero'd rotation (identity))
        GameObject newObject = (GameObject)Object.Instantiate(NerdPrefab, SpawnLocation.position, Quaternion.identity);
    }
}
