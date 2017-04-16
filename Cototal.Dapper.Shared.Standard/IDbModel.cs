namespace Cototal.Dapper.Shared.Standard
{
    /// <summary>
    /// Interface for any model with a primary key.
    /// </summary>
    /// <typeparam name="TKey">Intended for string or integer</typeparam>
    public interface IDbModel<TKey>
        where TKey : struct
    {
        TKey Id { get; set; }
    }
}
