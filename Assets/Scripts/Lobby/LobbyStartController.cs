using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyStartController : MonoBehaviour
{
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private CinemachineVirtualCamera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        //StatSetting

        //BasicPlayer
        NewDataManager.Instance.BasicPlayerHP = 18.0f;
        NewDataManager.Instance.BasicPlayerMoveSpeed = 6.0f;
        NewDataManager.Instance.BasicPlayerAttackDamage = 3.0f;
        NewDataManager.Instance.BasicPlayerAttackCooldown = 1.0f;

        //ShortPlayer
        NewDataManager.Instance.ShortPlayerHP = 24.0f;
        NewDataManager.Instance.ShortPlayerMoveSpeed = 2.0f;
        NewDataManager.Instance.ShortPlayerAttackDamage = 9.0f;
        NewDataManager.Instance.ShortPlayerAttackCooldown = 1.0f;

        //LongPlayer

        NewDataManager.Instance.LongPlayerHP = 10.0f;
        NewDataManager.Instance.LongPlayerMoveSpeed = 2.0f;
        NewDataManager.Instance.LongPlayerAttackDamage = 4.0f;
        NewDataManager.Instance.LongPlayerAttackCooldown = 1.0f;

        //BasicEnemy
        NewDataManager.Instance.BasicEnemyHP = 18.0f;
        NewDataManager.Instance.BasicEnemyMoveSpeed = 6.0f;
        NewDataManager.Instance.BasicEnemyAttackDamage = 3.0f;
        NewDataManager.Instance.BasicEnemyAttackCooldown = 1.0f;

        //ShortEnemy
        NewDataManager.Instance.ShortEnemyHP = 24.0f;
        NewDataManager.Instance.ShortEnemyMoveSpeed = 2.0f;
        NewDataManager.Instance.ShortEnemyAttackDamage = 9.0f;
        NewDataManager.Instance.ShortEnemyAttackCooldown = 1.0f;

        //LongEnemy

        NewDataManager.Instance.LongEnemyHP = 10.0f;
        NewDataManager.Instance.LongEnemyMoveSpeed = 2.0f;
        NewDataManager.Instance.LongEnemyAttackDamage = 4.0f;
        NewDataManager.Instance.LongEnemyAttackCooldown = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameStart()
    {
        /*
        DataManager.Instance.StageLevel = 1;
        DataManager.Instance.MaxHealth = 4f;
        DataManager.Instance.Health = DataManager.Instance.MaxHealth;
        DataManager.Instance.Speed = 10f;
        DataManager.Instance.Damage = 2f;
        DataManager.Instance.DashCount = 2;
        DataManager.Instance.DashState = false;
        DataManager.Instance.AttacSpeed = 0.25f;
        DataManager.Instance.Weapon = WeaponType.Gun.ToString();
        DataManager.Instance.SpecialWeapon = null;
        DataManager.Instance.BulletCount = 20;

        DataManager.Instance.firstDamage = DataManager.Instance.Damage;
        DataManager.Instance.firstMaxHealth = DataManager.Instance.MaxHealth;
        DataManager.Instance.firstSpeed = DataManager.Instance.Speed;
        DataManager.Instance.firstDashCount = DataManager.Instance.DashCount;
        DataManager.Instance.firstAttackSpeed = DataManager.Instance.AttacSpeed;

        DataManager.Instance.additionalDamage = 0;
        DataManager.Instance.additionalMaxHealth = 0;
        DataManager.Instance.additionalSpeed = 0;
        DataManager.Instance.additionalDashCount = 0;
        DataManager.Instance.additionalAttackSpeed = 0;

        DataManager.Instance.specialWeaponGet = false;
        */
        NewDataManager.Instance.StageLevel = 1;
        NewDataManager.Instance.BasicEnemyCount = 5;
        NewDataManager.Instance.ShortEnemyCount = 0;
        NewDataManager.Instance.LongEnemyCount = 0;

        Debug.Log("시작");
        SceneManager.LoadScene("Stage_Ready");
    }
    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameLoad()
    {
        if (NewDataManager.Instance.SavedStageLevel == 0)
        {
            Debug.Log("Can't load");
        }
        else
        {
            NewDataManager.Instance.StageLevel = NewDataManager.Instance.SavedStageLevel;
            SceneManager.LoadScene("Stage_Ready");
        }

    }

    public void SelectGun()
    {
        DataManager.Instance.StageLevel = 1;
        DataManager.Instance.MaxHealth = 4f;
        DataManager.Instance.Health = DataManager.Instance.MaxHealth;
        DataManager.Instance.Speed = 10f;
        DataManager.Instance.Damage = 2f;
        DataManager.Instance.DashCount = 2;
        DataManager.Instance.DashState = false;
        DataManager.Instance.AttacSpeed = 0.25f;
        DataManager.Instance.Weapon = WeaponType.Gun.ToString();
        DataManager.Instance.SpecialWeapon = null;
        DataManager.Instance.BulletCount = 20;

        DataManager.Instance.firstDamage = DataManager.Instance.Damage;
        DataManager.Instance.firstMaxHealth = DataManager.Instance.MaxHealth;
        DataManager.Instance.firstSpeed = DataManager.Instance.Speed;
        DataManager.Instance.firstDashCount = DataManager.Instance.DashCount;
        DataManager.Instance.firstAttackSpeed = DataManager.Instance.AttacSpeed;

        DataManager.Instance.additionalDamage = 0;
        DataManager.Instance.additionalMaxHealth = 0;
        DataManager.Instance.additionalSpeed = 0;
        DataManager.Instance.additionalDashCount = 0;
        DataManager.Instance.additionalAttackSpeed = 0;

        DataManager.Instance.specialWeaponGet = false;

        SceneManager.LoadScene("Game");
    }
    public void SelectSword()
    {
        DataManager.Instance.StageLevel = 1;
        DataManager.Instance.MaxHealth = 5f;
        DataManager.Instance.Health = DataManager.Instance.MaxHealth;
        DataManager.Instance.Speed = 10f;
        DataManager.Instance.Damage = 2f;
        DataManager.Instance.DashCount = 2;
        DataManager.Instance.DashState = false;
        DataManager.Instance.AttacSpeed = 500f;
        DataManager.Instance.Weapon = WeaponType.Sword.ToString();
        DataManager.Instance.SpecialWeapon = null;
        DataManager.Instance.SwordLength = 2f;
        DataManager.Instance.AxeDamage = 5f;
        DataManager.Instance.ShurikenDamage = 2f;

        DataManager.Instance.firstDamage = DataManager.Instance.Damage;
        DataManager.Instance.firstMaxHealth = DataManager.Instance.MaxHealth;
        DataManager.Instance.firstSpeed = DataManager.Instance.Speed;
        DataManager.Instance.firstDashCount = DataManager.Instance.DashCount;
        DataManager.Instance.firstAttackSpeed = DataManager.Instance.AttacSpeed;

        DataManager.Instance.additionalDamage = 0;
        DataManager.Instance.additionalMaxHealth = 0;
        DataManager.Instance.additionalSpeed = 0;
        DataManager.Instance.additionalDashCount = 0;
        DataManager.Instance.additionalAttackSpeed = 0;

        DataManager.Instance.specialWeaponGet = false;

        SceneManager.LoadScene("Game");
    }
}
