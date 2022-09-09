using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_set : MonoBehaviour {

    public int emtiaz = 0;
    public int mashins = 0;
    public int chai_req = 0;
    public bool ism = false;

    public bool isch1 = false;
    public bool isch2 = false;
    public bool isch3 = false;
    public bool isch4 = false;
    public bool isch5 = false;

    public GameObject obj_mashin;
    public GameObject obj_ghoori;
    public GameObject obj_estekan1;
    public GameObject obj_estekan2;
    public GameObject obj_estekan3;
    public GameObject obj_estekan4;
    public GameObject obj_estekan5;

    public Sprite spr_es_por;
    public Sprite spr_es_khali;

    public Sprite spr_m1;
    public Sprite spr_m2;
    public Sprite spr_m3;
    public Sprite spr_m4;

    void Start () {
        obj_mashin = GameObject.Find("obj_mashin");
        obj_ghoori = GameObject.Find("obj_jaghoori");
        Invoke("mashinsaz", 7f);
    }
	
	void Update () {
        if (mashins > 3)
        {
            GameObject.Find("bg_go").GetComponent<gameover>().StartCoroutine("handle");
            GameObject.Find("bg_go").GetComponent<gameover>().emtiaz = emtiaz;
            this.gameObject.GetComponent<game_set>().enabled = false;
        }
	}

    void mashinsaz () {
        mashins++;
        GameObject.Find("txt_mashins").GetComponent<Text>().text = mashins.ToString();
        if (mashins < 2)
        {
            GameObject.Find("txt_mashins").GetComponent<Text>().color = Color.white;
        }
        else if (mashins == 2)
        {
            GameObject.Find("txt_mashins").GetComponent<Text>().color = Color.yellow;
        }
        else if (mashins > 2)
        {
            GameObject.Find("txt_mashins").GetComponent<Text>().color = Color.red;
        }
        StartCoroutine("m_check");
        Invoke("mashinsaz", Random.Range(7f, 15f));
    }
    public IEnumerator m_check () {
        if (mashins > 0 && ism == false)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    obj_mashin.GetComponent<SpriteRenderer>().sprite = spr_m1;
                    break;
                case 1:
                    obj_mashin.GetComponent<SpriteRenderer>().sprite = spr_m2;
                    break;
                case 2:
                    obj_mashin.GetComponent<SpriteRenderer>().sprite = spr_m3;
                    break;
                case 3:
                    obj_mashin.GetComponent<SpriteRenderer>().sprite = spr_m4;
                    break;
            }
            obj_mashin.GetComponent<Animation>().PlayQueued("anim_mashin_1");
            chai_req = (int)Random.Range(1f, 5f);
            GameObject.Find("txt_chais").GetComponent<Text>().text = chai_req.ToString();
            Debug.Log("req: " + chai_req);
            ism = true;
            yield return new WaitForSeconds(2.5f);
            StartCoroutine("chaichk");
        }
    }

    public IEnumerator chaichk () {
        if (obj_ghoori.GetComponent<ghoori>().es_por >= chai_req)
        {
            for (int i = 0; i < chai_req; i++)
            {
                if (GameObject.Find("estekaan_1").GetComponent<SpriteRenderer>().sprite == spr_es_por)
                {
                    GameObject.Find("estekaan_1").GetComponent<SpriteRenderer>().sprite = spr_es_khali;
                    obj_ghoori.GetComponent<ghoori>().es_por--;
                }
                else if (GameObject.Find("estekaan_2").GetComponent<SpriteRenderer>().sprite == spr_es_por)
                {
                    GameObject.Find("estekaan_2").GetComponent<SpriteRenderer>().sprite = spr_es_khali;
                    obj_ghoori.GetComponent<ghoori>().es_por--;
                }
                else if (GameObject.Find("estekaan_3").GetComponent<SpriteRenderer>().sprite == spr_es_por)
                {
                    GameObject.Find("estekaan_3").GetComponent<SpriteRenderer>().sprite = spr_es_khali;
                    obj_ghoori.GetComponent<ghoori>().es_por--;
                }
                else if (GameObject.Find("estekaan_4").GetComponent<SpriteRenderer>().sprite == spr_es_por)
                {
                    GameObject.Find("estekaan_4").GetComponent<SpriteRenderer>().sprite = spr_es_khali;
                    obj_ghoori.GetComponent<ghoori>().es_por--;
                }
                else if (GameObject.Find("estekaan_5").GetComponent<SpriteRenderer>().sprite == spr_es_por)
                {
                    GameObject.Find("estekaan_5").GetComponent<SpriteRenderer>().sprite = spr_es_khali;
                    obj_ghoori.GetComponent<ghoori>().es_por--;
                }
            }
            Debug.Log("end: " + chai_req);
            chai_req = 0;
            GameObject.Find("txt_chais").GetComponent<Text>().text = chai_req.ToString();
            obj_mashin.GetComponent<Animation>().PlayQueued("anim_mashin_2");
            mashins--;
            GameObject.Find("txt_mashins").GetComponent<Text>().text = mashins.ToString();
            if (mashins < 2)
            {
                GameObject.Find("txt_mashins").GetComponent<Text>().color = Color.white;
            }
            else if (mashins == 2)
            {
                GameObject.Find("txt_mashins").GetComponent<Text>().color = Color.yellow;
            }
            else if (mashins > 2)
            {
                GameObject.Find("txt_mashins").GetComponent<Text>().color = Color.red;
            }
            emtiaz++;
            yield return new WaitForSeconds(2f);
            ism = false;
            StartCoroutine("m_check");
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine("chaichk");
        }
    }
}
