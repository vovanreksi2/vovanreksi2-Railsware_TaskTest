/// <summary>
/// Represents an email address with an optional name.
/// </summary>
public class EmailAddress
{
    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    /// <remarks>
    /// This property is required.
    /// </remarks>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the name associated with the email address.
    /// </summary>
    /// <remarks>
    /// This property is optional.
    /// </remarks>
    public string Name { get; set; } 


    /// <summary>
    /// Initializes a new instance of the <see cref="EmailAddress"/> class with the specified email address.
    /// </summary>
    /// <param name="email">The email address.</param>
    /// <param name="name">The optional name associated with the email address.</param>
    public EmailAddress(string email, string name = null)
    {
        Email = email;
        Name = name;
    }
}