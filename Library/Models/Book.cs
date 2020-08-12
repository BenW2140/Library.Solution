using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.Authors = new HashSet<AuthorBook>();
    }
    public int BookId { get; set; }
    public int? CatalogId { get; set; }
    public string Title { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual Catalog Catalog { get; set; }
    public virtual ICollection<AuthorBook> Authors { get; set; }
  }
}