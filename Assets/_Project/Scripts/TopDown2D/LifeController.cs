using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public enum ON_DEFEAT_BEHAVIOUR { DISABLE = 0, DESTROY = 1, NONE = 2 }

    [SerializeField] private int _currentHp = 10;
    [SerializeField] private int _maxHp = 10;
    [SerializeField] private bool _fullHpOnStart = true;
    [SerializeField] private ON_DEFEAT_BEHAVIOUR _onDefeatBehaviour = ON_DEFEAT_BEHAVIOUR.DISABLE;

    [SerializeField] private AudioSource _damageAS;
    [SerializeField] private AudioSource _healAS;

    private Animator _anim;

    public int GetHp() => _currentHp;
    public int GetMaxHp() => _maxHp;

    // int valore = life.GetHp() + 5;
    // life.SetHp( life.GetHp() + 5 );
    // life.AddHp( 5 );

    public void AddHp(int amount) => SetHp(_currentHp + amount);

    public void SetHp(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHp);

        if (_currentHp != hp)
        {
            if (hp > _currentHp && _healAS != null)
            {
                _healAS.Play();
            }
            else if (hp < _currentHp && _damageAS != null)
            {
                _damageAS.Play();
            }

            _currentHp = hp;

            if (_currentHp == 0)
            {
                Debug.Log($"The {gameObject.name} GameObject has been defeated!");

                Invoke("OnDefeated", 1f); // richiama OnDefeated() dopo 1.5 secondi
            }
        }
    }

    private void OnDefeated()
    {
        switch (_onDefeatBehaviour)
        {
            default:
                Debug.LogError($"The option {_onDefeatBehaviour} is not recognized!");
                break;
            case ON_DEFEAT_BEHAVIOUR.DISABLE:
                gameObject.SetActive(false);
                break;
            case ON_DEFEAT_BEHAVIOUR.DESTROY:
                Destroy(gameObject);
                break;
            case ON_DEFEAT_BEHAVIOUR.NONE:
                break;
        }
    }


    public void SetMaxHp(int maxHp)
    {
        _maxHp = Mathf.Max(1, maxHp);
        SetHp(_currentHp);
    }

    private void Start()
    {
        if (_fullHpOnStart)
        {
            SetHp(_maxHp);
        }

        _anim = GetComponentInChildren<Animator>();
    }
}
