using System.ComponentModel.DataAnnotations;

namespace SuggestionApp.Core.Entities;

/// <summary>
/// <c>Suggestion</c> model
/// </summary>
public class Suggestion : BaseEntity
{
    [BsonElement("adminNotes")]
    public string AdminNotes { get; set; }

    [BsonElement("author")]
    public Author Author { get; set; }
    
    [BsonElement("category")]
    [Required]
    [Display(Name = "Category")]
    public Category Category { get; set; }
    
    [BsonElement("dateCreated")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    
    [BsonElement("dateUpdated")]
    public DateTime DateUpdated { get; set; }
    
    [BsonElement("description")]
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
    
    [BsonElement("isApprovedForRelease")]
    public bool IsApprovedForRelease { get; set; } = false;
    
    [BsonElement("isArchived")]
    public bool IsArchived { get; set; } = false;
    
    [BsonElement("isRejected")]
    public bool IsRejected { get; set; } = false;
    
    [BsonElement("status")]
    public Status Status { get; set; }
    
    [BsonElement("title")]
    [Required]
    [MaxLength(75)]
    public string Title { get; set; }

    [BsonElement("votes")]
    public HashSet<string> Votes { get; } = new();
}