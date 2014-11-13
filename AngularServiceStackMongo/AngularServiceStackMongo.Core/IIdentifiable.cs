namespace AngularServiceStackMongo.Core
{
    public interface IIdentifiable<T>
    {
        T Id { get; set; }
    }
}
