namespace Aggregate;

public abstract class Entity<TKey>
{
    public TKey Id { get;  set; }
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (obj.GetType() != GetType()) return false;
        if (!SameAsIdentity(obj as Entity<TKey>)) return false;
        return true;
    }

    private bool SameAsIdentity(Entity<TKey>? entity)
    {
        if (entity is null) return false;
            
        return  entity.Id != null && entity.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
         return Id.GetHashCode();
    }
}