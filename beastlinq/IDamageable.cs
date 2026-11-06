public interface IDamageable
{
    // інтерфейс для всього, що може отримувати дамаг і помирати
    void TakeDamage(int damage);
    bool IsDead { get; }
}