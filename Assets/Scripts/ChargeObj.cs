using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChargeObj : MonoBehaviour
{
    [SerializeField]
    private float _charge = 1;
    [SerializeField]
    private float _rate = 0;
    private int _hashCharge;
    public float Charge
    {
        get { return _charge; }
        set { _charge = Mathf.Clamp(value, 0, 1); }
    }
    public float Rate => _rate;

    public Animator _animator;
    public UnityEvent onFull, onEmpty;

    private void Awake()
    {
        _hashCharge = Animator.StringToHash("charge");
        if (_animator == null) _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _charge += (_rate / 100f)* Time.deltaTime;
        _animator?.SetFloat(_hashCharge, _charge);
    }
}
