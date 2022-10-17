namespace WebApplication1.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public override string? ToString() => "{" + Id + "," + Name + "," + Description + "}";
    }
}
