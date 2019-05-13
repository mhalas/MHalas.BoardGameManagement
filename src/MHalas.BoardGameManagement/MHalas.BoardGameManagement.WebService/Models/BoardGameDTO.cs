namespace MHalas.BoardGameManagement.WebService.Models
{
    public class BoardGameDTO
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PlayerMinimalAge { get; set; }
    }
}