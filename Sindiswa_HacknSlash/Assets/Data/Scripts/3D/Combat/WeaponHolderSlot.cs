using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderSlot : MonoBehaviour
{
    public Transform parentOverride;
    public bool isLeftHandSlot;
    public bool isRightHandSlot;

    public GameObject currentWeaponModel;

    public void UnloadWeapon()
    {
        if(currentWeaponModel != null)
        {
            currentWeaponModel.SetActive(false);
        }
    }

    public void UnloadWeapon_And_Destroy()
    {
        if(currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }
    }

    public void LoadWeaponModel(WeaponItem weaponItem)
    {
        UnloadWeapon_And_Destroy();//if a weapon is already loaded destroy it before loading a new one


        if (weaponItem == null)
        {
            UnloadWeapon();
            return;
        }

        GameObject model = Instantiate(weaponItem.modelPrefab) as GameObject;
        if(model != null )
        {
            if(parentOverride != null)
            {
                model.transform.parent = parentOverride;
            }
            else
            {
                model.transform.parent = transform;
            }
            model.transform.localPosition = Vector3.zero;
            model.transform.localScale = Vector3.one;
            model.transform.localRotation = Quaternion.identity;
        }

        currentWeaponModel = model;
    }
}
