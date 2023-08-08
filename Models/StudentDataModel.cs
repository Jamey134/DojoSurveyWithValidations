#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;


    public class StudentData
{
    [Required]
    [MinLength(2, ErrorMessage = "Name required at least 2 characters")]
    public string Name { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public string Language { get; set; }
    [MinLength(20, ErrorMessage = "Comment requires at least 20 characters")]
    public string? Comment { get; set; }
}