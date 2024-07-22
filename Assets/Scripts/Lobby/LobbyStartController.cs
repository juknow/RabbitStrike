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
