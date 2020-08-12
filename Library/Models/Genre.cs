using System.Collections.Generic;

namespace Library.Models
{
  public class Genre
  {
    public Genre()
    {
      this.Books = new HashSet<Book>();
    }
    public int GenreId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
  }
}