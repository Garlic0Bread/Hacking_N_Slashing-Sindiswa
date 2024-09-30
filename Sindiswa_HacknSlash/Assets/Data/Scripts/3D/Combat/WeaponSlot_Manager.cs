using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot_Manager : GenericBehaviour
{
    WeaponSlot_Holder lefthandSlot;
    WeaponSlot_Holder righthandSlot;

    DamageCollider left_DamageCollider;
    DamageCollider right_DamageCollider;

    private void Awake()
    {
        WeaponSlot_Holder[] weaponSlot_holder = GetComponentsInChildren<WeaponSlot_Holder>();//find all weapon slots
        foreach(var weaponSlot in weaponSlot_holder) //check whether weapon slot is left or right handed
        {
            if (weaponSlot.isLeftHandSlot)
            {
                lefthandSlot = weaponSlot;
            }
            else if(weaponSlot.isRightHandSlot)
            {
                righthandSlot = weaponSlot;
            }
        
        }
    }

    public void LoadWeapon_To_Slot(WeaponItem weaponItem, bool isLeft)
    {
        if (isLeft)
        {
            //lefthandSlot.LoadWeaponModel(weaponItem);
            Load_LeftDamageCollider();
        }
        else
        {
            righthandSlot.LoadWeaponModel(weaponItem);
            Load_RightDamageCollider();
        }
    }

    #region Handle Weapons Damage Colliders
    private void Load_LeftDamageCollider()
    {
        //left_DamageCollider = lefthandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }
    private void Load_RightDamageCollider()
    {
        right_DamageCollider = righthandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    public void Open_LeftDamageCollider()
    {
        left_DamageCollider.Enable_DamageCollider();
    }
    public void Open_RightDamageCollider()
    {
        right_DamageCollider.Enable_DamageCollider();
    }

    public void Close_LeftDamageCollider()
    {
        left_DamageCollider.Disable_DamageCollider();
    }
    public void Close_RightDamageCollider()
    {
        right_DamageCollider.Disable_DamageCollider();
    }
    #endregion
}
