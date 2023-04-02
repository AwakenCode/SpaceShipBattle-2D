namespace Ship
{
    public interface IHealth
    {
        uint Value { get; }
        uint MaxValue { get; }
        void TakeDamage(float damage);
    }
}