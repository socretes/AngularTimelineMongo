namespace AngularServiceStackMongo.Domain
{
    using System.Collections.Generic;

    public interface IEntityRepository<T> where T : IEntity
    {
        string SaveUpdate(T entity);

        void Delete(string id);

        T Get(string id);
    }
}
