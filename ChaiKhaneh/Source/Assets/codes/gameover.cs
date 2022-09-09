using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour {

    public int emtiaz = 0;
	void Start () {
		
	}
	
	void Update () {
		
	}

    public IEnumerator handle () {
        GameObject.Find("bg_go").GetComponent<Animation>().Play();
        Destroy(GameObject.Find("obj_jaghoori"));
        yield return new WaitForSeconds(2f);
        GameObject.Find("txt_mashins").GetComponent<Text>().enabled = false;
        GameObject.Find("txt_chais").GetComponent<Text>().enabled = false;
        GameObject.Find("txt_ghoori").GetComponent<Text>().enabled = false;
        GameObject.Find("txt_emtiaz1").GetComponent<Text>().enabled = true;
        GameObject.Find("txt_emtiaz2").GetComponent<Text>().text = emtiaz.ToString();
        GameObject.Find("txt_emtiaz2").GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
