using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private int _moneyShotCost;
    [SerializeField] private Bullet _moneyBulletPrefab;
    [SerializeField] private Bullet _slipperBulletPrefab;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void MoneyShot(Vector3 mousePos)
    {
        var target = DetectTarget(mousePos);
        if (target == null)
            return;

        if (!GameVariables.Instance.TrySpendMoney(_moneyShotCost))
            return;
        
        Bullet bullet = Instantiate(
            _moneyBulletPrefab,
            _bulletSpawnPoint.position,
            _bulletSpawnPoint.rotation);
        StartCoroutine(ShotCoroutine(target, bullet, 1));
    }

    public void SlipperShot(Vector3 mousePos)
    {
        var target = DetectTarget(mousePos);
        if (target == null)
            return;
        
        Bullet bullet = Instantiate(
            _slipperBulletPrefab,
            _bulletSpawnPoint.position,
            _bulletSpawnPoint.rotation);
        StartCoroutine(ShotCoroutine(target, bullet, 1));
    }

    private Worker DetectTarget(Vector3 mousePos)
    {
        Ray ray = _camera.ScreenPointToRay(mousePos);
        Worker target = null;
        
        if (Physics.Raycast(ray, out var hit, 100f, _layerMask))
            target = hit.transform.GetComponent<Worker>();

        if (target != null && !target.IsWorking)
            return null;
        
        return target;
    }
    
    private IEnumerator ShotCoroutine(Worker target, Bullet bullet, float flyDuration)
    {
        var bulletTransform = bullet.transform;
        var startPos = bulletTransform.position;
        var finishPos = target.transform.position;

        var time = 0f;
        while (time < flyDuration)
        {
            time += Time.deltaTime;
            bulletTransform.position = Vector3.Lerp(
                startPos,
                finishPos,
                time/flyDuration);

            yield return null;
        }
        
        target.ChangeEnergy(bullet.EnergyChange);
        target.ChangeStress(bullet.StressChange);
        Destroy(bullet.gameObject);
    }
}