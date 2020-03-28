using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SwitchGuns : MonoBehaviour
{
    public GameObject[] AvailableGuns;
    private int CurrentGun = 0;

    void SwitchGun()
    {
        if (CurrentGun - 1 >= 0)
        {
            AvailableGuns[CurrentGun - 1].SetActive(false);
        }
        if (CurrentGun + 1 < AvailableGuns.Length)
        {
            AvailableGuns[CurrentGun + 1].SetActive(false);
        }
        AvailableGuns[CurrentGun].SetActive(true);
    }
    void Update()
    {
        //Scrolling Up (Mousewheel)
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (CurrentGun < AvailableGuns.Length - 1)
            {
                CurrentGun++;
            }
            else
            {
                CurrentGun = 0;
            }
            SwitchGun();
        }

        //Scrolling Down (Mousewheel)
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (CurrentGun < 1)
            {
                CurrentGun = AvailableGuns.Length - 1;
            }
            else
            {
                CurrentGun--;
            }
            SwitchGun();
        }
    }
}
