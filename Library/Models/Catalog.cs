using System.Collections.Generic;

namespace Library.Models
{
  public class Catalog
  {
    public Catalog()
    {
      this.Books = new HashSet<Book>();
    }
    public int CatalogId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
  }
}