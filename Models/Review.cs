using System.ComponentModel.DataAnnotations;

namespace creviews.Models
{
  public class Review
  {
    public int Id {get;set;}
    public string Title {get;set;}
    public string Body {get;set;}
    public string Owner {get;set;}
    [Range(0,6)]
    public int Rating {get;set;}
  }
}