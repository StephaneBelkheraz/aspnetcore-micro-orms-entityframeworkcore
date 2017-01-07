namespace AccessDataWithPetaPoco.Models
{
    [PetaPoco.TableName("Book")]
    [PetaPoco.PrimaryKey("Id")]
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}