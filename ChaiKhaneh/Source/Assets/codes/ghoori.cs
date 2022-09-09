using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ghoori : MonoBehaviour {

	Vector3 newPosition;
    bool isclick = false;
    public int ghoori_level = 10;
    public int es_selected = 0; // 0 for null
    public int es_por = 0;

    public Sprite spr_es_por;
    public Sprite spr_es_khali;

    void Start () {

	}
	
	void Update () {
        if (isclick == false) {
            newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
            this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(newPosition);
        }
    }
    public void OnMouseDown()
    {
        if (GameObject.Find("ghoori").GetComponent<Animation>().IsPlaying("anim_ghoori_charge") && es_selected != 6)
        {
            StopCoroutine("ghoori_charge");
            GameObject.Find("ghoori").GetComponent<Animation>().PlayQueued("anim_ghoori_charge");
            GameObject.Find("ghoori").GetComponent<Animation>().Stop();
            isclick = false;
        }
        if (isclick == false && es_selected != 6 && ghoori_level > 0)
        {
            isclick = true;
            GameObject.Find("ghoori").GetComponent<Animation>().Play("anim_ghoori");
            this.gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine("sabr");
        }
        else if (es_selected == 6)
        {
            isclick = true;
            StartCoroutine("ghoori_charge");
        }
    }
    public void OnMouseUp()
    {
        if (es_selected == 6)
        {
            StopCoroutine("ghoori_charge");
            GameObject.Find("ghoori").GetComponent<Animation>().PlayQueued("anim_ghoori_charge");
            GameObject.Find("ghoori").GetComponent<Animation>().Stop();
            isclick = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.StartsWith("estekaan_1"))
        {
            es_selected = 1;
        }
        else if (col.name.StartsWith("estekaan_2"))
        {
            es_selected = 2;
        }
        else if (col.name.StartsWith("estekaan_3"))
        {
            es_selected = 3;
        }
        else if (col.name.StartsWith("estekaan_4"))
        {
            es_selected = 4;
        }
        else if (col.name.StartsWith("estekaan_5"))
        {
            es_selected = 5;
        }
        else if (col.name.StartsWith("samavar")) //   <-----------
        {
            es_selected = 6;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        es_selected = 0;
    }
    public IEnumerator sabr()
    {
        yield return new WaitForSeconds(2.5f);
        ghoori_level--;
        GameObject.Find("txt_ghoori").GetComponent<Text>().text = ghoori_level.ToString();
        if (ghoori_level >= 6)
        {
            GameObject.Find("txt_ghoori").GetComponent<Text>().color = Color.white;
        }
        else if (ghoori_level < 6 && ghoori_level >= 3)
        {
            GameObject.Find("txt_ghoori").GetComponent<Text>().color = Color.yellow;
        }
        else if (ghoori_level < 3)
        {
            GameObject.Find("txt_ghoori").GetComponent<Text>().color = Color.red;
        }
        switch (es_selected)
        {
            case 1:
                if (GameObject.Find("estekaan_1").GetComponent<SpriteRenderer>().sprite == spr_es_khali)
                {
                GameObject.Find("estekaan_1").GetComponent<SpriteRenderer>().sprite = spr_es_por;
                    es_por++;
                }
                break;
            case 2:
                if (GameObject.Find("estekaan_2").GetComponent<SpriteRenderer>().sprite == spr_es_khali)
                {
                    GameObject.Find("estekaan_2").GetComponent<SpriteRenderer>().sprite = spr_es_por;
                    es_por++;
                }
                break;
            case 3:
                if (GameObject.Find("estekaan_3").GetComponent<SpriteRenderer>().sprite == spr_es_khali)
                {
                    GameObject.Find("estekaan_3").GetComponent<SpriteRenderer>().sprite = spr_es_por;
                    es_por++;
                }
                break;
            case 4:
                if (GameObject.Find("estekaan_4").GetComponent<SpriteRenderer>().sprite == spr_es_khali)
                {
                    GameObject.Find("estekaan_4").GetComponent<SpriteRenderer>().sprite = spr_es_por;
                    es_por++;
                }
                break;
            case 5:
                if (GameObject.Find("estekaan_5").GetComponent<SpriteRenderer>().sprite == spr_es_khali)
                {
                    GameObject.Find("estekaan_5").GetComponent<SpriteRenderer>().sprite = spr_es_por;
                    es_por++;
                }
                break;
        }
        isclick = false;
    }
    public IEnumerator ghoori_charge () {
        GameObject.Find("ghoori").GetComponent<Animation>().PlayQueued("anim_ghoori_charge");
        yield return new WaitForSeconds(2f);
        if (ghoori_level < 10)
        {
            ghoori_level++;
            GameObject.Find("txt_ghoori").GetComponent<Text>().text = ghoori_level.ToString();
            if (ghoori_level >= 6)
            {
                GameObject.Find("txt_ghoori").GetComponent<Text>().color = Color.white;
            }
            else if (ghoori_level < 6 && ghoori_level >= 3)
            {
                GameObject.Find("txt_ghoori").GetComponent<Text>().color = Color.yellow;
            }
            else if (ghoori_level < 3)
            {
                GameObject.Find("txt_ghoori").GetComponent<Text>().color = Color.red;
            }
        }
        StartCoroutine("ghoori_charge");
    }
}
