using UnityEngine;
using System.Collections;

public class BombProjectileScript : MonoBehaviour {

    [SerializeField]
    GameObject FragmentPrefab;

	// Use this for initialization
	void Start () {
        StartCoroutine(GoBoom());
        gameObject.transform.Rotate(0, 0, Random.Range(-90, 90));
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0, 0, 5);
        
	}

    IEnumerator GoBoom()
    {
        yield return new WaitForSeconds(3);
        GameObject Frag1 = Instantiate(FragmentPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        Frag1.transform.Rotate(0, 0, 90);
        GameObject Frag2 = Instantiate(FragmentPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        Frag2.transform.Rotate(0, 0, -90);
        GameObject Frag3 = Instantiate(FragmentPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        Frag3.transform.Rotate(0, 0, -180);
        GameObject Frag4 = Instantiate(FragmentPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        Frag4.transform.Rotate(0, 0, 0);
        Destroy(gameObject);
    }
}
