namespace Api.Domain.Entities
{
    /// <summary>Essa entidade herda a BaseEntity para ficar completa</summary>
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

    }
}
