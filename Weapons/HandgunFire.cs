using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] AudioSource gunFire;
    [SerializeField] GameObject handgun;
    [SerializeField] bool canFire = true;
    [SerializeField] private GameObject extraCross;
    [SerializeField] private AudioSource EmptyGunSound;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(canFire == true)
            {
                if (GlobalAmmo.handgunAmmoCount == 0)
                {
                    canFire = false;
                    StartCoroutine(EmptyGun());
                }
                else
                {
                    canFire = false;
                    StartCoroutine(FiringGun());
                }
            }
            
        }
    }

    IEnumerator FiringGun()//이거 와 안되노 시발 좆같은 새끼야 이렇게 하라메
    {
        gunFire.Play();
        extraCross.SetActive(true);
        GlobalAmmo.handgunAmmoCount -= 1;
        handgun.GetComponent<Animator>().Play("HandgunFire");
        yield return new WaitForSeconds(0.5f);
        handgun.GetComponent<Animator>().Play("New State");
        extraCross.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }

    IEnumerator EmptyGun()
    {
        EmptyGunSound.Play();
        yield return new WaitForSeconds(0.6f);
        canFire = true;
        
    }//TODO: 아마 모션중에 고정 위치값이 아니라 델타 값으로 모션을 바꿀 수있는게 있을거 같은데 그거 찾아서 만드는게 나을듯
}
