using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Electra.Core.Entities;

namespace Electra.Models;

// todo - determine what format to store the profile
// todo - later denormalize if join performance costs too much (cache first, then denormalize)
// todo - add foreign key to the Users (AspNetUsers) table
// https://www.npgsql.org/efcore/mapping/json.html?tabs=data-annotations%2Cpoco
public record ElectraUserProfile : Entity<Guid>
{
    // [JsonPropertyName("user_id")]
    // public string UserId { get; set; }

    [MinLength(4)] // todo - remove data annotations and use FluentValidation
    [MaxLength(256)]
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [Url]
    [MinLength(4)]
    [MaxLength(1024)]
    [JsonPropertyName("website")]
    public string Website { get; set; }

    [JsonPropertyName("social_media")]
    public Dictionary<string, string> SocialMedia { get; } = new();

    [MaxLength(256)]
    [JsonPropertyName("firstname")]
    public string Firstname { get; set; }

    [MaxLength(256)]
    [JsonPropertyName("lastname")]
    public string Lastname { get; set; }

    [MaxLength(50)]
    [JsonPropertyName("headline")]
    public string Headline { get; set; }

    [MaxLength(128)]
    [JsonPropertyName("location")]
    public string Location { get; set; }

    [MaxLength(1024)]
    [JsonPropertyName("bio")]
    public string Bio { get; set; }

    /// <summary>
    /// Can store as base64 encoded image or path to url
    /// </summary>
    [Url]
    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [EmailAddress]
    [MinLength(5)]
    [MaxLength(512)]
    [JsonPropertyName("email")]
    public string Email { get; set; }

    public bool AgreedToTos { get; set; }

    public AddressModel Address { get; set; }
}