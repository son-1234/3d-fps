using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] AudioSource gunFire;
    [SerializeField] GameObject handgun;
    [SerializeField] bool canFire = true;
    [SerializeField] private GameObject extraCross;

    [SerializeField] private AudioSource EmptyGunSound;

    //[SerializeField] private AudioSource ZoomSound;
    //[SerializeField] private GameObject ZoomMotion;//이거 필요없네 생각해보니까 
    void Update()
    {
        if (Input.GetMouseButton(1)) //mouseButtonDown으로 하면 꾹눌러도 되나?
        {
            handgun.GetComponent<Animator>().Play("Zoom");
            if (Input.GetMouseButtonDown(0))
            {
                if (canFire == true)
                {
                    if (GlobalAmmo.handgunAmmoCount == 0)
                    {
                        canFire = false;
                        StartCoroutine(EmptyGun());
                    }
                    else
                    {
                        canFire = false;
                        StartCoroutine(ZoomFiringGun());
                    }
                }

            }
        }
        else
        {
            //handgun.GetComponent<Animator>().Play("New State");
            if (Input.GetMouseButtonDown(0))
            {
                if (canFire == true)
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




    }

    IEnumerator FiringGun() //이거 와 안되노 시발 좆같은 새끼야 이렇게 하라메
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

    }

    // IEnumerator Zoom() // 줌 
    // {
    //     //ZoomSound.Play();
    //     handgun.GetComponent<Animator>().Play("Zoom");
    //     yield break;
    // }
    IEnumerator ZoomFiringGun()
    {
        gunFire.Play();
        extraCross.SetActive(true);
        GlobalAmmo.handgunAmmoCount -= 1;
        handgun.GetComponent<Animator>().Play("ZoomHandgunFire");
        yield return new WaitForSeconds(0.5f);
        handgun.GetComponent<Animator>().Play("Zoom");
        extraCross.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }
}
