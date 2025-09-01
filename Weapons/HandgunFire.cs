using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] AudioSource gunFire;
    [SerializeField] GameObject handgun;
    [SerializeField] bool canFire = true;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(canFire == true)
            {
                canFire = false;
                StartCoroutine(FiringGun());
            }
            
        }
    }

    IEnumerator FiringGun()//이거 와 안되노 시발 좆같은 새끼야 이렇게 하라메
    {
        gunFire.Play();
        handgun.GetComponent<Animation>().Play("HandgunFire");
        yield return new WaitForSeconds(0.5f);
        handgun.GetComponent<Animation>().Play("New State");
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }
}
