namespace eCommerce.Core.DTO;

public record AuthenticationResponse(Guid UserId, string? Email, string? Password, string? PersonName, GenderOptions Gender, string? Token, bool Success);
