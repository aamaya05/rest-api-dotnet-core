namespace rest_api_dotnet_core.Models;

public class Todo
{
  public int TodoId {get;set;}

  public Guid Uuid {get; set;}

  public int CategoryId {get;set;}

  //[Required]
  //[MaxLength(200)]
  public string Title {get;set;} = null!;

  public string? Description {get;set;}

  public Priority PriorityTask {get;set;}

  public DateTime CreationDate {get;set;}

  public virtual Category Category {get;set;}

  //[NotMapped]
  public string Resume {get;set;}

  public enum Priority
{
  LOW,
  MEDIUM,
  HIGH
}

}



// dotnet remove package Syncfusion.SfGrid.WPF : how to remove a nuget library for the project
// dotnet new gitignore : add git ignore file
// dotnet new globaljson: add global json for sdk version